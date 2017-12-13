using System;
using Animater.Entities;

namespace Animater.Helpers
{
    public class BulletFactory
    {
        static Lazy<BulletFactory> self =
            new Lazy<BulletFactory>(() => new BulletFactory());

        public static BulletFactory Self
        {
            get { return self.Value; }
        }
        
        private BulletFactory()
        {
        }

        public event Action<Bullet> BulletCreated;

        public Bullet CreateNew()
        {
            Bullet newBullet = new Bullet();
            if (BulletCreated != null)
            {
                BulletCreated(newBullet);
            }
            return newBullet;
        }
    }
}
