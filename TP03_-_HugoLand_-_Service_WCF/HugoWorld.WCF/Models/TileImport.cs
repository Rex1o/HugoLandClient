using System.Collections.Generic;

namespace HugoWorld_WCF.Models {

    public class TileImport {

        //public Bitmap Bitmap;
        //public Rectangle Rectangle;
        public List<string> Images;

        public int ID;
        public TypeTile Type;
        public bool IsTransparent;
        public int NumberOfFrames;
        public bool IsBlock;
        public string Category;
        public string color;

        //Special fields for some
        public string Color;

        public int Health;
        public int minDMG;
        public int maxDMG;

        public string Name;
        public string Shortcut;
        public int x;
        public int y;
    }
}