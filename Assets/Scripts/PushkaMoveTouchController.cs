using UnityEngine;

public class PushkaMoveTouchController : MonoBehaviour
{
    public Pushka pushka;

    private bool isFirstTouched = false;
    private bool isTouchedKoleso;

    private Touch touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            isFirstTouched = true;
            touch = Input.GetTouch(0);
        }

        if (Input.touchCount > 0)
        {
            isTouchedKoleso = isTouchedKoleso && Input.GetTouch(0).phase == TouchPhase.Moved;

            if (isTouchedKoleso)
            {
                Vector3 kolesoVP = Camera.main.WorldToViewportPoint(pushka.getKolesoPosition());
                Vector3 touchVP = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);

                pushka.move(touchVP.x > kolesoVP.x ? 1f : -1f);
            }
            else
            {
                pushka.move(0f);
            }
        }
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUILayout.BeginArea(new Rect(10, 10, 1000, 800));
        GUILayout.Label("rawPosition: " + touch.rawPosition.ToString("F3"));
        GUILayout.Label("position: " + touch.position.ToString("F3"));
        GUILayout.Label("deltaPosition: " + touch.deltaPosition.ToString("F3"));
        GUILayout.Label("fingerId: " + touch.fingerId);
        GUILayout.Label("pressure: " + touch.pressure.ToString("F3"));
        GUILayout.Label("phase: " + touch.phase.ToString());
        GUILayout.EndArea();
    }

    void FixedUpdate()
    {
        if (isFirstTouched)
        {
            isFirstTouched = false;

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
