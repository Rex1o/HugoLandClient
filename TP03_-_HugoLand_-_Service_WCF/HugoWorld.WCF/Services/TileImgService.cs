using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : ITileImgService
    {
        public TileImport ItemToTile(ItemDTO item)
        {
            TileImport tile = new TileImport();
            tile.Name = item.Nom;
            tile.Shortcut = item.Nom.Substring(0, 3).ToLower();
            tile.IsTransparent = true;
            tile.Category = item.Description;
            tile.NumberOfFrames = 1;
            tile.IsBlock = false;
            tile.ID = item.Id;
            tile.Type = "Item";
            return tile;
        }

        public TileImport MonstreToTile(MonstreDTO monstre)
        {
            TileImport tile = new TileImport();
            tile.Name = monstre.Nom;
            tile.Shortcut = monstre.Nom.Substring(0, 3).ToLower();
            tile.Category = "character";
            tile.IsTransparent = true;
            tile.NumberOfFrames = monstre.Images.Count();

            return tile;
        }

        public TileImport ObjetMondeToTile(ObjetMondeDTO objet)
        {
            throw new NotImplementedException();
        }
    }
}
