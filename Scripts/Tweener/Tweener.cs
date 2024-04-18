using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EaseType
{
    Linear,
    InSine,
    OutSine,
    InOutSine,
    InQuad,
    OutQuad,
    InOutQuad,
    InCubic,
    OutCubic,
    InOutCubic,
    InQuart,
    OutQuart,
    InOutQuart,
    InQuint,
    OutQuint,
    InOutQuint,
    InExpo,
    OutExpo,
    InOutExpo,
    InCirc,
    OutCirc,
    InOutCirc,
    InElastic,
    OutElastic,
    InOutElastic,
    InBack,
    OutBack,
    InOutBack,
    InBounce,
    OutBounce,
    InOutBounce
}

public enum LoopType
{
    None,
    Incremental,
    Restart,
    Yoyo
}

public static class Tweener
{
    public static ActionTween MoveToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType,Action onComplete = null)
    {
        ActionTween moveToTargetObj = target.GetComponent<MoveToTarget>();
        
        if (moveToTargetObj == null)
        {
            moveToTargetObj = target.gameObject.AddComponent<MoveToTarget>();
        }
        else
        {
            moveToTargetObj.enabled = true;
        }

        TweenData data = new TweenData
        {
            target = target,
            from = target.position,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = onComplete
        };

        moveToTargetObj.SetTweenData(data);

        moveToTargetObj.enabled = true;

        return moveToTargetObj;
    }
}