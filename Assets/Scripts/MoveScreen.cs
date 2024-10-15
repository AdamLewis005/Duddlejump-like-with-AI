using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    // Start is called before the first frame update
    /*
    private Jump ai;
    void Start (){

        ai = GetComponent<Jump>();
    }
    void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "player"){
            move(collider.gameObject);
        }
    }
    void move(GameObject player){
        
            moveobject("platform");
            moveobject("brokenplatform");
            moveobject("ennemy");
            moveplayer(player);
            ai.velocity.y += ai.gravity  * Time.fixedDeltaTime;
            ai.height += ai.velocity.y * Time.fixedDeltaTime;
            
        
    }
    void moveplayer(GameObject player){
        GameObject[] players = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject item in players){
                if (item != player) {
                    Vector3 pos2 = item.transform.position;
                    pos2.y -= ai.velocity.y*Time.fixedDeltaTime;
                    item.transform.position = pos2;
                }
            }
    }
    void moveobject(string objecte){
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objecte);
        foreach (GameObject item in objects){
                Vector3 pos2 = item.transform.position;
                pos2.y -= ai.velocity.y*Time.fixedDeltaTime;
                item.transform.position = pos2;
            }
    }
    */
}
