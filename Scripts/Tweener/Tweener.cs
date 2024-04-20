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
    public static ActionTween MoveToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType,Action onComplete = null)
    {
        ActionTween moveToTargetObj = !target.GetComponent<MoveToTarget>()
            ? target.gameObject.AddComponent<MoveToTarget>()
            : target.GetComponent<MoveToTarget>();

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = () =>
            {
                moveToTargetObj.enabled = false;
            }
        };

        moveToTargetObj.SetTweenData(data);

        moveToTargetObj.enabled = true;

        return moveToTargetObj;
    }

    public static ActionTween RotateToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween rotateToTargetObj = !target.GetComponent<RotateToTarget>() 
            ? target.gameObject.AddComponent<RotateToTarget>()
            : target.GetComponent<RotateToTarget>();

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = () =>
            {
                rotateToTargetObj.enabled = false;
            }
        };

        rotateToTargetObj.SetTweenData(data);

        rotateToTargetObj.enabled = true;

        return rotateToTargetObj;
    }

    public static ActionTween ScaleToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween scaleToTargetObj = !target.GetComponent<ScaleToTarget>()
            ? target.gameObject.AddComponent<ScaleToTarget>()
            : target.GetComponent<ScaleToTarget>();

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = () =>
            {
                scaleToTargetObj.enabled = false;
            }
        };

        scaleToTargetObj.SetTweenData(data);

        scaleToTargetObj.enabled = true;

        return scaleToTargetObj;
    }

    public static ActionTween ColorToTarget(Transform target, Color to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween colorToTargetObj = !target.GetComponent<ColorToTarget>()
            ? target.gameObject.AddComponent<ColorToTarget>()
            : target.GetComponent<ColorToTarget>();

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = () =>
            {
                colorToTargetObj.enabled = false;
            }
        };

        colorToTargetObj.SetTweenData(data);

        colorToTargetObj.enabled = true;

        return colorToTargetObj;
    }


    public static ActionTween AlphaToTarget(Transform target, float toAlpha, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween alphaToTargetObj = !target.GetComponent<AlphaToTarget>()
            ? target.gameObject.AddComponent<AlphaToTarget>()
            : target.GetComponent<AlphaToTarget>();

        TweenData data = new()
        {
            target = target,
            to = toAlpha,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = () =>
            {
                alphaToTargetObj.enabled = false;
            }
        };

        alphaToTargetObj.SetTweenData(data);

        alphaToTargetObj.enabled = true;

        return alphaToTargetObj;
    }
}