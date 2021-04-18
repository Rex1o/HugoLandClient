using System.ServiceModel;
using System.Collections.Generic;
using HugoWorld_WCF.DTOs;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IMondeService {
        [OperationContract]
        List<MondeDTO> ListWorlds();
    }
}