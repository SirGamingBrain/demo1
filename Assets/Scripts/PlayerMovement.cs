using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    protected Joybutton joybutton;
    protected float x;
    protected float y;
    protected float z;

    //protected bool something;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 25f + Input.GetAxis("Horizontal") * 25f, 0, joystick.Vertical * 25f + Input.GetAxis("Vertical") * 25f);

        if (joystick.Vertical > 0f)
        {
            z = (joystick.Horizontal * 90f);
        }
        else if (joystick.Vertical == 0f)
        {
            z = 0;
        }
        else
        {
            if (joystick.Horizontal > 0f)
            {
                z = (90f) + (joystick.Vertical * -90f);
            }
            else
            {
                z = (-90f) + (joystick.Vertical * 90f);
            }
        }

        this.transform.eulerAngles = new Vector3(0,z, 0);

        /*if (!something && (joybutton.Pressed || Input.GetButton("Fire2")))
        {
            jump = true;
        }

        if (something && (!joybutton.Pressed || Input.GetButton("Fire2")))
        {
            something = false;
        }*/
    }
}
