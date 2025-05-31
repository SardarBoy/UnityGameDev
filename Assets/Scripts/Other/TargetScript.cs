// Cleaned version below
using System.Collections;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
	private float randomTime;

	private bool routineStarted;

	public bool isHit;

	[Header("Customizable Options")]
	public float minTime;

	public float maxTime;

	[Header("Audio")]
	public AudioClip upSound;

	public AudioClip downSound;

	public AudioSource audioSource;

	private void Update()
	{
		randomTime = Random.Range(minTime, maxTime);
		if (isHit && !routineStarted)
		{
			((Component)this).gameObject.GetComponent<Animation>().Play("target_down");
			((Component)audioSource).GetComponent<AudioSource>().clip = downSound;
			audioSource.Play();
			((MonoBehaviour)this).StartCoroutine(DelayTimer());
			routineStarted = true;
		}
	}

	private IEnumerator DelayTimer()
	{
		yield return (object)new WaitForSeconds(randomTime);
		((Component)this).gameObject.GetComponent<Animation>().Play("target_up");
		((Component)audioSource).GetComponent<AudioSource>().clip = upSound;
		audioSource.Play();
		isHit = false;
		routineStarted = false;
	}
}
