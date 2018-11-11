using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadMovement : MonoBehaviour {

    public GameObject road;
    GameObject fRoad;
    float y, z;
    void Start () {
        fRoad = road;
	}
	
	// Update is called once per frame
	void Update () {
        if(road.GetComponent<Rigidbody>().position.x<=60f)
        {
            road.GetComponent<Rigidbody>().velocity = new Vector3(5f, 0, 0);
          

        }
        else{
            road.GetComponent<Rigidbody>().transform.position = new Vector3(26.8f, .4f, 3f);
           
        }
           
       

    }
}
