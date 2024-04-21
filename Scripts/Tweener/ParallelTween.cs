using System.Collections.Generic;
using System;

namespace TweenManager
{
    public class ParallelTween
    {
        private List<ActionTween> tweens = new List<ActionTween>();
        private Action onComplete;

        public ParallelTween(Action onComplete = null)
        {
            this.onComplete = onComplete;
        }

        public void AddTween(ActionTween tween)
        {
            tweens.Add(tween);
            tween.OnComplete += OnTweenComplete;
        }

        public void Play()
        {
            foreach (var tween in tweens)
            {
                tween.RunTween();
            }
        }

        private void OnTweenComplete()
        {
            tweens.Clear();
            onComplete?.Invoke();
        }
    }
}