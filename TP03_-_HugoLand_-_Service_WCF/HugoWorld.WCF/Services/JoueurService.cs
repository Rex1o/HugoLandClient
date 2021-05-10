using HugoWorld_WCF.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IJoueurService {

        public string Connection(string p_Username, string p_Password) {
            using (HugoLandContext dbcontext = new HugoLandContext()) {
                ObjectParameter message = new ObjectParameter("message", typeof(string));
                dbcontext.Connexion(p_Username, p_Password, message);
                return (Convert.ToString(message.Value));
            }
        }

        public List<HeroDTO> GetHeroesByAccountId(int p_Id) {
            using (HugoLandContext context = new HugoLandContext()) {
                return ConvertToHerosDTO(context.CompteJoueurs.Find(p_Id)?.Heros.ToList());
            }
        }

        public CompteJoueurDTO GetAccountByName(string p_Username) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                CompteJoueur compteJoueur = dbContext.CompteJoueurs
                    .Include(x => x.Heros)
                    .FirstOrDefault(x => x.NomJoueur.StartsWith(p_Username));

                if (compteJoueur != null) {
                    CompteJoueurDTO compteJoueurDTO = new CompteJoueurDTO(compteJoueur) {
                        Heros = ConvertToHerosDTO(compteJoueur.Heros)
                    };

                    return compteJoueurDTO;
                }

                return null;
            }
        }

        public List<HeroDTO> ConvertToHerosDTO(ICollection<Hero> heroes) {
            List<Hero> _heroes = heroes.ToList();

            List<HeroDTO> heroDTOs = new List<HeroDTO>();
            _heroes.ForEach(h => heroDTOs.Add(new HeroDTO(h)));
            return heroDTOs;
        }

        public List<ClasseDTO> ConvertToClassesDTO(ICollection<Classe> classes) {
            List<Classe> _classes = classes.ToList();

            List<ClasseDTO> classeDTOs = new List<ClasseDTO>();
            _classes.ForEach(s => classeDTOs.Add(new ClasseDTO(s)));
            return classeDTOs;
        }

        public async void EditAccount(CompteJoueurDTO compteJoueurDTO) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                CompteJoueur compteJoueur = dbContext.CompteJoueurs.Find(compteJoueurDTO.Id);
                compteJoueur.Courriel = compteJoueurDTO.Courriel;
                compteJoueur.NomJoueur = compteJoueurDTO.NomJoueur;
                compteJoueur.Nom = compteJoueurDTO.Nom;
                compteJoueur.Prenom = compteJoueurDTO.Prenom;

                dbContext.Entry(compteJoueur).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}