using HugoWorld_WCF.Services;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class ItemDTO {
        private readonly HugoLandService itemService = new HugoLandService();

        public ItemDTO()
        {
        }

        public ItemDTO(Item item)
        {
            Id = item.Id;
            Nom = item.Nom;
            Description = item.Description;
            x = item.x;
            y = item.y;
            MondeId = item.MondeId;
            ImageId = item.ImageId;
            IdHero = item.IdHero;
            RowVersion = item.RowVersion;
            
            if (item.Hero != null)
                Hero = new HeroDTO(item.Hero);
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? x { get; set; }

        [DataMember]
        public int? y { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int ImageId { get; set; }

        [DataMember]
        public int? IdHero { get; set; }
        [DataMember]
        public byte[] RowVersion { get; set; }

        [DataMember]
        public virtual List<EffetItemDTO> EffetsItems { get; set; }

        [DataMember]
        public virtual List<InventaireHeroDTO> InventaireHeroDTOs { get; set; }

        [DataMember]
        public virtual HeroDTO Hero { get; set; }

    }
}