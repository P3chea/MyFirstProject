using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewElevator : MonoBehaviour
{
    public SliderJoint2D slider;
    public JointMotor2D joint;
    void Start()
    {
        joint = slider.motor;
    }

    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            joint.motorSpeed = 1;
            slider.motor = joint;
        }

        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            joint.motorSpeed = -1;
            slider.motor = joint;
        }
    }
}
