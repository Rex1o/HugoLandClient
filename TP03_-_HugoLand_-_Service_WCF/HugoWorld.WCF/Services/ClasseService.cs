using HugoWorld_WCF.DTOs;
using TP01_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoWorld_WCF.Services
{
    public partial class HugoLandService : IClasseService
    {
        public bool AddClassToDatabase(ClasseDTO p_Class)
        {

            try
            {
                using (HugoLandContext dbcontext = new HugoLandContext())
                {
                    dbcontext.Classes.Add(new Classe()
                    {
                        NomClasse = p_Class.NomClasse,
                        Description = p_Class.Descrpition,
                        StatBaseStr = p_Class.StatBaseStr,
                        StatBaseInt = p_Class.StatBaseInt,
                        StatBaseVitalite = p_Class.StatBaseVitalite,
                        MondeId = p_Class.MondeId
                    });

                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
