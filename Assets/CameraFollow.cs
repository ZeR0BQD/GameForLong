using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float offsetCam = 3f;
    public float offsetPlayer = 2f;
    public Transform player;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ApplyOffset();
    }

    void Update()
    {
        transform.position = new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z - offsetCam
        );
        transform.LookAt(player.position + new Vector3(0, offsetPlayer, 0));
    }

    [ContextMenu("Update Offset")]
    void ApplyOffset()
    {
        transform.position = new Vector3(
            player.position.x,
            transform.position.y,
            player.position.z - offsetCam
        );
    }
}
