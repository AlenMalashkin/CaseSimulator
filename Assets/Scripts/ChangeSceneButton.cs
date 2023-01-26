using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeScene);
    }

    private void OnDisable()
    {
        _button.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneLoader.Instance.LoadScene(_sceneName);
    }
}
