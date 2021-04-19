using HugoWorld_WCF.Services;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TP01_Library.Models;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class CompteJoueurDTO {
        private HugoLandService joueurService = new HugoLandService();
        public CompteJoueurDTO()
        {

        }
        public CompteJoueurDTO(CompteJoueur compteJoueur)
        {
            Id = compteJoueur.Id;
            NomJoueur = compteJoueur.NomJoueur;
            Prenom = compteJoueur.Prenom;
            Nom = compteJoueur.Nom;
            Courriel = compteJoueur.Courriel;
            TypeUtilisateur = compteJoueur.TypeUtilisateur;
            MotDePasseHash = compteJoueur.MotDePasseHash;
            Salt = compteJoueur.Salt;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string NomJoueur { get; set; }

        [DataMember]
        public string Courriel { get; set; }

        [DataMember]
        public string Prenom { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public int TypeUtilisateur { get; set; }

        // Utiles (?)

        [DataMember]
        public byte[] MotDePasseHash { get; set; }

        [DataMember]
        public System.Guid Salt { get; set; }

        [DataMember]
        public virtual List<HeroDTO> Heros { get; set; }
    }
}