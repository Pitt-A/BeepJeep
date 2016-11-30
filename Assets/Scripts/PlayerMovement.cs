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

    public int direction;
    public int playerNo;


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

        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);

        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, mask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
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

        if (playerNo == 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                setDirection(stringDirection("left"));
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                setDirection(stringDirection("right"));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                setDirection(stringDirection("up"));
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                setDirection(stringDirection("down"));
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
        else if (playerNo == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                setDirection(stringDirection("left"));
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                setDirection(stringDirection("right"));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                setDirection(stringDirection("up"));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                setDirection(stringDirection("down"));
            }
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Speed(true);
            }
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Speed(false);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "corner")
        {
            setDirection(newDirection());

            GameObject resetLocation =  coll.transform.FindChild("resetLoc").gameObject;


            transform.position = resetLocation.transform.position;



            
        }
    }


    void setDirection(int dir)
    {
        switch(dir)
        {
            default: //Default - Up
            case 0: //0 - UP
                direction = 0;
                playerSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                break;

            case 1: //1 - RIGHT
                direction = 1;
                playerSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                break;

            case 2: //2 - DOWN
                direction = 2;
                playerSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
                break;

            case 3: //3 - LEFT
                direction = 3;
                playerSprite.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                break;
        }
    }

    int newDirection()
    {
        int playerDir = 1;

        if(playerNo == 0)
        {
            playerDir = -1;
        }

        int newDirection = direction + playerDir;

        if(newDirection < 0)
        {
            newDirection = 3;
        }

        if (newDirection > 3)
        {
            newDirection = 0;
        }

        return newDirection;
    }

    int stringDirection(string direction)
    {
        if(direction == "up")
        {
            return 0;
        }

        if (direction == "right")
        {
            return 1;
        }

        if (direction == "down")
        {
            return 2;
        }

        if (direction == "left")
        {
            return 3;
        }

        return 0;
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