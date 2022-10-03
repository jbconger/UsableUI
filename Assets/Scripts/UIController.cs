using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.M))
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
	}

    private void HideFullMap()
	{
        fullscreenMap.SetActive(false);
        minimap.SetActive(true);
	}
	#endregion
}
