using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Roulete : MonoBehaviour
{
    [SerializeField] private DropPanel _dropPanel;
    [SerializeField] private RouleteElement _rouleteElement;
    [SerializeField] private GameObject _rouleteTrigger;

    [SerializeField] private RectTransform _transform;

    [SerializeField] private float _startRouleteSpeed;
    
    private float _rouleteSpeed;
    private Vector2 _startPos;

    public RouletePanel RouletePanel { get; private set; }

    private void OnEnable()
    {
        _rouleteTrigger.SetActive(true);
        _rouleteSpeed = _startRouleteSpeed;
        _startPos = _transform.anchoredPosition;
    }

    private void OnDisable()
    {
        _rouleteTrigger.SetActive(false);
        _transform.anchoredPosition = _startPos;
    }

    private void Update()
    {
        _transform.anchoredPosition += -Vector2.right * (_rouleteSpeed * Time.deltaTime);

        _rouleteSpeed -= Random.Range(500, 1000) * Time.deltaTime;
        
        if (_rouleteSpeed <= 0)
        {
            OnRouleteSpinEnd();
            gameObject.SetActive(false);
        }
    }

    private void OnRouleteSpinEnd()
    {
        RaycastHit2D hit;

        Debug.DrawRay(_rouleteTrigger.transform.position, -Vector3.forward * 100);
        
        hit = Physics2D.Raycast(_rouleteTrigger.transform.position, -Vector3.forward);

        hit.collider.TryGetComponent(out RouleteElement el);

        _dropPanel.gameObject.SetActive(true);
        _dropPanel.ShowDroppedItem(el, this);

        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void FillRoulete(List<Item> items, RouletePanel rouletePanel)
    {
        RouletePanel = rouletePanel;
        
        System.Random rnd = new System.Random();
        
        for (int i = 0; i < 50; i++)
        {
            var index = rnd.Next(0, items.Count);
            var item = Instantiate(_rouleteElement, transform, true);
            
            item.Init(items[index]);
            
            item.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
