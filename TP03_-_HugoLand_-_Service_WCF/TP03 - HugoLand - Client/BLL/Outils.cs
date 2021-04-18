using HugoLand.HL_Services;
using System;

namespace HugoWorld.BLL {
    public static class Outils {

        private static CompteJoueurDTO _activeUser;
        private static MondeDTO _mondeToEdit;

        public static int RollD20()
        {
            Random rnd = new Random();
            return rnd.Next(1, 21);
        }

        public static void SetActiveUser(CompteJoueurDTO user)
        {
            _activeUser = user;
        }

        public static CompteJoueurDTO GetActiveUser()
        {
            return _activeUser;
        }

        public static void SetMondeToEdit(MondeDTO m)
        {
            _mondeToEdit = m;
        }

        public static MondeDTO GetMondeToEdit()
        {
            return _mondeToEdit;
        }
    }
}
