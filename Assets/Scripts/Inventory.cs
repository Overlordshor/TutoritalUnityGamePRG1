using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<AssetItem> items;
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform container;
    [SerializeField] private Transform draggingParent;

    public void OnEnable()
    {
        Render(items);
    }

    public void Render(List<AssetItem> items)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        items.ForEach(item =>
        {
            var cell = Instantiate(inventoryCellTemplate, container);
            cell.InitializationParent(draggingParent);
            cell.Render(item);

            cell.OutPutting += () => Destroy(cell.gameObject);
        });
    }
}