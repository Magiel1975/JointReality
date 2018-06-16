using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointRotator : JointSelectable
{
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    //[SerializeField]
    //private GameObject JointObject;
    [SerializeField]
    private GameObject ChildArmObject;
    [SerializeField]
    private RotationAxis Axis;
    [SerializeField]
    private int Speed;

    public bool IsRotating { get; set; }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsRotating)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        switch(Axis)
        {
            case RotationAxis.X:
                ChildArmObject.transform.Rotate(Time.deltaTime * Speed, 0, 0);
                break;
            case RotationAxis.Y:
                ChildArmObject.transform.Rotate(0, Time.deltaTime * Speed, 0);
                break;
            case RotationAxis.Z:
                ChildArmObject.transform.Rotate(0, 0, Time.deltaTime * Speed);
                break;
        }
    }

    public override void DoSelect()
    {
        base.DoSelect();
        IsRotating = !IsRotating;
    }
}
