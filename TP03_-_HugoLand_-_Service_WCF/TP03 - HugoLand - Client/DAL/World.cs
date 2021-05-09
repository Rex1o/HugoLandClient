using HugoWorld.BLL;
using HugoWorld_Client.DAL;
using HugoWorld_Client.HL_Services;
using HugoWorld_Client.Vue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld
{
    //Textpop up used to display damage when monsters and players are hit
    public struct textPopup
    {
        public int X;
        public int Y;
        public string Text;

        public textPopup(int x, int y, string text)
        {
            X = x;
            Y = y;
            Text = text;
        }
    }

    public class World : GameObject
    {
        ItemServiceClient ItemService = new ItemServiceClient();
        private const string _startArea = "CurrentChunk";

        //private Dictionary<string, Area> _world = new Dictionary<string, Area>();
        private MondeDTO _monde;
        private List<OtherPlayers> _herosMP = new List<OtherPlayers>();
        private HeroDTO _hero;
        private Area _currentArea;
        private Dictionary<string, Tile> _tiles;
        private Point _heroPosition;
        private Sprite _heroSprite;
        private bool _heroSpriteAnimating;
        private bool _heroSpriteFighting;
        private double _startFightTime = -1.0;
        private PointF _heroDestination;
        private HeroDirection _direction;
        private GameState _gameState;
        private List<textPopup> _popups = new List<textPopup>();

        private static Font _font = new Font("Arial", 18);
        private static Brush _whiteBrush = new SolidBrush(Color.White);
        private static Brush _blackBrush = new SolidBrush(Color.Red);
        private static Random _random = new Random();
        

        public World(GameState gameState, Dictionary<string, Tile> tiles, MondeDTO monde)
        {
            _gameState = gameState;
            _tiles = tiles;
            _monde = monde;
            _hero = Outils.GetHero();

            //Read in the map file
            //readMapfile(mapFile);
            LoadChunk();

            //Check player position in chunk
            VerifySpawnPoint();

            //Find the start point
            //_currentArea = _world[_startArea];
            HeroDTO h = Outils.GetHero();
            //Create and position the hero character

            int[] pos = GetHeroPosInChunk(_hero);
            _heroPosition = new Point(pos[0], pos[1]);


            _heroSprite = new Sprite(null, _heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                            _heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY,
                                            _tiles["71"].Bitmap, _tiles["71"].Rectangle, _tiles["71"].NumberOfFrames);
            _heroSprite.Flip = true;
            _heroSprite.ColorKey = Color.FromArgb(75, 75, 75);

        }

        public void RenderOtherPlayers()
        {
            //fetch the updated heros
            HeroServiceClient serviceHero = new HeroServiceClient();
            int[][] chunk = GetChunkLimitsAtHeroPos(_hero.x, _hero.y);

            //_herosMP.Clear();

            //Get all the connected heros in the loaded chunk
            List<HeroDTO> others = serviceHero.GetHerosInChunk(chunk, _monde.Id).ToList();
            foreach (HeroDTO other in others.Where(x => x.Id != _hero.Id))
            {
                if (_herosMP.FirstOrDefault(x => x.Hero.Id == other.Id) == null)
                {
                    OtherPlayers op = new OtherPlayers();
                    op.Hero = other;
                    int[] pos = GetHeroPosInChunk(other);
                    op._heroPosition = new Point(pos[0], pos[1]);
                    op._heroSprite = new Sprite(null, op._heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                                op._heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY,
                                                _tiles["71"].Bitmap, _tiles["71"].Rectangle, _tiles["71"].NumberOfFrames);
                    op._heroSprite.Flip = true;
                    op._heroSprite.ColorKey = Color.FromArgb(75, 75, 75);

                    _herosMP.Add(op);
                }

                if (_herosMP.FirstOrDefault(x => x.Hero.Id == other.Id).Hero.RowVersion != other.RowVersion)
                {
                    OtherPlayers og = _herosMP.FirstOrDefault(x => x.Hero.Id == other.Id);
                    int[] posother = GetHeroPosInChunk(other);


                    int diffx = posother[0] - og._heroPosition.X;
                    int diffy = posother[1] - og._heroPosition.Y;

                    if (!og._heroSpriteAnimating)
                    {

                        //x
                        if (diffx != 0)
                        {
                            if (diffx < 0)
                            {
                                //gauche
                                og._heroSprite.Velocity = new PointF(-100, 0);
                                og._heroSprite.Flip = false;
                                og._heroSpriteAnimating = true;
                                og._direction = HeroDirection.Left;
                                og._heroPosition.X--;
                            }
                            else
                            {
                                //droite
                                og._heroSprite.Velocity = new PointF(100, 0);
                                og._heroSprite.Flip = true;
                                og._heroSpriteAnimating = true;
                                og._direction = HeroDirection.Right;
                                og._heroPosition.X++;
                            }
                        }
                        //y
                        else if (diffy != 0)
                        {
                            if (diffy > 0)
                            {
                                //haut
                                og._heroSprite.Velocity = new PointF(0, 100);
                                og._heroSpriteAnimating = true;
                                og._direction = HeroDirection.Down;
                                og._heroPosition.Y++;
                            }
                            else
                            {
                                og._heroSprite.Velocity = new PointF(0, -100);
                                og._heroSpriteAnimating = true;
                                og._direction = HeroDirection.Up;
                                og._heroPosition.Y--;
                            }
                        }

                        setDestination(og);
                    }
                }
            }

            //Vérifie si les héros sont toujours connecté ou dans le chunk
            List<int> localID = _herosMP.Select(x => x.Hero.Id).ToList();
            List<int> ExternalID = others.Select(x => x.Id).ToList();

            foreach (int id in localID)
            {
                if (!ExternalID.Contains(id))
                    _herosMP.Remove(_herosMP.FirstOrDefault(x => x.Hero.Id == id));
            }

        }

        public void Clear()
        {
            //Vide l'écran du joueur
            _heroSprite = new Sprite(null, _heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX, _heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY, _tiles["82"].Bitmap, _tiles["82"].Rectangle, _tiles["82"].NumberOfFrames);
            _heroSprite.ColorKey = Color.FromArgb(75, 75, 75);
            for (int i = 0; i < _currentArea.Map.GetLength(0); i++)
            {
                for (int j = 0; j < _currentArea.Map.GetLength(1); j++)
                {
                    if (_currentArea.Map[i, j] != null)
                    {
                        _currentArea.Map[i, j].Sprite = new Sprite(null, 0, 0, _tiles["82"].Bitmap, _tiles["82"].Rectangle, _tiles["82"].NumberOfFrames);
                        _currentArea.Map[i, j].Sprite.ColorKey = Color.FromArgb(75, 75, 75);
                    }
                }
            }
            _gameState.Armour = 0;
            _gameState.Attack = 0;
            _gameState.Health = 1;
            _gameState.Experience = 0;
            _gameState.HasBrownKey = false;
            _gameState.HasGreenKey = false;
            _gameState.HasRedKey = false;
            _gameState.Level = 0;
            _gameState.Potions = 0;
            _gameState.Treasure = 0;
        }

        private void readMapfile(string mapFile)
        {
            using (StreamReader stream = new StreamReader(mapFile))
            {
                while (!stream.EndOfStream)
                {
                    //Each area constructor will consume just one area
                    Area area = new Area(stream, _tiles);
                    //_world.Add(area.Name, area);
                }
            }
        }

        private int[] GetHeroPosInChunk(HeroDTO h)
        {
            int[] pos = new int[2];

            pos[0] = h.x == 0 ? 0 : h.x % 8;
            pos[1] = h.y == 0 ? 0 : h.y % 8;

            return pos;
        }

        private int[][] GetChunkLimitsAtHeroPos(int x, int y)
        {
            //Chunk position
            int Chunkx = (x / 8);
            int Chunky = (y / 8);


            //x = [0]
            //y = [1]
            int[] TopLeftCorner = new int[2];
            TopLeftCorner[0] = Chunkx * 8;
            TopLeftCorner[1] = Chunky * 8;

            int[] BotRightCorner = new int[2];
            BotRightCorner[0] = (Chunkx + 1) * 8 - 1;
            BotRightCorner[1] = (Chunky + 1) * 8 - 1;

            int[][] chunk = new int[2][] { TopLeftCorner, BotRightCorner };

            return chunk;
        }

        private void LoadChunk(int p_posx = -1, int p_posy = -1)
        {
            try
            {
                MondeDTO w = _monde;
                HeroDTO h = _hero;

                //World size
                int x_size = w.LimiteX;
                int y_size = w.LimiteY;

                int p_x, p_y;
                if (p_posx < 0)
                    p_x = h.x;
                else
                    p_x = p_posx;

                if (p_posy < 0)
                    p_y = h.y;
                else
                    p_y = p_posy;

                int[][] chunk = GetChunkLimitsAtHeroPos(p_x, p_y);

                MondeServiceClient MondeService = new MondeServiceClient();
                List<TileImport> objects = MondeService.GetChunk(chunk[0], chunk[1], w).ToList();

                Area area = new Area(_tiles, objects);
                if (_currentArea == null)
                    _currentArea = area;
                else if (_currentArea.Map[0, 0].GlobalX != area.Map[0, 0].GlobalX || _currentArea.Map[0, 0].GlobalY != area.Map[0, 0].GlobalY)
                {
                    if (area != null && area.Name != null)
                    {
                        area.NorthArea = "OK";
                        area.WestArea = "OK";
                        area.SouthArea = "OK";
                        area.EastArea = "OK";
                        _currentArea = area;
                    }
                }
                else
                {
                    _currentArea.NorthArea = null;
                    _currentArea.WestArea = null;
                    _currentArea.SouthArea = null;
                    _currentArea.EastArea = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Vérifiez la connection au VPN!");
            }
        }

        public void VerifySpawnPoint()
        {
            //Player Position
            bool isOccupied = false;

            int[][] chunkCheck = GetChunkLimitsAtHeroPos(_hero.x, _hero.y);
            HeroServiceClient heroService = new HeroServiceClient();
            //Get all the connected heros in the loaded chunk
            List<HeroDTO> heroInSameWorld = heroService.GetHerosInChunk(chunkCheck, _monde.Id)
                                                        .Where(x => x.Id != _hero.Id).ToList();
            if (heroInSameWorld != null && heroInSameWorld.Count > 0)
            {
                foreach (HeroDTO player in heroInSameWorld)
                {
                    // si le hero est sur une casé déjà occupé
                    if (_hero.x == player.x && _hero.y == player.y)
                    {
                        isOccupied = true;
                        break;
                    }
                }

                int distance = 1;
                HeroDirection direction = HeroDirection.Right;
                int[] pos = GetHeroPosInChunk(_hero);
                while (isOccupied)
                {
                    // vérifie les tuiles en haut, en bas, à gauche et à droite,
                    // mais prend la première disponible,
                    // regarde les autres seulement si tu ne trouve rien

                    switch (direction)
                    {
                        case HeroDirection.Left:
                            if (pos[0] - distance < 0)
                            {
                                direction = HeroDirection.Down;
                                distance = 1;
                            }
                            break;
                        case HeroDirection.Right:
                            if (pos[0] + distance >= Area.MapSizeX)
                            {
                                direction = HeroDirection.Left;
                                distance = 1;
                            }
                            break;
                        case HeroDirection.Up:
                            if (pos[1] + distance >= Area.MapSizeY)
                            {
                                direction = HeroDirection.Right;
                                distance = 1;
                            }
                            break;
                        case HeroDirection.Down:
                            if (pos[1] - distance < 0)
                            {
                                direction = HeroDirection.Up;
                                distance = 1;
                            }
                            break;
                    }


                    switch (direction)
                    {
                        case HeroDirection.Left:
                            if (CheckTilesToSpawn(_currentArea.Map[pos[0] - distance, pos[1]], heroInSameWorld))
                            {
                                isOccupied = false;
                                _hero.x -= distance;
                                SaveHeroPos();
                                break;
                            }
                            break;
                        case HeroDirection.Right:
                            if (CheckTilesToSpawn(_currentArea.Map[pos[0] + distance, pos[1]], heroInSameWorld))
                            {
                                isOccupied = false;
                                _hero.x += distance;
                                SaveHeroPos();
                                break;
                            }
                            break;
                        case HeroDirection.Up:
                            if (CheckTilesToSpawn(_currentArea.Map[pos[0], pos[1] - distance], heroInSameWorld))
                            {
                                isOccupied = false;
                                _hero.y -= distance;
                                SaveHeroPos();
                                break;
                            }
                            break;
                        case HeroDirection.Down:
                            if (CheckTilesToSpawn(_currentArea.Map[pos[0], pos[1] + distance], heroInSameWorld))
                            {
                                isOccupied = false;
                                _hero.y += distance;
                                SaveHeroPos();
                                break;
                            }
                            break;
                    }

                    distance++;
                }
            }
        }

        public bool CheckTilesToSpawn(MapTile mapTile, List<HeroDTO> heroInSameWorld)
        {

            foreach (HeroDTO player in heroInSameWorld)
            {
                if (player.x == mapTile.GlobalX && player.y == mapTile.GlobalY)
                {
                    return false;
                }
            }

            if (mapTile.TileImport.Type == TypeTile.Monstre || mapTile.TileImport.Type == TypeTile.Item)
                return false;

            //If the next tile is a blocker then we can't move
            if (mapTile.TileImport.Type == TypeTile.ObjetMonde)
                if (mapTile.Tile.IsBlock)
                    return false;

            // si aucun ne passe dans les conditions, la tuile est disponible
            return true;
        }

        public void CheckPlayerHealth()
        {
            HeroServiceClient service = new HeroServiceClient();
            //check if there is a hp diff
            int hpDiff = service.GetHeroHPDiff(_hero.Id, _hero.Hp);
            if (hpDiff != 0)
            {
                _popups.Clear();
                _popups.Add(new textPopup((int)_heroSprite.Location.X + 40, (int)_heroSprite.Location.Y + 20, hpDiff.ToString()));
                _heroSpriteFighting = true;
                _startFightTime = -1;
                _hero.Hp += hpDiff;
                _gameState.Health = _hero.Hp;

                //kill player if under 0 hp
                if (_gameState.Health <= 0)
                    DeadHero();
            }


        }


        public override void Update(double gameTime, double elapsedTime)
        {
            RenderOtherPlayers();

            CheckPlayerHealth();
            //We only actually update the current area the rest all 'sleep'
            _currentArea.Update(gameTime, elapsedTime);

            _heroSprite.Update(gameTime, elapsedTime);

            //UpdateSprites
            _herosMP.ForEach((x) => x._heroSprite.Update(gameTime, elapsedTime));

            //If the hero is moving we need to check if we are there yet
            if (_heroSpriteAnimating)
            {
                if (checkDestination())
                {
                    //We have arrived. Stop moving and animating
                    _heroSprite.Location = _heroDestination;
                    _heroSprite.Velocity = PointF.Empty;
                    _heroSpriteAnimating = false;

                    //Check if there is anything on this square
                    checkObjects();
                }
            }

            _herosMP.ForEach((x) =>
            {
                if (x._heroSpriteAnimating)
                {
                    if (checkDestination(x))
                    {
                        x._heroSprite.Location = x._heroDestination;
                        x._heroSprite.Velocity = PointF.Empty;
                        x._heroSpriteAnimating = false;

                        //Check objects?
                        MapTile mt = _currentArea.Map[x._heroPosition.X, x._heroPosition.Y];
                        if (mt.TileImport.Type == TypeTile.Item)
                        {
                            TileImgServiceClient service = new TileImgServiceClient();
                            _currentArea.Map[x._heroPosition.X, x._heroPosition.Y] = new MapTile(service.GetTileAt(mt.GlobalX, mt.GlobalY, _monde.Id), _tiles);
                        }
                    }
                }
            });

            //The hero gets animated when moving or fighting
            if (_heroSpriteAnimating || _heroSpriteFighting)
                _heroSprite.CurrentFrame = (int)((gameTime * 8.0) % _heroSprite.NumberOfFrames);
            else
            {
                //Otherwise use frame 0
                _heroSprite.CurrentFrame = 0;
            }

            //Update l'animation des autres joueurs
            _herosMP.ForEach((x) =>
            {
                if (x._heroSpriteAnimating || x._heroSpriteFighting)
                    x._heroSprite.CurrentFrame = (int)((gameTime * 8.0) % x._heroSprite.NumberOfFrames);
                else
                {
                    //Otherwise use frame 0
                    x._heroSprite.CurrentFrame = 0;
                }

            });

            //If we are fighting then keep animating for a period of time
            if (_heroSpriteFighting)
            {
                if (_startFightTime < 0)
                    _startFightTime = gameTime;
                else
                {
                    if (gameTime - _startFightTime > 1.0)
                        _heroSpriteFighting = false;
                }
            }

            _herosMP.ForEach((x) =>
            {
                if (x._heroSpriteFighting)
                {
                    if (x._startFightTime < 0)
                        x._startFightTime = gameTime;
                    else
                    {
                        if (gameTime - x._startFightTime > 1.0)
                            x._heroSpriteFighting = false;
                    }
                }
            });
        }

        private void checkObjects()
        {
            
            MapTile tile = _currentArea.Map[_heroPosition.X, _heroPosition.Y];

            Tile objectTile = tile.ObjectTile;
            TileImport t = tile.TileImport;


            if (objectTile == null)
                return;
            HeroServiceClient HeroService = new HeroServiceClient();
            switch (objectTile.Category)
            {
                //Most objects change your stats in some way.
                case "armour":
                    if (RamasserItems(t))
                    {
                        _gameState.Armour++;
                        HeroService.ChangeHeroStats(Outils.GetHero().Id,1,null,null);
                        Sounds.Pickup();
                    }
                    break;

                case "attack":

                    if (RamasserItems(t))
                    {
                        _gameState.Attack++;
                        HeroService.ChangeHeroStats(Outils.GetHero().Id, null, 1, null);
                        Sounds.Pickup();
                    }
                    break;

                case "food":
                    if (RamasserItems(t))
                    {
                        HeroService.ChangeHeroStats(Outils.GetHero().Id, null, null, 10);
                        Sounds.Eat();
                    }
                    break;

                case "treasure":
                    if (RamasserItems(t))
                    {
                        _gameState.Treasure += 5;
                        Sounds.Pickup();
                    }
                    break;

                case "potion":
                    if (RamasserItems(t))
                    {
                        _gameState.Potions++;
                        Sounds.Pickup();
                    }
                    break;

                case "key":
                    if (RamasserItems(t))
                    {
                        if (objectTile.Color == "brown") _gameState.HasBrownKey = true;
                        if (objectTile.Color == "green") _gameState.HasGreenKey = true;
                        if (objectTile.Color == "red") _gameState.HasRedKey = true;
                        Sounds.Pickup();
                    }
                    break;

                case "fire":
                    _gameState.Health -= 2;
                    break;
            }
            //Remove the object unless its bones or fire
            if (objectTile.Category != "fire" && objectTile.Category != "bones" && objectTile.Category != "character")
            {
                // _currentArea.Map[_heroPosition.X, _heroPosition.Y].ObjectTile = null;
                // _currentArea.Map[_heroPosition.X, _heroPosition.Y].ObjectSprite = null;
                TileImgServiceClient service = new TileImgServiceClient();
                _currentArea.Map[_heroPosition.X, _heroPosition.Y] = new MapTile(service.GetTileAt(tile.GlobalX, tile.GlobalY, _monde.Id), _tiles);
            }
        }

        private bool checkDestination()
        {
            //Depending on the direction we are moving we check different bounds of the destination
            switch (_direction)
            {
                case HeroDirection.Right:
                    return (_heroSprite.Location.X >= _heroDestination.X);

                case HeroDirection.Left:
                    return (_heroSprite.Location.X <= _heroDestination.X);

                case HeroDirection.Up:
                    return (_heroSprite.Location.Y <= _heroDestination.Y);

                case HeroDirection.Down:
                    return (_heroSprite.Location.Y >= _heroDestination.Y);
            }

            throw new ArgumentException("Direction is not set correctly");
        }

        private bool checkDestination(OtherPlayers p)
        {
            //Depending on the direction we are moving we check different bounds of the destination
            switch (p._direction)
            {
                case HeroDirection.Right:
                    return (p._heroSprite.Location.X >= p._heroDestination.X);

                case HeroDirection.Left:
                    return (p._heroSprite.Location.X <= p._heroDestination.X);

                case HeroDirection.Up:
                    return (p._heroSprite.Location.Y <= p._heroDestination.Y);

                case HeroDirection.Down:
                    return (p._heroSprite.Location.Y >= p._heroDestination.Y);
            }

            throw new ArgumentException("Direction is not set correctly");
        }

        public override void Draw(Graphics graphics)
        {
            _currentArea.Draw(graphics);
            _heroSprite.Draw(graphics);

            _herosMP.ForEach((x) => x._heroSprite.Draw(graphics));

            //If we are fighting then draw the damage
            if (_heroSpriteFighting)
            {
                foreach (textPopup popup in _popups)
                {
                    //Draw 4 text offsets to get an outline
                    graphics.DrawString(popup.Text, _font, _whiteBrush, popup.X + 2, popup.Y);
                    graphics.DrawString(popup.Text, _font, _whiteBrush, popup.X - 1, popup.Y);
                    graphics.DrawString(popup.Text, _font, _whiteBrush, popup.X, popup.Y + 2);
                    graphics.DrawString(popup.Text, _font, _whiteBrush, popup.X, popup.Y - 2);

                    //Draw the actual text
                    graphics.DrawString(popup.Text, _font, _blackBrush, popup.X, popup.Y);
                }
            }
        }

        private void SaveHeroPos()
        {
            try
            {
                HeroServiceClient service = new HeroServiceClient();
                service.SaveHeroPos(_hero.Id, _hero.x, _hero.y);
            }
            catch (Exception)
            {
                MessageBox.Show("V�rifiez la connection au VPN!");
            }
        }

        /// <summary>
        /// Gestion du d�placement du h�ro
        /// </summary>
        /// <param name="key"></param>
        public void KeyDown(Keys key)
        {
            //Ignore keypresses while we are animating or fighting
            if (!_heroSpriteAnimating && !_heroSpriteFighting)
            {
                TileImgServiceClient service = new TileImgServiceClient();
                switch (key)
                {
                    case Keys.Right:
                        if (_hero.x < _monde.LimiteX - 1)
                        {
                            //Are we at the edge of the map?
                            if (_heroPosition.X < Area.MapSizeX - 1)
                            {
                                //Can we move to the next tile or not (blocking tile or monster)
                                if (checkNextTile(_currentArea.Map[_heroPosition.X + 1, _heroPosition.Y], _heroPosition.X + 1, _heroPosition.Y))
                                {
                                    _heroSprite.Velocity = new PointF(100, 0);
                                    _heroSprite.Flip = true;
                                    _heroSpriteAnimating = true;
                                    _direction = HeroDirection.Right;
                                    _heroPosition.X++;
                                    //SetDB pos
                                    _hero.x++;
                                    SaveHeroPos();
                                    setDestination();
                                }
                            }
                            else if (_currentArea.EastArea != "-")
                            {
                                //Edge of map - move to next area
                                if (checkNextTile(new MapTile(service.GetTileAt(_hero.x + 1, _hero.y, _monde.Id), _tiles), _heroPosition.X + 1, _heroPosition.Y, true))
                                {
                                    LoadChunk(_hero.x + 1);
                                    //_currentArea = _world[_currentArea.EastArea];
                                    if (_currentArea.EastArea == "OK")
                                    {
                                        _heroPosition.X = 0;
                                        _hero.x++;
                                        SaveHeroPos();
                                        setDestination();
                                        _heroSprite.Location = _heroDestination;
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.Left:
                        if (_hero.x > 0)
                        {

                            //Are we at the edge of the map?
                            if (_heroPosition.X > 0)
                            {
                                //Can we move to the next tile or not (blocking tile or monster)
                                if (checkNextTile(_currentArea.Map[_heroPosition.X - 1, _heroPosition.Y], _heroPosition.X - 1, _heroPosition.Y))
                                {
                                    _heroSprite.Velocity = new PointF(-100, 0);
                                    _heroSprite.Flip = false;
                                    _heroSpriteAnimating = true;
                                    _direction = HeroDirection.Left;
                                    _heroPosition.X--;
                                    _hero.x--;
                                    SaveHeroPos();
                                    setDestination();
                                }
                            }
                            else if (_currentArea.WestArea != "-")
                            {
                                if (checkNextTile(new MapTile(service.GetTileAt(_hero.x - 1, _hero.y, _monde.Id), _tiles), _heroPosition.X - 1, _heroPosition.Y, true))
                                {
                                    LoadChunk(_hero.x - 1);
                                    //_currentArea = _world[_currentArea.WestArea];
                                    if (_currentArea.WestArea == "OK")
                                    {
                                        _heroPosition.X = Area.MapSizeX - 1;
                                        _hero.x--;
                                        SaveHeroPos();
                                        setDestination();
                                        _heroSprite.Location = _heroDestination;
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.Up:
                        //Are we at the edge of the world?

                        if (_hero.y > 0)
                        {
                            //Are we at the edge of the map?
                            if (_heroPosition.Y > 0)
                            {
                                //Can we move to the next tile or not (blocking tile or monster)
                                if (checkNextTile(_currentArea.Map[_heroPosition.X, _heroPosition.Y - 1], _heroPosition.X, _heroPosition.Y - 1))
                                {
                                    _heroSprite.Velocity = new PointF(0, -100);
                                    _heroSpriteAnimating = true;
                                    _direction = HeroDirection.Up;
                                    _heroPosition.Y--;
                                    _hero.y--;
                                    SaveHeroPos();
                                    setDestination();
                                }
                            }
                            else if (_currentArea.NorthArea != "-")
                            {
                                if (checkNextTile(new MapTile(service.GetTileAt(_hero.x, _hero.y - 1, _monde.Id), _tiles), _heroPosition.X, _heroPosition.Y - 1, true))
                                {
                                    //Edge of map - move to next area
                                    LoadChunk(-1, _hero.y - 1);
                                    if (_currentArea.NorthArea == "OK")
                                    {
                                        //_currentArea = _world[_currentArea.NorthArea];
                                        _heroPosition.Y = Area.MapSizeY - 1;
                                        _hero.y--;
                                        SaveHeroPos();
                                        setDestination();
                                        _heroSprite.Location = _heroDestination;
                                    }
                                }
                            }
                        }
                        break;

                    case Keys.Down:
                        if (_hero.y < _monde.LimiteY - 1)
                        {
                            //Are we at the edge of the map?
                            if (_heroPosition.Y < Area.MapSizeY - 1)
                            {
                                //Can we move to the next tile or not (blocking tile or monster)
                                if (checkNextTile(_currentArea.Map[_heroPosition.X, _heroPosition.Y + 1], _heroPosition.X, _heroPosition.Y + 1))
                                {
                                    _heroSprite.Velocity = new PointF(0, 100);
                                    _heroSpriteAnimating = true;
                                    _direction = HeroDirection.Down;
                                    _heroPosition.Y++;
                                    _hero.y++;
                                    SaveHeroPos();
                                    setDestination();
                                }
                            }
                            else if (_currentArea.SouthArea != "-")
                            {
                                //Edge of map - move to next area
                                if (checkNextTile(new MapTile(service.GetTileAt(_hero.x, _hero.y + 1, _monde.Id), _tiles), _heroPosition.X, _heroPosition.Y + 1, true))
                                {
                                    LoadChunk(-1, _hero.y + 1);
                                    if (_currentArea.SouthArea == "OK")
                                    {
                                        //_currentArea = _world[_currentArea.SouthArea];
                                        _heroPosition.Y = 0;
                                        _hero.y++;
                                        SaveHeroPos();
                                        setDestination();
                                        _heroSprite.Location = _heroDestination;
                                    }
                                }
                            }
                        }
                        break;
                    case Keys.P:
                        //Potion - if we have any
                        if (_gameState.Potions > 0)
                        {
                            Sounds.Magic();

                            _gameState.Potions--;

                            _heroSpriteFighting = true;
                            _startFightTime = -1;

                            //All monsters on the screen take maximum damage
                            _popups.Clear();
                            for (int i = 0; i < Area.MapSizeX; i++)
                            {
                                for (int j = 0; j < Area.MapSizeY; j++)
                                {
                                    MapTile mapTile = _currentArea.Map[i, j];
                                    if (mapTile.ObjectTile != null && mapTile.ObjectTile.Category == "character")
                                    {
                                        damageMonster(_gameState.Attack * 2, mapTile, i, j);
                                    }
                                }
                            }
                        }
                        break;
                    case Keys.Escape:
                        _hero.EstConnecte = false;
                        // save content hero (items, monstres, vie hero, etc)

                        SaveHeroPos();
                        Clear();
                        break;
                }
            }
        }

        /// <summary>
        /// V�rifie la nouvelle position h�ro
        /// </summary>
        /// <param name="mapTile"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private bool checkNextTile(MapTile mapTile, int x, int y, bool newChunk = false)
        {
            //See if there is a door we need to open
            checkDoors(mapTile, x, y);

            //ne peux pas changer de chunk sur un item ou un monstre
            if (newChunk)
                if (mapTile.TileImport.Type == TypeTile.Monstre)
                    return false;

            //See if there is character to fight
            if (mapTile.ObjectTile != null && mapTile.ObjectTile.Category == "character")
            {
                if (mapTile.ObjectTile.Shortcut == "pri")
                {
                    //Game is won
                    Sounds.Kiss();
                    _gameState.GameIsWon = true;
                    return false; //Don't want to walk on her
                }

                if (mapTile.ObjectHealth < 0)
                {
                    return true;
                }

                Sounds.Fight();

                _heroSpriteFighting = true;
                _startFightTime = -1;

                int heroDamage = 0;
                //A monsters attack ability is 1/2 their max health. Compare that to your armour
                //If you outclass them then there is still a chance of a lucky hit
                if (_random.Next((mapTile.ObjectTile.Health / 2) + 1) >= _gameState.Armour
                    || (mapTile.ObjectTile.Health / 2 < _gameState.Armour && _random.Next(10) == 0))
                {
                    //Monsters do damage up to their max health - if they hit you.
                    heroDamage = _random.Next(mapTile.ObjectTile.Health) + 1;
                    _gameState.Health -= heroDamage;

                    _hero.Hp = _gameState.Health;

                    HeroServiceClient heroService = new HeroServiceClient();
                    heroService.ChangeHeroStats(_hero.Id, null, null, -heroDamage);

                    if (_gameState.Health <= 0)
                    {
                        _gameState.Health = 0;
                        DeadHero();
                    }
                }

                //Hero
                _popups.Clear();
                _popups.Add(new textPopup((int)_heroSprite.Location.X + 40,
                                          (int)_heroSprite.Location.Y + 20,
                                          (heroDamage != 0) ? heroDamage.ToString() : "miss"));

                //A monsters armour is 1/5 of their max health
                if (_random.Next(_gameState.Attack + 1) >= (mapTile.ObjectTile.Health / 5))
                {
                    //Hero damage is up to twice the attack rating

                    if (Combat(mapTile, x, y, null))
                    {
                        //Monster is dead now
                        return true;
                    }
                }
                else
                {
                    _popups.Add(new textPopup((int)mapTile.Sprite.Location.X + 40, (int)mapTile.Sprite.Location.Y + 20, "miss"));
                }
                //Monster not dead
                return false;
            }

            foreach (OtherPlayers player in _herosMP)
            {
                if (player.Hero.x == mapTile.GlobalX && player.Hero.y == mapTile.GlobalY)
                {
                    // combat
                    Sounds.Fight();

                    _heroSpriteFighting = true;
                    _startFightTime = -1;

                    if (Combat(mapTile, x, y, player))
                    { // s'il est mort return true
                        // opponent mort
                        player._heroSprite = new Sprite(null, player._heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                                              player._heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY,
                                                              _tiles["3"].Bitmap, _tiles["3"].Rectangle, _tiles["3"].NumberOfFrames);
                        player._heroSprite.ColorKey = Color.FromArgb(75, 75, 75);
                        return true;

                    }
                    else
                    { // s'il est toujours vivant return false
                        return false;
                    }
                }
            }


            //If the next tile is a blocker then we can't move
            if (mapTile.Tile.IsBlock)
                return false;

            return true;
        }

        private bool Combat(MapTile mapTile, int x, int y, OtherPlayers opponent)
        {

            // current player
            int h_chance = _random.Next(0, 2);

            int h_dmg = (h_chance * _hero.StatDex * _hero.StatStr);

            if (opponent != null)
            {

                if (h_dmg != 0)
                {
                    // dmg opponent 
                    opponent.Hero.Hp -= h_dmg;
                    HeroServiceClient heroService = new HeroServiceClient();
                    heroService.ChangeHeroStats(opponent.Hero.Id, null, null, -h_dmg);
                }

                // popup de dmg local sur le héro
                _popups.Add(new textPopup((int)opponent._heroSprite.Location.X + 40,
                          (int)opponent._heroSprite.Location.Y + 20,
                          (h_dmg != 0) ? h_dmg.ToString() : "miss"));

                if (opponent.Hero.Hp <= 0)
                    return true; // he dead fam
                else
                    return false; // he livin fam

            }
            else
            {
                //Do some damage, and remove the monster if its dead
                bool returnValue = false; //monster not dead

                //Set the monster health if its not already set
                if (mapTile.ObjectHealth == 0)
                {
                    mapTile.ObjectHealth = mapTile.ObjectTile.Health;
                }

                mapTile.ObjectHealth -= h_dmg;
                MondeServiceClient mondeService = new MondeServiceClient();
                mondeService.ChangeMonsterStats(mapTile.TileImport.ID, -h_dmg, null);

                if (mapTile.ObjectHealth <= 0)
                {
                    mapTile.ObjectHealth = 0;
                    //Experience is the monsters max health
                    _gameState.Experience += mapTile.ObjectTile.Health;

                    mondeService.ChangeMonsterStats(mapTile.TileImport.ID, null, 3);

                    //Remove the monster and replace with bones
                    mapTile.ObjectTile = _tiles["3"];
                    mapTile.SetObjectSprite(x, y);
                    returnValue = true; //monster is dead
                }

                _popups.Add(new textPopup((int)mapTile.Sprite.Location.X + 40,
                                          (int)mapTile.Sprite.Location.Y + 20,
                                          (h_dmg != 0) ? h_dmg.ToString() : "miss"));

                return returnValue;
            }

        }

        private bool damageMonster(int damage, MapTile mapTile, int x, int y)
        {
            //Do some damage, and remove the monster if its dead
            bool returnValue = false; //monster not dead

            //Set the monster health if its not already set
            if (mapTile.ObjectHealth == 0)
            {
                mapTile.ObjectHealth = mapTile.ObjectTile.Health;
            }

            mapTile.ObjectHealth -= damage;

            if (mapTile.ObjectHealth <= 0)
            {
                mapTile.ObjectHealth = 0;
                //Experience is the monsters max health
                _gameState.Experience += mapTile.ObjectTile.Health;

                //Remove the monster and replace with bones
                mapTile.ObjectTile = _tiles["3"];
                mapTile.SetObjectSprite(x, y);
                returnValue = true; //monster is dead
            }

            _popups.Add(new textPopup((int)mapTile.Sprite.Location.X + 40, (int)mapTile.Sprite.Location.Y + 20, (damage != 0) ? damage.ToString() : "miss"));

            return returnValue;
        }

        private void checkDoors(MapTile mapTile, int x, int y)
        {
            //If the next tile is a closed door then check if we have the key
            if (mapTile.Tile.Category == "door" && mapTile.Tile.IsBlock)
            {
                //For each key if it matches then open the door by switching the sprite & sprite to its matching open version
                if (mapTile.Tile.Color == "brown" && _gameState.HasBrownKey)
                {
                    //Open the door
                    mapTile.Tile = _tiles["10"];
                    mapTile.SetSprite(x, y);
                }

                if (mapTile.Tile.Color == "red" && _gameState.HasRedKey)
                {
                    //Open the door
                    mapTile.Tile = _tiles["14"];
                    mapTile.SetSprite(x, y);
                }

                if (mapTile.Tile.Color == "green" && _gameState.HasGreenKey)
                {
                    //Open the door
                    mapTile.Tile = _tiles["12"];
                    mapTile.SetSprite(x, y);
                }
            }
        }

        private void setDestination()
        {
            //Calculate the eventual sprite destination based on the area grid coordinates
            _heroDestination = new PointF(_heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                            _heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY);
        }

        private void setDestination(OtherPlayers o)
        {
            //Calculate the eventual sprite destination based on the area grid coordinates
            o._heroDestination = new PointF(o._heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                            o._heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY);
        }

        public enum HeroDirection
        {
            Left,
            Right,
            Up,
            Down
        }

        private bool RamasserItems(TileImport t)
        {

            ItemDTO dto = new ItemDTO()
            {
                Id = t.ID,
                Nom = t.Name,
                Description = t.Description,
                x = t.x,
                y = t.y,
                MondeId = _monde.Id,
                IdHero = _hero.Id,
                ImageId = int.Parse(t.tileID),
                RowVersion = t.RowVersion
            };

            if (ItemService.PickUpItem(dto) != null)
            {
                return true;
            }

            return false;

        }

        private void DeadHero()
        {
            _heroSprite = new Sprite(null, _heroPosition.X * Tile.TileSizeX + Area.AreaOffsetX,
                                    _heroPosition.Y * Tile.TileSizeY + Area.AreaOffsetY,
                                    _tiles["3"].Bitmap, _tiles["3"].Rectangle, _tiles["3"].NumberOfFrames);
            _heroSprite.ColorKey = Color.FromArgb(75, 75, 75);
        }
    }
}