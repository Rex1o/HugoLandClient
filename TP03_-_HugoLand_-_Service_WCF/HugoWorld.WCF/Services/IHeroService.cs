using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace HugoWorld_WCF.Services
{

    [ServiceContract]
    public interface IHeroService
    {

        [OperationContract]
        void AddHeroToDataBase(HeroDTO p_heroDTO);

        [OperationContract]
        void SaveHeroPos(int id, int x, int y);

        [OperationContract]
        bool DeleteHeroById(int p_HeroId);

        [OperationContract]
        void ConnectDisconnectHeroById(int p_HeroId, bool p_State);

        [OperationContract]
        bool IsHeroAvailable(int p_HeroId);

        [OperationContract]
        List<HeroDTO> GetHerosInChunk(int[][] chunk, int mondeID);

        [OperationContract]
        HeroDTO GetHeroByID(int heroID);

        [OperationContract]
        void ChangeHeroStats(int heroID, int? Integrity = null, int? Strenght = null, int? Vie = null, long? xp = null);

        [OperationContract]
        void SetHeroStats(int heroID, int? Integrity = null, int? Strenght = null, int? Vie = null);
    }
}