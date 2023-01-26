using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items", fileName = "Item", order = 0)]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite _itemImage;
    [SerializeField] private Color _itemRarity;
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemCost;
    [SerializeField] private string _itemSavePath;

    public Sprite itemImage => _itemImage;
    public Color itemRarity => _itemRarity;
    public string itemName => _itemName;
    public int itemCost => _itemCost;
    public string itemSavePath => _itemSavePath;
}
