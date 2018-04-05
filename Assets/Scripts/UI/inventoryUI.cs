using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour {

	public Canvas ui;
	public Text ammo9mm, ammo44, ammo45, ammo545, ammo556, ammo762, ammo308, ammo12g;
	public GameObject backpack;
	itemController inventory;
    ammoController ammo;
	bool openUI = false;

	// Use this for initialization
	void Start () {
        ui.enabled = false;
        inventory = FindObjectOfType<itemController>();
        //inventory = backpack.GetComponent<itemController> ();//Remove code if not needed
		ammo = backpack.GetComponent<ammoController> ();
		ui.enabled = false;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Ensure the inventory stays open
            openUI = !openUI;
            ui.enabled = openUI;
            if (openUI)
            {
                ui.enabled = true;
                updateAmmo();
                updateInventory();
            }
            else
            {
                ui.enabled = false;
            }
        }
    }

	void updateAmmo() {
		ammo9mm.text = ammo.ammo9mm.ToString ();
		ammo44.text = ammo.ammo44.ToString ();
		ammo45.text = ammo.ammo45.ToString ();
		ammo545.text = ammo.ammo545.ToString ();
		ammo556.text = ammo.ammo556.ToString ();
		ammo762.text = ammo.ammo762.ToString ();
		ammo308.text = ammo.ammo308.ToString ();
		ammo12g.text = ammo.ammo12g.ToString ();
	}

	void updateInventory() {
		for (int j = 0; j < inventory.size; j++) {
			GameObject I = GameObject.Find ("Slot " + j.ToString ());
			GameObject T = GameObject.Find ("Slot " + j.ToString () + "/Text");
			Text t = T.GetComponent<Text> ();
			Image i = I.GetComponent<Image>();
			t.text = inventory.inventory [j].name;
			i.sprite = inventory.inventory [j].image;
		}
	}
}
