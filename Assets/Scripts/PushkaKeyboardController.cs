using UnityEngine;

public class PushkaKeyboardController : MonoBehaviour
{
    public Pushka pushka;

    void Update()
    {
        pushka.move(Input.GetAxis("Horizontal"));
        pushka.rotateDulo(Input.GetAxis("Vertical") * 90);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pushka.fire();
        }
    }
}
