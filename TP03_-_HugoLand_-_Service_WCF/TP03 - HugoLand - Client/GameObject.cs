using System.Drawing;

namespace HugoWorld {

    public abstract class GameObject {

        public abstract void Update(double gameTime, double elapsedTime);

        public abstract void Draw(Graphics graphics);
    }
}