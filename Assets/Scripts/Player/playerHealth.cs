using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public static playerHealth healthController;

    public float health = 100;
    public float armor = 100;

    private void Start()
    {
        health = 100;
        armor = 100;
    }

    void Awake()
    {
        if(healthController == null)
        {
            DontDestroyOnLoad(gameObject);
            healthController = this;
        }
        else if (healthController != this)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update() {
        if (health < 0) {
            //this.gameObject.SetActive(false);
        }
    }

    public float getHealth()
    {
        return health;
    }

    public float getArmor()
    {
        return armor;
    }

	public void takeDamage(int damage) {

        if (armor <= 0)
            health -= damage;
        else
            armor -= damage;

        if (health <= 0)
            health = 0;
        if (armor <= 0)
            armor = 0;
    }
}
