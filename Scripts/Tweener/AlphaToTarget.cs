using UnityEngine;
using UnityEngine.UI;

namespace TweenManager
{
    public class AlphaToTarget : ActionTween
    {
        private Graphic targetGraphic;
        private Renderer targetRenderer;
        private Color initialColor;
        private Color targetAlpha;

        private void Start()
        {
            _target.TryGetComponent<Graphic>(out targetGraphic);
            if (targetGraphic != null)
            {
                initialColor = targetGraphic.color;
            }
            else
            {
                _target.TryGetComponent<Renderer>(out targetRenderer);
                if (targetRenderer != null)
                {
                    targetRenderer.material.SetFloat("_Mode", 2.0f);
                    targetRenderer.material.SetOverrideTag("RenderType", "Transparent");
                    targetRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    targetRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    targetRenderer.material.SetInt("_ZWrite", 0);
                    targetRenderer.material.DisableKeyword("_ALPHATEST_ON");
                    targetRenderer.material.EnableKeyword("_ALPHABLEND_ON");
                    targetRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    targetRenderer.material.renderQueue = 3000;

                    initialColor = targetRenderer.material.color;
                }
            }
        }

        public override void SetTweenData(TweenData data)
        {
            base.SetTweenData(data);

            targetAlpha = new Color(initialColor.r, initialColor.g, initialColor.b, (float)_to);
        }

        protected override void UpdateTween(float easeV)
        {
            if (targetGraphic != null)
            {
                targetGraphic.color = Color.LerpUnclamped(initialColor, targetAlpha, easeV);
            }
            else if (targetRenderer != null)
            {
                targetRenderer.material.color = Color.LerpUnclamped(initialColor, targetAlpha, easeV);
            }
        }

        protected override object GetOriginalValue()
        {
            return initialColor;
        }
    }
}
