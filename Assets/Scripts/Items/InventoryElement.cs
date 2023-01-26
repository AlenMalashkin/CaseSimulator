using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryElement : MonoBehaviour
{
    [SerializeField] private Button _sellButton;
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _itemRarity;
    [SerializeField] private Text _itemName;
    [SerializeField] private Text _itemCost;
    [SerializeField] private Text _itemCount;

    private ViewCollectedItemsCount _viewCollectedItemsCount;
    private Item _item;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(SellItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(SellItem);
    }

    private void SellItem()
    {
        Bank.Instance.AddMoney(_item.itemCost);
        var itemCount = PlayerPrefs.GetInt(_item.itemSavePath, 0);

        itemCount -= 1;

        PlayerPrefs.SetInt(_item.itemSavePath, itemCount);

        _itemCount.text = itemCount.ToString();
        
        if (itemCount == 0)
        {
            _viewCollectedItemsCount.UpdateItemsCount();
            Destroy(gameObject);
        }
    }
    
    public void Init(Item item, ViewCollectedItemsCount viewCollectedItemsCount)
    {
        _viewCollectedItemsCount = viewCollectedItemsCount;
        
        _itemImage.sprite = item.itemImage;
        _itemRarity.color = item.itemRarity;
        _itemName.text = item.itemName;
        _itemCost.text = item.itemCost.ToString();
        _itemCount.text = PlayerPrefs.GetInt(item.itemSavePath).ToString();
        
        _item = item;
    }
}
