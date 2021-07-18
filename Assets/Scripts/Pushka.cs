using UnityEngine;

public class Pushka : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Rigidbody dulo;
    [SerializeField] private Rigidbody koleso;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform bulletShootPoint;
    [SerializeField] private float moveHorizSpeedMultiplier = 10f;
    [SerializeField] private float duloRotateSpeedMultiplier = 0.05f;
    [SerializeField] private float bulletForceMultiplier = 8f;
    
    // Moving
    private float moveSpeed = 0f;

    // Rotating dulo
    private HingeJoint duloHingeJoint;
    private float duloAngle = 0;

    // Fire
    private bool isFire = false;
    private float bulletForce = 0;
    
    void Start()
    {
        duloHingeJoint = dulo.GetComponent<HingeJoint>();
    }

    public void move(float horizontal)
    {
        this.moveSpeed = -horizontal * moveHorizSpeedMultiplier;
    }

    public void rotateDuloRight()
    {
        rotateDulo(1f);
    }

    public void rotateDuloLeft()
    {
        rotateDulo(-1f);
    }

    public void fire(float bulletForce)
    {
        this.bulletForce = bulletForce * bulletForceMultiplier;
        isFire = true;
    }

    public float getDuloAngle()
    {
        return duloAngle;
    }

    private void rotateDulo(float direction)
    {
        duloAngle = Mathf.Clamp(duloAngle + direction * duloRotateSpeedMultiplier * Time.deltaTime, -90, 90);
    }

    void FixedUpdate()
    {
        updateMove();
        updateRotateDulo();
        updateFire();
    }

    private void updateMove()
    {
        koleso.AddTorque(Vector3.forward * this.moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void updateRotateDulo()
    {
        JointSpring spring = duloHingeJoint.spring;
        spring.targetPosition = -duloAngle;
        duloHingeJoint.spring = spring;
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
