using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : IClasseService
    {
        public void AddClassToDataBase(int p_Str,int p_Dex, int p_Vit, int p_Int, int p_WId)
        {
            int a = 0;
            //using (HugoLandContext dbContext = new HugoLandContext())
            //{  
            //        dbContext.Classes.Add(new Classe()
            //        {
            //            NomClasse = p_name,
            //            Description = p_description,
            //            StatBaseStr = p_Str,
            //            StatBaseDex = p_Dex,
            //            StatBaseInt = p_Int,
            //            StatBaseVitalite = p_Vit,
            //            MondeId = p_WId
            //        });
            //        dbContext.SaveChanges();
            //}
        }
    }
}
