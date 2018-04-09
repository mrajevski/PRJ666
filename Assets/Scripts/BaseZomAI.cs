using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseZomAI : MonoBehaviour {
    
    public float speed;
    private Rigidbody rb;
    private bool moving;
    public float stillTime;
    private float stillCounter;
    public float moveTime;
    private float moveCounter;
    private Vector3 moveDir;
    public bool still;
    public Animator animator;
    public GameObject player;
    public float minDist;
    private float dir;
    public playerHealth playerDamage;
    public int damageTime = 7;
    private int damageCounter;
    private int ranX, ranY;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        //playerDamage = GetComponent<playerHealth>();
        playerDamage = Object.FindObjectOfType<playerHealth>();
        //playerDamage = new playerHealth();
        damageCounter = damageTime;
        rb = GetComponent<Rigidbody>();

        //gets how long the enemy should take to move and for how long when idle
        stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
        moveCounter = Random.Range (moveTime * 0.75f, moveTime * 1.25f);
        moving = false;

	}
	
	// Update is called once per frame
	void Update () {
        if(still)
            animator.SetBool("idle", true);
        //if the player gets too close, then the enemy chases the player
        if (Vector3.Distance(rb.transform.position, player.transform.position) < minDist) {

            if (still) {
                animator.SetBool("idle", false);
            }

            //look at player
            transform.LookAt(player.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            //chase player
            if(playerDamage.health > 0 && (Vector3.Distance(rb.transform.position, player.transform.position) > .55f))
                transform.Translate(new Vector3((speed) * Time.deltaTime, 0, 0));
            
        } else if (still == false) {//if not then the enemy is idle
            //checks if enemy should be moving when idle
            if (moving) {
                animator.SetBool("idle", false);

                //makes them move for a certain amount of time
                moveCounter -= Time.deltaTime;
                transform.Translate(moveDir * (speed - 0.5f) * Time.smoothDeltaTime, Space.World);
                //adjusts the enemy direction they are facing
                dir = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);

                //after they move for a certain amount of time, make them stop moving and reset the stop time
                if (moveCounter < 0f) {
                    moving = false;
                    stillCounter = Random.Range(stillTime * 0.75f, stillTime * 1.25f);
                }

            } else { //makes enemy stop for a certain amount of time
                animator.SetBool("idle", true);
                stillCounter -= Time.deltaTime;
                rb.velocity = Vector2.zero;
                //after theyre still for a certain time, set the moving bool to be true so they move
                if (stillCounter < 0f) {
                    moving = true;
                    moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                    //make them move in a random direction
                    ranX = Random.Range(-1, 2);
                    ranY = Random.Range(-1, 2);
                    moveDir = new Vector3(ranX , ranY, 0f);
                }
            }
        }

        //if player is too close then hit
        if ((Vector3.Distance(rb.transform.position, player.transform.position) < .55f) && playerDamage.getHealth() >= 0)
        {
            --damageCounter;
            if(damageCounter == 0)
            {
                playerDamage.takeDamage(Random.Range(5, 10));
                damageCounter = damageTime;
            }
        }
    }
}
