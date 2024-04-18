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

        // ���콺 �̵����� Canvas�� ������ ���ͷ� ����� ������ ��ġ ���
        Vector2 position = dragRect.anchoredPosition + eventData.delta / canvas.scaleFactor;

        // ȭ�� ��踦 ����� �ʵ��� ó��
        Vector2 minPosition = canvasRect.rect.min - dragRect.rect.min;
        Vector2 maxPosition = canvasRect.rect.max - dragRect.rect.max;

        // x ��ǥ ���� ����
        position.x = Mathf.Clamp(position.x, minPosition.x, maxPosition.x);

        // y ��ǥ ���� ����
        position.y = Mathf.Clamp(position.y, minPosition.y, maxPosition.y);

        // �巡���� ��ġ ����
        dragRect.anchoredPosition = position;
    }
}