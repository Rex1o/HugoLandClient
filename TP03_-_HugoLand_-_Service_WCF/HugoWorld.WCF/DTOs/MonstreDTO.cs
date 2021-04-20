using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class MonstreDTO {

        public MonstreDTO()
        {
        }

        public MonstreDTO(Monstre monstre)
        {
            Id = monstre.Id;
            Nom = monstre.Nom;
            Niveau = monstre.Niveau;
            x = monstre.x;
            y = monstre.y;
            StatPV = monstre.StatPV;
            StatDmgMin = monstre.StatDmgMin;
            StatDmgMax = monstre.StatDmgMax;
            MondeId = monstre.MondeId;
            Monde = new MondeDTO(monstre.Monde);
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public int Niveau { get; set; }

        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public int StatPV { get; set; }

        [DataMember]
        public float StatDmgMin { get; set; }

        [DataMember]
        public float StatDmgMax { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int ImageId { get; set; }

        [DataMember]
        public virtual MondeDTO Monde { get; set; }
    }
}