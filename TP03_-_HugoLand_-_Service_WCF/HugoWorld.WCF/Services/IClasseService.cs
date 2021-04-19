using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services
{
    [ServiceContract]
    public interface IClasseService
    {
        [OperationContract]
        void AddClassToDataBase(string p_Description, string p_Name, int p_Str, int p_Dex, int p_Vit, int p_Int, int p_WId);
    }
}
