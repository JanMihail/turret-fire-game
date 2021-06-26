using System;
using UnityEngine;

public class Pushka : MonoBehaviour
{
    // public Rigidbody root;
    public Rigidbody dulo;
    public Rigidbody koleso;
    public Rigidbody bulletPrefab;
    public Transform bulletShootPoint;

    public float moveHorizSpeed = 500f;
    // public float duloRotateSpeed = 100f;
    public float bulletForce = 20f;

    private HingeJoint duloHingeJoint;
    private float moveHoriz = 0;
    private float duloAngle = 0;
    private bool isFire = false;
    
    void Start()
    {
        duloHingeJoint = dulo.GetComponent<HingeJoint>();
    }

    public void move(float horizontal)
    {
        moveHoriz = horizontal;
    }

    public void rotateDulo(float angle)
    {
        duloAngle = Mathf.Clamp(angle, -90, 90);
    }

    public void fire()
    {
        isFire = true;
    }

    void FixedUpdate()
    {
        updateRotateKoleso();
        updateRotateDulo();
        updateFire();
    }

    private void updateRotateKoleso()
    {
        // root.AddForce(Vector3.right * moveHoriz * moveHorizSpeed * Time.deltaTime, ForceMode.VelocityChange);
        koleso.AddTorque(Vector3.forward * -moveHoriz * moveHorizSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void updateRotateDulo()
    {
        // duloHingeJoint.useSpring = false;

        JointSpring spring = duloHingeJoint.spring;
        spring.targetPosition = duloAngle;
        duloHingeJoint.spring = spring;
        
        // duloHingeJoint.useSpring = true;
    }

    private void updateFire()
    {
        if (!isFire)
        {
            return;
        }

        Vector3 force = bulletShootPoint.forward * bulletForce;
        Rigidbody bullet = Instantiate(bulletPrefab, bulletShootPoint.position, bulletShootPoint.rotation);
        bullet.AddForce(force, ForceMode.VelocityChange);
        dulo.AddForceAtPosition(-force * bulletForce, bulletShootPoint.position, ForceMode.Impulse);
        
        isFire = false;
    }
}
