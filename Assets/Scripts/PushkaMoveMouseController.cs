using UnityEngine;

public class PushkaMoveMouseController : MonoBehaviour
{
    public Pushka pushka;

    private bool isFirstTouched = false;
    private bool isTouchedKoleso;

    private Vector3 firstTouchPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFirstTouched = true;
            firstTouchPos = Input.mousePosition;
        }

        isTouchedKoleso = isTouchedKoleso && Input.GetMouseButton(0);

        if (isTouchedKoleso)
        {
            Vector3 kolesoVP = Camera.main.WorldToViewportPoint(pushka.getKolesoPosition());
            Vector3 touchVP = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            pushka.move(touchVP.x > kolesoVP.x ? 1f : -1f);
        } else
        {
            pushka.move(0f);
        }
    }

    void FixedUpdate()
    {
        if (isFirstTouched)
        {
            isFirstTouched = false;

            Vector3 touchPosNear = Camera.main.ScreenToWorldPoint(new Vector3(firstTouchPos.x, firstTouchPos.y, Camera.main.nearClipPlane));
            Vector3 touchPosFar = Camera.main.ScreenToWorldPoint(new Vector3(firstTouchPos.x, firstTouchPos.y, Camera.main.farClipPlane));

            RaycastHit hit;
            isTouchedKoleso = Physics.Raycast(
                touchPosNear,
                touchPosFar - touchPosNear,
                out hit,
                Mathf.Infinity,
                LayerMask.GetMask("PushkaKoleso"));
            
            if (isTouchedKoleso)
            {
                Debug.DrawRay(touchPosNear, Vector3.Normalize(touchPosFar - touchPosNear) * hit.distance, Color.green);
            }
            else
            {
                Debug.DrawRay(touchPosNear, touchPosFar - touchPosNear, Color.red);
            }
        }
    }

}
