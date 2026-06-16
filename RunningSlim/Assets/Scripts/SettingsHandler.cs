using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    public static SettingsHandler Instance;

    public bool ShowMusic = true;
    public bool ShowHardcore = false;
    public bool ShowDevmenu = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMusic()
    {
        ShowMusic = !ShowMusic;
    }

    public void ToggleHardcore()
    {
        ShowHardcore = !ShowHardcore;
    }

    public void ToggleDevmenu()
    {
        ShowDevmenu = !ShowDevmenu;
    }

    public void ResetSettings()
    {
        ShowMusic = true;
        ShowHardcore = false;
        ShowDevmenu = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menuscreen");
    }
}