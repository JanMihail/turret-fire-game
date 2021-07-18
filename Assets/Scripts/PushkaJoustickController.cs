using UnityEngine;

public class PushkaJoustickController : MonoBehaviour
{
    [SerializeField] private VariableJoystick pushkaJoustick;
    [SerializeField] private Pushka pushka;

    void Update()
    {
        Vector2 direction = new Vector2(pushkaJoustick.Horizontal, pushkaJoustick.Vertical);
        
        updateMove(direction);
        updateRotateDuloWithMoving(direction);
        updateRotateDuloWithoutMoving(direction);
    }

    private void updateMove(Vector2 direction)
    {
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        if (direction.sqrMagnitude < 0.3f || angle > 70f && angle < 110f)
        {
            pushka.move(0f);
            return;
        }

        if (angle > -90f && angle < 70f)
        {
            pushka.move(1f);
            return;
        }

        if ((angle > 110f && angle <= 180f) || (angle >= -180f && angle < -90f)) {
            pushka.move(-1f);
        }
    }
    
    private void updateRotateDuloWithMoving(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.3f)
        {
            return;
        }

        float angle = Vector2.SignedAngle(Vector2.right, direction);
        float needAngleDulo = 90f - angle;

        if (angle > 20f && angle < 70f)
        {
            if (needAngleDulo > pushka.getDuloAngle())
            {
                pushka.rotateDuloRight();
            } else
            {
                pushka.rotateDuloLeft();
            }
        }

        if (angle > 110f && angle < 160f)
        {
            if (needAngleDulo > pushka.getDuloAngle())
            {
                pushka.rotateDuloRight();
            } else
            {
                pushka.rotateDuloLeft();
            }
        }
    }

    private void updateRotateDuloWithoutMoving(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.3f)
        {
            return;
        }

        float angle = Vector2.SignedAngle(Vector2.right, direction);

        if (angle > 70f && angle < 90f)
        {
            pushka.rotateDuloRight();
        }

        if (angle > 90f && angle < 110f)
        {
            pushka.rotateDuloLeft();
        }
    }
}
