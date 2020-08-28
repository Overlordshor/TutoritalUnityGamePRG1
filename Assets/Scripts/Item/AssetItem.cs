using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, IItem
{
    public string Name => nameItem;
    public Sprite UIIcon => uiIcon;

    [SerializeField] private string nameItem;
    [SerializeField] private Sprite uiIcon;
}