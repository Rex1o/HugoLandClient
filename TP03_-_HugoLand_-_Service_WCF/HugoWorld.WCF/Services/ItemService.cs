using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IItemService {

        public void AddItem(string p_Nom, string p_Description, int p_X, int p_Y, int p_ImageId, int p_MondeId)
        {
            using (HugoLandContext dbcontext = new HugoLandContext())
            {
                dbcontext.Items.Add(new Item()
                {
                    Nom = p_Nom,
                    Description = p_Description,
                    x = p_X,
                    y = p_Y,
                    MondeId = p_MondeId,
                    ImageId = p_ImageId
                });

                dbcontext.SaveChanges();
            }
        }

        public void AddItemEffectById(int p_ItemId, int p_ValeurEffet, int p_TypeEffet)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                dbContext.EffetItems.Add(new EffetItem()
                {
                    Item = dbContext.Items.Find(p_ItemId),
                    ItemId = p_ItemId,
                    ValeurEffet = p_ValeurEffet,
                    TypeEffet = p_TypeEffet
                });
                dbContext.SaveChanges();
            }
        }

        public void AddRangeItems(List<ItemDTO> lstItems)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                List<Item> items = new List<Item>();
                lstItems.ForEach(i => items.Add(new Item()
                {
                    Nom = i.Nom,
                    Description = i.Description,
                    x = i.x,
                    y = i.y,
                    MondeId = i.MondeId,
                    ImageId = i.ImageId
                }));
                context.Items.AddRange(items);
                context.SaveChanges();
            }
        }

        public void DeleteItemById(int p_ItemId, HeroDTO p_Hero)
        {
            using (HugoLandContext dbcontext = new HugoLandContext())
            {
                Item itemDelete = dbcontext.Items
                        .Find(p_ItemId);

                if (itemDelete != null)
                {
                    if (p_Hero != null)
                    {
                        if (itemDelete != null)
                        {
                            itemDelete.x = null;
                            itemDelete.y = null;
                            itemDelete.IdHero = p_Hero.Id;
                            dbcontext.SaveChanges();
                        }
                    }
                    else
                        dbcontext.Items.Remove(itemDelete);
                }
            }
        }

        public void DeleteItemEffectById(int p_EffetItemId, int p_ItemId)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                EffetItem effetItem = dbContext.EffetItems.FirstOrDefault(x => x.ItemId == p_ItemId && x.Id == p_EffetItemId);

                if (effetItem != null)
                {
                    dbContext.EffetItems.Remove(effetItem);
                    dbContext.SaveChanges();
                }
            }
        }

        public void EditItemEffectById(int p_ItemId, int p_EffetItemId, int p_ValeurEffet, int p_TypeEffet)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                EffetItem effetItem = dbContext.EffetItems.FirstOrDefault(x => x.Id == p_EffetItemId);

                if (p_TypeEffet != effetItem.TypeEffet)
                {
                    effetItem.TypeEffet = p_TypeEffet;
                }

                if (p_ValeurEffet != effetItem.ValeurEffet)
                {
                    effetItem.ValeurEffet = p_ValeurEffet;
                }

                if (p_ItemId != effetItem.ItemId)
                {
                    effetItem.ItemId = p_ItemId;
                }

                dbContext.SaveChanges();
            }
        }

        public void EditItemQuantityById(int p_ItemId, int p_Quantite)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                InventaireHero item = context.InventaireHeroes.FirstOrDefault(x => x.ItemId == p_ItemId);

                if (item != null)
                {
                    item.Quantite = p_Quantite;
                    context.SaveChanges();
                }
            }
        }

        public void RemoveRangeById(int p_Id)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                //context.Items.RemoveRange(context.Items.Where(x => x.MondeId == p_Id));
                //context.SaveChanges();

                //La requête SQL est beacoup plus rapide que le entity framework
                context.Database.ExecuteSqlCommand($"DELETE FROM dbo.Item WHERE MondeId = {p_Id}");
            }
        }

        public List<ItemDTO> ConvertToItemsDTOs(ICollection<Item> items)
        {
            List<Item> _items = items.ToList();

            List<ItemDTO> itemDTOs = new List<ItemDTO>();
            _items.ForEach(s => itemDTOs.Add(new ItemDTO(s)
            {
                EffetsItems = ConvertToEffetItemsDTOs(s.EffetItems),
                InventaireHeroDTOs = ConvertToInventaireHeroDTOs(s.InventaireHeroes)
            }));
            return itemDTOs;
        }

        public List<EffetItemDTO> ConvertToEffetItemsDTOs(ICollection<EffetItem> effetItems)
        {
            List<EffetItem> _effetItems = effetItems.ToList();

            List<EffetItemDTO> effetItemsDTOs = new List<EffetItemDTO>();
            _effetItems.ForEach(s => effetItemsDTOs.Add(new EffetItemDTO(s)));
            return effetItemsDTOs;
        }

        public List<InventaireHeroDTO> ConvertToInventaireHeroDTOs(ICollection<InventaireHero> inventaireHeroes)
        {
            List<InventaireHero> _inventaireHeroes = inventaireHeroes.ToList();

            List<InventaireHeroDTO> inventaireHeroesDTOs = new List<InventaireHeroDTO>();
            _inventaireHeroes.ForEach(s => inventaireHeroesDTOs.Add(new InventaireHeroDTO(s)));
            return inventaireHeroesDTOs;
        }

        public List<MonstreDTO> ConvertToMonstresDTOs(ICollection<Monstre> monstres)
        {
            List<Monstre> _monstres = monstres.ToList();

            List<MonstreDTO> monstresDTOs = new List<MonstreDTO>();
            _monstres.ForEach(s => monstresDTOs.Add(new MonstreDTO(s)));
            return monstresDTOs;
        }

        public List<ObjetMondeDTO> ConvertToObjetMondeDTOs(ICollection<ObjetMonde> objetMondes)
        {
            List<ObjetMonde> _objetMondes = objetMondes.ToList();

            List<ObjetMondeDTO> objetMondesDTOS = new List<ObjetMondeDTO>();
            _objetMondes.ForEach(s => objetMondesDTOS.Add(new ObjetMondeDTO(s)));
            return objetMondesDTOS;
        }
    }
}