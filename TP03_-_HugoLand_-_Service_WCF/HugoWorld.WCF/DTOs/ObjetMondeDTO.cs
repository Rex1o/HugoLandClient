using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class ObjetMondeDTO {

        public ObjetMondeDTO()
        {
        }

        public ObjetMondeDTO(ObjetMonde objetMonde)
        {
            Id = objetMonde.Id;
            x = objetMonde.x;
            y = objetMonde.y;
            Description = objetMonde.Description;
            TypeObjet = objetMonde.TypeObjet;
            MondeId = objetMonde.MondeId;
            ImageId = objetMonde.ImageId;
            IsBlock = objetMonde.IsBlock;
            Monde = new MondeDTO(objetMonde.Monde);
        }

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
        public int ImageId { get; set; }

        [DataMember]
        public bool IsBlock { get; set; }

        [DataMember]
        public virtual MondeDTO Monde { get; set; }
    }
}