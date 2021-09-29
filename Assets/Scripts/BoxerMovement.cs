using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerMovement : MonoBehaviour
{
    public Animator anim;
    public float right;
    public float forward;
    public VariableJoystick variableJoystick;
    public float lastH;
    public float lastV;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // right = Input.GetAxis("Horizontal");
        // forward = Input.GetAxis("Vertical");


        if(variableJoystick.Vertical != lastV || variableJoystick.Horizontal != lastH){

//        print("v: "+variableJoystick.Vertical + " h: " + variableJoystick.Horizontal);


            anim.SetFloat("Right",variableJoystick.Horizontal);
            anim.SetFloat("Forward",variableJoystick.Vertical);
        }

        lastH = variableJoystick.Horizontal;
        lastV = variableJoystick.Vertical;
    }
}
