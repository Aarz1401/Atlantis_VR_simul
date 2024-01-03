using JetBrains.Annotations;
using UnityEngine;


public class TeleportPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the Player GameObject

    public void TeleportToOrigin()
    {
        if (player != null)
        {
            player.transform.position = Vector3.zero; // Teleport the player to coordinates (0, 0, 0)
        }
        else
        {
            Debug.LogError("Player reference is not set! Assign the player object in the inspector.");
        }
    }
    public void TeleportToMuseum()
    {
        if (player != null)
        {
            player.transform.position = Vector3.zero; // Substitute with coordinates of museum entrance
        }
        else
        {
            Debug.LogError("Player reference is not set! Assign the player object in the inspector.");
        }

    }
    public void TeleportNextToDolphins()
    {
        player.transform.position =  new Vector3(-4.55f, 1f, 0f);
    }
}


