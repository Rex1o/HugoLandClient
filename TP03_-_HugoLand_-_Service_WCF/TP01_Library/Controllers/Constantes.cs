namespace TP01_Library.Controllers {

    public class Constantes {
        public const int MAX_LEVEL = 201;
        public const int DMG_PER_LEVEL = 50;
        public const int DMG_MIN_GAP = 100;
        public const int HP_PER_LEVEL = 1000;
        public const double MULTIPLE_HERO_STAT = 0.5d;

        public const int MAX_STAT = 100;

        public enum Types {
            Joueur = 0,
            Admin
        }
    }
}