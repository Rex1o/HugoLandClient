using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class InventaireHeroDTO {

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