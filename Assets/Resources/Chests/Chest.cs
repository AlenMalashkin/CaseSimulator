using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chests", fileName = "Chest", order = 1)]
public class Chest : ScriptableObject
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _chestName;
    [SerializeField] private int _cost;

    public List<Item> Items => _items;
    public Sprite Sprite => _sprite;
    public string ChestName => _chestName;
    public int Cost => _cost;
}
