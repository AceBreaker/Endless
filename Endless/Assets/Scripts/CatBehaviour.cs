using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : MonoBehaviour {

    //movement values
    [SerializeField]
    float moveSpeed = 0.0f;
    [SerializeField]
    float jumpForce = 0.0f;
    bool canJump = false;

    //score values
    float distanceTraveled = 0.0f;
    [SerializeField]
    int totalTreats = -1;
    int treatCount = 0;

    //reference values
    float startingPositionX = 0.0f;
    Rigidbody2D myRigidbody2d = null;


	// Use this for initialization
	void Start () {
        startingPositionX = transform.position.x;
        myRigidbody2d = GetComponent<Rigidbody2D>();
        totalTreats = GameObject.Find("TreatsParent").transform.childCount;
        myRigidbody2d.velocity = new Vector2(moveSpeed, myRigidbody2d.velocity.y);
    }
	
	// Update is called once per frame
	void Update () {
        HandleInput();
        UpdateDistance();
	}

    private void FixedUpdate()
    {
        
    }

    void UpdateDistance()
    {
        distanceTraveled = transform.position.x - startingPositionX;
    }

    void HandleInput()
    {
        if(Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            myRigidbody2d.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ground":
                canJump = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Complete":
                myRigidbody2d.velocity = Vector2.zero;
                GameManager.SetScore(treatCount);
                Destroy(gameObject);
                break;
            case "KillPlane":
                GameManager.StartOver();
                Destroy(gameObject);
                break;
            case "Treats":
                Destroy(collision.gameObject);
                treatCount++;
                break;
            default:
                break;
        }
    }
}
