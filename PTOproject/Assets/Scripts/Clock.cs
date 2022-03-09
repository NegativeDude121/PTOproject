using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickupController
{
    public int addTime = 10;
    public int minusTime = 10;
    public bool timeAdd = true;

    public override void Picked()
    {
        if (timeAdd)
        {
            GameManager.gameManager.AddTime(addTime);  
        }
        else
        {
            GameManager.gameManager.RemoveTime(minusTime);
        }
        Destroy(this.gameObject);
    }
}
