using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    public class TileImgDTO {

        [DataMember]
        public int ImageId { get; set; }

        [DataMember]
        public string Imageb64 { get; set; }
    }
}