using System.ServiceModel;
using HugoWorld.WCF.DTOs;
using System.Collections.Generic;

namespace HugoWorld.WCF.Services {

    [ServiceContract]
    public interface IMondeService {
        [OperationContract]
        List<MondeDTO> ListWorlds();
    }
}