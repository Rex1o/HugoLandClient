using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld
{

    public class GameState
    {
        public SizeF GameArea;
        public World World;
        public MondeDTO Monde;
        public HeroDTO Hero;
        public int Attack;
        public int Armour;
        public int Level;
        public int Health;
        public int Treasure;
        public int Potions;
        public bool HasBrownKey;
        public bool HasGreenKey;
        public bool HasRedKey;
        public bool GameIsWon;

        private int _experience;
        private int _nextUpgrade;
        private Sprite _experienceSprite;
        private Sprite _attackSprite;
        private Sprite _armourSprite;
        private Sprite _healthSprite;
        private Sprite _treasureSprite;
        private Sprite _potionSprite;
        private Sprite _brownKeySprite;
        private Sprite _greenKeySprite;
        private Sprite _redKeySprite;
        private Dictionary<string, Tile> _tiles = new Dictionary<string, Tile>();

        private static Font _font = new Font("Arial", 24);
        private static Brush _brush = new SolidBrush(Color.White);
        private static Random _random = new Random();

        private ItemServiceClient ItemService = new ItemServiceClient();

        public GameState(SizeF gameArea)
        {
            GameArea = gameArea;

            //Load in all the tile definitions
            readTileDefinitions(@"gamedata\NewTilesLookup.csv");

            //Create the sprites for the UI
            int y = 50;
            _experienceSprite = new Sprite(this, 580, y, _tiles["71"].Bitmap, _tiles["71"].Rectangle, _tiles["71"].NumberOfFrames);
            _experienceSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _healthSprite = new Sprite(this, 580, y += 74, _tiles["15"].Bitmap, _tiles["15"].Rectangle, _tiles["15"].NumberOfFrames);
            _healthSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _attackSprite = new Sprite(this, 580, y += 74, _tiles["2"].Bitmap, _tiles["2"].Rectangle, _tiles["2"].NumberOfFrames);
            _attackSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _armourSprite = new Sprite(this, 580, y += 74, _tiles["1"].Bitmap, _tiles["1"].Rectangle, _tiles["1"].NumberOfFrames);
            _armourSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _treasureSprite = new Sprite(this, 580, y += 74, _tiles["65"].Bitmap, _tiles["65"].Rectangle, _tiles["65"].NumberOfFrames);
            _treasureSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _potionSprite = new Sprite(this, 580, y += 74, _tiles["37"].Bitmap, _tiles["37"].Rectangle, _tiles["37"].NumberOfFrames);
            _potionSprite.ColorKey = Color.FromArgb(75, 75, 75);
            _brownKeySprite = new Sprite(this, 580, y += 74, _tiles["22"].Bitmap, _tiles["22"].Rectangle, _tiles["22"].NumberOfFrames);
            _brownKeySprite.ColorKey = Color.FromArgb(75, 75, 75);
            _greenKeySprite = new Sprite(this, 654, y, _tiles["23"].Bitmap, _tiles["23"].Rectangle, _tiles["23"].NumberOfFrames);
            _greenKeySprite.ColorKey = Color.FromArgb(75, 75, 75);
            _redKeySprite = new Sprite(this, 728, y, _tiles["24"].Bitmap, _tiles["24"].Rectangle, _tiles["24"].NumberOfFrames);
            _redKeySprite.ColorKey = Color.FromArgb(75, 75, 75);
        }

        //Experience property automatically upgrades your skill as the 'set' passes
        //the level threshold
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                _experience = value;
                //If we hit the upgrade threshold then increase our abilities
                if (_experience > _nextUpgrade)
                {
                    Attack++;
                    Armour++;
                    //Each upgrade is a little harder to get
                    _nextUpgrade = _nextUpgrade + 20 * Level;
                    Level++;
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            World.Draw(graphics);

            //Draw the HUD
            _experienceSprite.Draw(graphics);
            _healthSprite.Draw(graphics);
            _attackSprite.Draw(graphics);
            _armourSprite.Draw(graphics);
            _treasureSprite.Draw(graphics);
            _potionSprite.Draw(graphics);
            if (HasBrownKey) _brownKeySprite.Draw(graphics);
            if (HasGreenKey) _greenKeySprite.Draw(graphics);
            if (HasRedKey) _redKeySprite.Draw(graphics);
            int y = 65;
            graphics.DrawString(Experience.ToString(), _font, _brush, 650, y);
            graphics.DrawString(Health.ToString(), _font, _brush, 650, y += 74);
            graphics.DrawString(Attack.ToString(), _font, _brush, 650, y += 74);
            graphics.DrawString(Armour.ToString(), _font, _brush, 650, y += 74);
            graphics.DrawString(Treasure.ToString(), _font, _brush, 650, y += 74);
            graphics.DrawString(Potions.ToString(), _font, _brush, 650, y += 74);

            //If the game is over then display the end game message
            if (Health <= 0)
            {
                graphics.DrawString("You died!", _font, _brush, 200, 250);
                graphics.DrawString("Press 's' to play again", _font, _brush, 100, 300);
            }

            //If the game is won then show congratulations
            if (GameIsWon)
            {
                graphics.DrawString("You Won!", _font, _brush, 200, 250);
                graphics.DrawString("Press 's' to play again", _font, _brush, 100, 300);
            }
        }

        public void Update(double gameTime, double elapsedTime)
        {
            World.Update(gameTime, elapsedTime);
        }

        public void Initialize()
        {
            if (Outils.GetHero() != null)
            {
                Sounds.Start();

                MondeServiceClient MondeService = new MondeServiceClient();
                Monde = MondeService.GetWorldByHero(Outils.GetHero());

                //Create all the main gameobjects
                World = new World(this, _tiles, Monde);

                //Reset the game state

                //Instancier les valeurs de base du héro ici
                List<ItemDTO> items = ItemService.ObtenirItemHero(Outils.GetHero()).ToList();

                //Verifier si il a une clef verte
                if (items.Where(x => x.Nom == "KeyGreen").FirstOrDefault() != null)
                {
                    HasGreenKey = true;//Si il a la clef Verte
                }
                else
                {
                    HasGreenKey = false;
                }
                //Verifier si il a une clef rouge
                if (items.Where(x => x.Nom == "KeyRed").FirstOrDefault() != null)
                {
                    HasRedKey = true;//Si il a la clef Verte
                }
                else
                {
                    HasRedKey = false;
                }
                //Verifier si il a une clef rune
                if (items.Where(x => x.Nom == "KeyBrown").FirstOrDefault() != null)
                {
                    HasBrownKey = true;
                }
                else
                {
                    HasBrownKey = false;
                }

                Armour = Outils.GetHero().StatInt;
                Attack = Outils.GetHero().StatStr; //Force/strength -> ajouter directement au héro
                Health = Outils.GetHero().Hp;//Vie -> ajouter directement au héro
                Experience = (int)Outils.GetHero().Experience;//En tuant des monstre
                Level = Outils.GetHero().Niveau;//Niveau selon l'xp
                Potions = items.Where(x => x.Nom == "Potion").Count();//Nb de postion dans l'inventaire
                Treasure = items.Where(x => x.Description == "treasure").Count() * 5;//Nb d'argent

                GameIsWon = false;
            }
        }

        //Each line contains a comma delimited tile definition that the tile constructor understands
        private void readTileDefinitions(string tileDescriptionFile)
        {
            using (StreamReader stream = new StreamReader(tileDescriptionFile))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    //separate out the elements of the
                    string[] elements = line.Split(';');

                    //And make the tile.
                    Tile tile = new Tile(elements);
                    _tiles.Add(tile.Shortcut, tile);
                }
            }
        }

        public void KeyDown(Keys keys)
        {
            if (keys == Keys.Escape)
            {
                if (World != null)
                {
                    World.SaveHeroPos();
                    World.Disconnect();
                    World.Clear();
                    World = null;
                }
            }
            //If the game is not over then allow the user to play
            else if (Health > 0 && !GameIsWon)
            {

                World.KeyDown(keys);
            }
            else
            {
                //If game is over then allow S to restart
                if (keys == Keys.S)
                {
                    World.Respawn();
                }
            }
        }
    }
}