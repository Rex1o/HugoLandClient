using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IItemService {
        // Items
        [OperationContract]
        void AddItem(string p_Nom, string p_Description, int p_X, int p_Y, int p_ImageId, int p_MondeId);
        [OperationContract]
        void DeleteItemById(int p_ItemId, HeroDTO p_Hero);
        [OperationContract]
        void EditItemQuantityById(int p_ItemId, int p_Quantite);
        [OperationContract]
        void AddRangeItems(List<ItemDTO> lstItems);
        [OperationContract]
        void RemoveRangeById(int p_ItemId);


        // EffetItems
        [OperationContract]
        void AddItemEffectById(int p_ItemId, int p_ValeurEffet, int p_TypeEffet);
        [OperationContract]
        void DeleteItemEffectById(int p_EffetItemId, int p_ItemId);
        [OperationContract]
        void EditItemEffectById(int p_ItemId, int p_EffetItemId, int p_ValeurEffet, int p_TypeEffet);

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
    }
}