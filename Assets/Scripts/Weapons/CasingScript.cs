// Cleaned version below
using System.Collections;
using UnityEngine;

public class CasingScript : MonoBehaviour
{
	[Header("Force X")]
	[Tooltip("Minimum force on X axis")]
	public float minimumXForce;

	[Tooltip("Maimum force on X axis")]
	public float maximumXForce;

	[Header("Force Y")]
	[Tooltip("Minimum force on Y axis")]
	public float minimumYForce;

	[Tooltip("Maximum force on Y axis")]
	public float maximumYForce;

	[Header("Force Z")]
	[Tooltip("Minimum force on Z axis")]
	public float minimumZForce;

	[Tooltip("Maximum force on Z axis")]
	public float maximumZForce;

	[Header("Rotation Force")]
	[Tooltip("Minimum initial rotation value")]
	public float minimumRotation;

	[Tooltip("Maximum initial rotation value")]
	public float maximumRotation;

	[Header("Despawn Time")]
	[Tooltip("How long after spawning that the casing is destroyed")]
	public float despawnTime;

	[Header("Audio")]
	public AudioClip[] casingSounds;

	public AudioSource audioSource;

	[Header("Spin Settings")]
	[Tooltip("How fast the casing spins over time")]
	public float speed = 2500f;

	private void Awake()
	{
		((Component)this).GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(minimumRotation, maximumRotation), Random.Range(minimumRotation, maximumRotation), Random.Range(minimumRotation, maximumRotation) * Time.deltaTime);
		((Component)this).GetComponent<Rigidbody>().AddRelativeForce(Random.Range(minimumXForce, maximumXForce), Random.Range(minimumYForce, maximumYForce), Random.Range(minimumZForce, maximumZForce));
	}

	private void Start()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		((MonoBehaviour)this).StartCoroutine(RemoveCasing());
		((Component)this).transform.rotation = Random.rotation;
		((MonoBehaviour)this).StartCoroutine(PlaySound());
	}

	private void FixedUpdate()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).transform.Rotate(Vector3.right, speed * Time.deltaTime);
		((Component)this).transform.Rotate(Vector3.down, speed * Time.deltaTime);
	}

	private IEnumerator PlaySound()
	{
		yield return (object)new WaitForSeconds(Random.Range(0.25f, 0.85f));
		audioSource.clip = casingSounds[Random.Range(0, casingSounds.Length)];
		audioSource.Play();
	}

	private IEnumerator RemoveCasing()
	{
		yield return (object)new WaitForSeconds(despawnTime);
		Object.Destroy((Object)(object)((Component)this).gameObject);
	}
}
