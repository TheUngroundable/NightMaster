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
    private bool deployTrap;

    //MOVEMENT
    private Vector3 moveVector;
    private float headingDirection;

    //MOVEMENT SCALAR
    public float playerSpeed;

    //GAME
    public bool hasPickable;
    public int hp = 100;
    public bool isSlowed = false;
    public bool hasTrap = false;
    public int playerNumber = 1;
    public float delayTime = 3.0f;
    public GameObject trap;
    void Start()
    {
        PlayerInit();
    }

    void Update()
    {
        GetInput();
        PlayerMovement();
        PlayerTurn();
        DeployTrap();
    }

    // PlayerInit take all components and set values
    void PlayerInit()
    {
        rb = GetComponent<Rigidbody>();
    }

    void GetInput()
    {
        lhAxis = Input.GetAxis(playerNumber + "LHorizontal");
        rhAxis = Input.GetAxis(playerNumber + "RHorizontal");
        lvAxis = Input.GetAxis(playerNumber + "LVertical");
        rvAxis = Input.GetAxis(playerNumber + "RVertical");
        deployTrap = Input.GetButtonDown(playerNumber+"Trap");
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
    
    public void SlowDown(int slowedSpeed, int delayTime)
    {
        StartCoroutine(slowPlayerDown(slowedSpeed,delayTime));
    }

    IEnumerator slowPlayerDown(int slowedSpeed,int delayTime)
    {
        float tempSpeed = playerSpeed;
        this.playerSpeed = slowedSpeed;

        yield return new WaitForSeconds(delayTime);
        this.isSlowed = false;
        playerSpeed = tempSpeed;
    }

    void DeployTrap()
    {
        if (deployTrap && hasTrap)
        {
            GameObject deployedTrap;
            deployedTrap = GameObject.Instantiate(trap,transform.position,new Quaternion(0,0,0,0));
            deployedTrap.GetComponent<Trap>().isDeployed = true;
            deployedTrap.GetComponent<Trap>().playerNumber = this.playerNumber;
            
            hasTrap = false;
        }
    }
}
