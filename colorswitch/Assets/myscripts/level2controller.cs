using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2controller : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject ColorChanger;
    [SerializeField]
    private GameObject finishline;
    private GameObject previous;
    float y = 2f;
    float gap = 4f; // gap between the obstacles
    int count;
    // Start is called before the first frame update
    void Start()
    {
         count =0;
         spawner(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawner(bool firsttime = false){
        if(!firsttime){
            Destroy(previous);
        }
        else{
            firsttime= false;
        }
        int ri = Random.Range(0, obstacles.Length); // right side boundary not included
        previous = Instantiate(obstacles[ri],new Vector3(0, y, 0), Quaternion.identity);// ask about Quaternion.identity
        y += gap;
        if(count ==  2){
            count = 0;
            Instantiate(finishline,new Vector3(0, y, 0), Quaternion.identity);// ask about Quaternion.identity  // no rotation on the parent object 
        }
        else {
           Instantiate(ColorChanger,new Vector3(0, y, 0), Quaternion.identity);// ask about Quaternion.identity  // no rotation on the parent object 
           count++;
           y += gap;  
        }
    }                               
}
