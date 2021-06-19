using UnityEngine;

public class Turret : MonoBehaviour
{
    public float moveSpeed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(float horizontal)
    {
        move(horizontal, Time.deltaTime);
    }

    public void move(float horizontal, float multiplicity)
    {
        float hor = horizontal * moveSpeed;

        Vector3 direction = new Vector3(0, 0, -hor);

        transform.Translate(direction.normalized * moveSpeed * multiplicity);
    }
}
