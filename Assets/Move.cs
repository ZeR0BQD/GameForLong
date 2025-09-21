using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;
    float horizontal;
    public float rotationSpeed = 10f;
    Transform modelChild;
    [SerializeField] private AudioClip audioClip;
    AudioSource audioSource;
    Animator animator;
    void Start()
    {
        modelChild = transform.GetChild(0);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        RotateModelSmooth();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(horizontal, 0, 0);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        AnimationForPlayer();
    }

    void RotateModelSmooth()
    {
        if (modelChild == null) return;

        Quaternion targetRotation = modelChild.rotation;

        if (horizontal > 0.01f)
        {
            targetRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (horizontal < -0.01f)
        {
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            return;
        }

        modelChild.rotation = Quaternion.RotateTowards(
            modelChild.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindAnyObjectByType<Score>().score += 1;
            AudioForPlayer();
            Destroy(collision.gameObject);
        }
    }

    void AudioForPlayer()
    {
        audioSource.PlayOneShot(audioClip);
    }

    void AnimationForPlayer()
    {
        if (animator != null)
        {
            if (math.abs(horizontal) > 0f)
            {
                animator.SetBool("moveState", true);
            }
            else
            {
                animator.SetBool("moveState", false);
            }
        }
        else
        {
            Debug.LogWarning("Animator component not found on the player.");
        }
    }
}

