using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    float buttonA;
    float buttonB;
    float horizontalAxis;
    float verticalAxis;
    float buttonSelect;
    float buttonStart;

    float keyLeft;
    float keyRight;
    float keyUp;
    float keyDown;
    float keySpeed;
    float keySlow;

    public GameObject player;
    public float playerSpeed;

    Rigidbody2D rb2d;
    BoxCollider2D box2d;
    SpriteRenderer playerSprite;

    public bool isGrounded;
    bool facingRight;
    bool facingLeft;
    bool facingUp;
    bool facingDown;
    public LayerMask mask;

   public float currentSpeed = 1.0f;

    Vector2 currentDirection;
    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        buttonA = Input.GetAxis("ButtonA");
        buttonB = Input.GetAxis("ButtonB");
        horizontalAxis = Input.GetAxis("HorizontalAxis");
        verticalAxis = Input.GetAxis("VerticalAxis");
        buttonSelect = Input.GetAxis("ButtonSelect");
        buttonStart = Input.GetAxis("ButtonStart");

        keyLeft = Input.GetAxis("LeftKey");
        keyRight = Input.GetAxis("RightKey");

        transform.Translate(currentDirection * currentSpeed * Time.deltaTime);

        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, mask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (horizontalAxis >= 0.05f)
        {
            Direction(true, false, false, false);
        }

        if (horizontalAxis <= -0.05f)
        {
            Direction(false, true, false, false);
        }

        if (verticalAxis <= -0.05f)
        {
            Direction(false, false, true, false);
        }

        if (verticalAxis >= 0.05f)
        {
            Direction(false, false, false, true);
        }





        if (buttonA >= 1.0f && rb2d.velocity.y == 0)
        {
            if (isGrounded == true)
            {
                rb2d.AddForce(Vector2.up * 150);
            }
        }

        if (buttonB >= 1.0f)
        {
            //create bullet class similar to GUN FURY and then instnatiate here pls b0ss
        }

        if (buttonSelect >= 1.0f)
        {

        }

        if (buttonStart >= 1.0f)
        {

        }

        if (Input.GetKeyDown(KeyCode.A))
        {       
            Direction(false, true, false, false);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {         
            Direction(true, false, false, false);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Direction(false, false, true, false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Direction(false, false, false, true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed(true);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed(false);
        }
    }



    void Direction(bool right, bool left, bool up, bool down)
    {
        facingRight = right;
        facingLeft = left;
        facingUp = up;
        facingDown = down;

        if(facingRight == true)
        {
            currentDirection = Vector2.right;
        }
        if (facingLeft == true)
        {
            currentDirection = Vector2.left;
        }
        if (facingUp == true)
        {
            currentDirection = Vector2.up;
        }
        if (facingDown == true)
        {
            currentDirection = Vector2.down;
        }
        

    }

    void Speed(bool accelerate)
    {
        if(accelerate)
        {
            currentSpeed += 1;
        }
        else if(!accelerate)
        {
            currentSpeed -= 1;
        }
    }
    
}