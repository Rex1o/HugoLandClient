using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : IClasseService
    {
        public void AddClassToDataBase(string p_Description, string p_Name, int p_Str,int p_Dex, int p_Vit, int p_Int, int p_WId)
        {
            using (HugoLandContext dbContext = new HugoLandContext())
            {
                dbContext.Classes.Add(new Classe()
                {
                    NomClasse = p_Name,
                    Description = p_Description,
                    StatBaseStr = p_Str,
                    StatBaseDex = p_Dex,
                    StatBaseInt = p_Int,
                    StatBaseVitalite = p_Vit,
                    MondeId = p_WId
                });
                dbContext.SaveChanges();
            }
        }
    }
}
