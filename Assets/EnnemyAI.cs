using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAI : MonoBehaviour
{   

    public Collider2D platformCollider;
    private GameObject player;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("player");
        
    }
}
