using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class HeroDTO {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CompteJoueurId { get; set; }

        [DataMember]
        public long Niveau { get; set; }

        [DataMember]
        public long Experience { get; set; }

        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public int StatStr { get; set; }

        [DataMember]
        public int StatDex { get; set; }

        [DataMember]
        public int StatInt { get; set; }

        [DataMember]
        public int StatVitalite { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int ClasseId { get; set; }

        [DataMember]
        public string NomHero { get; set; }

        [DataMember]
        public bool EstConnecte { get; set; }
        [DataMember]
        public int ImageId { get; set; }

        [DataMember]
        public virtual ClasseDTO Classe { get; set; }

        [DataMember]
        public virtual CompteJoueurDTO CompteJoueur { get; set; }

        [DataMember]
        public virtual List<InventaireHeroDTO> InventaireHeros { get; set; }

        [DataMember]
        public virtual MondeDTO Monde { get; set; }

        [DataMember]
        public virtual List<ItemDTO> Items { get; set; }
           
        [DataMember]
        public virtual TileImgDTO Image { get; set; }
    }
}