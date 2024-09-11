using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    private Vector3 velocity;
    public float jumpvelo=10;
    public float gravity = -10;
    //private bool above= false;
    public float height = 0;
    public bool isdead = false;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update(){
    }


    // Update is called once per frame
    private void FixedUpdate(){   

        if (isdead){
            velocity.y = gravity;
        }

        pos = transform.position;
        if (pos.y < -12.5){
            isdead = true;
            return;
        }


        pos.y += velocity.y * Time.fixedDeltaTime;
        move();
        
        

    }

    void OnCollisionEnter2D(Collision2D collider){
        //Debug.Log("Collided with " + collider.gameObject.name);
        if (collider.gameObject.tag == "platform"){
            velocity.y = jumpvelo; 
        }
        if (collider.gameObject.tag == "mob"){
            isdead = true;  
        }
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("in");
        if (collider.gameObject.name == "brokenplatform(Clone)"){
            Destroy(collider.gameObject);
            
        }
    }

    void move(){
        if ((transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y)&&(velocity.y>0)){
            GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");
            foreach (GameObject platform in platforms){
                Vector3 pos2 = platform.transform.position;
                pos2.y -= velocity.y*Time.fixedDeltaTime;
                platform.transform.position = pos2;
            }
            moveobject("brokenplatform");
            velocity.y += gravity  * Time.fixedDeltaTime;
            height += velocity.y * Time.fixedDeltaTime;
            
        }else{
            height += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity  * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }
    void moveobject(string objecte){
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objecte);
        foreach (GameObject item in objects){
                Vector3 pos2 = item.transform.position;
                pos2.y -= velocity.y*Time.fixedDeltaTime;
                item.transform.position = pos2;
            }
    }
}
