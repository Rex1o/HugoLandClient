//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP01_Library.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompteJoueur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompteJoueur()
        {
            this.Heros = new HashSet<Hero>();
        }
    
        public int Id { get; set; }
        public string NomJoueur { get; set; }
        public string Courriel { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int TypeUtilisateur { get; set; }
        public byte[] MotDePasseHash { get; set; }
        public System.Guid Salt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hero> Heros { get; set; }
    }
}