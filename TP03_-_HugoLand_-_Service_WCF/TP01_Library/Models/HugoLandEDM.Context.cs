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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HugoLandContext : DbContext
    {
        public HugoLandContext()
            : base("name=HugoLandContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<CompteJoueur> CompteJoueurs { get; set; }
        public virtual DbSet<EffetItem> EffetItems { get; set; }
        public virtual DbSet<Hero> Heros { get; set; }
        public virtual DbSet<InventaireHero> InventaireHeroes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Monde> Mondes { get; set; }
        public virtual DbSet<Monstre> Monstres { get; set; }
        public virtual DbSet<ObjetMonde> ObjetMondes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual int Connexion(string pNomJoueur, string pMotDePasse, ObjectParameter message)
        {
            var pNomJoueurParameter = pNomJoueur != null ?
                new ObjectParameter("pNomJoueur", pNomJoueur) :
                new ObjectParameter("pNomJoueur", typeof(string));
    
            var pMotDePasseParameter = pMotDePasse != null ?
                new ObjectParameter("pMotDePasse", pMotDePasse) :
                new ObjectParameter("pMotDePasse", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Connexion", pNomJoueurParameter, pMotDePasseParameter, message);
        }
    
        public virtual int CreerCompteJoueur(string pNomUtilisateur, string pCourriel, string pPrenom, string pNom, Nullable<int> pTypeUtilisateur, string pMotDePasse, ObjectParameter message)
        {
            var pNomUtilisateurParameter = pNomUtilisateur != null ?
                new ObjectParameter("pNomUtilisateur", pNomUtilisateur) :
                new ObjectParameter("pNomUtilisateur", typeof(string));
    
            var pCourrielParameter = pCourriel != null ?
                new ObjectParameter("pCourriel", pCourriel) :
                new ObjectParameter("pCourriel", typeof(string));
    
            var pPrenomParameter = pPrenom != null ?
                new ObjectParameter("pPrenom", pPrenom) :
                new ObjectParameter("pPrenom", typeof(string));
    
            var pNomParameter = pNom != null ?
                new ObjectParameter("pNom", pNom) :
                new ObjectParameter("pNom", typeof(string));
    
            var pTypeUtilisateurParameter = pTypeUtilisateur.HasValue ?
                new ObjectParameter("pTypeUtilisateur", pTypeUtilisateur) :
                new ObjectParameter("pTypeUtilisateur", typeof(int));
    
            var pMotDePasseParameter = pMotDePasse != null ?
                new ObjectParameter("pMotDePasse", pMotDePasse) :
                new ObjectParameter("pMotDePasse", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreerCompteJoueur", pNomUtilisateurParameter, pCourrielParameter, pPrenomParameter, pNomParameter, pTypeUtilisateurParameter, pMotDePasseParameter, message);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
