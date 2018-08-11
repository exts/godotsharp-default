using Godot;
using MenuPrep.App.Core;

namespace MenuPrep.App
{
    public class Splash : Node
    {
        private float _start = 1.5f;
        private float _counter;
        private ColorRect _fadeTransition;
        private AnimationPlayer _animationPlayer;

        public override void _Ready()
        {
            _fadeTransition = GetNode<ColorRect>("Fade");
            _fadeTransition.Show();
            
            _animationPlayer = _fadeTransition.GetNode<AnimationPlayer>("AnimationPlayer");
            _animationPlayer.Connect("animation_finished", this, nameof(SwitchScene));
        }

        public override void _Process(float delta)
        {
            if(_counter < _start)
            {
                _counter += delta;
            }

            if(_counter >= _start && !_animationPlayer.IsPlaying())
            {
                _animationPlayer.Play("Fade");
            }
        }

        public void SwitchScene(string name)
        {
            Global.Instance.LoadStartScene();
        }
    }
}