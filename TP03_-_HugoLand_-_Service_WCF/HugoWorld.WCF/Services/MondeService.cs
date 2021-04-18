using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Linq;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IMondeService
    {
        public List<MondeDTO> ListWorlds()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Mondes.Select(m => new MondeDTO()
                {
                    Id = m.Id,
                    Description = m.Description,
                    LimiteX = m.LimiteX,
                    LimiteY = m.LimiteY
                }).ToList();
            }
        }
    }
}