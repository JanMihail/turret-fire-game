using UnityEngine;

public class PushkaMoveMouseController : MonoBehaviour
{
    public Pushka pushka;

    private bool isExistTouch = false;
    private bool isCheckedRayIntersect = false;
    private bool isTouchedKoleso = false;

    void Update()
    {
        if (isExistTouch)
        {
            if (!Input.GetMouseButton(0))
            {
                isExistTouch = false;
                isCheckedRayIntersect = false;
                isTouchedKoleso = false;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
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
        }
    }

    void FixedUpdate()
    {
        if (!isCheckedRayIntersect && isExistTouch)
        {
            isCheckedRayIntersect = true;
            Vector3 touchPosNear = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 touchPosFar = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane));

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
