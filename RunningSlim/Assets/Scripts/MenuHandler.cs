using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void LoadQuit()
    {
        Application.Quit();
    }
}
