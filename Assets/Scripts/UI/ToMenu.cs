// Cleaned version below
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(MenuTo());
	}

	private IEnumerator MenuTo()
	{
		yield return (object)new WaitForSeconds(4f);
		SceneManager.LoadScene("Menu");
	}
}
