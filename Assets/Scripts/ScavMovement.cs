using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavMovement : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private bool moving;
    public float stillTime;
    private float stillCounter;
    public float moveTime;
    private float moveCounter;
    private Vector3 moveDir;

    public GameObject player;
    public Transform zone;
    public float minDist;
    private float dir;
    public float zoneSize;
    private int above, below;

    private float xDir;
    private float yDir;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        zone = GameObject.FindGameObjectWithTag("ScavZone").transform;
        rb = GetComponent<Rigidbody>();

        //gets how long the enemy should take to move and for how long when idle
        stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
        moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
        moving = false;

    }
	
	// Update is called once per frame
	void Update () {
        //if the player gets too close, then the enemy lookks at the player
        if (Vector3.Distance(rb.transform.position, player.transform.position) < minDist)
        {
            //look at player
            transform.LookAt(player.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
        }
        else {//if not then the enemy is idle
            //checks if enemy should be moving when idle
            if (moving)
            {
                //makes them move for a certain amount of time
                moveCounter -= Time.deltaTime;
                transform.Translate(moveDir * (speed - 0.5f) * Time.smoothDeltaTime, Space.World);
                //adjusts the enemy direction they are facing
                dir = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);

                //after they move for a certain amount of time, make them stop moving and reset the stop time
                if (moveCounter < 0f)
                {
                    moving = false;
                    stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
                }

            }
            else
            { //makes enemy stop for a certain amount of time
                stillCounter -= Time.deltaTime;
                rb.velocity = Vector2.zero;
                //after theyre still for a certain time, set the moving bool to be true so they move
                if (stillCounter < 0f)
                {
                    moving = true;
                    moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                    //make them move in a random direction
                    //if (Vector3.Distance(rb.position, zone.position) > zoneSize)
                    if (rb.position.x - zone.position.x > zoneSize || rb.position.y - zone.position.y > zoneSize ||
                        zone.position.x - rb.position.x > zoneSize || zone.position.y - rb.position.y > zoneSize)
                    {
                        if (zone.position.x - rb.position.x > 0)
                            xDir = 1f;
                        else
                            xDir = -1f;
                        if (zone.position.y - rb.position.y > 0)
                            yDir = 1f;
                        else
                            yDir = -1f;
                        moveDir = new Vector3(xDir * speed, yDir * speed, 0f);
                    }
                    else
                        moveDir = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0f);
                }
            }
        }
    }
}
