﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeOffDescriptorElem : MonoBehaviour
{
    //This class determines the tradeOffs, which will increase or decrease the counters of Resources or Products.

    public string reqName;
    //public Amount targetResOrProd; //Add Amount Class to each TradeOffDescrElem. //IT WAS ACTUALLY NOT NEEDED.
    //public float quantPerClick;
    //public float costPerClick;
    //public bool autoIsActive;
    //public float quantPerSec;
    //public float costPerSec;
    public float tradeFloat; //This was used for UpDescrElem. Use quantPerClick or quantPerSec instead. CHOSE TO RATHER GO WITH THIS.

    public bool isPurchasable;
    public GameObject prodOffButton;
    public bool isAutomated;
    public string perClick = " / click";
    public string perSec = " / 1 sec";

    public bool elemIsEconomy;
    public bool elemIsFood;
    public bool elemIsEnergy;
    public bool elemIsWaste;
    public bool elemIsPollution;
    public bool elemIsApproval;
    public bool isAdditive;

    public TextMeshProUGUI tradeOffTxt;

    //public int chosenIcon;
    public GameObject[] icons; //Goes 0-6.
    // 0 Economy
    // 1 Food
    // 2 Energy
    // 3 Waste
    // 4 approval
    // 5 is Positive
    // 6 is Negative

    public bool tradeIsResPassive;
    public bool tradeIsProduct;
    public bool tradeIsRes;
    public bool tradeIsMixedProdRes;

    public int chosenResPassive;
    public List<ResourcePassive> checkedResPassive = new List<ResourcePassive>();
    // 0 Economy
    // 1 Population
    // 2 Approval
    // 3 Pollution

    public int chosenProduct;
    public List<Product> checkedProduct = new List<Product>();
    // 0 Boats (EMPTY)
    // 1 Livestock
    // 2 Crops
    // 3 Fish
    // 4 Insects
    // 5 Algae
    // 6 Oil barrels
    // 7 Biofuel barrels
    // 8 Biogas tanks
    // 9 Artificial fertilizer
    // 10 Organic fertilizer
    // 11 Fish plastic
    // 12 organic waste
    // 13 plastic waste
    // 14 mixed waste (12.5)
    // 15 Recycled plastic (25)
    // 16 Soil (26)
    // 17 Water (27)

    public int chosenRes;
    public List<Resource> checkedRes = new List<Resource>();
    // 0 food
    // 1 energy
    // 2 waste



    //END OF REFERENCES ////////////////////////////////////////////////////////////////////////////

    public void ExecuteTrade()
    {
        if (isAdditive == true)
        {
            if (tradeIsProduct == true && tradeIsRes == false && tradeIsResPassive == false && tradeIsMixedProdRes == false)
            {
                checkedProduct[chosenProduct].amountTxt.amountFloat += tradeFloat;
                //checkedRes[chosenRes].resourceCurrent.amountFloat += tradeFloat; //The next if statement does this.

                //This should update float-TMP.


            }
            else if (tradeIsResPassive == true && tradeIsProduct == false && tradeIsRes == false && tradeIsMixedProdRes == false)
            {
                checkedResPassive[chosenResPassive].resourceCurrent.amountFloat += tradeFloat;

            }
            else if (tradeIsRes == true && tradeIsProduct == false && tradeIsResPassive == false && tradeIsMixedProdRes == false)
            {
                checkedRes[chosenRes].resourceCurrent.amountFloat += tradeFloat;
                //checkedProduct[chosenProduct].amountTxt.amountFloat += tradeFloat; //The next if statement does this.


            }
            else if (tradeIsMixedProdRes == true && tradeIsRes == false && tradeIsProduct == false && tradeIsResPassive == false)
            {
                checkedRes[chosenRes].resourceCurrent.amountFloat += tradeFloat;
                checkedProduct[chosenProduct].amountTxt.amountFloat += tradeFloat;
                Debug.Log("Added to prod and res.");


            }
        }
        else if (isAdditive == false)
        {
            if (tradeIsProduct == true && tradeIsRes == false && tradeIsResPassive == false && tradeIsMixedProdRes == false) 
            {
                checkedProduct[chosenProduct].amountTxt.amountFloat -= tradeFloat;
                //checkedRes[chosenRes].resourceCurrent.amountFloat += tradeFloat;

            }
            else if (tradeIsResPassive == true && tradeIsProduct == false && tradeIsRes == false && tradeIsMixedProdRes == false)
            {
                checkedResPassive[chosenResPassive].resourceCurrent.amountFloat -= tradeFloat;

            }
            else if (tradeIsRes == true && tradeIsProduct == false && tradeIsResPassive == false && tradeIsMixedProdRes == false)
            {
                checkedRes[chosenRes].resourceCurrent.amountFloat -= tradeFloat;
                //checkedProduct[chosenProduct].amountTxt.amountFloat -= tradeFloat;

            }
            else if (tradeIsMixedProdRes == true && tradeIsRes == false && tradeIsProduct == false && tradeIsResPassive == false)
            {
                checkedRes[chosenRes].resourceCurrent.amountFloat -= tradeFloat;
                checkedProduct[chosenProduct].amountTxt.amountFloat -= tradeFloat;
                Debug.Log("Subtracted to prod and res.");

            }
        }
    }

    public void VerifyIsPurchasable()
    {

        if (tradeIsResPassive == true && tradeIsRes == false && tradeIsProduct == false)
        {
            if (isAdditive == false)
            {
                //float calculatorResPass = (checkedResPassive[chosenResPassive].resourceCurrent.amountFloat - tradeFloat);

                //if (checkedResPassive[chosenResPassive].resourceCurrent.amountFloat >= tradeFloat)
                if (checkedResPassive[chosenResPassive].resourceCurrent.amountFloat >= tradeFloat)
                {
                    isPurchasable = true;
                }
                else if (checkedResPassive[chosenResPassive].resourceCurrent.amountFloat < tradeFloat)
                {
                    isPurchasable = false;
                    Debug.Log("Not enough " + checkedResPassive[chosenResPassive] + ".");

                }
                // calculator < tradefloat && 
            }

            else
            {
                isPurchasable = true;

            }
        }

        if (tradeIsProduct == true && tradeIsRes == false && tradeIsResPassive == false)
        {
            if (isAdditive == false)
            {
                //float calculatorProd = (checkedProduct[chosenProduct].amountTxt.amountFloat - tradeFloat);

                if (checkedProduct[chosenProduct].amountTxt.amountFloat >= tradeFloat)
                //if (checkedProduct[chosenProduct].amountTxt.amountFloat >= tradeFloat)
                {
                    isPurchasable = true;
                }
                else if (checkedProduct[chosenProduct].amountTxt.amountFloat < tradeFloat)
                {
                    isPurchasable = false;
                    Debug.Log("Not enough " + checkedProduct[chosenProduct] + ".");

                }
            }
            else
            {
                isPurchasable = true;

            }
        }

        if (tradeIsRes == true && tradeIsProduct == false && tradeIsResPassive == false)
        {
            if (isAdditive == false)
            {
                //float calculatorRes = (checkedRes[chosenRes].resourceCurrent.amountFloat - tradeFloat);

                if (checkedRes[chosenRes].resourceCurrent.amountFloat >= tradeFloat)
                //if (checkedRes[chosenRes].resourceCurrent.amountFloat >= tradeFloat)
                {
                    isPurchasable = true;
                }
                else if (checkedRes[chosenRes].resourceCurrent.amountFloat < tradeFloat)
                {
                    isPurchasable = false;
                    Debug.Log("Not enough " + checkedRes[chosenRes] + ".");


                }
            }
            else
            {
                isPurchasable = true;

            }
        }

        if (tradeIsMixedProdRes == true /*&& tradeIsRes == true && tradeIsProduct == true && tradeIsResPassive == false*/)
        {
            if (isAdditive == false)
            {
                //float calculatorMixed = (checkedRes[chosenRes].resourceCurrent.amountFloat - tradeFloat);

                if (checkedRes[chosenRes].resourceCurrent.amountFloat >= tradeFloat)
                //if (checkedRes[chosenRes].resourceCurrent.amountFloat >= tradeFloat)
                {
                    isPurchasable = true;
                }
                else if (checkedRes[chosenRes].resourceCurrent.amountFloat < tradeFloat)
                {
                    isPurchasable = false;
                    Debug.Log("Not enough " + checkedRes[chosenRes] + ".");

                }
            }
            else
            {
                isPurchasable = true;

            }
        }
    }

    public void Update()
    {
        VerifyIsPurchasable();

        if (isPurchasable == false)
        {
            prodOffButton.gameObject.SetActive(true);

        }
        else if (isPurchasable == true)
        {
            prodOffButton.gameObject.SetActive(false);

        }

        //VerifyIsPurchasable(); //This is done in UpgradeDescriptor class.

        //Turns on the correct sign.
        if (isAdditive == true)
        {
            icons[5].gameObject.SetActive(true);
            icons[6].gameObject.SetActive(false);
        }
        else if (isAdditive == false)
        {
            icons[5].gameObject.SetActive(false);
            icons[6].gameObject.SetActive(true);
        }

        // THE FOLLOWING LINES TURN ON THE CORRECT ICON FOR THE TRADEOFF.
        if (elemIsEconomy == true)
        {
            icons[0].gameObject.SetActive(true);

            icons[1].gameObject.SetActive(false);
            icons[2].gameObject.SetActive(false);
            icons[3].gameObject.SetActive(false);
            icons[4].gameObject.SetActive(false);
            icons[7].gameObject.SetActive(false);


            if (tradeIsResPassive == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.00");

            }

            //else if (tradeIsProduct == true)
            //{

            //}

            //else if (tradeIsRes == true)
            //{

            //}

        }
        else if (elemIsFood == true)
        {
            icons[1].gameObject.SetActive(true);

            icons[0].gameObject.SetActive(false);
            icons[2].gameObject.SetActive(false);
            icons[3].gameObject.SetActive(false);
            icons[4].gameObject.SetActive(false);
            icons[7].gameObject.SetActive(false);


            

            if (tradeIsProduct == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

            else if (tradeIsRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

            else if (tradeIsMixedProdRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }


        }
        else if (elemIsEnergy == true)
        {
            icons[2].gameObject.SetActive(true);

            icons[1].gameObject.SetActive(false);
            icons[0].gameObject.SetActive(false);
            icons[3].gameObject.SetActive(false);
            icons[4].gameObject.SetActive(false);
            icons[7].gameObject.SetActive(false);


            

            if (tradeIsProduct == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0");

            }

            else if (tradeIsRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

            else if (tradeIsMixedProdRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

        }
        else if (elemIsWaste == true)
        {
            icons[3].gameObject.SetActive(true);

            icons[1].gameObject.SetActive(false);
            icons[2].gameObject.SetActive(false);
            icons[0].gameObject.SetActive(false);
            icons[4].gameObject.SetActive(false);
            icons[7].gameObject.SetActive(false);


            

            if (tradeIsProduct == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0");

            }

            else if (tradeIsRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

            else if (tradeIsMixedProdRes == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0.0");

            }

        }
        else if (elemIsApproval == true)
        {
            icons[4].gameObject.SetActive(true);

            icons[1].gameObject.SetActive(false);
            icons[2].gameObject.SetActive(false);
            icons[3].gameObject.SetActive(false);
            icons[0].gameObject.SetActive(false);
            icons[7].gameObject.SetActive(false);


            if (tradeIsResPassive == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0");

            }

            

        }
        else if (elemIsPollution == true)
        {
            icons[7].gameObject.SetActive(true);

            icons[0].gameObject.SetActive(false);
            icons[1].gameObject.SetActive(false);
            icons[2].gameObject.SetActive(false);
            icons[3].gameObject.SetActive(false);
            icons[4].gameObject.SetActive(false);

            if (tradeIsResPassive == true)
            {
                //if (isAdditive == true)
                //{
                //    icons[5].gameObject.SetActive(true);
                //    icons[6].gameObject.SetActive(false);
                //}
                //else
                //{
                //    icons[5].gameObject.SetActive(false);
                //    icons[6].gameObject.SetActive(true);
                //}

                tradeOffTxt.text = tradeFloat.ToString("0");

            }

            

        }
    }

}
