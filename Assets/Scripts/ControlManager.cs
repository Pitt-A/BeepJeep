using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlManager : MonoBehaviour {


    float buttonA; 
    float buttonB;
    float horizontalAxis;
    float verticalAxis;
    float buttonSelect;
    float buttonStart;

    public Button btnUp;
    public Button btnDown;
    public Button btnLeft;
    public Button btnRight;

    public Button btnA;
    public Button btnB;

    public Button btnStart;
    public Button btnSelect;


    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        buttonA         = Input.GetAxis("ButtonA");
        buttonB         = Input.GetAxis("ButtonB");
        horizontalAxis  = Input.GetAxis("HorizontalAxis");
        verticalAxis    = Input.GetAxis("VerticalAxis");
        buttonSelect    = Input.GetAxis("ButtonSelect");
        buttonStart     = Input.GetAxis("ButtonStart");

        Debug.Log(horizontalAxis);




    }
}
