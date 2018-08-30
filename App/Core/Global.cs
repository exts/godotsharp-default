using System;
using Godot;
using System.Collections.Generic;

namespace MenuPrep.App.Core
{
    public class Global
    {
        private Viewport _root;
        public static Global Instance => _instance ?? (_instance = new Global());
        private static Global _instance;

        public enum Scenes
        {
            Splash,
            StartMenu
        }

        private Scenes _startScene = Scenes.StartMenu;
        private Dictionary<string, string> _scenePaths = new Dictionary<string, string>
        {
            {"Splash", "Splash.tscn"},
            {"StartMenu", "StartMenu.tscn"}
        };

        private string _sceneDirectory = "res://Data/Scenes";
        

        public void SetRootViewport(Viewport root)
        {
            _root = root;
        }

        public static Viewport Root()
        {
            return Instance._root ?? throw new Exception("The root viewport hasn't been set");
        }

        public static App App()
        {
            return Root().GetNode<App>("App");
        }
        
        public static Node CurrentScene()
        {
            return Root().GetChild(Root().GetChildCount() - 1);
        }

        public void LoadStartScene()
        {
            ChangeScene(_startScene);
        }

        public void ChangeScene(Scenes scene)
        {
            App().SwitchScene(GetScenePath(scene));
        }

        private string GetScenePath(Scenes scene)
        {
            var path = _scenePaths[scene.ToString("G")];
            return $"{_sceneDirectory}/{path}";
        }
        
    }
}