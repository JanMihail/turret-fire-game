using UnityEngine;

public class KolesoController : MonoBehaviour
{

    private Rigidbody rb;
    private float moveX = 0f;
    private float moveSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.AddTorque(Vector3.forward * -moveX * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }
}
