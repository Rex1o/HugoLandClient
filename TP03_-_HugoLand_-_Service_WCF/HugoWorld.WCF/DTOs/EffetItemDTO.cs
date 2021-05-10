using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class EffetItemDTO {

        public EffetItemDTO() {
        }

        public EffetItemDTO(EffetItem effetItem) {
            Id = effetItem.Id;
            ItemId = effetItem.ItemId;
            ValeurEffet = effetItem.ValeurEffet;
            TypeEffet = effetItem.TypeEffet;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ValeurEffet { get; set; }

        [DataMember]
        public int TypeEffet { get; set; }

        [DataMember]
        public int ItemId { get; set; }
    }
}