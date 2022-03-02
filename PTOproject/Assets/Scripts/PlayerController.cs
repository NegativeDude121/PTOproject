using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed = 12f;
    public float speedLow = 8f;
    public float speedHigh = 16f;
    public float speedStandard = 12f;
    CharacterController characterController;
    public LayerMask groundMask;
    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void playerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        RaycastHit hit;

        if(Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.8f, groundMask))
        {
            string terrainType;
            terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                case "Low":
                    movementSpeed = speedLow;
                    break;
                case "High":
                    movementSpeed = speedHigh;
                    break;
                default:
                    movementSpeed = speedStandard;
                    break;
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * movementSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
}
