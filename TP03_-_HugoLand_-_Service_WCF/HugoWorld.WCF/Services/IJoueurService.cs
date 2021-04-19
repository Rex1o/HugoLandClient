using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IJoueurService {

        [OperationContract]
        string Connection(string p_Username, string p_Password);

        [OperationContract]
        List<HeroDTO> GetHeroesByAccountId(int p_Id);

        [OperationContract]
        CompteJoueurDTO GetAccountByName(string p_Username);
        [OperationContract]
        HeroDTO GetHeroById(int p_Id);
    }
}