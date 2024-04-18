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
        ActionTween moveToTargetObj = target.GetComponent<MoveToTarget>();
        
        if (moveToTargetObj == null)
        {
            moveToTargetObj = target.gameObject.AddComponent<MoveToTarget>();
        }
        else
        {
            moveToTargetObj.enabled = true;
        }

        TweenData data = new()
        {
            target = target,
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

    public static ActionTween RotateToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween rotateToTargetObj = target.GetComponent<RotateToTarget>();

        if (rotateToTargetObj == null)
        {
            rotateToTargetObj = target.gameObject.AddComponent<RotateToTarget>();
        }
        else
        {
            rotateToTargetObj.enabled = true;
        }

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = onComplete
        };

        rotateToTargetObj.SetTweenData(data);

        rotateToTargetObj.enabled = true;

        return rotateToTargetObj;
    }

    public static ActionTween ScaleToTarget(Transform target, Vector3 to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween scaleToTargetObj = target.GetComponent<ScaleToTarget>();

        if (scaleToTargetObj == null)
        {
            scaleToTargetObj = target.gameObject.AddComponent<ScaleToTarget>();
        }
        else
        {
            scaleToTargetObj.enabled = true;
        }

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = onComplete
        };

        scaleToTargetObj.SetTweenData(data);

        scaleToTargetObj.enabled = true;

        return scaleToTargetObj;
    }

    public static ActionTween ColorToTarget(Transform target, Color to, float duration, EaseType easeType, LoopType loopType, Action onComplete = null)
    {
        ActionTween colorToTargetObj = target.GetComponent<ColorToTarget>();

        if (colorToTargetObj == null)
        {
            colorToTargetObj = target.gameObject.AddComponent<ColorToTarget>();
        }
        else
        {
            colorToTargetObj.enabled = true;
        }

        TweenData data = new()
        {
            target = target,
            to = to,
            duration = duration,
            easeType = easeType,
            loopType = loopType,
            OnComplete = onComplete
        };

        colorToTargetObj.SetTweenData(data);

        colorToTargetObj.enabled = true;

        return colorToTargetObj;
    }
}