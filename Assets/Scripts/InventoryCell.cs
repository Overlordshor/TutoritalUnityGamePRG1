using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
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
}