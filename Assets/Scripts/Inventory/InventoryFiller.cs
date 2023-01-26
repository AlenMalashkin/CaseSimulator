using System;
using UnityEngine;

public class InventoryFiller : MonoBehaviour
{
        [SerializeField] private Item[] _items;
        [SerializeField] private InventoryElement _inventoryElement;
        [SerializeField] private ViewCollectedItemsCount _viewCollectedItemsCount;

        private void Awake()
        { 
                FillInventory();
        }

        private void FillInventory()
        {
                foreach (var item in _items)
                {
                        if (PlayerPrefs.HasKey(item.itemSavePath) && PlayerPrefs.GetInt(item.itemSavePath) != 0)
                        { 
                                var el = Instantiate(_inventoryElement, transform, true);
                                el.Init(item, _viewCollectedItemsCount);
                                el.transform.localScale = new Vector3(1, 1, 1);
                        }
                }
        }

        private void ClearInventory()
        {
                for (int i = 0; i < transform.childCount; i++)
                {
                        Destroy(transform.GetChild(i).gameObject);
                }
        }

        public void UpdateUI()
        {
                ClearInventory();
                FillInventory();
        }
}