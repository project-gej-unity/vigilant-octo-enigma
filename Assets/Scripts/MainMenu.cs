using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void MainMenuPlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenuQuitButton()
    {
        Debug.Log("Wylaczanie!");
        Application.Quit();
    }
}
