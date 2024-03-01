using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroler : MonoBehaviour
{
    Jump player;
    Text distanceText;
    Text scoretext;
    GameObject over;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake(){
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Jump>();
        distanceText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        over = GameObject.Find("Over");
        scoretext =  GameObject.Find("Score").GetComponent<Text>();
        over.SetActive(false );
        
    }
    // Update is called once per frame 
    void Update()
    {
        int distance = (int)player.height;
        distanceText.text = distance + " m";
        if(player.isdead){
            over.SetActive(true);
            scoretext.text = "Score : " + distance + " m";
        }
    }

    public void retry(){
        SceneManager.LoadScene("SampleScene");
    }
}
