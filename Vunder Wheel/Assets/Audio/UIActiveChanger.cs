using UnityEngine;
using UnityEngine.UI;

public class UIActiveChanger : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private bool startValue;
    [SerializeField] private GameObject[] targetObjects;
    [SerializeField] private GameObject[] deactivateObjects;

    private void Start()
    {
        foreach (GameObject obj in deactivateObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in targetObjects)
        {
            obj.SetActive(startValue);
        }

        button.onClick.AddListener(() =>
        {
            foreach (GameObject obj in deactivateObjects)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in targetObjects)
            {
                obj.SetActive(!obj.activeSelf);
            }
        });
    }
}
