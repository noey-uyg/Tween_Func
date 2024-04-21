using UnityEngine;
using UnityEngine.UI;

public class AlphaToTarget : ActionTween
{
    private Graphic targetGraphic;
    private Renderer targetRenderer;
    private Color initialColor;
    private Color targetAlpha;

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

        isCompleted = true;
        targetAlpha = new Color(initialColor.r, initialColor.g, initialColor.b, (float)_to);
    }

    protected override void UpdateTween(float easeV)
    {
        if (targetGraphic != null)
        {
            targetGraphic.color = Color.Lerp(initialColor, targetAlpha, easeV);
        }
        else if (targetRenderer != null)
        {
            targetRenderer.material.color = Color.Lerp(initialColor, targetAlpha, easeV);
        }
    }

    protected override object GetOriginalValue()
    {
        return initialColor;
    }
}
