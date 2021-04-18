using System.ServiceModel;
using System.Collections.Generic;
using HugoWorld_WCF.DTOs;

namespace HugoWorld_WCF.Services
{
    [ServiceContract]
    public interface IClasseService
    {
        [OperationContract]
        bool AddClassToDatabase(ClasseDTO p_Class);
    }
}
