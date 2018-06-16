using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointSelectable : MonoBehaviour, IInputClickHandler {
    public void OnInputClicked(InputClickedEventData eventData)
    {
 
        DoSelect();
    }

    private void OnMouseUp()
    {
        DoSelect();
    }

    private void OnMouseDown()
    {
        DoSelect();
    }

    public virtual void DoSelect()
    {

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
