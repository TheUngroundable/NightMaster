using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Public Variables (name order by a-Z)
    public float deadZone = 0.1f;
    public float gravity = 20.0f;
    public float speed = 2.0f;
    public float rotationSpeed = 2.0f;
	private float value = -90;

    private Vector3 rotation;
    public string leftHorizontalAxis = "Horizontal";
    public string leftVerticalAxis = "Vertical";

    // Private Variables (name order by a-Z)
    private CharacterController controller;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start(){
        controller = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        gameObject.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
		
	}

    // Update is called once per frame
    void Update(){
        Movement();
    }

    void Movement(){

        if (controller.isGrounded) {
            if (Mathf.Abs(Input.GetAxis(leftHorizontalAxis)) > deadZone || Mathf.Abs(Input.GetAxis(leftVerticalAxis)) > deadZone) {
                moveDirection = new Vector3(Input.GetAxis(leftHorizontalAxis), 0.0f, Input.GetAxis(leftVerticalAxis));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;
            }else{
				moveDirection = new Vector3(0, 0, 0);
			}
        }
		
		if (Mathf.Abs(Input.GetAxis("R" + leftHorizontalAxis)) > deadZone || Mathf.Abs(Input.GetAxis("R" + leftVerticalAxis)) > deadZone) {
			rotation = new Vector3(Input.GetAxis("R" + leftHorizontalAxis), 0, Input.GetAxis("R" + leftVerticalAxis));
			transform.rotation = Quaternion.LookRotation(rotation);
		}

		// Apply gravity
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
		
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
    }
}

