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
        scoretext =  GameObject.Find("Score").GetComponent<Text>();
        over.SetActive(false );
    }

    void Awake(){
        //player = GameObject.FindGameObjectWithTag("player").GetComponent<Jump>();

        distanceText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        over = GameObject.Find("Over");
        
        
        
    }
    public void setplayer(Jump player){
        this.player = player;
    }
    // Update is called once per frame 
    void Update()
    {   
        if (player != null){
        distanceText.text = player.score + " m";
        if(player.isdead){
            over.SetActive(true);
            scoretext.text = "Score : " + player.score + " m";
        }
        }
    }

    public void retry(){
        SceneManager.LoadScene("SampleScene");
    }
    public void play(){
        SceneManager.LoadScene("SampleScene");
    }
    public void ai(){
        SceneManager.LoadScene("AiScene");
    }
}
