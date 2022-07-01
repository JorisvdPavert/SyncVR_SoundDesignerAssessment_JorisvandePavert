using UnityEngine;
using UnityEngine.UI;

public class ExitAppButton : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => ExitApp());
    }

    private void ExitApp()
    {
        Application.Quit();
    }
}