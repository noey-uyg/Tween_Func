using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : ActionTween
{
    private Vector3 initialRotation;

    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);
        initialRotation = _target.eulerAngles;
    }

    protected override void UpdateTween(float easeV)
    {
        _target.eulerAngles = Vector3.Lerp(initialRotation, (Vector3)_to, easeV);
    }

}
