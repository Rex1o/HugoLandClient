using HugoWorld_WCF.Services;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class HeroDTO {
        private readonly HugoLandService joueurService = new HugoLandService();

        public HeroDTO()
        {
        }

        public HeroDTO(Hero hero)
        {
            Id = hero.Id;
            NomHero = hero.NomHero;
            CompteJoueurId = hero.CompteJoueurId;
            Niveau = hero.Niveau;
            Experience = hero.Experience;
            x = hero.x;
            y = hero.y;
            StatStr = hero.StatStr;
            StatDex = hero.StatDex;
            StatInt = hero.StatInt;
            StatVitalite = hero.StatVitalite;
            MondeId = hero.MondeId;
            ClasseId = hero.ClasseId;
            EstConnecte = hero.EstConnecte;

            Monde = new MondeDTO(hero.Monde);
            Classe = new ClasseDTO(hero.Classe);
            CompteJoueur = new CompteJoueurDTO(hero.CompteJoueur);
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CompteJoueurId { get; set; }

        [DataMember]
        public int Niveau { get; set; }

        [DataMember]
        public long Experience { get; set; }

        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public int StatStr { get; set; }

        [DataMember]
        public int StatDex { get; set; }

        [DataMember]
        public int StatInt { get; set; }

        [DataMember]
        public int StatVitalite { get; set; }

        [DataMember]
        public int MondeId { get; set; }

        [DataMember]
        public int ClasseId { get; set; }

        [DataMember]
        public string NomHero { get; set; }

        [DataMember]
        public bool EstConnecte { get; set; }

        [DataMember]
        public virtual ClasseDTO Classe { get; set; }

        [DataMember]
        public virtual CompteJoueurDTO CompteJoueur { get; set; }

        [DataMember]
        public virtual List<InventaireHeroDTO> InventaireHeros { get; set; }

        [DataMember]
        public virtual MondeDTO Monde { get; set; }

        [DataMember]
        public virtual List<ItemDTO> Items { get; set; }

    }
}