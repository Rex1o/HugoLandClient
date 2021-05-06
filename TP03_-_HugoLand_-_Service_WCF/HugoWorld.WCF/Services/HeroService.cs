﻿using HugoWorld_WCF.DTOs;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IHeroService {

        public void AddHeroToDataBase(HeroDTO p_heroDTO) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Hero hero = new Hero() {
                    CompteJoueurId = p_heroDTO.CompteJoueurId,
                    x = p_heroDTO.x,
                    y = p_heroDTO.y,
                    StatDex = p_heroDTO.StatDex,
                    StatInt = p_heroDTO.StatInt,
                    StatStr = p_heroDTO.StatStr,
                    StatVitalite = p_heroDTO.StatVitalite,
                    ClasseId = p_heroDTO.ClasseId,
                    Experience = p_heroDTO.Experience,
                    Niveau = p_heroDTO.Niveau,
                    NomHero = p_heroDTO.NomHero,
                    MondeId = p_heroDTO.MondeId
                };

                dbContext.Heros.Add(hero);
                dbContext.CompteJoueurs.Find(p_heroDTO.CompteJoueurId).Heros.Add(hero);
                dbContext.SaveChanges();
            }
        }

        public bool DeleteHeroById(int p_HeroId) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Hero hero = dbContext.Heros.Find(p_HeroId);

                if (hero == null)
                    return false;

                dbContext.Heros.Remove(hero);
                dbContext.SaveChanges();

                return true;
            }
        }

        public void SaveHeroPos(int id, int x, int y) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Hero h = dbContext.Heros.Find(id);

                h.x = x;
                h.y = y;
                dbContext.SaveChanges();
            }
        }

        public void ConnectDisconnectHeroById(int p_HeroId, bool p_State) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Hero h = dbContext.Heros.Find(p_HeroId);

                h.EstConnecte = p_State;
                dbContext.SaveChanges();
            }
        }

        public bool IsHeroAvailable(int p_HeroId) {
            using (HugoLandContext dbContext = new HugoLandContext()) {
                Hero h = dbContext.Heros.Find(p_HeroId);

                if (h != null) {
                    if (h.EstConnecte)
                        return true;
                    else
                        return false;
                }

                return false;
            }
        }
    }
}