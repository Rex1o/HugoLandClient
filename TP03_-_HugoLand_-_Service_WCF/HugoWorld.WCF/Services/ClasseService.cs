﻿using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    public partial class HugoLandService : IClasseService {

        public async void AddClassToDataBase(ClasseDTO classeDTO)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                Classe classe = new Classe()
                {
                    NomClasse = classeDTO.NomClasse,
                    Description = classeDTO.Description,
                    StatBaseStr = classeDTO.StatBaseStr,
                    StatBaseDex = classeDTO.StatBaseDex,
                    StatBaseInt = classeDTO.StatBaseInt,
                    StatBaseVitalite = classeDTO.StatBaseVitalite,
                    MondeId = classeDTO.MondeId
                };
                dbContext.Entry(classe).State = EntityState.Added;
                await dbContext.SaveChangesAsync();
            }
        }

        public async void EditClass(ClasseDTO classeDTO)
        {
            using(HugoLandContext dbContext = new HugoLandContext())
            {
                Classe classe = new Classe()
                {
                    NomClasse = classeDTO.NomClasse,
                    Description = classeDTO.Description,
                    StatBaseStr = classeDTO.StatBaseStr,
                    StatBaseDex = classeDTO.StatBaseDex,
                    StatBaseInt = classeDTO.StatBaseInt,
                    StatBaseVitalite = classeDTO.StatBaseVitalite
                };

                dbContext.Entry(classe).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }

        public List<ClasseDTO> GetClassDTOFromMap(int p_MapId)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Classes.Where(x => x.MondeId == p_MapId).ToList().Select(x => new ClasseDTO(x)).ToList();
            }
        }

        public List<ClasseDTO> GetClasseDTOs()
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                return dbContext.Classes.ToList().Select(x => new ClasseDTO(x)).ToList();
            }
        }
    }
}