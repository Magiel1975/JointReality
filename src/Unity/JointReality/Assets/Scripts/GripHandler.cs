using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripHandler : MonoBehaviour {

    public GameObject KeyObject;
    float pickrange = 0.05f;
    bool canPick = true;
	// Use this for initialization
	void Start () {
        KeyObject = GameObject.Find("KeyObject");

    }
	
	// Update is called once per frame
	void Update () {
		
        if(KeyObject!=null)
        {
            if(canPick && Vector3.Distance(KeyObject.transform.position, transform.position)<pickrange)
            {
                KeyObject.transform.position = Vector3.Lerp(KeyObject.transform.position, transform.position, Time.deltaTime);
            }
        }
	}
}
