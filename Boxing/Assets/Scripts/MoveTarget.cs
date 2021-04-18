using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public VariableJoystick variableJoystick;
	//public bool movingCursor;
	public GameObject cursor;
	public GameObject boxer;
	public float lastY;
	public float cursorSpeed = 3f;

    // Start is called before the first frame update
    void Start () {

		lastY = cursor.transform.position.y;
	}

    // Update is called once per frame
    void FixedUpdate()
    {

        if(variableJoystick.Vertical != 0 || variableJoystick.Horizontal != 0){

			float newY = lastY + variableJoystick.Vertical;
			Vector3 cursorPosition = new Vector3(variableJoystick.Horizontal,newY,boxer.transform.position.z + 1f);
			cursor.transform.position = Vector3.Lerp(cursor.transform.position, cursorPosition, cursorSpeed * Time.deltaTime);
		}
    }
}
