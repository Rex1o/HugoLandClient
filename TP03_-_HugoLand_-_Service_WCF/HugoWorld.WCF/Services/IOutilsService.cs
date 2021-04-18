using HugoWorld_WCF.DTOs;
using System.ServiceModel;

namespace HugoWorld_WCF.Services {
    [ServiceContract]
    public interface IOutilsService {
        [OperationContract]
        int RollD20();
        [OperationContract]
        void SetActiveUser(CompteJoueurDTO p_User);
        [OperationContract]
        CompteJoueurDTO GetActiveUser();
        [OperationContract]
        void SetMondeToEdit(MondeDTO p_Monde);
        [OperationContract]
        MondeDTO GetMondeToEdit();
    }
}
