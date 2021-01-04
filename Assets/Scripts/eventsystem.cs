using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class eventsystem : MonoBehaviour
{
    public GameObject hint;
    public character player;
    public GameObject background;
    public RentHint rentHint;
    //public Days days;
    //public donDestroy don;
    public float hungerEveryNight=30,cleanEveryNight=50;
    private Energy energy;
    private BarsController barsController;
    public float fullEnergyNum = 100f;
    public float hungerCost = 10, cleanCost = 10,workCost=30;
    protected Text[] texts;
    //private string oldName;
    // Start is called before the first frame update
    void Start()
    {
        texts = background.GetComponentsInChildren<Text>();
        //Debug.Log(texts.Length);
        energy = GetComponent<Energy>();
        energy.num = fullEnergyNum;
        barsController = GetComponent<BarsController>();
        player.barsController = barsController;
        {
            //表明各数值
            //4 3 3 4
            texts[1].text = hungerCost.ToString();
            texts[2].text = player.hunngerIncrease.ToString();

            texts[5].text = fullEnergyNum.ToString();
            //texts[2].text = player.hunngerIncrease.ToString();

            texts[8].text = workCost.ToString();
            texts[9].text = donDestroy.don.days.wage.ToString();

            texts[11].text = cleanCost.ToString();
            texts[12].text = player.cleanIncrease.ToString();
        }
    }
    public void hideHint()
    {
        hint.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        rentHint.texts[3].text =((int)(donDestroy.don.days.dayNum/10+1)*10).ToString();
        //Debug.Log(rentHint.texts[3].text);
        if (energy.num - hungerCost < 0) player.ableToEat = false;
        else player.ableToEat = true;

        if (energy.num - cleanCost < 0) player.ableToWash = false;
        else player.ableToWash = true;

        if (energy.num - workCost < 0) player.ableToWork = false;
        else player.ableToWork = true;

        if (player.isBlack)
        {
            energy.num = fullEnergyNum;
            if (!donDestroy.don.days.addOnce)
            {
                donDestroy.don.days.dayNum++;
                donDestroy.don.days.addOnce = true;
            }
        }
        else donDestroy.don.days.addOnce = false;
        //Debug.Log(player.cleanNumChange);
        if (player.cleanNumChange)
        {
            if (energy.num - cleanCost < 0)
            {
                //energy.num = 0;
                player.cleanNumChange = false;
                return;
            }
            else energy.num = energy.num - cleanCost;

            if (barsController.bars[1].value + player.cleanIncrease / 100 > 1)
                barsController.bars[1].value = 1;
            else
                barsController.bars[1].value += player.cleanIncrease / 100;
            //
            donDestroy.don.days.money -= 5;
            player.cleanNumChange = false;
        }
        if (player.hungerNumChange)
        {
            if (energy.num - hungerCost < 0)
            {
                //energy.num = 0;
                player.hungerNumChange = false;
                return;
            }
            else energy.num = energy.num - hungerCost;
            //
            if (barsController.bars[0].value + player.hunngerIncrease / 100 > 1)
                barsController.bars[0].value = 1;
            else
                barsController.bars[0].value += player.hunngerIncrease / 100;
            //
            donDestroy.don.days.money -= 30;
            player.hungerNumChange = false;
        }
        if (player.moneyNumChange)
        {
            if (energy.num - workCost < 0)
            {
                //energy.num = 0;
                player.moneyNumChange = false;
                return;
            }
            else energy.num = energy.num - workCost;
            //
            donDestroy.don.days.money += donDestroy.don.days.wage;
            //
            
            player.moneyNumChange = false;
        }
        if (player.sleepChange)
        {
            if (barsController.bars[1].value - cleanEveryNight / 100 < 0)
                barsController.bars[1].value = 0;
            else
                barsController.bars[1].value -= cleanEveryNight / 100;
            //
            if (barsController.bars[0].value - hungerEveryNight / 100 <0)
                barsController.bars[0].value = 0;
            else
                barsController.bars[0].value -= hungerEveryNight / 100;
            //
            player.sleepChange = false;
        }
        //

    }
    
}
