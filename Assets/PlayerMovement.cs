using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    float buttonA;
    float buttonB;
    float horizontalAxis;
    float verticalAxis;
    float buttonSelect;
    float buttonStart;

    public GameObject player;
    public float playerSpeed;

    Rigidbody2D rb2d;
    BoxCollider2D box2d;
    SpriteRenderer playerSprite;

    public bool isGrounded;
    bool facingRight;
    public LayerMask mask;
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        buttonA = Input.GetAxis("ButtonA");
        buttonB = Input.GetAxis("ButtonB");
        horizontalAxis = Input.GetAxis("HorizontalAxis");
        verticalAxis = Input.GetAxis("VerticalAxis");
        buttonSelect = Input.GetAxis("ButtonSelect");
        buttonStart = Input.GetAxis("ButtonStart");


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
            player.transform.position += Vector3.right * playerSpeed;
            facingRight = true;
        }
      

        if (horizontalAxis <= -0.05f)
        {
            player.transform.position += Vector3.left * playerSpeed;
            facingRight = false;
        }
      

        if (verticalAxis >= 0.05f)
        {
           
        }
        

        if (verticalAxis <= -0.05f )
        {
            
           
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
    }
}
