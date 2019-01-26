using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //COMPONENTS
    private Rigidbody rb;

    //DEBUG
    public bool debugInput;
    public bool debugMovement;
    public bool debugRotation;
    public bool debugStat;

    //INPUTS
    private float lhAxis;
    private float rhAxis;
    private float lvAxis;
    private float rvAxis;

    //MOVEMENT
    private Vector3 moveVector;
    private float headingDirection;

    //MOVEMENT SCALAR
    public float playerSpeed;

    //GAME
    public int point;

    void Start()
    {
        PlayerInit();
    }

    void Update()
    {
        GetInput();
        PlayerMovement();
        PlayerTurn();
        if (debugStat)
        {
            Debug.Log(point);
        }
    }

    // PlayerInit take all components and set values
    void PlayerInit()
    {
        rb = GetComponent<Rigidbody>();
    }

    void GetInput()
    {
        lhAxis = Input.GetAxis("1LHorizontal");
        rhAxis = Input.GetAxis("1RHorizontal");
        lvAxis = Input.GetAxis("1LVertical");
        rvAxis = Input.GetAxis("1RVertical");

        if (debugInput)
        {
            Debug.Log("left horizontal axis : " + lhAxis);
            Debug.Log("right horizontal axis : " + rhAxis);
            Debug.Log("left vertical axis : " + lvAxis);
            Debug.Log("right vertical axis : " + rvAxis);
        }
    }

    void PlayerMovement()
    {
        moveVector = new Vector3(lhAxis * playerSpeed, 0, lvAxis * playerSpeed);
        rb.AddForce(moveVector);
    }

    void PlayerTurn()
    {
        if(Mathf.Abs(rhAxis) > 0 || (Mathf.Abs(rvAxis) > 0))
        {
            headingDirection = Mathf.Atan2(rhAxis,rvAxis);
            transform.rotation = Quaternion.Euler(0, headingDirection * Mathf.Rad2Deg,0);
            if (debugRotation)
            {
                Debug.Log("headingDirection :" + headingDirection);
            }
        }
    }
}
