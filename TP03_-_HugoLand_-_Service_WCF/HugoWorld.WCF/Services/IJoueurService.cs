using System.ServiceModel;
using HugoWorld.WCF.DTOs;
using System.Collections.Generic;
namespace HugoWorld.WCF.Services {

    [ServiceContract]
    public interface IJoueurService {
        string Connection(string p_Username, string p_Password);

        List<HeroDTO> GetHeroesById(int p_Id);

    }
}