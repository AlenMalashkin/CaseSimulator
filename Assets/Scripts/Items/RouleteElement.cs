using UnityEngine;
using UnityEngine.UI;

public class RouleteElement : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _itemRarity;
    [SerializeField] private Text _itemName;
    
    public Item item { get; private set; }

    public void Init(Item item)
    {
        _itemImage.sprite = item.itemImage;
        _itemRarity.color = item.itemRarity;
        _itemName.text = item.itemName;

        this.item = item;
    }
}
