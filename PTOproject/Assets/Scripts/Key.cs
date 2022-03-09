using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickupController
{
    public KeyColor color;

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }
}
public enum KeyColor
{
    Red,
    Green,
    Purple
}