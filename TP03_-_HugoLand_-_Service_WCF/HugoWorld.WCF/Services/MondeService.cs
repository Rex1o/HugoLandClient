﻿using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IMondeService {
        public List<MondeDTO> ListWorlds()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                //return dbContext.Mondes
                //    .Include(x => x.Classes)
                //    .Include(x => x.Heros)
                //    .Include(x => x.Items)
                //    .Include(x => x.ObjetMondes)
                //    .Include(x => x.Monstres)
                //    .Select(m => new MondeDTO(m)).ToList();

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
    }
}