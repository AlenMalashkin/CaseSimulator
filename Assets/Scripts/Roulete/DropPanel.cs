using System;
using UnityEngine;
using UnityEngine.UI;

public class DropPanel : MonoBehaviour
{
    [SerializeField] private Button _sellAndOpenAgainButton;
    [SerializeField] private Button _sellAndCloseButton;
    [SerializeField] private Button _claimButton;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _massage;
    [SerializeField] private RectTransform _spawnPoint;

    private Roulete _roulete;
    private Item _item;
    
    private void OnEnable()
    {
        _sellAndOpenAgainButton.onClick.AddListener(SellAndOpenAgain);
        _sellAndCloseButton.onClick.AddListener(SellAndClose);
        _claimButton.onClick.AddListener(ClaimItem);
    }
    
    private void OnDisable()
    {
        _sellAndOpenAgainButton.onClick.RemoveListener(SellAndOpenAgain);
        _sellAndCloseButton.onClick.RemoveListener(SellAndClose);
        _claimButton.onClick.RemoveListener(ClaimItem);
        _massage.gameObject.SetActive(false);
        
    }

    private void SellAndOpenAgain()
    {
        if (Bank.Instance.Money + _item.itemCost >= _roulete.RouletePanel.Chest.Cost)
        {
            _roulete.RouletePanel.gameObject.SetActive(true);
            Bank.Instance.AddMoney(_item.itemCost);
            _roulete.RouletePanel.OpenCase();
            CloseAndClearDropPanel();
        }
        else
        {
            _massage.gameObject.SetActive(true);
        }
    }

    private void SellAndClose()
    {
        Bank.Instance.AddMoney(_item.itemCost);
        CloseAndClearDropPanel();
        _roulete.RouletePanel.gameObject.SetActive(true);
    }
    
    private void ClaimItem()
    {
        var itemCount = PlayerPrefs.GetInt(_item.itemSavePath, 0);
        
        PlayerPrefs.SetInt(_item.itemSavePath, itemCount + 1);

        CloseAndClearDropPanel();
        
        _roulete.RouletePanel.gameObject.SetActive(true);
    }

    private void CloseAndClearDropPanel()
    {
        Destroy(_spawnPoint.GetChild(0).gameObject);
        gameObject.SetActive(false);
    }

    public void ShowDroppedItem(RouleteElement item, Roulete roulete)
    {
        roulete.RouletePanel.gameObject.SetActive(false);

        _item = item.item;

        _roulete = roulete;

        _roulete.gameObject.SetActive(false);

        var el = Instantiate(item, _spawnPoint);
        el.Init(item.item);
        el.transform.localScale = new Vector3(1, 1, 1);

        _costText.text = item.item.itemCost.ToString();
    }
}