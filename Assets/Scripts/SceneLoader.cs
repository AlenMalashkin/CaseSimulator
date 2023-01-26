using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Bank))]
public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance = null;
    
    public static SceneLoader Instance
    {
        get
        { 
            if (instance == null)
            {
                var instance = GameObject.FindObjectOfType<SceneLoader>();
    
                if (instance == null)
                {
                    GameObject obj = new GameObject("SceneLoader");
                    instance = obj.AddComponent<SceneLoader>();
    
                    DontDestroyOnLoad(obj);
                }
            }
    
            return instance;
        }
    }
    
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
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
