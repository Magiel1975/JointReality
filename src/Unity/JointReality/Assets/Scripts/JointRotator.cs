using UnityEngine;

public class JointRotator : JointSelectable
{
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }
    public enum RotationDirection
    {
        Forward,
        Backward
    }

    [SerializeField]
    private GameObject ChildArmObject;
    [SerializeField]
    private RotationAxis Axis = RotationAxis.X;
    [SerializeField]
    private int Speed = 5;
    [SerializeField]
    private RotationDirection Direction = RotationDirection.Forward;

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
        var direction = Direction == RotationDirection.Backward ? -1 : 1;

        switch (Axis)
        {
            case RotationAxis.X:
                ChildArmObject.transform.Rotate(direction * Time.deltaTime * Speed, 0, 0);
                break;
            case RotationAxis.Y:
                ChildArmObject.transform.Rotate(0, direction * Time.deltaTime * Speed, 0);
                break;
            case RotationAxis.Z:
                ChildArmObject.transform.Rotate(0, 0, direction * Time.deltaTime * Speed);
                break;
        }
    }

    public override void DoSelect()
    {
        base.DoSelect();
        IsRotating = !IsRotating;
    }
}
