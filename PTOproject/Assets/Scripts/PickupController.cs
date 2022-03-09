using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public virtual void Picked()
    {
        Debug.Log("Picked Up");
        Destroy(this.gameObject);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0f, 4f, 0),0.5f);
    }
}
