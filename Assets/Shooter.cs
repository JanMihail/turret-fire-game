using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform bulletShootPoint;
    private Rigidbody rb;
    public Rigidbody koleso;

    private bool isFire = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFire = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFire)
        {
            Vector3 force = bulletShootPoint.forward * 20f;
            Rigidbody bullet = Instantiate(bulletPrefab, bulletShootPoint.position, bulletShootPoint.rotation);
            bullet.AddForce(force, ForceMode.VelocityChange);
            rb.AddForceAtPosition(-force * 3f, bulletShootPoint.position, ForceMode.Impulse);
            koleso.AddForceAtPosition(-force * 1.2f, bulletShootPoint.position, ForceMode.Impulse);
            isFire = false;
        }
    }
}
