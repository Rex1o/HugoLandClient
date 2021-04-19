using HugoWorld_WCF.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IJoueurService {

        public string Connection(string p_Username, string p_Password)
        {
            using (HugoLandContext dbcontext = new HugoLandContext())
            {
                ObjectParameter message = new ObjectParameter("message", typeof(string));
                dbcontext.Connexion(p_Username, p_Password, message);
                return (Convert.ToString(message.Value));
            }
        }

        public List<HeroDTO> GetHeroesByAccountId(int p_Id)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                //return context.CompteJoueurs
                //    .Find(p_Id)?.Heros
                //    .Select(m => new HeroDTO()
                //    {
                //        Id = m.Id,
                //        Niveau = m.Niveau,
                //        Experience = m.Experience,
                //        x = m.x,
                //        y = m.y,
                //        StatStr = m.StatStr,
                //        StatDex = m.StatDex,
                //        StatInt = m.StatInt,
                //        StatVitalite = m.StatVitalite,
                //        MondeId = m.MondeId,
                //        ClasseId = m.ClasseId,
                //        NomHero = m.NomHero,
                //        EstConnecte = m.EstConnecte
                //    }).
                //ToList();

                return context.CompteJoueurs
                    .Find(p_Id)?.Heros
                    .Select(m => new HeroDTO(m))
                    .ToList();
            }
        }

        public CompteJoueurDTO GetAccountByName(string p_Username)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                CompteJoueur compteJoueur = dbContext.CompteJoueurs
                    .Include(x => x.Heros)
                    .FirstOrDefault(x => x.NomJoueur.StartsWith(p_Username));

                if (compteJoueur != null)
                {
                    //List<HeroDTO> heroDTOs = GetHeroesByAccountId(compteJoueur.Id);
                    //CompteJoueurDTO compteJoueurDTO = new CompteJoueurDTO()
                    //{
                    //    Id = compteJoueur.Id,
                    //    NomJoueur = compteJoueur.NomJoueur,
                    //    Courriel = compteJoueur.Courriel,
                    //    Prenom = compteJoueur.Prenom,
                    //    Nom = compteJoueur.Nom,
                    //    TypeUtilisateur = compteJoueur.TypeUtilisateur,
                    //    Heros = heroDTOs
                    //};
                    //return compteJoueurDTO;
                    CompteJoueurDTO compteJoueurDTO = new CompteJoueurDTO(compteJoueur)
                    {
                        Heros = ConvertToHerosDTO(compteJoueur.Heros)
                    };

                    return compteJoueurDTO;
                }

                return null;
            }
        }

        public HeroDTO GetHeroById(int p_Id)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                //dbContext.Heros
                //   .Find(p_Id)
            }
            throw new NotImplementedException();
        }

        public List<HeroDTO> ConvertToHerosDTO(ICollection<Hero> heroes)
        {
            List<Hero> _heroes = heroes.ToList();

            List<HeroDTO> heroDTOs = new List<HeroDTO>();
            _heroes.ForEach(h => heroDTOs.Add(new HeroDTO(h)
            {
                InventaireHeros = ConvertToInventaireHeroDTOs(h.InventaireHeroes),
                Items = ConvertToItemsDTOs(h.Items)
            }));
            return heroDTOs;
        }

        public List<ClasseDTO> ConvertToClassesDTO(ICollection<Classe> classes)
        {
            List<Classe> _classes = classes.ToList();

            List<ClasseDTO> classeDTOs = new List<ClasseDTO>();
            _classes.ForEach(s => classeDTOs.Add(new ClasseDTO(s)));
            return classeDTOs;
        }
    }
}