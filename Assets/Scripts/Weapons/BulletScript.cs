using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Range(5f, 100f)]
    public float destroyAfter = 5f;

    public bool destroyOnImpact = true;
    public float minDestroyTime = 0.1f;
    public float maxDestroyTime = 0.5f;

    public Transform[] metalImpactPrefabs;

    private void Start()
    {
        StartCoroutine(DestroyAfter());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!destroyOnImpact)
        {
            StartCoroutine(DestroyTimer());
        }
        else
        {
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("Metal"))
        {
            ContactPoint contact = collision.contacts[0];
            Instantiate(metalImpactPrefabs[Random.Range(0, metalImpactPrefabs.Length)],
                        transform.position,
                        Quaternion.LookRotation(contact.normal));
        }

        if (collision.transform.CompareTag("Target"))
        {
            collision.transform.GetComponent<TargetScript>().isHit = true;
        }

        if (collision.transform.CompareTag("ExplosiveBarrel"))
        {
            collision.transform.GetComponent<ExplosiveBarrelScript>().explode = true;
        }

        Destroy(gameObject);
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(Random.Range(minDestroyTime, maxDestroyTime));
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        yield return new WaitForSeconds(destroyAfter);
        Destroy(gameObject);
    }
}
