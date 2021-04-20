using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;


namespace HugoWorld_WCF.Services
{
    [ServiceContract]
    public interface IHeroService
    {
        [OperationContract]
        void AddHeroToDataBase(HeroDTO p_heroDTO);

        [OperationContract]
        void SaveHeroPos(int id, int x, int y);
    }
}
