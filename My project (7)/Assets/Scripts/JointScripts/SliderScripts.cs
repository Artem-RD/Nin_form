using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScripts : MonoBehaviour
{
    public SliderJoint2D platform;
    public SliderJoint2D _slide;
    public int speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slider"))
        {
            JointMotor2D motor = _slide.motor;
            motor.motorSpeed = speed;
            _slide.motor = motor;
        }
    }


}
