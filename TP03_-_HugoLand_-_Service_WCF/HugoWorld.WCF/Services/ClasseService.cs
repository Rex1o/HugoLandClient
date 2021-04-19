using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;
using TP01_Library.Controllers;

namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : IClasseService
    {
        public void AddClassToDataBase(ClasseDTO classeDTO)
        {
            //using (HugoLandContext dbContext = new HugoLandContext())
            //{
            //    Classe classe = new Classe()
            //    {
            //        NomClasse = p_Name,
            //        Description = p_Description,
            //        StatBaseStr = p_Str,
            //        StatBaseDex = p_Dex,
            //        StatBaseInt = p_Int,
            //        StatBaseVitalite = p_Vit,
            //        MondeId = p_WId
            //    };
            //    dbContext.Entry(classe).State = System.Data.Entity.EntityState.Added;
            //    await dbContext.SaveChangesAsync();
            //}
            ClasseController classeController = new ClasseController();
            classeController.AjouterClasse(classeDTO.MondeId, classeDTO.NomClasse, classeDTO.Description, classeDTO.StatBaseStr, classeDTO.StatBaseDex, classeDTO.StatBaseInt, classeDTO.StatBaseVitalite);
        }
    }
}
