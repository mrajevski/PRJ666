using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
    [SerializeField]
    private float currentValue;
    private float damage;
    private float maxValue;

    private bool armorState;

    public Text CurrentValueText;

    public GameObject player;

    private Animator animator;

    [SerializeField]
    private Image content;
	// Use this for initialization
	void Start () {
        armorState = true;
        currentValue = 100;
        damage = 0;
        maxValue = 100;
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        CurrentValueText.text = currentValue + "%";
        HandleBar();
        if (currentValue <= 0)
        {
            animator.SetBool("Dead", true);
            Destroy(player.GetComponent<PlayerMovement>());
            Destroy(player.GetComponent<playerShoot>());
        }
	}

    private void HandleBar()
    {
        if (!armorState) {
            content.fillAmount = Map(currentValue, damage, maxValue);
        }
        damage = 0;
    }
    public bool setArmorState(bool ar)
    {
        return armorState = ar;
    }
    public float setDamage(float d)
    {
        return currentValue = currentValue - d;
    }
    private float Map(float value, float damage, float MaxH)
    {
        return (value - damage) / MaxH;
    }
}
