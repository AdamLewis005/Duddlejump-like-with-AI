using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnplatform : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float radius = 1;
    private float max = -5;
    private float maxdist = 5.0f;
    private float mindist = 0.5f;
    float palier= 0;
    Jump player;
    // Start is called before the first frame update
    void Awake(){
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Jump>();
    }
    void Start()
    {   
        //SpawnObjectunderP();
        for(int i=0;i<8;i++)
            SpawnObjectstart();
    }

    // Update is called once per frame
    void Update()
    {   
        
        UpdateObject();
        if (mindist < maxdist){
            
            if (player.height/10> palier){
                mindist += 0.1f;
                palier +=1;
                //Debug.Log(mindist.ToString());
            }
            
        }

    }

    void UpdateObject(){
        float max2 = 0;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");
        foreach(GameObject platform in platforms){
            if (platform.transform.position.y > max2){
                max2 = platform.transform.position.y;
            }
            if (platform.transform.position.y<-12.5){
                Destroy(platform);
            }

        } 
        if (max2 < 10){
            Vector3 radomPos = new Vector3(Random.Range(-3.0f,3.0f),max2 + Random.Range(mindist,maxdist),0);
            Instantiate(ItemPrefab,radomPos,Quaternion.identity);
        } 

    }

    void SpawnObjectstart(){
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("platform");
        foreach(GameObject platform in platforms){
            if (platform.transform.position.y > max){
                max = platform.transform.position.y;
            }
        }
        Vector3 radomPos = new Vector3(Random.Range(-3.0f,3.0f),max + Random.Range(0.5f,3f),0);
        Instantiate(ItemPrefab,radomPos,Quaternion.identity);
    }

/*
    void SpawnObjectunderP(){
        GameObject otherGameObject = GameObject.FindWithTag("player");
        if (otherGameObject != null) {
            Vector3 position = otherGameObject.transform.position;
            Debug.Log("Position: " + position.ToString());
        } else {
            Debug.Log("GameObject not found");
        }
    }
*/
}
