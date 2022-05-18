using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Gold
}

public class Key : PickUp
{
    public Material red;
    public Material green;
    public Material gold;

    private void Start()
    {
        SetMyColour();
    }

    void SetMyColour()
    {
        switch (color)
        {
            case KeyColor.Red:
                Material[] redMaterials = { red, red, red, red };
                GetComponent<Renderer>().materials = redMaterials;
                break;
            case KeyColor.Green:
                Material[] greenMaterials = { green, green, green, green };
                GetComponent<Renderer>().materials = greenMaterials;
                break;
            case KeyColor.Gold:
                Material[] goldMaterials = { gold, gold, gold, gold };
                GetComponent<Renderer>().materials = goldMaterials;
                break;
        }
    }

    public KeyColor color;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(pickupClip);
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }

    void Update()
    {
        Rotation();
    }
}
