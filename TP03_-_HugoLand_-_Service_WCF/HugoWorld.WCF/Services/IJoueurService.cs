﻿using HugoWorld.WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;

namespace HugoWorld.WCF.Services {

    [ServiceContract]
    public interface IJoueurService {

        [OperationContract]
        string Connection(string p_Username, string p_Password);

        [OperationContract]
        List<HeroDTO> GetHeroesByAccountId(int p_Id);

        [OperationContract]
        CompteJoueurDTO GetAccountByName(string p_Username);
    }
}