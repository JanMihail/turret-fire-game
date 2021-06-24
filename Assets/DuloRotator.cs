using UnityEngine;

public class DuloRotator : MonoBehaviour
{
    private HingeJoint hj;

    private float moveY = 0f;
    private float moveSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        moveY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        hj.useSpring = false;
        JointSpring jsp = hj.spring;
        float newpos = jsp.targetPosition + moveY * Time.deltaTime * moveSpeed;
        jsp.targetPosition = Mathf.Clamp(newpos, -90, 90);
        hj.spring = jsp;
        hj.useSpring = true;
    }
}
