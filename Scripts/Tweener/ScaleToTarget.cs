using UnityEngine;

public class ScaleToTarget : ActionTween
{
    private Vector3 initialScale;

    private void Start()
    {
        initialScale = _target.localScale;
    }

    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);
        isCompleted = true;
    }

    protected override void UpdateTween(float easeV)
    {
        _target.localScale = Vector3.Lerp(initialScale, (Vector3)_to, easeV);
    }

    protected override object GetOriginalValue()
    {
        return initialScale;
    }
}
