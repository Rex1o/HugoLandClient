using HugoWorld_WCF.DTOs;
using System.ServiceModel;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IHeroService {

        [OperationContract]
        void AddHeroToDataBase(HeroDTO p_heroDTO);

        [OperationContract]
        void SaveHeroPos(int id, int x, int y);

        [OperationContract]
        bool DeleteHeroById(int p_HeroId);

        [OperationContract]
        void ConnectDisconnectHeroById(int p_HeroId, bool p_State);
    }
}