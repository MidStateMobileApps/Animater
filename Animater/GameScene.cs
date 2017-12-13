using System;
using CocosSharp;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Animater.Layers;

namespace Animater
{
    public class GameScene : CCScene
    {
        CCParticleFireworks fireworks;
        CCParticleExplosion explosion;
        CCPoint startLocation;
        float xRatio = (float)App.ScreenWidth / 675;
        float yRatio = (float)App.ScreenHeight / 1165;
        int XLoc = 60;
        int YLoc = 120;
        CCLayer layer;

        public GameScene(CCGameView gameView) : base(gameView)
        {
            layer = new GameLayer();
            this.AddLayer(layer);

            fireworks = new CCParticleFireworks(CCPoint.Zero);
            explosion = new CCParticleExplosion(CCPoint.Zero);
            startLocation = CCPoint.Zero;

            fireworks.StartColor = new CCColor4F(CCColor3B.Yellow);
            fireworks.Position = new CCPoint(App.ScreenWidth / 1.5f, App.ScreenHeight / 1.5f);
            layer.AddChild(fireworks);

            explosion.StartColor = new CCColor4F(CCColor3B.Red);
            explosion.EndColor = new CCColor4F(CCColor3B.Black);
            explosion.Position = new CCPoint(App.ScreenWidth / 3f, App.ScreenHeight / 3f);

            layer.AddChild(explosion);

            //Device.StartTimer(TimeSpan.FromMilliseconds(2000), HandleFunc);

            var touchEvent = new CCEventListenerTouchOneByOne();
            touchEvent.OnTouchBegan = (CCTouch arg1, CCEvent arg2) => {
                CCPoint newLocation = 
                    new CCPoint(arg1.LocationOnScreen.X * xRatio, App.ScreenHeight - arg1.LocationOnScreen.Y * yRatio);
                startLocation = newLocation;
                return HandleFunc();
            };
           // AddEventListener(touchEvent);

        }

        bool HandleFunc()
        {
            explosion.ResetSystem();
            var explodo = new CCParticleExplosion(CCPoint.Zero);
            explodo.StartColor = new CCColor4F(CCColor3B.Red);
            explodo.EndColor = new CCColor4F(CCColor3B.Black);
            //startLocation = new CCPoint(XLoc, YLoc);
           // XLoc += 10;
           /// YLoc += 10;
            explodo.Position = startLocation;

            layer.AddChild(explodo);
            return true;
        }
    }
}
