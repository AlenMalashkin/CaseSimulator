using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _chestImage;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _itemName;
    
    private RouletePanel _rouletePanel;
    private List<Item> _items;

    public int Cost => int.Parse(_costText.text);

    private void OnEnable()
    {
        _button.onClick.AddListener(ShowCaseInfo);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ShowCaseInfo);
    }

    private void ShowCaseInfo()
    {
        _rouletePanel.gameObject.SetActive(true);
        _rouletePanel.LoadCase(_items, this);
    }

    public void Init(Chest chest, RouletePanel rouletePanel)
    {
        _rouletePanel = rouletePanel;

        _items = chest.Items;
        _chestImage.sprite = chest.Sprite;
        _costText.text = chest.Cost.ToString();
        _itemName.text = chest.ChestName;
    }
}
