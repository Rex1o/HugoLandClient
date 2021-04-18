using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoWorld_WCF.Models
{
    public class TileImport
    {
        //public Bitmap Bitmap;
        //public Rectangle Rectangle;
        public List<string> Images;
        public int ID;
        public string Type;
        public bool IsTransparent;
        public int NumberOfFrames;
        public bool IsBlock;
        public string Category;

        //Special fields for some
        public string Color;

        public int Health;

        public string Name;
        public string Shortcut;
    }
}
