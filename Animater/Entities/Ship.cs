using System;
using System.Collections.Generic;
using Animater.Helpers;
using CocosSharp;

namespace Animater.Entities
{
    public class Ship : CCNode
    {
        CCSprite sprite;

        CCEventListenerTouchAllAtOnce touchListener;

        public Ship(Single rotation = 0) : base()
        {
            sprite = new CCSprite("ship.png");
            sprite.AnchorPoint = CCPoint.AnchorMiddle;
            this.AddChild(sprite);

            touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesMoved = HandleInput;
            AddEventListener(touchListener);

            Rotation = rotation;
            Schedule(FireBullet, interval: 0.5f);
        }

        void FireBullet(float val)
        {
            Bullet bullet = BulletFactory.Self.CreateNew();
            bullet.Position = this.Position;
            int velocity = 180;
            if ( !RotationY.Equals(0)){
                velocity *= -1;
            }
            bullet.VelocityY = velocity;
        }

        private void HandleInput(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0) 
            {
                CCTouch firstTouch = touches[0];
                var rect = this.sprite.BoundingBoxTransformedToWorld;
                if ( rect.ContainsPoint(firstTouch.Location))
                {
                    this.PositionX = firstTouch.Location.X;
                    this.PositionY = firstTouch.Location.Y;

                }
            }

        }
    }
}
