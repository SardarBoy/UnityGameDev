using System.Collections;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float grenadeTimer = 5f;
    public Transform explosionPrefab;
    public float radius = 25f;
    public float power = 350f;

    public float minimumForce = 1500f;
    public float maximumForce = 2500f;

    private float throwForce;

    public AudioSource impactSound;

    private void Awake()
    {
        throwForce = Random.Range(minimumForce, maximumForce);
        GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(500, 1500), 0f, 0f);
    }

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        StartCoroutine(ExplosionTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        impactSound.Play();
    }

    private IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(grenadeTimer);

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50f))
        {
            Instantiate(explosionPrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
        }

        Vector3 position = transform.position;
        Collider[] colliders = Physics.OverlapSphere(position, radius);
        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power * 5f, position, radius, 3f);

            if (col.CompareTag("Target") && !col.GetComponent<TargetScript>().isHit)
            {
                col.GetComponent<Animation>().Play("target_down");
                col.GetComponent<TargetScript>().isHit = true;
            }

            if (col.CompareTag("ExplosiveBarrel"))
            {
                col.GetComponent<ExplosiveBarrelScript>().explode = true;
            }
        }

        Destroy(gameObject);
    }
}
