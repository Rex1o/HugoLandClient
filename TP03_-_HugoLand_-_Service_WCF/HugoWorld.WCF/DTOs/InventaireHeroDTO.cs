using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class InventaireHeroDTO {
        public InventaireHeroDTO()
        {

        }

        public InventaireHeroDTO(InventaireHero inventaireHero)
        {
            IdHero = inventaireHero.IdHero;
            ItemId = inventaireHero.ItemId;
            IdInventaireHero = inventaireHero.IdInventaireHero;
            Quantite = inventaireHero.Quantite;
            Hero = new HeroDTO(inventaireHero.Hero);
            Item = new ItemDTO(inventaireHero.Item);
        }

        [DataMember]
        public int IdHero { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int IdInventaireHero { get; set; }

        [DataMember]
        public int Quantite { get; set; }

        [DataMember]
        public virtual HeroDTO Hero { get; set; }

        [DataMember]
        public virtual ItemDTO Item { get; set; }
    }
}