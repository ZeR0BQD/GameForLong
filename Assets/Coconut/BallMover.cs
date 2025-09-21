using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 5f;
    public void Init(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Destroy(gameObject, 3f);
    }
}
