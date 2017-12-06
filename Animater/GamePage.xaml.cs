using System;
using System.Collections.Generic;
using CocosSharp;
using Xamarin.Forms;

namespace Animater
{
    public partial class GamePage : ContentPage
    {
        GameScene gameScene;

        public GamePage()
        {
            InitializeComponent();

            var gameView = new CocosSharpView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ViewCreated = HandleEventHandler
            };
            mainLayout.Children.Add(gameView);
        }

        void HandleEventHandler(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            if (gameView != null)
            {
                gameView.DesignResolution = new CCSizeI(App.ScreenWidth, App.ScreenHeight);
                // GameScene is the root of the CocosSharp rendering hierarchy:
                gameScene = new GameScene(gameView);
                // Starts CocosSharp:
                gameView.RunWithScene(gameScene);
            }
        }
    }
}
