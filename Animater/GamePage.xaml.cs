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
                ViewCreated = HandleViewCreated
            };
            mainLayout.Children.Add(gameView);
        }

        private void HandleViewCreated(object sender, EventArgs e)
        {
            var gameView = sender as CCGameView;
            var searchPaths = new List<string> { "Images" };
            if ( gameView != null)
            {
                gameView.ContentManager.SearchPaths = searchPaths;

                gameView.DesignResolution =
                    new CCSizeI(App.ScreenWidth, App.ScreenHeight);
                gameScene = new GameScene(gameView);
                gameView.RunWithScene(gameScene);                          
            }

        }
    }
}
