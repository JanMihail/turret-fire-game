using UnityEngine;

public class PushkaMoveMouseController : MonoBehaviour
{
    public Pushka pushka;

    private bool isExistTouch = false;
    private bool isCheckedRayIntersect = false;
    private bool isTouchedKoleso = false;
    private bool isNeedFire = false;
    private Vector3 firstTouchPos;

    void Update()
    {
        if (isExistTouch)
        {
            if (!Input.GetMouseButton(0))
            {
                isNeedFire = !isTouchedKoleso;
                isExistTouch = false;
                isCheckedRayIntersect = false;
                isTouchedKoleso = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                firstTouchPos = Input.mousePosition;
                isExistTouch = true;
            }
        }

        if (isTouchedKoleso)
        {
            Vector3 touchWP = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z));
            pushka.moveHorizontal(touchWP.x);
        } else if (isCheckedRayIntersect && isExistTouch)
        {
            Vector3 duloRotatePoint = pushka.getDuloRotatePoint();
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z - 0.0132328f /* координата z дула / 100 (масштаб) */));

            float duloAngle = Vector2.SignedAngle(new Vector2(touchPos.x - duloRotatePoint.x, touchPos.y - duloRotatePoint.y), Vector2.up);
            pushka.rotateDulo(duloAngle);
        } else if (isNeedFire)
        {
            isNeedFire = false;

            Vector3 duloRotatePoint = pushka.getDuloRotatePoint();

            Vector3 firstPos = Camera.main.ScreenToWorldPoint(new Vector3(
                firstTouchPos.x,
                firstTouchPos.y,
                -Camera.main.transform.position.z - 0.0132328f /* координата z дула / 100 (масштаб) */));

            Vector3 releasePos = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z - 0.0132328f /* координата z дула / 100 (масштаб) */));

            float a = (firstPos - duloRotatePoint).sqrMagnitude;
            float b = (releasePos - duloRotatePoint).sqrMagnitude;

            float bulletForce = 0f;
            if (a > 0.001)
            {
                bulletForce = Mathf.Clamp( (a - b) / a, 0, 1);
            }

            pushka.fire(bulletForce);
        }
    }

    private void OnGUI()
    {
        /*
        GUI.skin.label.fontSize = 50;
        GUILayout.BeginArea(new Rect(10, 10, 1000, 800));
        GUILayout.Label("bulletForce: " + bulletForce.ToString("F3"));
        GUILayout.EndArea();
        */
    }

    void FixedUpdate()
    {
        if (!isCheckedRayIntersect && isExistTouch)
        {
            isCheckedRayIntersect = true;
            Vector3 touchPosNear = Camera.main.ScreenToWorldPoint(new Vector3(firstTouchPos.x, firstTouchPos.y, Camera.main.nearClipPlane));
            Vector3 touchPosFar = Camera.main.ScreenToWorldPoint(new Vector3(firstTouchPos.x, firstTouchPos.y, Camera.main.farClipPlane));

            isTouchedKoleso = Physics.Raycast(
                touchPosNear,
                touchPosFar - touchPosNear,
                Mathf.Infinity,
                LayerMask.GetMask("PushkaKoleso"));

            /*
            if (isTouchedKoleso)
            {
                Debug.DrawRay(touchPosNear, Vector3.Normalize(touchPosFar - touchPosNear) * hit.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(touchPosNear, touchPosFar - touchPosNear, Color.red);
            }
            */
        }
    }
}
