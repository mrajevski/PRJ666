using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBarScript : MonoBehaviour {
    [SerializeField]
    private float currentValue;
    private float damage;
    private float maxValue;

    public Text CurrentValueText;

    public BarScript health;


    [SerializeField]
    private Image content;
    // Use this for initialization
    void Start()
    {
        health = FindObjectOfType<BarScript>();
        currentValue = 100;
        damage = 0;
        maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentValueText.text = currentValue + "%";
        HandleBar();
        if (currentValue <= 0)
        {
            health.setArmorState(false);
        }
        else
        {
            health.setArmorState(true);
        }
    }

    public float gainHealth(float hpGain)
    {
        return currentValue += hpGain;
    }
    private void HandleBar()
    {
        content.fillAmount = Map(currentValue, damage, maxValue);
        damage = 0;
    }

    public float setDamage(float v, float d)
    {
        v = v - d;
        return currentValue = v;
    }
    private float Map(float value, float damage, float MaxH)
    {
        return setDamage(value, damage) / MaxH;
    }
}
