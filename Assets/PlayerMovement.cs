using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // ----- MOVEMENT INPUT -----
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(x, 0f, z);
        Vector3 move = transform.TransformDirection(input);

        controller.Move(move * speed * Time.deltaTime);

        // ----- GROUND CHECK -----
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // ----- JUMP -----
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // ----- GRAVITY -----
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
