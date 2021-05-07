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
    
    public partial class Hero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hero()
        {
            this.InventaireHeroes = new HashSet<InventaireHero>();
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public int CompteJoueurId { get; set; }
        public int Niveau { get; set; }
        public long Experience { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int StatStr { get; set; }
        public int StatDex { get; set; }
        public int StatInt { get; set; }
        public int StatVitalite { get; set; }
        public int MondeId { get; set; }
        public int ClasseId { get; set; }
        public string NomHero { get; set; }
        public bool EstConnecte { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual Classe Classe { get; set; }
        public virtual CompteJoueur CompteJoueur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventaireHero> InventaireHeroes { get; set; }
        public virtual Monde Monde { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
