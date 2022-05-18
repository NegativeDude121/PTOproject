using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool canIOpen = false;
    public Door door;
    public KeyColor doorColor;
    bool locked = false;
    Animator key;

    public Material red;
    public Material green;
    public Material gold;

    public Renderer myLock;

    private void Start()
    {
        SetMyColour();
        key = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canIOpen == true && locked == false)
        {
            key.SetBool("useKey", KeyCheck());
        }
    }

    void SetMyColour()
    {
        switch (doorColor)
        {
            case KeyColor.Red:
                Material[] redMaterials = { red, red, red, red };
                GetComponent<Renderer>().materials = redMaterials;
                myLock.material = red;
                break;
            case KeyColor.Green:
                Material[] greenMaterials = { green, green, green, green };
                GetComponent<Renderer>().materials = greenMaterials;
                myLock.material = green;
                break;
            case KeyColor.Gold:
                Material[] goldMaterials = { gold, gold, gold, gold };
                GetComponent<Renderer>().materials = goldMaterials;
                myLock.material = gold;
                break;
        }
    }

    public void UseKey()
    {
        door.CloseOpen();
    }

    public bool KeyCheck()
    {
        if(GameManager.gameManager.redKey>0 && doorColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && doorColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && doorColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza");
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canIOpen = true;
            Debug.Log("You can use the lock");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canIOpen = false;
            Debug.Log("You can't use the lock");
        }
    }
}
