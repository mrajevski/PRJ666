using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float currentValue;
    private float damage;
    private float maxValue;
    private bool armorState;
    private bool isDead;
    private double counter;
    public bool posionState;
    public Text CurrentValueText;

    public GameObject player;

    private playerHealth health;

    private Animator animator;

    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
        isDead = false;
        counter = 0;
        posionState = false;
        armorState = true;
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<playerHealth>();
        currentValue = health.getHealth();
        maxValue = health.getHealth();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if(isDead)
            counter += Time.deltaTime + 0.1;

        if (counter >= 35 && counter <= 36)
            SceneManager.LoadScene("dead");

        currentValue = health.health;
        CurrentValueText.text = (int)currentValue + "%";
        HandleBar();
        if (currentValue <= 0)
        {
            isDead = true;
            animator.SetBool("Dead", true);
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<playerShoot>().enabled  = false;
        }
        else
        {
            isDead = false;
            animator.SetBool("Dead", false);
        }
    }

    private void HandleBar() {
        if (!armorState || posionState) {
            content.fillAmount = Map(currentValue, maxValue);
        }
    }

    public bool setArmorState(bool ar) {
        return armorState = ar;
    }
    private float Map(float value, float MaxH) {
        return (value) / MaxH;
    }
}
