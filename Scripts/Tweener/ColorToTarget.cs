using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorToTarget : ActionTween
{
    private Renderer targetRenderer;
    private Color initialColor;
    private RawImage targetImage;
    private Color initialImageColor;

    private Color colorTo;
    public override void SetTweenData(TweenData data)
    {
        base.SetTweenData(data);

        colorTo = (Color)_to;

        // 게임 오브젝트가 일반적인 오브젝트인 경우 Renderer를 가져옴
        targetRenderer = _target.GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            initialColor = targetRenderer.material.color;
        }

        // 게임 오브젝트가 이미지 오브젝트인 경우 Image를 가져옴
        targetImage = _target.GetComponent<RawImage>();
        if (targetImage != null)
        {
            initialImageColor = targetImage.color;
        }
    }

    protected override void UpdateTween(float easeV)
    {
        Color normalizedColor = new Color(colorTo.r / 255f, colorTo.g / 255f, colorTo.b / 255f,colorTo.a);

        if (targetRenderer != null)
        {
            targetRenderer.material.color = Color.Lerp(initialColor, (Color)_to, easeV);
        }

        if (targetImage != null)
        {
            targetImage.color = Color.Lerp(initialImageColor, normalizedColor, easeV);
        }
    }
}
