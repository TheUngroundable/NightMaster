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

    private Vector3 rotation;
    private string leftHorizontalAxis = "LHorizontal";
    private string leftVerticalAxis = "LVertical";

    private string rightHorizontalAxis = "RHorizontal";
    private string rightVerticalAxis = "RVertical";

    // Private Variables (name order by a-Z)
    private CharacterController controller;
    private Vector3 moveDirection;

    public Torch torcia;
    

    // Start is called before the first frame update
    void Start(){
        controller = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
        gameObject.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
	}

    // Update is called once per frame
    void Update(){
        Movement();

        if (Input.GetButtonDown("Fire1"))
        {
            torcia.Toggle();
        }
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
		
		if (Mathf.Abs(Input.GetAxis(rightHorizontalAxis)) > deadZone || Mathf.Abs(Input.GetAxis(rightVerticalAxis)) > deadZone) {
            Debug.Log("Rotate");
            rotation = new Vector3(Input.GetAxis(rightHorizontalAxis), 0, Input.GetAxis(rightVerticalAxis));
			transform.rotation = Quaternion.LookRotation(rotation);
		}

		// Apply gravity
		moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
		
		// Move the controller
		controller.Move(moveDirection * Time.deltaTime);
    }

    void Debuff()
    {
        //viene rallentato
    }
}

