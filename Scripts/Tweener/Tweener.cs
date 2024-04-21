using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EaseType
{
    Linear, // ������ �ӵ��� ��ȭ
    InSine, // ���� �� �ε巴�� ����
    OutSine, // ���� �� �ε巴�� ����
    InOutSine, //���۰� ���� �� �ε巴�� ���� �� ����
    InQuad, // ���ۺ��� ���� ����
    OutQuad, // ���� �� ���� ����
    InOutQuad, // ���۰� ���� ���� ���� �� ����
    InCubic, // ���� �� ������ ����
    OutCubic, // ���� �� ������ ����
    InOutCubic, // ���۰� ���� �� ������ ���� �� ����
    InQuart, // ���� �� �ſ� ������ ����
    OutQuart, // ���� �� �ſ� ������ ����
    InOutQuart, // ���۰� ���� �� ������ ���� �� ����
    InQuint, // ���� �� ���� õõ�� ����
    OutQuint, // ���� �� ���� õõ�� ����
    InOutQuint, // ���۰� ���� �� ���� õõ�� ���� �� ����
    InExpo, //���� �� �ް��� ����
    OutExpo, // ���� �� �ް��� ����
    InOutExpo, // ���۰� ���� �� �ް��� ���� �� ����
    InCirc, // ���� �� ���� ����
    OutCirc, // ���� �� ���� ����
    InOutCirc, // ���� �� �շ� �� ���� ���� �� ����
    InElastic, // ���� �� ź���� ������ ����
    OutElastic, // ���� �� ź���� ������ ����
    InOutElastic, // ���۰� ���� �� ź���� ������ ���� �� ����
    InBack, // ���� �� �з��� �� ����
    OutBack, // ���� �� �з��� �� ����
    InOutBack, // ���۰� ���� �� �з����� ���� �� ����
    InBounce, // ���� �� Ƣ��� ����
    OutBounce, // ���� �� Ƣ��� ����
    InOutBounce // ���۰� ���� �� �ٿ ���� �� ����
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