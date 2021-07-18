using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTimeSeconds = 300f;

    void Start()
    {
        Destroy(gameObject, lifeTimeSeconds);
    }
}
