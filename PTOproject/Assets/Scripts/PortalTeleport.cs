using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
	public Transform player;
	public Transform reciever;

	private bool isPlayerOverlapping = false;

	private void FixedUpdate()
	{
		Teleportation();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			isPlayerOverlapping = true;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			isPlayerOverlapping = false;
		}
	}

	void Teleportation()
	{
		if (isPlayerOverlapping)
		{
			Vector3 portalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			if(dotProduct < 0f)
			{
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff = rotationDiff + 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = reciever.position + positionOffset;
			}

			isPlayerOverlapping = false;
		}
	}
}
