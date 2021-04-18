using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class MonstreDTO {

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
        public int StatDmgMin { get; set; }

        [DataMember]
        public int StatDmgMax { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int ImageId { get; set; }

        [DataMember]
        public virtual TileImgDTO Image {get; set;}

        [DataMember]
        public virtual MondeDTO Monde { get; set; }
    }
}