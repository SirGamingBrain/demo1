using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollow : MonoBehaviour
{
    Camera main;
    GameObject player;
    protected Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        main = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

        main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15f, player.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovement>().alive == true) {
            main.transform.position = new Vector3((player.transform.position.x + joystick.Horizontal * 2f), player.transform.position.y + 15f, player.transform.position.z + joystick.Vertical * 2f);
        }
    }
}
