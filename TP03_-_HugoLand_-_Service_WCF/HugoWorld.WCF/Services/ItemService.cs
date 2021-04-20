using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IItemService {

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