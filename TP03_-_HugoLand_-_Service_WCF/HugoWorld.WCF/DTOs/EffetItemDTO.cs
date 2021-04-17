using System.Runtime.Serialization;

namespace HugoWorld.WCF.DTOs {

    [DataContract]
    public class EffetItemDTO {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int ValeurEffet { get; set; }
        [DataMember]
        public int TypeEffet { get; set; }

        [DataMember]
        public virtual ItemDTO Item { get; set; }
    }
}