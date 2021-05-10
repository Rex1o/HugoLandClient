using HugoWorld_Client.HL_Services;
using System.Collections.Generic;
using System.Drawing;

namespace HugoWorld {

    /// <summary>
    /// A MapTile is a reference to the original tile and the sprite that represents it. Note that they have to be different
    /// because each tile can be used for multiple map tiles and each sprite has to have a unique location
    /// Each MapTile can also have an other tile object associated with it which is used for special items and monsters
    /// If its a monster then the current health is also stored per MapTile.
    /// </summary>
    public class MapTile {
        public Tile Tile;
        public TileImport TileImport;
        public Sprite Sprite;
        public Sprite ObjectSprite;
        public Tile ObjectTile;
        public int GlobalX;
        public int GlobalY;
        public int ObjectHealth; //A copy of the health of the tile so we remember how damage monsters are

        public MapTile() {
        }

        public MapTile(TileImport t, Dictionary<string, Tile> tiles) {
            if (t.Type == TypeTile.Item || t.Type == TypeTile.Monstre) {
                ObjectTile = tiles[t.tileID];
                SetObjectSprite(t.x % 8, t.y % 8);
                Tile = tiles["17"];
            } else
                Tile = tiles[t.tileID];

            if (Tile != null) {
                SetSprite(t.x % 8, t.y % 8);
                if (ObjectTile?.IsTransparent ?? false) {
                    ObjectSprite.ColorKey = Color.FromArgb(75, 75, 75);
                }
            }

            GlobalX = t.x;
            GlobalY = t.y;

            TileImport = t;
        }

        public void SetSprite(int x, int y) {
            //Update the sprite
            Sprite = new Sprite(null, Area.AreaOffsetX + x * Tile.TileSizeX,
                                      Area.AreaOffsetY + y * Tile.TileSizeY,
                                      Tile.Bitmap, Tile.Rectangle,
                                      Tile.NumberOfFrames);
        }

        public void SetObjectSprite(int x, int y) {
            //Update the sprite
            ObjectSprite = new Sprite(null, Area.AreaOffsetX + x * Tile.TileSizeX,
                                      Area.AreaOffsetY + y * Tile.TileSizeY,
                                      ObjectTile.Bitmap, ObjectTile.Rectangle,
                                      ObjectTile.NumberOfFrames);
            if (ObjectTile.IsTransparent) {
                ObjectSprite.ColorKey = Color.FromArgb(75, 75, 75);
            }
        }
    }
}