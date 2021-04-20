﻿using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;


namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : IHeroService
    {
        public void AddHeroToDataBase(HeroDTO p_heroDTO)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Hero hero = new Hero()
                {
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
                dbContext.SaveChanges();
            }
        }

        public void SaveHeroPos(int id, int x, int y)
        {
            using(HugoLandContext dbContext = new HugoLandContext())
            {
                Hero h = dbContext.Heros.Find(id);

                h.x = x;
                h.y = y;
                dbContext.SaveChanges();
            }
        }
    }
}
