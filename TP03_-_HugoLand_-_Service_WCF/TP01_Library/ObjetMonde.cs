//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP01_Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class ObjetMonde
    {
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string Description { get; set; }
        public int TypeObjet { get; set; }
        public int MondeId { get; set; }
        public Nullable<int> ImageId { get; set; }
    
        public virtual Monde Monde { get; set; }

        public ObjetMonde Clone()
        {
            return (ObjetMonde)this.MemberwiseClone();
        }
    }
}
