using UnityEngine;

namespace TweenManager
{
    public class MoveToTarget : ActionTween
    {
        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        public override void SetTweenData(TweenData data)
        {
            base.SetTweenData(data);
            initialPosition = _target.position;

        }

        protected override void UpdateTween(float easeV)
        {
            _target.position = Vector3.LerpUnclamped((Vector3)_from, (Vector3)_to, easeV);
        }

        protected override object GetOriginalValue()
        {
            return initialPosition;
        }
    }
}
