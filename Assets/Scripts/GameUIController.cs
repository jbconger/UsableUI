using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private MenuAudio menuAudio;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject minimap;
    [SerializeField] private GameObject fullscreenMap;

    [HideInInspector] public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.M) && !isPaused)
        {
            ShowFullMap();
        }
        else if (Input.GetKeyUp(KeyCode.M))
        {
            HideFullMap();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

        menuAudio.PlayPauseSound();
    }

    public void ChooseScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #region Map Controls
    private void ShowFullMap()
    {
        minimap.SetActive(false);
        fullscreenMap.SetActive(true);

        menuAudio.PlayMapSound();
    }

    private void HideFullMap()
    {
        fullscreenMap.SetActive(false);
        minimap.SetActive(true);
    }
    #endregion
}
