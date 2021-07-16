using UnityEngine;

public class Pushka : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Rigidbody dulo;
    [SerializeField] private Rigidbody koleso;
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform bulletShootPoint;
    [SerializeField] private Transform platformToMove;
    [SerializeField] private float bulletForceMultiplier = 8f;

    private HingeJoint duloHingeJoint;
    private float duloAngle = 0;
    private bool isFire = false;
    private float bulletForce = 0;
    
    void Start()
    {
        duloHingeJoint = dulo.GetComponent<HingeJoint>();
    }

    public Vector3 getDuloRotatePoint()
    {
        return dulo.transform.position;
    }

    public void moveHorizontal(float worldCoordX)
    {
        Vector3 curPos = platformToMove.position;
        curPos.x = worldCoordX;
        platformToMove.position = curPos;
    }

    public void rotateDulo(float angle)
    {
        duloAngle = Mathf.Clamp(angle, -90, 90);
    }

    public void fire(float bulletForce)
    {
        this.bulletForce = bulletForce * bulletForceMultiplier;
        isFire = true;
    }

    void Update()
    {
        updatePlatformToMovePosition();
    }

    void FixedUpdate()
    {
        updateRotateDulo();
        updateFire();
    }

    private void updatePlatformToMovePosition()
    {
        Vector3 curPos = platformToMove.position;
        curPos.y = root.position.y;
        platformToMove.position = curPos;
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
