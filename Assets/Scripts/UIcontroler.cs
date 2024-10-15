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
        //player = GameObject.FindGameObjectWithTag("player").GetComponent<Jump>();

        distanceText = GameObject.FindGameObjectWithTag("score").GetComponent<Text>();
        
        
        
        
    }
    public void setplayer(Jump player){
        this.player = player;
        if (player.name == "Player"){
            scoretext =  GameObject.Find("Score").GetComponent<Text>();
            over = GameObject.Find("Over");
            over.SetActive(false );
        }
    }
    // Update is called once per frame 
    void Update()
    {   
        if (player != null){
        distanceText.text = player.score + " m";
        if(player.isdead && player.name == "Player"){
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
