using System;
using System.Collections.Generic;
using Animater.Entities;
using Animater.Helpers;
using CocosSharp;

namespace Animater.Layers
{
    public class GameLayer : CCLayer
    {
        Ship ship;
        Ship enemy;

        List<Bullet> bullets;
        public GameLayer()
        {
            ship = new Ship();
            ship.PositionX = 100;
            ship.PositionY = 250;
            this.AddChild(ship);

            enemy = new Ship(rotation: 180);
            enemy.PositionX = 100;
            enemy.PositionY = 450;
            this.AddChild(enemy);

            bullets = new List<Bullet>();
            BulletFactory.Self.BulletCreated += HandleBulletCreated;

        }

        void HandleBulletCreated(Bullet newBullet)
        {
            AddChild(newBullet);
            bullets.Add(newBullet);
        }
    }
}
