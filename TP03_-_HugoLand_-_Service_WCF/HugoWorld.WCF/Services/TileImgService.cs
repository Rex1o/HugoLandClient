using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System;
using System.Linq;

namespace HugoWorld_WCF.Services
{

    public partial class HugoLandService : ITileImgService
    {
        public TileImport ItemToTile(ItemDTO item)
        {
            TileImport tile = new TileImport();
            tile.Name = item.Nom;
            tile.ID = item.Id;
            tile.Type = TypeTile.Item;
            tile.tileID = item.ImageId.ToString();
            tile.x = item.x ?? -1;
            tile.y = item.y ?? -1;
            return tile;
        }

        public TileImport MonstreToTile(MonstreDTO monstre)
        {
            TileImport tile = new TileImport();
            tile.Name = monstre.Nom;
            tile.Health = monstre.StatPV;
            tile.minDMG = (int)monstre.StatDmgMin;
            tile.maxDMG = (int)monstre.StatDmgMax;
            tile.ID = monstre.Id;
            tile.Type = TypeTile.Monstre;
            tile.tileID = monstre.ImageId.ToString();
            tile.x = monstre.x;
            tile.y = monstre.y;
            return tile;
        }

        public TileImport ObjetMondeToTile(ObjetMondeDTO objet)
        {
            TileImport tile = new TileImport();
            tile.Name = objet.Description;
            tile.ID = objet.Id;
            tile.Type = TypeTile.ObjetMonde;
            tile.tileID = objet.ImageId.ToString();
            tile.x = objet.x;
            tile.y = objet.y;
            return tile;
        }
    }
}