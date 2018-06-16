using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour {
    public GameObject gripObject;
    public GameObject lockObject;
    ObjectState objectState = ObjectState.loose;
    float pickrange = 0.05f;
    float grabbedrange = 0.01f;
    float lockrange = 0.05f;
    bool canPick = true;
    // Use this for initialization
    void Start()
    {
        gripObject = GameObject.Find("GripObject");
        lockObject = GameObject.Find("LockObject");

    }

    // Update is called once per frame
    void Update()
    {

        if (gripObject != null && lockObject!=null)
        {
            switch(objectState)
            {
                case ObjectState.loose:
                    var dist = Vector3.Distance(gripObject.transform.position, transform.position);
                    if (dist < grabbedrange)
                    {
                        transform.position = gripObject.transform.position;
                        objectState = ObjectState.grabbed;
                    }
                    else if (dist < pickrange)
                    {
                        transform.position = Vector3.Lerp(transform.position,gripObject.transform.position, Time.deltaTime);
                    }
                    break;
                case ObjectState.grabbed:
                    var dist2 = Vector3.Distance(lockObject.transform.position, transform.position);
                    if (dist2 < grabbedrange)
                    {
                        transform.position = lockObject.transform.position;
                        objectState = ObjectState.placed;
                    }
                    else if (dist2 < lockrange)
                    {
                        transform.position = Vector3.Lerp(transform.position, lockObject.transform.position, Time.deltaTime);
                    }
                    break;
            }
        }
    }
    enum ObjectState
    {
        loose,
        grabbed,
        placed
    }
}
