using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewCurrency : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        ViewCurrencyCount();
        Bank.Instance.OnCurrencyValueChangedEvent += ViewCurrencyCount;
    }

    private void OnDisable()
    {
        Bank.Instance.OnCurrencyValueChangedEvent -= ViewCurrencyCount;
    }

    private void ViewCurrencyCount()
    {
        _text.text = Bank.Instance.Money.ToString();
    }
}
