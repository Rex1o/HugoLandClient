using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HugoWorld_WCF.DTOs {

    [DataContract]
    public class CompteJoueurDTO {

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