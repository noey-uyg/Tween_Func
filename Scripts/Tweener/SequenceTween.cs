using System.Collections.Generic;
using System;

namespace TweenManager
{
    public class SequenceTween
    {
        private List<ActionTween> tweens = new List<ActionTween>();
        private Action onComplete;

        public SequenceTween(Action onComplete = null)
        {
            this.onComplete = onComplete;
        }

        public void AddTween(ActionTween tween)
        {
            tweens.Add(tween);
        }

        public void Play()
        {
            foreach (var tween in tweens)
            {
                tween.isCompleted = false;
            }

            PlayNextTween();
        }

        private void PlayNextTween()
        {
            if (tweens.Count == 0)
            {
                onComplete?.Invoke();
            }
            else
            {
                ActionTween currentTween = tweens[0];
                currentTween.isCompleted = true;
                currentTween.OnComplete += OnTweenComplete;
                currentTween.RunTween();
            }
        }

        private void OnTweenComplete()
        {
            tweens[0].isCompleted = false;
            tweens.RemoveAt(0);
            PlayNextTween();
        }
    }
}