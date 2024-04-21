using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EaseType
{
    Linear, // 일정한 속도로 변화
    InSine, // 시작 시 부드럽게 가속
    OutSine, // 종료 시 부드럽게 감속
    InOutSine, //시작과 종료 시 부드럽게 가속 및 감속
    InQuad, // 시작부터 점점 가속
    OutQuad, // 종료 시 점점 감속
    InOutQuad, // 시작과 종료 점점 가속 및 감속
    InCubic, // 시작 시 느리게 가속
    OutCubic, // 종료 시 느리게 감속
    InOutCubic, // 시작과 종료 시 느리게 가속 및 감속
    InQuart, // 시작 시 매우 느리게 가속
    OutQuart, // 종료 시 매우 느리게 감속
    InOutQuart, // 시작과 종료 시 느리게 가속 및 감속
    InQuint, // 시작 시 아주 천천히 가속
    OutQuint, // 종료 시 아주 천천히 감속
    InOutQuint, // 시작과 종료 시 아주 천천히 가속 및 감속
    InExpo, //종료 시 급격히 가속
    OutExpo, // 종료 시 급격히 감속
    InOutExpo, // 시작과 종료 시 급격히 가속 및 감속
    InCirc, // 시작 시 점차 가속
    OutCirc, // 종료 시 점차 감속
    InOutCirc, // 시작 과 죵료 시 점차 가속 및 감속
    InElastic, // 시작 시 탄성을 가지며 가속
    OutElastic, // 종료 시 탄성을 가지며 감속
    InOutElastic, // 시작과 종료 시 탄성을 가지며 가속 및 감속
    InBack, // 시작 시 밀려나 듯 가속
    OutBack, // 종료 시 밀려나 듯 감속
    InOutBack, // 시작과 종료 시 밀려나듯 가속 및 감속
    InBounce, // 시작 시 튀기듯 가속
    OutBounce, // 종료 시 튀기듯 감속
    InOutBounce // 시작과 종료 시 바운스 가속 및 감속
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
    public static ActionTween MoveToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, float delay = 0f, Action onComplete = null)
    {
        ActionTween moveToTargetObj = CreateTweenObject<MoveToTarget>(target);

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            delayTimer = delay,
            OnComplete = () =>
            {
                moveToTargetObj.enabled = false;
                onComplete?.Invoke();
            }
        };

        SetupTween(moveToTargetObj, data);

        return moveToTargetObj;
    }

    public static ActionTween RotateToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, float delay = 0f, Action onComplete = null)
    {
        ActionTween rotateToTargetObj = CreateTweenObject<RotateToTarget>(target);

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            delayTimer = delay,
            OnComplete = () =>
            {
                rotateToTargetObj.enabled = false;
                onComplete?.Invoke();
            }
        };

        SetupTween(rotateToTargetObj, data);

        return rotateToTargetObj;
    }

    public static ActionTween ScaleToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, float delay = 0f, Action onComplete = null)
    {
        ActionTween scaleToTargetObj = CreateTweenObject<ScaleToTarget>(target);
        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            delayTimer = delay,
            OnComplete = () =>
            {
                scaleToTargetObj.enabled = false;
                onComplete?.Invoke();
            }
        };

        SetupTween(scaleToTargetObj, data);

        return scaleToTargetObj;
    }

    public static ActionTween ColorToTarget(Transform target, Color to, float duration, EaseType easeType, LoopType loopType, float delay = 0f, Action onComplete = null)
    {
        ActionTween colorToTargetObj = CreateTweenObject<ColorToTarget>(target);

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            delayTimer = delay,
            OnComplete = () =>
            {
                colorToTargetObj.enabled = false;
                onComplete?.Invoke();
            }
        };

        SetupTween(colorToTargetObj, data);

        return colorToTargetObj;
    }


    public static ActionTween AlphaToTarget(Transform target, float toAlpha, float duration, EaseType easeType, LoopType loopType, float delay = 0f, Action onComplete = null)
    {
        ActionTween alphaToTargetObj = CreateTweenObject<AlphaToTarget>(target);

        TweenData data = new()
        {
            target = target,
            to = toAlpha,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            delayTimer = delay,
            OnComplete = () =>
            {
                alphaToTargetObj.enabled = false;
                onComplete?.Invoke();
            }
        };

        SetupTween(alphaToTargetObj, data);

        return alphaToTargetObj;
    }

    private static T CreateTweenObject<T>(Transform target) where T : ActionTween
    {
        T tweenObj = target.GetComponent<T>();
        if (tweenObj == null)
        {
            tweenObj = target.gameObject.AddComponent<T>();
        }
        return tweenObj;
    }

    private static void SetupTween(ActionTween tweenObj, TweenData data)
    {
        tweenObj.SetTweenData(data);
        tweenObj.enabled = true;
    }
}