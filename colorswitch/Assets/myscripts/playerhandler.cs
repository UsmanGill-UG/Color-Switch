using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhandler : MonoBehaviour
{
    public float JumpFactor = 0;
    public Rigidbody2D rb;
    public Color pink;
    public Color yellow;
    public Color blue;
    public Color green;
    string PlayerColor;
    public SpriteRenderer sr;
    public static int score =0; // score  
    public Text scoredisplay; //
    public TrailRenderer ball_trail;  // to give trail the same color as the ball
    public GameObject LC;

    // Start is called before the first frame update
    void Start()
    {
       setcolor();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            rb.velocity = Vector2.up * JumpFactor;
        }
        scoredisplay.text = score.ToString(); 
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "bonus"){ // if touches the star then increase the score
            Destroy(collision.gameObject);
            score+=1;
            Debug.Log("Score: " + score);
        }
        else if(collision.tag == "finishline"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //go to the next scene
            //Debug.Log("Load Next Scene");
        }
        else if(collision.tag == "colorswitcher"){  // color switcher condition
            Scene crr_level =  SceneManager.GetActiveScene();
            Destroy(collision.gameObject);
            if(crr_level.name == "level 1"){
            LC.GetComponent<level1controller>().spawner();
            }
            else if(crr_level.name == "level 2"){
            LC.GetComponent<level2controller>().spawner();
            }
            else if(crr_level.name == "level 3"){
            LC.GetComponent<level3controller>().spawner();
            }
            else if(crr_level.name == "level 4"){
            LC.GetComponent<level4controller>().spawner();
            }
             else if(crr_level.name == "level 5"){
            LC.GetComponent<level5controller>().spawner();
            }
            setcolor();
        }
        else if(collision.tag!= PlayerColor){    // if touches wrong color , reload the same level again
            if(SceneManager.GetActiveScene().buildIndex == 0){
                score = 0;
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void setcolor(){
        int index = Random.Range(0,4);
        ball_trail = GetComponentInChildren<TrailRenderer>();
        switch(index){  // setting color of the ball and the trail
            case 0:
            sr.color = pink;
            PlayerColor = "pink";
            ball_trail.material.color = pink;
            break;
            case 1:
            sr.color = yellow;
            PlayerColor = "yellow";
            ball_trail.material.color = yellow;
            break;
            case 2:
            sr.color = blue;
            PlayerColor = "blue";
            ball_trail.material.color = blue;
            break;
            case 3:
            sr.color = green;
            PlayerColor = "green";
            ball_trail.material.color = green;
            break;
        }
    }
}
