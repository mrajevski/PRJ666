using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    //Define Variable
    public itemController ItemController;
    public GameObject player;
    public InputField[] ammo;
    public Button sell, buy;
    public Text txt9mm, txt45ACP, txt44mag, txt12gage, txt556, txt545, txt762, txt308, txtWorth, txtWallet;
    public int valueCost;
    public List<int> ammoSpec;
    public List<int> ammoCount;
    public int currentWallet;
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
        ItemController = GameObject.FindObjectOfType<itemController>();
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

        valueCost = 0;

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
    }//end of start

    // Update is called once per frame
    void Update () {

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
         * Update Ammo Count 
         * 
         **/


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


        valueCost = 0;

        /*
         * This block code checks if player input
         * anything in the input-field and check
         * the current ammo type has ammo and make
         * sure player cannot sell more than they have
         * 
         **/ 
        if (ammoSpec[0] > 0 && ammoCount[0] > 0 && ammoSpec[0] != 0 && ammoSpec[0] <= ammoCount[0])
            valueCost += ammoSpec[0] * 1;
        if (ammoSpec[1] > 0 && ammoCount[1] > 0 && ammoSpec[1] != 0 && ammoSpec[1] <= ammoCount[1])
            valueCost += ammoSpec[1] * 5;
        if (ammoSpec[2] > 0 && ammoCount[2] > 0 && ammoSpec[2] != 0 && ammoSpec[2] <= ammoCount[2])
            valueCost += ammoSpec[2] * 2;
        if (ammoSpec[3] > 0 && ammoCount[3] > 0 && ammoSpec[3] != 0 && ammoSpec[3] <= ammoCount[3])
            valueCost += ammoSpec[3] * 5;
        if (ammoSpec[4] > 0 && ammoCount[4] > 0 && ammoSpec[4] != 0 && ammoSpec[4] <= ammoCount[4])
            valueCost += ammoSpec[4] * 4;
        if (ammoSpec[5] > 0 && ammoCount[5] > 0 && ammoSpec[5] != 0 && ammoSpec[5] <= ammoCount[5])
            valueCost += ammoSpec[5] * 5;
        if (ammoSpec[6] > 0 && ammoCount[6] > 0 && ammoSpec[6] != 0 && ammoSpec[6] <= ammoCount[6])
            valueCost += ammoSpec[6] * 6;
        if (ammoSpec[7] > 0 && ammoCount[7] > 0 && ammoSpec[7] != 0 && ammoSpec[7] <= ammoCount[7])
            valueCost += ammoSpec[7] * 3;

        if(emptyCount < 8)
            txtWorth.text = "Value: $" + valueCost.ToString(); 
        else
            txtWorth.text = "Value: $" + 0;
        
        txtWallet.text = "Wallet: $" + currentWallet;
    }//end of update

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

        currentWallet += valueCost;
        player.GetComponent<PlayerMovement>().wallet = currentWallet;
    }//end of sellConfirm
}//end of class
