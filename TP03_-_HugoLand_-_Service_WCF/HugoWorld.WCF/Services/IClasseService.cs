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
        [OperationContract]
        void EditClass(ClasseDTO classeDTO);
        [OperationContract]
        List<ClasseDTO> GetClassDTOFromMap(int p_MapId);
        [OperationContract]
        void DeleteClass(ClasseDTO classeDTO);
    }
}