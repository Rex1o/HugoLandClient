using HugoWorld_WCF.DTOs;
using System.Collections.Generic;
using System.ServiceModel;
using TP01_Library.Models;

namespace HugoWorld_WCF.Services {

    [ServiceContract]
    public interface IJoueurService {

        [OperationContract]
        string Connection(string p_Username, string p_Password);

        [OperationContract]
        void EditAccount(CompteJoueurDTO compteJoueurDTO);

        [OperationContract]
        List<HeroDTO> GetHeroesByAccountId(int p_Id);

        [OperationContract]
        CompteJoueurDTO GetAccountByName(string p_Username);

        [OperationContract]
        List<HeroDTO> ConvertToHerosDTO(ICollection<Hero> heroes);

        [OperationContract]
        List<ClasseDTO> ConvertToClassesDTO(ICollection<Classe> classes);
    }
}