using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10000f;
    public float fireRate = 8f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

            AudioManager audioManager = UnityEngine.Object.FindFirstObjectByType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.Play("shootar");
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("Hit: " + hit.transform.name);
                target.TakeDamage(damage);
            }

            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
