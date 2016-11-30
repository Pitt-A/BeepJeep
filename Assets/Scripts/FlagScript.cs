using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FlagScript : MonoBehaviour {
    bool pickedUp = false;
    Vector3 tempPos;
    const float carryOffset = 0.4f;

    public AudioClip flagPickup;
    AudioSource audioComp;

    // Use this for initialization
    void Start ()
    {
        audioComp = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pickedUp == true)
        {
            FollowPlayer();
        }
    }

    void OnTriggerEnter2D()
    {
        pickedUp = true;
        audioComp.PlayOneShot(flagPickup, 0.7f);
    }

    void FollowPlayer()
    {
        tempPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        tempPos.y = tempPos.y + carryOffset;
        transform.position = tempPos;
    }
}
