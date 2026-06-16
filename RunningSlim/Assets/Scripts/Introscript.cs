using UnityEngine;
using UnityEngine.SceneManagement;
public class Introscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("LoadMenu", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menuscreen");
    }
}
