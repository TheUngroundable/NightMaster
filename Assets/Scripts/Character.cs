using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Public Variables (name order by a-Z)

    //Movement Attributes
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public Vector3 oldPosition;
    public Vector3 direction;
    //Controller Attributes
    public float deadZone = 0.5f;
    private float LxDirection;
    private float RxDirection;
    private float LzDirection;
    private float RzDirection;

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

        var x = Input.GetAxis("LHorizontal");
        var y = Input.GetAxis("LVertical");


        Move(x, y);

        if (Mathf.Abs(Input.GetAxis("RHorizontal")) >= deadZone || Mathf.Abs(Input.GetAxis("RVertical")) >= deadZone)
        {
            RxDirection = Input.GetAxis("RHorizontal") * rotationSpeed;
            RzDirection = Input.GetAxis("RVertical") * rotationSpeed;

        }

        Vector3 targetRotation = new Vector3(RxDirection, 0, RzDirection);
        transform.rotation = Quaternion.LookRotation(targetRotation);
    }

    void Move(float x, float y)
    {


        /*transform.position += (Vector3.forward * speed) * y * Time.deltaTime;
        transform.position += (Vector3.right * speed) * x * Time.deltaTime;*/
        Vector3 movementDirection = new Vector3(x * speed * Time.deltaTime, 0, y * speed * Time.deltaTime);
        transform.Translate(movementDirection, Space.World);
        
    }


    void Debuff()
    {
        //viene rallentato
    }
}

