// Cleaned version below
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused;

	public GameObject PauseMenuUI;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown((KeyCode)27))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		Cursor.visible = false;
		Cursor.lockState = (CursorLockMode)1;
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		Cursor.visible = true;
		Cursor.lockState = (CursorLockMode)0;
		PauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void MainMenu()
	{
		PauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		SceneManager.LoadScene("Menu");
	}
}
