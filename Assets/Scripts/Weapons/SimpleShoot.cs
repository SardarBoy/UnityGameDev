using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    public Transform barrelLocation;
    public Transform casingExitLocation;

    public float shotPower = 100f;

    private Animator animator;

    void Start()
    {
        if (barrelLocation == null)
        {
            barrelLocation = transform;
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Fire");
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(barrelLocation.forward * shotPower, ForceMode.Impulse);

        Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
    }

    private void CasingRelease()
    {
        GameObject casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation);
        Rigidbody rb = casing.GetComponent<Rigidbody>();

        rb.AddExplosionForce(Random.Range(70f, 150f), casingExitLocation.position - Vector3.right, 1f);
        rb.AddTorque(new Vector3(Random.Range(10, 100), Random.Range(10, 100), Random.Range(10, 100)));
    }
}
