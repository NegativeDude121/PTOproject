using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : PickupController
{
    public int points = 0;

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(2);
        Destroy(this.gameObject);
    }
}
