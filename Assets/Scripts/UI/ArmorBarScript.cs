using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBarScript : MonoBehaviour {
    [SerializeField]
    private float currentValue;

    public Text CurrentValueText;
    private playerHealth health;
    public BarScript healthbar;

    [SerializeField]
    private Image content;
    // Use this for initialization
    void Start()
    {
        health = FindObjectOfType<playerHealth>();
        healthbar = FindObjectOfType<BarScript>();
        currentValue = health.getArmor();
    }

    // Update is called once per frame
    void Update()
    {
        currentValue = health.getArmor();
        CurrentValueText.text = (int)currentValue + "%";
        HandleBar();
        if (currentValue <= 0)
        {
            healthbar.setArmorState(false);
        }
        else
        {
            healthbar.setArmorState(true);
        }
    }

    private void HandleBar()
    {
        content.fillAmount = currentValue / 100;
    }
}
