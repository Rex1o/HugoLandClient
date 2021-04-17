﻿using System.Runtime.Serialization;

namespace HugoWorld.WCF.DTOs {

    [DataContract]
    public class ClasseDTO {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string NomClasse { get; set; }

        [DataMember]
        public int StatBaseStr { get; set; }

        [DataMember]
        public int StatBaseDex { get; set; }

        [DataMember]
        public int StatBaseInt { get; set; }

        [DataMember]
        public int StatBaseVitalite { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        //[DataMember]
        //public virtual MondeDTO Monde { get; set; }

        //[DataMember]
        //public virtual List<HeroDTO> Heros { get; set; }
    }
}