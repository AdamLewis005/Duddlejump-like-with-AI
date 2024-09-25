using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAI : MonoBehaviour
{   
    public float movevelo = 2;
    private Vector3 velocity;
    private Vector3 pos;
    private Vector3 ogpos;

    

    // Start is called before the first frame update
    void Start()
    {
        ogpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = transform.position;
        velocity.x += movevelo*Time.fixedDeltaTime;
        transform.position = velocity;
        if ((transform.position.x > ogpos.x+1) || (transform.position.x < ogpos.x-1)){
            movevelo = -movevelo;
        }
        
    }   
}
