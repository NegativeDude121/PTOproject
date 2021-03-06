using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public AudioClip pickupClip;

    void Update()
    {
        Rotation();
    }

    public virtual void Picked()
    {
        GameManager.gameManager.PlayClip(pickupClip);
        Debug.Log("Picked");
        Destroy(this.gameObject);
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0f, 1f, 0));
    }
}
