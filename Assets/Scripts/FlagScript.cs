using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class FlagScript : MonoBehaviour
{
    bool pickedUp = false;
    Vector3 tempPos;
    const float carryOffset = 0.4f;
    int spawnCorner, posX, posY;
    public int player;
    Vector3 spawn1, spawn2, spawn3, spawn4;

    public AudioClip flagPickup;
    AudioSource audioComp;

    // Use this for initialization
    void Start()
    {
        audioComp = GetComponent<AudioSource>();

        setupSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            FollowPlayer();
        }
    }

    void setupSpawn()
    {
        spawnCorner = Random.Range(1, 5);
        posX = Random.Range(1, 3);
        posY = Random.Range(1, 3);

        spawn1 = new Vector3(5.2f, 4.3f, 0.0f);
        spawn2 = new Vector3(4.3f, 3.47f, 0.0f);
        spawn3 = new Vector3(3.45f, 2.6f, 0.0f);
        spawn4 = new Vector3(2.6f, 1.73f, 0.0f);

        if (posX == 2)
        {
            spawn1.x = spawn1.x * -1;
            spawn2.x = spawn2.x * -1;
            spawn3.x = spawn3.x * -1;
            spawn4.x = spawn4.x * -1;
        }

        if (posY == 2)
        {
            spawn1.y = spawn1.y * -1;
            spawn2.y = spawn2.y * -1;
            spawn3.y = spawn3.y * -1;
            spawn4.y = spawn4.y * -1;
        }

        switch (spawnCorner)
        {
            case 1:
                transform.position = spawn1;
                break;
            case 2:
                transform.position = spawn2;
                break;
            case 3:
                transform.position = spawn3;
                break;
            case 4:
                transform.position = spawn4;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (pickedUp == false)
        {
            if (coll.tag == "Player")
            {
                player = 1;
            }
            else if (coll.tag == "Player2")
            {
                player = 2;
            }
            pickedUp = true;
            audioComp.PlayOneShot(flagPickup, 0.7f);
        }
    }

    void FollowPlayer()
    {
        if (player == 1)
        {
            tempPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            tempPos.y = tempPos.y + carryOffset;
            transform.position = tempPos;
        }
        else if (player == 2)
        {
            tempPos = GameObject.FindGameObjectWithTag("Player2").transform.position;
            tempPos.y = tempPos.y + carryOffset;
            transform.position = tempPos;
        }
    }
}
