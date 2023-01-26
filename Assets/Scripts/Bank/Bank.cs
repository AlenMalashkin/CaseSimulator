using System;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public event Action OnCurrencyValueChangedEvent;
    
    private static Bank instance = null;

    public static Bank Instance
    {
        get
        {
            if (instance == null)
            {
                var instance = GameObject.FindObjectOfType<Bank>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("Bank");
                    instance = obj.AddComponent<Bank>();

                    DontDestroyOnLoad(obj);
                }
            }

            return instance;
        }
    }

    public int Money { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
                instance = this;

                DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        Money = PlayerPrefs.GetInt("Money", 0);
    }

    public void AddMoney(int count)
    {
        if (count >= 0)
        {
            Money += count;
            PlayerPrefs.SetInt("Money", Money);
            OnCurrencyValueChangedEvent?.Invoke();
        }
    }

    public void SpendMoney(int count)
    {
        if (Money >= count)
        {
             Money -= count;
             PlayerPrefs.SetInt("Money", Money);
             OnCurrencyValueChangedEvent?.Invoke();
        }
    }
}
