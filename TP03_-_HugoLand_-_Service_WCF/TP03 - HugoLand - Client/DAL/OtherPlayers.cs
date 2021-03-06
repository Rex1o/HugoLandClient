using HugoWorld;
using HugoWorld_Client.HL_Services;
using System.Collections.Generic;
using System.Drawing;
using static HugoWorld.World;

namespace HugoWorld_Client.DAL {

    public class OtherPlayers {
        public HeroDTO Hero;
        public Point _heroPosition;
        public Sprite _heroSprite;
        public bool _heroSpriteAnimating;
        public bool _heroSpriteFighting;
        public double _startFightTime = -1.0;
        public PointF _heroDestination;
        public HeroDirection _direction;
        public bool isDead = false;
        public List<textPopup> _popups = new List<textPopup>();

        public OtherPlayers() {
        }
    }
}