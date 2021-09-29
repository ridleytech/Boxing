using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AimPunch : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	public bool touched;
	private int pointerID;
	public bool movingCursor;
	public GameObject cursor;
	public GameObject boxer;
	public float lastY;
	public float lastX;
	public float cursorSpeed = 3f;
	public float cursorDistance = 1f;

	void Awake () {

		direction = Vector2.zero;
		touched = false;
	}

	void Start () {

		lastY = cursor.transform.position.y;
		lastX = cursor.transform.position.x;
	}

	public void OnPointerDown (PointerEventData data) {

		if (!touched) 
		{
			touched = true;
			pointerID = data.pointerId;
			origin = data.position;
		}
	}

	void Update() {

		if(movingCursor){

			float newY = lastY + direction.y;
			float newX = lastX + direction.x;
			Vector3 cursorPosition = new Vector3(newX,newY,boxer.transform.position.z + cursorDistance);
			cursor.transform.position = Vector3.Lerp(cursor.transform.position, cursorPosition, cursorSpeed * Time.deltaTime);

			lastY = cursor.transform.position.y;
			lastX = cursor.transform.position.x;

		}
	}

	public void OnDrag (PointerEventData data) {

		if (data.pointerId == pointerID) 
		{
			Vector2 currentPosition = data.position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw.normalized;

			movingCursor = true;

			//print("direction: "+direction);
		}
	}

	public void OnPointerUp (PointerEventData data) {

		if (data.pointerId == pointerID) 
		{
			direction = Vector3.zero;

			touched = false;
			movingCursor = false;
		}
	}

	public Vector2 GetDirection () {

		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
		return smoothDirection;
	}
}