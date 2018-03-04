using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZomAI : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private bool moving;
    public float stillTime;
    private float stillCounter;
    public float moveTime;
    private float moveCounter;
    private Vector3 moveDir;
    public bool still;

    public Transform player;
    public float minDist;
    private float dir;

    // Use this for initialization
    void Start () {

        //player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();

        //gets how long the enemy should take to move and for how long when idle
        stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
        moveCounter = Random.Range (moveTime * 0.75f, moveTime * 1.25f);
        moving = false;

	}
	
	// Update is called once per frame
	void Update () {

        //if the player gets too close, then the enemy chases the player
        if (Vector3.Distance(rb2d.transform.position, player.transform.position) < minDist) {
        //look at player
        transform.LookAt(player.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //chase player
        transform.Translate(new Vector3((speed + 1) * Time.deltaTime, 0, 0));
        } else if (still == false) {//if not then the enemy is idle
            //checks if enemy should be moving when idle
            if (moving) {
                //makes them move for a certain amount of time
                moveCounter -= Time.deltaTime;
                transform.Translate(moveDir * Time.deltaTime, Space.World);
                //adjusts the enemy direction they are facing
                dir = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);

                //after they move for a certain amount of time, make them stop moving and reset the stop time
                if (moveCounter < 0f) {
                    moving = false;
                    stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
                }

            } else { //makes enemy stop for a certain amount of time
                stillCounter -= Time.deltaTime;
                rb2d.velocity = Vector2.zero;
                //after theyre still for a certain time, set the moving bool to be true so they move
                if (stillCounter < 0f) {
                    moving = true;
                    moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                    //make them move in a random direction
                    moveDir = new Vector3(Random.Range(-1f, 1f) * speed, Random.Range(-1f, 1f) * speed, 0f);
                }
            }
        }
    }
}
