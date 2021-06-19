using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Turret turret;

    private float moveHor;

    void Start()
    {
        updateCoords();
    }

    void Update()
    {
        updateCoords();
        turret.move(moveHor);
    }

    private void updateCoords()
    {
        moveHor = Input.GetAxis("Horizontal");
    }
}
