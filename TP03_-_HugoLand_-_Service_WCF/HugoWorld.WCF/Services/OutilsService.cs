using HugoWorld_WCF.DTOs;
using System;

namespace HugoWorld_WCF.Services {
    public partial class HugoLandService : IOutilsService {

        private CompteJoueurDTO _activeUser;
        private MondeDTO _mondeToEdit;

        public int RollD20()
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }

        public void SetActiveUser(CompteJoueurDTO user)
        {
            _activeUser = user;
        }

        public CompteJoueurDTO GetActiveUser()
        {
            return _activeUser;
        }

        public void SetMondeToEdit(MondeDTO m)
        {
            _mondeToEdit = m;
        }

        public MondeDTO GetMondeToEdit()
        {
            return _mondeToEdit;
        }
    }
}
