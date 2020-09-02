using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Action OutPutting;

    [SerializeField] private Text nameField;
    [SerializeField] private Image iconField;
    private Transform draggingParent;
    private Transform originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = draggingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (In((RectTransform)originalParent))
        {
            InsertInGrid();
        }
        else
        {
            Output();
        }
    }

    public void InitializationParent(Transform draggingParent)
    {
        this.draggingParent = draggingParent;
        originalParent = transform.parent;
    }

    public void Render(IItem item)
    {
        nameField.text = item.Name;
        iconField.sprite = item.UIIcon;
    }

    private void InsertInGrid()
    {
        int closestIndex = 0;

        for (int i = 0; i < originalParent.transform.childCount; i++)
        {
            if (Vector2.Distance(transform.position, originalParent.GetChild(i).position) <
                Vector2.Distance(transform.position, originalParent.GetChild(closestIndex).position))
            {
                closestIndex = i;
            }
        }

        transform.parent = originalParent;
        transform.SetSiblingIndex(closestIndex);
    }

    private bool In(RectTransform originalParent)
    {
        return originalParent.rect.Contains(transform.position);
    }

    private void Output()
    {
        OutPutting?.Invoke();
    }
}