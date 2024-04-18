using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRect : MonoBehaviour,IDragHandler
{
    public RectTransform dragRect;
    public Canvas canvas;
    private RectTransform canvasRect;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
        }

        if (dragRect == null)
        {
            dragRect = GetComponent<RectTransform>();
        }

        if (canvas != null)
        {
            canvasRect = canvas.GetComponent<RectTransform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragRect == null || canvas == null)
            return;

        dragRect.SetAsLastSibling();

        // 마우스 이동량을 Canvas의 스케일 팩터로 나누어서 움직일 위치 계산
        Vector2 position = dragRect.anchoredPosition + eventData.delta / canvas.scaleFactor;

        // 화면 경계를 벗어나지 않도록 처리
        Vector2 minPosition = canvasRect.rect.min - dragRect.rect.min;
        Vector2 maxPosition = canvasRect.rect.max - dragRect.rect.max;

        // x 좌표 범위 제한
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);

        // y 좌표 범위 제한
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

        // 드래그한 위치 적용
        dragRect.anchoredPosition = position;
    }
}