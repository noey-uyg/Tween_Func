using UnityEngine;
using UnityEngine.UI;

namespace TweenManager
{
    public class ColorToTarget : ActionTween
    {
        private Graphic targetGraphic;
        private Renderer targetRenderer;
        private Color initialColor;
        private Color colorTo;
        private Color normalizedColor;


        private void Start()
        {
            targetGraphic = _target.GetComponent<Graphic>();
            if (targetGraphic != null)
            {
                initialColor = targetGraphic.color;
            }
            else
            {
                targetRenderer = _target.GetComponent<Renderer>();
                if (targetRenderer != null)
                {
                    initialColor = targetRenderer.material.color;
                }
            }
        }

        public override void SetTweenData(TweenData data)
        {
            base.SetTweenData(data);

            colorTo = (Color)_to;
            normalizedColor = new Color(colorTo.r / 255f, colorTo.g / 255f, colorTo.b / 255f, colorTo.a);
        }

        protected override void UpdateTween(float easeV)
        {
            if (targetGraphic != null)
            {
                targetGraphic.color = Color.Lerp(initialColor, normalizedColor, easeV);
            }
            else if (targetRenderer != null)
            {
                targetRenderer.material.color = Color.Lerp(initialColor, normalizedColor, easeV);
            }
        }

        protected override object GetOriginalValue()
        {
            return initialColor;
        }
    }
}