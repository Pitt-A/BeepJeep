using UnityEngine;
using System.Collections;

public class AutoMenu : MonoBehaviour {
    public GameObject car;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        car.transform.Translate(Vector2.right * 2 * Time.deltaTime);
    }
}
