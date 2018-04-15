using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    //
    public Canvas ShopOpen;
    //Define Variable
    public itemController ItemController;
    public List<itemObject> ItemObject;
    public GameObject player;
    public InputField[] ammo;
    public Button sell, buy;
    public Text txt9mm, txt45ACP, txt44mag, txt12gage, txt556, txt545, txt762, txt308, txtWorth, txtWallet;
    public int SvalueCost, BvalueCost;
    public List<int> ammoSpec;
    public List<int> ammoCount;
    public int currentWallet;
    public GameObject backpack;

    //Define variable for BuyList
    public Text txtBuyCost;
    public InputField[] buyAmmo;
    public Toggle[] othersItems;

    public List<int> buyAmountAmmo;

    /*
     * Value Chart for each ammo type
     * 9mm   : $ 1
     * 45ACP : $ 2
     * 44Mag : $ 5
     * 12Gage: $ 3
     * 5.56  : $ 4
     * 5.45  : $ 5
     * 762   : $ 5
     * 308   : $ 6
     * 
     * Ammo ID base of ammo-controller
     * 9mm   : 0
     * 44Mag : 1
     * 45ACP : 2
     * 5.45  : 3    
     * 5.56  : 4
     * 762   : 5
     * 308   : 6     
     * 12Gage: 7
     **/

    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        currentWallet = player.GetComponent<PlayerMovement>().wallet;
        backpack = player.transform.Find("Backpack").gameObject;
        ItemController = backpack.GetComponent<itemController>();
        //Setting Value for onHand text
        txt9mm.text = "On-Hand: " + ItemController.ammo.ammo9mm.ToString();
        txt45ACP.text = "On-Hand: " + ItemController.ammo.ammo45.ToString();
        txt44mag.text = "On-Hand: " + ItemController.ammo.ammo44.ToString();
        txt12gage.text = "On-Hand: " + ItemController.ammo.ammo12g.ToString();
        txt556.text = "On-Hand: " + ItemController.ammo.ammo556.ToString();
        txt545.text = "On-Hand: " + ItemController.ammo.ammo545.ToString();
        txt762.text = "On-Hand: " + ItemController.ammo.ammo762.ToString();
        txt308.text = "On-Hand: " + ItemController.ammo.ammo308.ToString();

        //Setting Value for ammoCount
        //Ammo count looks at the backpack
        ammoCount.Add(int.Parse(ItemController.ammo.ammo9mm.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo44.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo45.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo545.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo556.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo762.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo308.ToString()));
        ammoCount.Add(int.Parse(ItemController.ammo.ammo12g.ToString()));

        SvalueCost = 0;
        BvalueCost = 0;

        //Setting value for ammoSpec
        //AmmoSpec is the type of ammo and the amount the user enter in the field
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);
        ammoSpec.Add(0);

        //Setting value for buy ammo amount
        //buyAmountAmmo is the type of ammo and the amount the user enter in the field
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);
        buyAmountAmmo.Add(0);

        ShopOpen.enabled = false;
    }//end of start

    // Update is called once per frame
    void Update () {

        updateSellList();
        updateBuyList();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitShop();
        }

    }//end of update

    public void updateBuyList()
    {
        //Counter
        int emptyCount = 0;
        /*
         * This block code here checks if the input
         * field is empty or not. The counter inside
         * will given to a condition at the end to set
         * what the current value should be.
         * 
         **/
        for (int i = 0; i < buyAmountAmmo.Capacity; i++)
        {
            buyAmountAmmo[i] = 0;
            if (!buyAmmo[i].text.ToString().Equals(""))
                buyAmountAmmo[i] = int.Parse(buyAmmo[i].text.ToString());
            else
                emptyCount++;
        }

        for (int i = 0; i < othersItems.Length; i++)
        {
            if (!othersItems[i].isOn)
                emptyCount++;
        }

        BvalueCost = 0;

        /*
        * This block code checks if player input
        * anything in the input-field
        * 
        **/

        if (buyAmountAmmo[0] > 0 && buyAmountAmmo[0] != 0)
            BvalueCost += buyAmountAmmo[0] * 1;
        if (buyAmountAmmo[1] > 0 && buyAmountAmmo[1] != 0)
            BvalueCost += buyAmountAmmo[1] * 5;
        if (buyAmountAmmo[2] > 0 && buyAmountAmmo[2] != 0)
            BvalueCost += buyAmountAmmo[2] * 2;
        if (buyAmountAmmo[3] > 0 && buyAmountAmmo[3] != 0)
            BvalueCost += buyAmountAmmo[3] * 5;
        if (buyAmountAmmo[4] > 0 && buyAmountAmmo[4] != 0)
            BvalueCost += buyAmountAmmo[4] * 4;
        if (buyAmountAmmo[5] > 0 && buyAmountAmmo[5] != 0)
            BvalueCost += buyAmountAmmo[5] * 5;
        if (buyAmountAmmo[6] > 0 && buyAmountAmmo[6] != 0)
            BvalueCost += buyAmountAmmo[6] * 6;
        if (buyAmountAmmo[7] > 0 && buyAmountAmmo[7] != 0)
            BvalueCost += buyAmountAmmo[7] * 3;


        if (othersItems[0].isOn)
            BvalueCost += 750;
        if (othersItems[1].isOn)
            BvalueCost += 800;
        if (othersItems[2].isOn)
            BvalueCost += 600;
        if (othersItems[3].isOn)
            BvalueCost += 250;
        if (othersItems[4].isOn)
            BvalueCost += 700;
        if (othersItems[5].isOn)
            BvalueCost += 1000;
        if (othersItems[6].isOn)
            BvalueCost += 1000;
        if (othersItems[7].isOn)
            BvalueCost += 200;

        if (emptyCount < 16)
            txtBuyCost.text = "Value: $" + BvalueCost.ToString();
        else
            txtBuyCost.text = "Value: $" + 0;


    }
    public void updateSellList()
    {

        //Counter
        int emptyCount = 0;
        /*
         * Update Value
         */
        txt9mm.text = "On-Hand: " + ItemController.ammo.ammo9mm.ToString();
        txt45ACP.text = "On-Hand: " + ItemController.ammo.ammo45.ToString();
        txt44mag.text = "On-Hand: " + ItemController.ammo.ammo44.ToString();
        txt12gage.text = "On-Hand: " + ItemController.ammo.ammo12g.ToString();
        txt556.text = "On-Hand: " + ItemController.ammo.ammo556.ToString();
        txt545.text = "On-Hand: " + ItemController.ammo.ammo545.ToString();
        txt762.text = "On-Hand: " + ItemController.ammo.ammo762.ToString();
        txt308.text = "On-Hand: " + ItemController.ammo.ammo308.ToString();

        /*
         * This block code here checks if the input
         * field is empty or not. The counter inside
         * will given to a condition at the end to set
         * what the current value should be.
         * 
         **/
        for (int i = 0; i < ammoSpec.Capacity; i++)
        {
            ammoSpec[i] = 0;
            if (!ammo[i].text.ToString().Equals(""))
                ammoSpec[i] = int.Parse(ammo[i].text.ToString());
            else
                emptyCount++;
        }


        SvalueCost = 0;

        /*
         * This block code checks if player input
         * anything in the input-field and check
         * the current ammo type has ammo and make
         * sure player cannot sell more than they have
         * 
         **/
        if (ammoSpec[0] > 0 && ammoCount[0] > 0 && ammoSpec[0] != 0 && ammoSpec[0] <= ammoCount[0])
            SvalueCost += ammoSpec[0] * 1;
        if (ammoSpec[1] > 0 && ammoCount[1] > 0 && ammoSpec[1] != 0 && ammoSpec[1] <= ammoCount[1])
            SvalueCost += ammoSpec[1] * 5;
        if (ammoSpec[2] > 0 && ammoCount[2] > 0 && ammoSpec[2] != 0 && ammoSpec[2] <= ammoCount[2])
            SvalueCost += ammoSpec[2] * 2;
        if (ammoSpec[3] > 0 && ammoCount[3] > 0 && ammoSpec[3] != 0 && ammoSpec[3] <= ammoCount[3])
            SvalueCost += ammoSpec[3] * 5;
        if (ammoSpec[4] > 0 && ammoCount[4] > 0 && ammoSpec[4] != 0 && ammoSpec[4] <= ammoCount[4])
            SvalueCost += ammoSpec[4] * 4;
        if (ammoSpec[5] > 0 && ammoCount[5] > 0 && ammoSpec[5] != 0 && ammoSpec[5] <= ammoCount[5])
            SvalueCost += ammoSpec[5] * 5;
        if (ammoSpec[6] > 0 && ammoCount[6] > 0 && ammoSpec[6] != 0 && ammoSpec[6] <= ammoCount[6])
            SvalueCost += ammoSpec[6] * 6;
        if (ammoSpec[7] > 0 && ammoCount[7] > 0 && ammoSpec[7] != 0 && ammoSpec[7] <= ammoCount[7])
            SvalueCost += ammoSpec[7] * 3;

        if (emptyCount < 8)
            txtWorth.text = "Value: $" + SvalueCost.ToString();
        else
            txtWorth.text = "Value: $" + 0;

        txtWallet.text = "Wallet: $" + currentWallet;
    }

    public void sellConfirm()
    {
        for (int i = 0; i < ammoSpec.Capacity; i++)
        {
            if (ammoSpec[i] <= ammoCount[i] && ammoSpec[i] != 0)
            {
                ammoCount[i] -= ammoSpec[i];
                ItemController.ammo.removeAmmo(ammoSpec[i], i);
                ammo[i].text = "";
            }
        }

        currentWallet += SvalueCost;
        player.GetComponent<PlayerMovement>().wallet = currentWallet;
    }//end of sellConfirm

    public void buyConfirm()
    {
        for (int i = 0; i < buyAmountAmmo.Capacity; i++)
        {
            if (buyAmountAmmo[i] != 0 && (currentWallet - BvalueCost) >= 0)
            {
                ammoCount[i] += buyAmountAmmo[i];
                ItemController.ammo.addAmmo(buyAmountAmmo[i], i);
            }
            buyAmmo[i].text = "";
            if (othersItems[i].isOn && (currentWallet - BvalueCost) >= 0)
            {
                if (!(i == 5 || i == 6))
                {
                    ItemController.addItem(ItemObject[i]);
                    othersItems[i].isOn = false;
                    othersItems[i].enabled = false;
                }
                else if (i == 5)
                    player.GetComponent<playerHealth>().armor = 100;
                else if (i == 6)
                    player.GetComponent<playerHealth>().health = 100;
            }
        }

        if ((currentWallet - BvalueCost) >= 0)
        {
            currentWallet -= BvalueCost;
            player.GetComponent<PlayerMovement>().wallet = currentWallet;
        }
    }//end of buyConfirm

    public void ExitShop()
    {
        Time.timeScale = 1f;

        ShopOpen.enabled = false;
    }
}//end of class
