using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public float movevelo = 5;
    private Vector3 velocity;
    private Vector3 pos;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("help");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            velocity = transform.position;
            velocity.x -= movevelo*Time.fixedDeltaTime;
            transform.position = velocity;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            velocity = transform.position;
            velocity.x += movevelo*Time.fixedDeltaTime;
            transform.position = velocity;
        }
    }
    void Update(){
        if (transform.position.x > GameObject.Find("wallright").transform.position.x){
            pos = transform.position;
            pos.x = GameObject.Find("wallleft").transform.position.x;
            transform.position = pos;
        }
        else if (transform.position.x < GameObject.Find("wallleft").transform.position.x){
            pos = transform.position;
            pos.x = GameObject.Find("wallright").transform.position.x;
            transform.position = pos;
        }
    }
}
