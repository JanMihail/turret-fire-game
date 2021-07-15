using UnityEngine;

public class PushkaMoveTouchController : MonoBehaviour
{
    public Pushka pushka;

    private bool isExistTouch = false;
    private bool isCheckedRayIntersect = false;
    private bool isTouchedKoleso = false;

    void Update()
    {
        if (isExistTouch)
        {
            if (Input.touchCount == 0)
            {
                isExistTouch = false;
                isCheckedRayIntersect = false;
                isTouchedKoleso = false;
            }
        }
        else
        {
            if (Input.touchCount == 1)
            {
                isExistTouch = true;
            }
        }

        if (isTouchedKoleso)
        {
            Vector3 touchWP = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.GetTouch(0).position.x,
                Input.GetTouch(0).position.y,
                -Camera.main.transform.position.z));
            pushka.moveHorizontal(touchWP.x);
        }
    }

    void FixedUpdate()
    {
        if (!isCheckedRayIntersect && isExistTouch)
        {
            isCheckedRayIntersect = true;
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosNear = Camera.main.ScreenToWorldPoint(new Vector3(touch.rawPosition.x, touch.rawPosition.y, Camera.main.nearClipPlane));
            Vector3 touchPosFar = Camera.main.ScreenToWorldPoint(new Vector3(touch.rawPosition.x, touch.rawPosition.y, Camera.main.farClipPlane));

            RaycastHit hit;
            isTouchedKoleso = Physics.Raycast(
                touchPosNear,
                touchPosFar - touchPosNear,
                out hit,
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
