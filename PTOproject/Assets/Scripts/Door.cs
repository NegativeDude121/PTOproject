using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform openPosition;
    public Transform closedPosition;
    public Transform door;

    public bool open = false;

    [SerializeField]
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        door.position = closedPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(open && Vector3.Distance(door.position, openPosition.position)>0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * speed);
        }
        if (!open && Vector3.Distance(door.position, closedPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, closedPosition.position, Time.deltaTime * speed);
        }
    }

    public void CloseOpen()
    {
        open = !open;
    }
}
