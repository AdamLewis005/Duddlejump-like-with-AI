using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformcolider : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D platformCollider;
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        if (PlayerIsAbovePlatform(player)) {
            platformCollider.enabled = true;
            //Debug.Log("on ");
        } else {
            platformCollider.enabled = false;
            //Debug.Log("off ");
        }
    }
    bool PlayerIsAbovePlatform(GameObject player) {
    // Implement logic to determine if the player is above the platform
    // This could be as simple as comparing the y-position of the player and the platform
        return player.transform.position.y-(player.transform.lossyScale.y+0.5)/2 > transform.position.y+transform.lossyScale.y/2;
    }
    
}
