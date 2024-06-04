using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UISceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    [Space]
    [SerializeField] private float delay;

    private Button button;
    private bool isClicked;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (isClicked) return;

            isClicked = true;
            
            if (delay == 0)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Invoke(nameof(ChangeScene), delay);
            }
        });
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
