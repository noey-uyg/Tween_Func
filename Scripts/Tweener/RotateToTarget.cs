using UnityEngine;

public class RotateToTarget : ActionTween
{
    private Vector3 initialRotation;

    private void Start()
    {
        initialRotation = _target.eulerAngles;
    }

    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);
        isCompleted = true;
    }

    protected override void UpdateTween(float easeV)
    {
        _target.eulerAngles = Vector3.Lerp(initialRotation, (Vector3)_to, easeV);
    }

    protected override object GetOriginalValue()
    {
        return initialRotation;
    }
}
