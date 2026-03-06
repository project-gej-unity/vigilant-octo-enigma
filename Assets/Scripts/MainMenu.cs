using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Rigidbody targetRb;

    void Start()
    {
        
    }
    public void MainMenuPlayButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (targetRb == null) return;
        targetRb.useGravity = !targetRb.useGravity;
    }
    public void MainMenuQuitButton()
    {
        Debug.Log("Wylaczanie!");
        Application.Quit();
    }
}
