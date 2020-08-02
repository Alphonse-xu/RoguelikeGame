using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float maxY = 12.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)){
            Lift();
        }
        
    }

    public void Echo(){
        print("noooooo");
    }

    public void Lift(){
        if(transform.position.y <= 14.0F){
            transform.position=new Vector3( transform.position.x,
            transform.position.y + 0.1F, transform.position.z);
        }
    }
}
