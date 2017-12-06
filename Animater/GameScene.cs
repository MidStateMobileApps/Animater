using System;
using CocosSharp;
using System.Threading;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Reflection;

namespace Animater
{
    public class GameScene : CCScene
    {
        CCParticleFireworks fireworks;
        CCParticleExplosion explosion;
        float yRatio = (float)App.ScreenHeight / 1165;
        float xRatio = (float)App.ScreenWidth / 675;
        CCLayer layer;
        CCPoint startLocation;
        CCProgressTimer timer;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            layer = new CCLayer();
            this.AddLayer(layer);

            fireworks = new CCParticleFireworks(CCPoint.Zero);
            explosion = new CCParticleExplosion(CCPoint.Zero);
            startLocation = new CCPoint(CCPoint.Zero);
            //In order to use a custom image for the particle
            //var assembly = this.GetType().GetTypeInfo().Assembly;
            //byte[] buffer;
           // var baseFile = "CocosDemo";

            //Set the color and position of Fireworks
            fireworks.StartColor = new CCColor4F(CCColor3B.Yellow);
            fireworks.Position = new CCPoint(App.ScreenWidth / 1.5f, App.ScreenHeight / 1.5f);
            layer.AddChild(fireworks);

            //Set the color and position of the Explosion
            explosion.StartColor = new CCColor4F(CCColor3B.Red);
            explosion.EndColor = new CCColor4F(CCColor3B.Black);
            explosion.Position = new CCPoint(App.ScreenWidth / 3, App.ScreenHeight / 3);
            layer.AddChild(explosion);

            Device.StartTimer(TimeSpan.FromMilliseconds(3000), HandleFunc);

            var touchEvent = new CCEventListenerTouchOneByOne();
            touchEvent.OnTouchBegan = (CCTouch arg1, CCEvent arg2) => {
                CCPoint newLocation = new CCPoint(arg1.LocationOnScreen.X * xRatio, App.ScreenHeight - (arg1.LocationOnScreen.Y * yRatio));
                startLocation = newLocation;
                return HandleFunc();
            };
            AddEventListener(touchEvent);
            //ResetExplosion();
            //Set a timer that will reset the explosion once it has finished

        }

        bool HandleFunc()
        {
            explosion.ResetSystem();

            layer.RemoveChild(explosion);

            var explodo = new CCParticleExplosion(CCPoint.Zero);

            explodo.StartColor = new CCColor4F(CCColor3B.Red);
            explodo.EndColor = new CCColor4F(CCColor3B.Black);
            explodo.Position = startLocation;
            layer.AddChild(explodo);

            return false;
        }

    }
}
