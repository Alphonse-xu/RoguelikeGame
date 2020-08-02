using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{ 
    public GameObject wall;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
 
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(ps != null){
            ps.Play();
            Destroy(ps.transform.parent.gameObject, 1.0F);
        }
            
    }
    private void OnTriggerStay(Collider other) {
        wall.SendMessage("Lift");
    }
}
