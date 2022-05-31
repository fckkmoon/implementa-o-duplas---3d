using UnityEngine;

public class Player : MonoBehaviour {
  
    bool alive = true;

    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float forwardSpeed = 6f;
    float strafeSpeed = 6f;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    void Start() {

         if (!alive) return;
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    void Update() {

        if (transform.position.y < -5) {
            Die();
        }

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // force = input * speed * direction
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;

        if(controller.isGrounded) {
            vertical = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }

         Vector3 finalVelocity = forward + strafe + vertical;

         controller.Move(finalVelocity * Time.deltaTime);

         horizontalInput = Input.GetAxis("Horizontal");

         

    }

    public void Die ()
    {
        alive = false;
        // Restart the game
        Invoke("Restart", 2);
    }

    
}

