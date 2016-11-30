using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public GameObject flag;
    public float playerSpeed;
    public Text scoreText;

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
    public int lane;

    public bool switchable;
    public string changeloc;

    public float currentSpeed = 1.0f;

    public float score;

    Vector2 currentDirection;
    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        score = 0.0f;
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


        FlagScript flagScript = flag.GetComponent<FlagScript>();

       if (flagScript.player - 1 == playerNo)
        {
            score += Time.deltaTime;
            scoreText.text = "PLAYER " + (playerNo+1).ToString() + ": " +  Mathf.FloorToInt(score).ToString();
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
                changeLane(3);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                changeLane(1);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                changeLane(0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                changeLane(2);
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
                changeLane(3);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                changeLane(1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                changeLane(0);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                changeLane(2);
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
        if (coll.gameObject.tag == "AC" || coll.gameObject.tag == "C")
        {

            if ((playerNo == 0 && coll.gameObject.tag == "AC") || (playerNo == 1 && coll.gameObject.tag == "C"))
            {
                setDirection(newDirection());
                GameObject resetLocation = coll.transform.FindChild("resetLoc").gameObject;
                transform.position = resetLocation.transform.position;
            }

        }

        if (coll.gameObject.tag == "laneswitch")
        {
            changeloc = coll.gameObject.name;
            switchable = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "laneswitch")
        {
            changeloc = "";
            switchable = false;
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

    void changeLane(int dir)
    {
        if (changeloc == "RightSwitch")
        {
            if (dir == 1)
            {
                lane++;
            }
            else if (dir == 3)
            {
                lane--;
            }
        }
        else if (changeloc == "LeftSwitch")
        {
            if (dir == 1)
            {
                lane--;
            }
            else if (dir == 3)
            {
                lane++;
            }
        }
        else if (changeloc == "TopSwitch")
        {
            if (dir == 0)
            {
                lane++;
            }
            else if (dir == 2)
            {
                lane--;
            }
        }
        else if (changeloc == "BottomSwitch")
        {
            if (dir == 0)
            {
                lane--;
            }
            else if (dir == 2)
            {
                lane++;
            }
        }







        //If in a valid lane and is in a switch
        if ((lane >= 1 && lane <= 4) && switchable)
        {
            //If going up or down (Right or Left switchable)
            if ((direction == 0 || direction == 2))
            {
                GameObject goSwitch = GameObject.Find(changeloc).gameObject;
                GameObject laneAlign = goSwitch.transform.FindChild("Lane" + lane.ToString()).gameObject;
                transform.position = new Vector2(laneAlign.transform.position.x, transform.position.y);
            }
            //If going left or right (Top or Bottom switchable)
            else if ((direction == 1 || direction == 3))
            {
                GameObject goSwitch = GameObject.Find(changeloc).gameObject;
                GameObject laneAlign = goSwitch.transform.FindChild("Lane" + lane.ToString()).gameObject;
                transform.position = new Vector2(transform.position.x, laneAlign.transform.position.y);
            }
        }

        //INVALID LANE SWITCH KILL PLAYER
        if (lane < 1 || lane > 4 || !switchable)
        {
            //EXPLODE PLAYER - INVALID LANE CHANGE
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