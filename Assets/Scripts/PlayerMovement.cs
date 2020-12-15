using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	
	private CharacterController controller; // Instantiate Controller
    private Vector3 moveVector; // Instantiate move vector
    public GameObject player;

    private float speed = 5.0f; // Instantiate Speed as float
    private float verticalVelocity = 0.0f; // Instantiate Velocity as float
    private float gravity = 10.0f; // Instantiate Velocity as float
    private float animationDuration = 2.0f;
    private float startTime;

    private bool isDead = false;
    // Use this for initialization
    void Start () 
	{
		controller = GetComponent<CharacterController> ();
        player = GameObject.FindGameObjectWithTag("Player");
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (isDead)
        {
            return;
        }

        // Disable movement until animation is done
        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero; // Vector is 0

        // Add gravity to ball
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        //X Axis - Left & Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; // Player moves with Horizontal Input
        if (Input.GetMouseButton (0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
        }

        //Y Axis - Up & Down
        moveVector.y = verticalVelocity; // Player drops with gravity
        //Z - Axis Forward & Back
        moveVector.z = speed; // Z is locked 

        controller.Move (moveVector * Time.deltaTime); // Infinite Running

        if (player.transform.position.y <= -5)
        {
            Death();
        }
    }


    //On collision, death function is activated.
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if (hit.point.z > transform.position.z + controller.radius)
        {
            Death();
        }
    }

    // Change Speed modifier
    public void SetSpeed(int modifier)
    {
        speed = 5.0f + modifier;
    }

    // Death is occured
    public void Death()
    {
        isDead = true;

        GetComponent<Score>().OnDeath();
    }
}
