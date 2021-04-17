using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HugoWorld.WCF.DTOs {

    [DataContract]
    public class ItemDTO {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }
        [DataMember]
        public int MondeId { get; set; }
        [DataMember]
        public int? ImageId { get; set; }
        [DataMember]
        public int? IdHero { get; set; }
        [DataMember]
        public virtual List<EffetItemDTO> EffetsItems { get; set; }
        [DataMember]
        public virtual List<InventaireHeroDTO> InventaireHeroDTOs { get; set; }
        [DataMember]
        public virtual HeroDTO Hero { get; set; }
        [DataMember]
        public virtual MondeDTO Monde { get; set; }

    }
}