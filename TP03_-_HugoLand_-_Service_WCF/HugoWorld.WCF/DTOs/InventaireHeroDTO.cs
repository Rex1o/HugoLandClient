using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class InventaireHeroDTO {

        public InventaireHeroDTO() {
        }

        public InventaireHeroDTO(InventaireHero inventaireHero) {
            IdHero = inventaireHero.IdHero;
            ItemId = inventaireHero.ItemId;
            IdInventaireHero = inventaireHero.IdInventaireHero;
        }

        [DataMember]
        public int IdHero { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int IdInventaireHero { get; set; }
    }
}