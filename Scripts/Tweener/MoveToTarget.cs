using UnityEngine;

public class MoveToTarget : ActionTween
{
    private Vector3 initialPosition;

    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);
        initialPosition = _target.position;
    }

    protected override void UpdateTween(float easeV)
    {
        _target.position = Vector3.Lerp((Vector3)_from, (Vector3)_to, easeV);
    }
}
