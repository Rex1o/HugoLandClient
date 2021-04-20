using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IMondeService {

        [OperationContract]
        List<MondeDTO> GetMondeDTOs();
    }
}