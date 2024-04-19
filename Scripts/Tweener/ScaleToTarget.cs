using UnityEngine;

public class ScaleToTarget : ActionTween
{
    private Vector3 initialScale;

    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);
        initialScale = _target.localScale;
    }

    protected override void UpdateTween(float easeV)
    {
        _target.localScale = Vector3.Lerp(initialScale, (Vector3)_to, easeV);
    }
}
