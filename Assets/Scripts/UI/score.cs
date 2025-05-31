// Cleaned version below
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class score : MonoBehaviour
{
	public static int scoreValue;

	[SerializeField]
	private Text killscore;

	private void Start()
	{
		killscore = ((Component)this).GetComponent<Text>();
	}

	private void Update()
	{
		killscore.text = "Score: " + scoreValue + "/25";
		if (scoreValue == 25)
		{
			SceneManager.LoadScene("level02");
			scoreValue = 0;
		}
	}
}
