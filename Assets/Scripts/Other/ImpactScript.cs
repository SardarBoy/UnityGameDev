// Cleaned version below
using System.Collections;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
	[Header("Impact Despawn Timer")]
	public float despawnTimer = 10f;

	[Header("Audio")]
	public AudioClip[] impactSounds;

	public AudioSource audioSource;

	private void Start()
	{
		((MonoBehaviour)this).StartCoroutine(DespawnTimer());
		audioSource.clip = impactSounds[Random.Range(0, impactSounds.Length)];
		audioSource.Play();
	}

	private IEnumerator DespawnTimer()
	{
		yield return (object)new WaitForSeconds(despawnTimer);
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}
}
