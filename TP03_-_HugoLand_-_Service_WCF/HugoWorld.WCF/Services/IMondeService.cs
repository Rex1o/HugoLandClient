using System.ServiceModel;
using HugoWorld.WCF.DTOs;
using System.Collections.Generic;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IMondeService {
        [OperationContract]
        List<MondeDTO> ListWorlds();
    }
}