using System;
using System.Drawing;
using HugoWorld_Client.HL_Services;

namespace HugoWorld {

    public class Tile {
        private static BitmapCache _bitmaps = new BitmapCache();
        public const int TileSizeX = 64;
        public const int TileSizeY = 64;

        public int ID;
        public string Type;
        public Bitmap Bitmap;
        public Rectangle Rectangle;
        public bool IsTransparent;
        public int NumberOfFrames;
        public bool IsBlock;
        public string Category;

        //Special fields for some
        public string Color;

        public int Health;
        public int minDmg;
        public int maxDmg;

        public string Name;
        public string Shortcut;

        public Tile(string[] tileData)
        {
            Name = tileData[0];
            Shortcut = tileData[1];
            Category = tileData[2].ToLower();
            Bitmap = _bitmaps[tileData[3]];
            NumberOfFrames = Convert.ToInt32(tileData[7]);
            Rectangle = new Rectangle((Convert.ToInt32(tileData[4]) - 1) * TileSizeX, (Convert.ToInt32(tileData[5]) - 1) * TileSizeY, TileSizeX * NumberOfFrames, TileSizeY);
            IsTransparent = (tileData[6].ToLower() == "y");
            IsBlock = ((tileData[8].ToLower()) == "block");

            //Some types of tiles have a color
            if (Category == "door" || Category == "key")
            {
                Color = tileData[9].ToLower();
            }

            //Some types of tiles have health
            if (Category == "character")
            {
                Health = Convert.ToInt32(tileData[9]);
            }
        }

        public Tile(TileImport tile)
        {
            Name = tile.Name;
            Shortcut = tile.Shortcut;
            Category = tile.Category;

            NumberOfFrames = tile.NumberOfFrames;
            IsTransparent = tile.IsTransparent;
            IsBlock = tile.IsBlock;

            //Some types of tiles have a color
            if (Category == "door" || Category == "key")
            {
                Color = tile.Color;
            }

            //Some types of tiles have health
            if (Category == "character")
            {
                Health = tile.Health;
                minDmg = tile.minDMG;
                maxDmg = tile.maxDMG;
                ID = tile.ID;
                Type = tile.Type;
            }
        }
    }
}