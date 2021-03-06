using HugoWorld_WCF.DTOs;
using HugoWorld_WCF.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IItemService {

        public List<ItemDTO> ConvertToItemsDTOs(ICollection<Item> items) {
            List<Item> _items = items.ToList();

            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            _items.ForEach(s => itemDTOs.Add(new ItemDTO(s)));
            return itemDTOs;
        }

        public List<EffetItemDTO> ConvertToEffetItemsDTOs(ICollection<EffetItem> effetItems) {
            List<EffetItem> _effetItems = effetItems.ToList();

            List<EffetItemDTO> effetItemsDTOs = new List<EffetItemDTO>();
            _effetItems.ForEach(s => effetItemsDTOs.Add(new EffetItemDTO(s)));
            return effetItemsDTOs;
        }

        public List<InventaireHeroDTO> ConvertToInventaireHeroDTOs(ICollection<InventaireHero> inventaireHeroes) {
            List<InventaireHero> _inventaireHeroes = inventaireHeroes.ToList();

            List<InventaireHeroDTO> inventaireHeroesDTOs = new List<InventaireHeroDTO>();
            _inventaireHeroes.ForEach(s => inventaireHeroesDTOs.Add(new InventaireHeroDTO(s)));
            return inventaireHeroesDTOs;
        }

        public List<MonstreDTO> ConvertToMonstresDTOs(ICollection<Monstre> monstres) {
            List<Monstre> _monstres = monstres.ToList();

            List<MonstreDTO> monstresDTOs = new List<MonstreDTO>();
            _monstres.ForEach(s => monstresDTOs.Add(new MonstreDTO(s)));
            return monstresDTOs;
        }

        public List<ObjetMondeDTO> ConvertToObjetMondeDTOs(ICollection<ObjetMonde> objetMondes) {
            List<ObjetMonde> _objetMondes = objetMondes.ToList();

            List<ObjetMondeDTO> objetMondesDTOS = new List<ObjetMondeDTO>();
            _objetMondes.ForEach(s => objetMondesDTOS.Add(new ObjetMondeDTO(s)));
            return objetMondesDTOS;
        }

        public ItemDTO PickUpItem(ItemDTO dto) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Item item = DTOtoReg.DTOToItem(dto);

                InventaireHero inv = new InventaireHero() {
                    IdHero = (int)dto.IdHero,
                    ItemId = dto.Id
                };

                ObjetMonde grass = new ObjetMonde() {
                    x = (int)item.x,
                    y = (int)item.y,
                    TypeObjet = 0,
                    MondeId = item.MondeId,
                    ImageId = 17,
                    IsBlock = false,
                    Description = "Grass"
                };

                item.x = null;
                item.y = null;

                dbContext.ObjetMondes.Add(grass);
                dbContext.InventaireHeroes.Add(inv);
                dbContext.Entry(item).State = EntityState.Modified;
                try {
                    dbContext.SaveChanges();
                    return new ItemDTO(item);
                } catch (System.Exception) {
                    return null;
                }
            }
        }

        public List<ItemDTO> ObtenirItemHero(HeroDTO h) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                List<Item> items = dbContext.Items.Where(x => x.IdHero == h.Id).ToList();
                List<ItemDTO> itemsdto = ConvertToItemsDTOs(items);
                return itemsdto;
            }
        }
    }
}