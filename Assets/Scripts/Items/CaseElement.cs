using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseElement : MonoBehaviour
{
	[SerializeField] private Image _itemImage;
	[SerializeField] private Image _itemRarity;
	[SerializeField] private Text _itemName;
    
	public void Init(Item item)
	{
		_itemImage.sprite = item.itemImage;
		_itemRarity.color = item.itemRarity;
		_itemName.text = item.itemName;
	}
}
