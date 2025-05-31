// Cleaned version below
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2 : MonoBehaviour
{
	public void StartGamelevel02()
	{
		SceneManager.LoadScene("level02");
	}

	public void StartGame3rdgunBunny()
	{
		SceneManager.LoadScene("3rd gun bunny");
	}

	public void BacktoMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
