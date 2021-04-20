using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using HugoWorld_WCF.Models;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IMondeService {

        [OperationContract]
        List<MondeDTO> GetMondeDTOs();

        [OperationContract]
        List<MondeDTO> GetWorldsForSelection();
        [OperationContract]
        MondeDTO GetWorldByHero(HeroDTO p_Hero);
        [OperationContract]
        List<TileImport> GetChunk(int[] TopLeft, int[] BotRight, MondeDTO p_world);
    }
}