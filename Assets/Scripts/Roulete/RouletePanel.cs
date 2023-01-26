using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletePanel : MonoBehaviour
{
    [SerializeField] private Roulete _roulete;
    [SerializeField] private CaseElement _caseElement;
    [SerializeField] private Button _openCaseButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Transform _itemsInitPoint;
    
    private List<Item> _items;
    
    public Case Chest { get; private set; }

    private void OnEnable()
    {
        _openCaseButton.onClick.AddListener(OpenCase);
        _closeButton.onClick.AddListener(ClosePanel);
        _closeButton.gameObject.SetActive(true);
        _openCaseButton.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _openCaseButton.onClick.RemoveListener(OpenCase);     
        _closeButton.onClick.RemoveListener(ClosePanel);     
    }

    private void ClearCaseItems()
    {
        for (int i = 0; i < _itemsInitPoint.childCount; i++)
        {
            Destroy(_itemsInitPoint.GetChild(i).gameObject);
        }
    }

    private void ClosePanel()
    {
        ClearCaseItems();
        gameObject.SetActive(false);
    }

    public void LoadCase(List<Item> items, Case chest)
    {
        _items = items;
        Chest = chest;
        
        ClearCaseItems();
        
        for (int i = 0; i < items.Count; i++)
        {
            var item = Instantiate(_caseElement, _itemsInitPoint);
            item.Init(items[i]);
        }
    }

    public void OpenCase()
    {
        if (Bank.Instance.Money >= Chest.Cost)
        {
            Bank.Instance.SpendMoney(Chest.Cost);
            _roulete.gameObject.SetActive(true);
            _roulete.FillRoulete(_items, this);
            _closeButton.gameObject.SetActive(false);
            _openCaseButton.gameObject.SetActive(false);
        }
    }
}
