using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : ITileImgService {

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

        public TileImport GetTileAt(int x, int y, int mondeId)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                Monstre ms = context.Monstres.FirstOrDefault(m => m.x == x && m.y == y && m.MondeId == mondeId);
                if (ms != null)
                {
                    return MonstreToTile(new MonstreDTO(ms));
                }

                ObjetMonde obj = context.ObjetMondes.FirstOrDefault(o => o.x == x && o.y == y && o.MondeId == mondeId);
                if(obj != null)
                {
                    return ObjetMondeToTile(new ObjetMondeDTO(obj));
                }

                Item it = context.Items.FirstOrDefault(i => i.x == x && i.y == y && i.MondeId == mondeId);
                if(it != null)
                {
                    return ItemToTile(new ItemDTO(it));
                }

                return null;
            }
        }
    }
}