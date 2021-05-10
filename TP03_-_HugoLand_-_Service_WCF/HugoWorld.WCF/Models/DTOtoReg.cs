using HugoWorld_WCF.DTOs;
using TP01_Library.Models;

namespace HugoWorld_WCF.Models {

    public static class DTOtoReg {

        public static Item DTOToItem(ItemDTO dto) {
            Item Toreturn = new Item() {
                Id = dto.Id,
                Nom = dto.Nom,
                Description = dto.Description,
                x = dto.x,
                y = dto.y,
                MondeId = dto.MondeId,
                IdHero = dto.IdHero,
                ImageId = dto.ImageId,
                RowVersion = dto.RowVersion
            };
            return Toreturn;
        }
    }
}