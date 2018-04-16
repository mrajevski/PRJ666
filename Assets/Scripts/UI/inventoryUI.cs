using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour {

	public Canvas ui;
	public Text ammo9mm, ammo44, ammo45, ammo545, ammo556, ammo762, ammo308, ammo12g;
	public GameObject backpack;
	public itemObject empty;
    public GameObject player;

    int UIMask;
    public static bool invExists;
	itemController inventory;
	ammoController ammo;
	bool openUI = false, pause = false, shop = false;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        backpack = player.transform.Find("Backpack").gameObject;
        inventory = backpack.GetComponent<itemController>();
        ammo = backpack.GetComponent<ammoController>();
        ui.enabled = false;
        if (!invExists)
        {
            invExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			openUI = !openUI;
			ui.enabled = openUI;
		}
		if (openUI) {
			updateAmmo ();
			updateInventory ();
			updateEquipment ();
			updateStuff ();
		}
	}

	void updateAmmo() {
		ammo9mm.text = ammo.ammo[0].ToString ();
		ammo44.text = ammo.ammo[1].ToString ();
		ammo45.text = ammo.ammo[2].ToString ();
		ammo545.text = ammo.ammo[3].ToString ();
		ammo556.text = ammo.ammo[4].ToString ();
		ammo762.text = ammo.ammo[5].ToString ();
		ammo308.text = ammo.ammo[6].ToString ();
		ammo12g.text = ammo.ammo[7].ToString ();
	}

	void updateInventory() {
		for (int j = 0; j < inventory.capacity; j++) {
			GameObject I = GameObject.Find ("iItem " + j.ToString());
			I.GetComponent<Image>().sprite = inventory.inventory [j].image;
			GameObject T = GameObject.Find ("iItem " + j.ToString() + "/Text");
			Text t = T.GetComponent<Text> ();
			t.text = inventory.inventory [j].name;
		}
		if (inventory.bagID >= 1) {
			GameObject.Find ("Inventory UI/Inventory/R1").SetActive(true);
			if (inventory.bagID == 2) 
				GameObject.Find ("Inventory UI/Inventory/R1/R2").SetActive(true);				
		}
	}

	void updateEquipment() {
		for (int j = 0; j < 9; j++) {
			GameObject I = GameObject.Find ("eItem " + j.ToString ());
			I.GetComponent<Image> ().sprite = inventory.equipment[j].image;
		}
	}

	void updateStuff() {
		GameObject T = GameObject.Find ("Armor/Text");
		T.GetComponent<Text> ().text = "LVL " + inventory.armorLVL.ToString();
		T = GameObject.Find ("Bag/Text");
		T.GetComponent<Text> ().text = "LVL " + inventory.bagID.ToString();
		T = GameObject.Find ("Gas/Text");
		T.GetComponent<Text> ().text = "x" + inventory.gas.ToString();
	}

}