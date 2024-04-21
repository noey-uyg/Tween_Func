using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SequenceTween
{
    private List<ActionTween> tweens = new List<ActionTween>();
    private int currentTweenIdx = 0;
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
        currentTweenIdx = 0;

        foreach (var tween in tweens)
        {
            tween.isCompleted = false;
        }

        PlayNextTween();
    }

    private void PlayNextTween()
    {
        if(currentTweenIdx < tweens.Count)
        {
            ActionTween currentTween = tweens[currentTweenIdx];
            currentTween.isCompleted = true;
            currentTween.OnComplete += OnTweenComplete;
            currentTween.RunTween();
        }
        else
        {
            onComplete?.Invoke();
        }
    }

    private void OnTweenComplete()
    {
        currentTweenIdx++;
        PlayNextTween();
    }
}
