using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : ITileImgService {
        //public TileImport ItemToTile(ItemDTO item)
        //{
        //    TileImport tile = new TileImport();
        //    tile.Name = item.Nom;
        //    tile.Shortcut = item.Nom.Substring(0, 3).ToLower();
        //    tile.IsTransparent = true;
        //    tile.Category = item.Description;
        //    tile.NumberOfFrames = 1;
        //    tile.IsBlock = false;
        //    tile.ID = item.Id;
        //    tile.Type = "Item";

        //    if (tile.Category == "Key")
        //        tile.Color = item.Nom.Substring(3);
        //    return tile;
        //}

        //public TileImport MonstreToTile(MonstreDTO monstre)
        //{
        //    TileImport tile = new TileImport();
        //    tile.Name = monstre.Nom;
        //    tile.Shortcut = monstre.Nom.Substring(0, 3).ToLower();
        //    tile.Category = "character";
        //    tile.IsTransparent = true;
        //    tile.NumberOfFrames = monstre.Images.Count();
        //    tile.Images = monstre.Images.Select(x => x.Imageb64).ToList();
        //    tile.IsBlock = false;
        //    tile.Health = monstre.StatPV;
        //    tile.minDMG = monstre.StatDmgMin;
        //    tile.maxDMG = monstre.StatDmgMax;
        //    tile.ID = monstre.Id;
        //    tile.Type = "Monstre";

        //    return tile;
        //}

        //public TileImport ObjetMondeToTile(ObjetMondeDTO objet)
        //{
        //    TileImport tile = new TileImport();
        //    tile.Name = objet.Description;
        //    tile.Shortcut = objet.Description.Substring(0, 3).ToLower();
        //    tile.Category = ((TypeObj)objet.TypeObjet).ToString();
        //    tile.IsTransparent = false;
        //    tile.IsBlock = objet.IsBlock;
        //    tile.Images = new List<string>() { objet.Image.Imageb64 };
        //    tile.NumberOfFrames = 1;
        //    tile.ID = objet.Id;
        //    tile.Type = "ObjetMonde";
        //    if (tile.Category == TypeObj.Door.ToString())
        //    {
        //        tile.color = tile.Name.Substring(4, tile.Name.IndexOf('O'));
        //        if(tile.color.Length > 5)
        //            tile.color = tile.Name.Substring(4, tile.Name.IndexOf('C'));
        //    }
        //    return tile;
        //}

        //private enum TypeObj
        //{
        //    Normal, Door
        //}
        public TileImport ItemToTile(ItemDTO item)
        {
            throw new NotImplementedException();
        }

        public TileImport MonstreToTile(MonstreDTO monstre)
        {
            throw new NotImplementedException();
        }

        public TileImport ObjetMondeToTile(ObjetMondeDTO objet)
        {
            throw new NotImplementedException();
        }
    }
}