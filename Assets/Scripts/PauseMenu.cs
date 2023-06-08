using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public static bool GameIsPause = false;


	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
		pauseButton.SetActive(true);
        Time.timeScale = 0;
        GameIsPause = true;
    }
    public void Resume()
    {
		pauseButton.SetActive(false);
        Time.timeScale = 1;
        GameIsPause= false;
    }
	public static void Quit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
	public void Retry()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		pauseButton.SetActive(false);
		Time.timeScale = 1;
		GameIsPause = false;
	}
}
