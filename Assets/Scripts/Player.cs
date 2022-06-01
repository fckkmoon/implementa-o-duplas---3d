using UnityEngine;
 using UnityEngine.SceneManagement; 

public class Player : MonoBehaviour {
  
    bool alive = true;
    
    Vector3 vertical;
    public float velocidade = 0.01f;
    Vector3 m;
    CharacterController controller;

    

    

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;


    void Movimento(Vector3 m)
    {
		transform.Translate(m);

	}

    void Start() {

        if (!alive) return;
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

        m.x = 0.0f;
	    m.y = 0.0f;
	    m.z = 0.0f;

    }

    void Update() {

        if (Input.GetKey (KeyCode.W)) {
			m.x = -velocidade;
			Movimento(m);
			m.z = 0.0f;
			m.y = 0.0f;
   }  
        if (Input.GetKey (KeyCode.S)) {

			m.x = velocidade;
			Movimento(m);
			m.z = 0.0f;
			m.y = 0.0f;

		}  
        if (Input.GetKey (KeyCode.D)) {
			m.z = velocidade;
			Movimento(m);
			m.y = 0.0f;
			m.x = 0.0f;
			
		}  
        if (Input.GetKey (KeyCode.A)) {
			m.z = -velocidade;
			Movimento(m);
			m.y = 0.0f;
			m.x = 0.0f;
		}
        if (transform.position.y < -5) {
            Die();
        }

        

        if(controller.isGrounded) {
            vertical = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            vertical = jumpSpeed * Vector3.up;
        }

        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }

        

         

    }

    
    public void Die()
    {
        
        alive = false;
        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        Debug.Log(alive);
    }


    
}

