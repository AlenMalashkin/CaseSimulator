using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasesFiller : MonoBehaviour
{
    [SerializeField] private Chest[] _chests;
    [SerializeField] private Case _casePrefab;
    [SerializeField] private RouletePanel _rouletePanel;

    private void Awake()
    {
        for (int i = 0; i < _chests.Length; i++)
        {
            var chest = Instantiate(_casePrefab, transform, true);
            chest.Init(_chests[i], _rouletePanel);
            chest.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
