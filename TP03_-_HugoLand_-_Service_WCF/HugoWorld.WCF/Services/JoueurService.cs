using HugoWorld.WCF.DTOs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using TP01_Library.Models;
namespace HugoWorld.WCF.Services {

    public partial class HugoLandService : IJoueurService
    {
        public string Connection(string p_Username, string p_Password)
        {
            using(HugoLandContext dbcontext = new HugoLandContext())
            {
                ObjectParameter message = new ObjectParameter("message", typeof(string));
                dbcontext.Connexion(p_Username, p_Password, message);
                return (Convert.ToString(message.Value));
            }
        }

        public List<HeroDTO> GetHeroesById(int p_Id)
        {
            using (var context = new HugoLandContext())
            {
                return context.Heros.Where(x => x.CompteJoueurId == p_Id).Select(m => new HeroDTO()
                {
                    Id = m.Id,
                    Niveau = m.Niveau,
                    Experience = m.Experience,
                    x = m.x,
                    y = m.y,
                    StatStr = m.StatStr,
                    StatDex = m.StatDex,
                    StatInt = m.StatInt,
                    StatVitalite = m.StatVitalite,
                    MondeId = m.MondeId,
                    ClasseId = m.ClasseId,
                    NomHero = m.NomHero,
                    EstConnecte = m.EstConnecte
                }).
                ToList();
            }
        }
    }
}