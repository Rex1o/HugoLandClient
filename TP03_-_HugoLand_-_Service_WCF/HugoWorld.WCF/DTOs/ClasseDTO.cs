using System.Collections.Generic;
using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class ClasseDTO
    {
        public ClasseDTO()
        {
            
        }
        public ClasseDTO(Classe classe)
        {
            Id = classe.Id;
            Description = classe.Description;
            NomClasse = classe.NomClasse;
            StatBaseDex = classe.StatBaseDex;
            StatBaseInt = classe.StatBaseInt;
            StatBaseStr = classe.StatBaseStr;
            StatBaseVitalite = classe.StatBaseVitalite;
            MondeId = classe.MondeId;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Description { get; set; }
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
    }
}