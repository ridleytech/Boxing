using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class BoxerMovement2 : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	public bool touched;
	private int pointerID;
	public bool movingCursor;
	//public GameObject boxer;
	public float lastY;
	public Animator anim;


	void Awake () {

		direction = Vector2.zero;
		touched = false;
	}

	void Start () {}

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

			anim.SetFloat("Right",direction.x);
            anim.SetFloat("Forward",direction.y);
		}
		else
		{
			anim.SetFloat("Right",0f);
            anim.SetFloat("Forward",0f);
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