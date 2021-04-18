using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class ObjetMondeDTO {

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int TypeObjet { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int? ImageId { get; set; }

        [DataMember]
        public virtual MondeDTO Monde { get; set; }
    }
}