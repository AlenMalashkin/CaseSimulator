using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewCollectedItemsCount : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private int _itemsCount;

    private void Start()
    {
        _text.text = "Предметов получено: " + transform.childCount +"/" + _itemsCount;
    }

    public void UpdateItemsCount()
    {
        var count = transform.childCount - 1;
        _text.text = "Предметов получено: " + count +"/" + _itemsCount;
    }
}
