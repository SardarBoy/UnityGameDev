using System.Collections;
using UnityEngine;

public class ExplosiveBarrelScript : MonoBehaviour
{
    public bool explode;
    public Transform explosionPrefab;
    public Transform destroyedBarrelPrefab;

    public float minTime = 0.05f;
    public float maxTime = 0.25f;
    public float explosionRadius = 12.5f;
    public float explosionForce = 4000f;

    private bool routineStarted;
    private float randomTime;

    private void Update()
    {
        randomTime = Random.Range(minTime, maxTime);
        if (explode && !routineStarted)
        {
            StartCoroutine(Explode());
            routineStarted = true;
        }
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(randomTime);

        Instantiate(destroyedBarrelPrefab, transform.position, transform.rotation);

        Vector3 position = transform.position;
        Collider[] colliders = Physics.OverlapSphere(position, explosionRadius);
        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(explosionForce * 50f, position, explosionRadius);

            if (col.CompareTag("ExplosiveBarrel"))
                col.GetComponent<ExplosiveBarrelScript>().explode = true;

            if (col.CompareTag("Target"))
                col.GetComponent<TargetScript>().isHit = true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 50f))
        {
            Instantiate(explosionPrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
        }

        Destroy(gameObject);
    }
}
