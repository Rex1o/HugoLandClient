using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IItemService {

        [OperationContract]
        List<ItemDTO> ConvertToItemsDTOs(ICollection<Item> items);

        [OperationContract]
        List<EffetItemDTO> ConvertToEffetItemsDTOs(ICollection<EffetItem> effetItems);

        [OperationContract]
        List<InventaireHeroDTO> ConvertToInventaireHeroDTOs(ICollection<InventaireHero> inventaireHeroes);

        [OperationContract]
        List<MonstreDTO> ConvertToMonstresDTOs(ICollection<Monstre> monstres);

        [OperationContract]
        List<ObjetMondeDTO> ConvertToObjetMondeDTOs(ICollection<ObjetMonde> objetMondes);
        [OperationContract]
        ItemDTO PickUpItem(ItemDTO item);
    }
}