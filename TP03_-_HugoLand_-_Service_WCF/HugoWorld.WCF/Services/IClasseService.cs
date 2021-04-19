using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IClasseService {
        [OperationContract]
        void AddClassToDataBase(ClasseDTO classeDTO);
        [OperationContract]
        List<ClasseDTO> GetClasseDTOs(); 
    }
}