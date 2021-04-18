using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HugoWorld_WCF.DTOs
{
    public class TileImgDTO
    {
        [DataMember]
        public int ImageId { get; set; }
        [DataMember]
        public string Imageb64 { get; set; }
    }
}
