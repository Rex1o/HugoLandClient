using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class MondeDTO {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int LimiteX { get; set; }

        [DataMember]
        public int LimiteY { get; set; }

        [DataMember]
        public virtual List<ClasseDTO> Classes { get; set; }

        [DataMember]
        public virtual List<HeroDTO> Heros { get; set; }

        [DataMember]
        public virtual List<ItemDTO> Items { get; set; }

        [DataMember]
        public virtual List<MondeDTO> Monstres { get; set; }

        [DataMember]
        public virtual List<ObjetMondeDTO> ObjetMondes { get; set; }
    }
}