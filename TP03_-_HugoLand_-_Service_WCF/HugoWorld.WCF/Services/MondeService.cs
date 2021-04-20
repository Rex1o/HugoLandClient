using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IMondeService {

        public List<MondeDTO> GetMondeDTOs()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                List<Monde> mondes = dbContext.Mondes
                                    .Include(x => x.Classes)
                                    .Include(x => x.Heros)
                                    .Include(x => x.Items)
                                    .Include(x => x.ObjetMondes)
                                    .Include(x => x.Monstres).ToList();

                List<MondeDTO> mondeDTOs = new List<MondeDTO>();
                mondes.ForEach(m => mondeDTOs.Add(new MondeDTO(m)
                {
                    Items = ConvertToItemsDTOs(m.Items),
                    Classes = ConvertToClassesDTO(m.Classes),
                    Heros = ConvertToHerosDTO(m.Heros),
                    Monstres = ConvertToMonstresDTOs(m.Monstres),
                    ObjetMondes = ConvertToObjetMondeDTOs(m.ObjetMondes)
                }));

                return mondeDTOs;
            }
        }

        public List<MondeDTO> GetWorldsForSelection()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Mondes.Select(m => new MondeDTO()
                {
                    Id = m.Id,
                   Description = m.Description
                }).ToList();
            }
        }
    }
}