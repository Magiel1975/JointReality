using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{
    public GameObject gripObject;
    public GameObject lockObject;
    ObjectState objectState = ObjectState.loose;
    float pickrange = 0.10f;
    float grabbedrange = 0.01f;
    float lockrange = 0.10f;
    bool canPick = true;

    Material isGrabbed;
    Material isDropped;
    Material isPlaced;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {
        gripObject = GameObject.Find("GripObject");
        lockObject = GameObject.Find("LockObject");
        isGrabbed = Resources.Load<Material>("Material/IsGrabbed");
        isDropped = Resources.Load<Material>("Material/IsDropped");
        isPlaced = Resources.Load<Material>("Material/IsPlaced");
        renderer = GetComponent<Renderer>();

        if (isDropped != null && renderer != null)
            renderer.material = isDropped;
    }

    // Update is called once per frame
    void Update()
    {

        if (gripObject != null && lockObject != null)
        {
            switch (objectState)
            {
                case ObjectState.loose:
                    var dist = Vector3.Distance(gripObject.transform.position, transform.position);
                    if (dist < grabbedrange)
                    {
                        transform.position = gripObject.transform.position;
                        objectState = ObjectState.grabbed;

                        if (isGrabbed != null && renderer != null)
                            renderer.material = isGrabbed;
                    }
                    else if (dist < pickrange)
                    {
                        transform.position = Vector3.Lerp(transform.position, gripObject.transform.position, Time.deltaTime);
                    }
                    break;
                case ObjectState.grabbed:
                    var dist2 = Vector3.Distance(lockObject.transform.position, transform.position);
                    if (dist2 < grabbedrange)
                    {
                        transform.position = lockObject.transform.position;
                        objectState = ObjectState.placed;
                        if (isPlaced != null && renderer != null)
                        {
                            renderer.material = isPlaced;
                            Supporters.Instance.SayWinner();
                        }
                    }
                    else if (dist2 < lockrange)
                    {
                        transform.position = Vector3.Lerp(transform.position, lockObject.transform.position, Time.deltaTime);
                    }
                    else
                    {
                        transform.position = gripObject.transform.position;
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
