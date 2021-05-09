using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
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
                dbContext.CompteJoueurs.Find(p_heroDTO.CompteJoueurId).Heros.Add(hero);
                dbContext.SaveChanges();
            }
        }

        public bool DeleteHeroById(int p_HeroId)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Hero hero = dbContext.Heros.Find(p_HeroId);

                if (hero == null)
                    return false;

                dbContext.Heros.Remove(hero);
                dbContext.SaveChanges();

                return true;
            }
        }

        public void SaveHeroPos(int id, int x, int y)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                bool isAdded = true;
                do
                {
                    Hero h = dbContext.Heros.Find(id);

                    h.x = x;
                    h.y = y;

                    dbContext.Entry(h).State = EntityState.Modified;
                    try
                    {
                        dbContext.SaveChanges();
                        isAdded = false;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        isAdded = true;
                    }
                } while (isAdded);
            }
        }

        public void ConnectDisconnectHeroById(int p_HeroId, bool p_State)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Hero h = dbContext.Heros.Find(p_HeroId);

                h.EstConnecte = p_State;
                dbContext.SaveChanges();
            }
        }

        public bool IsHeroAvailable(int p_HeroId)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Hero h = dbContext.Heros.Find(p_HeroId);

                if (h != null)
                {
                    if (h.EstConnecte)
                        return false;
                    else
                        return true;
                }

                return false;
            }
        }
        //Caller crissement souvent
        public List<HeroDTO> GetHerosInChunk(int[][] chunk, int mondeID)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                IJoueurService service = new HugoLandService();
                int TLX = chunk[0][0];
                int BRX = chunk[1][0];
                int TLY = chunk[0][1];
                int BRY = chunk[1][1];
                return service.ConvertToHerosDTO(context.Heros.Where(h => h.MondeId == mondeID && h.x >= TLX && h.x <= BRX && h.y >= TLY && h.y <= BRY && h.EstConnecte).ToList());
            }
        }

        public void ChangeHeroStats(int heroID, int? Integrity = null, int? Strenght = null, int? Vie = null)
        {
            Hero heroToChange;
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                bool isAdded = true;

                do
                {
                    heroToChange = dbContext.Heros.Where(x => x.Id == heroID).Single();

                    if (Integrity != null)
                    {
                        heroToChange.StatInt += (int)Integrity;
                    }
                    if (Strenght != null)
                    {
                        heroToChange.StatStr += (int)Strenght;
                    }
                    if (Vie != null)
                    {
                        heroToChange.Hp += (int)Vie;
                    }
                    dbContext.Entry(heroToChange).State = EntityState.Modified;
                    try
                    {
                        dbContext.SaveChanges();
                        isAdded = false;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        isAdded = true;
                    }
                } while (isAdded);
            }
        }

        public HeroDTO GetHeroByID(int heroID)
        {
            using (HugoLandContext context = new HugoLandContext())
            {
                return new HeroDTO(context.Heros.FirstOrDefault(x => x.Id == heroID));
            }
        }
        //En train d'être enlever
    }


}