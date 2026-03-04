using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCockpitControls : MonoBehaviour
{

    [Header("Flight control transforms and ranges")] [SerializeField]
    Transform _joystick;

    [Header("Flight control transforms and ranges")] [SerializeField]
    Vector3 _joystickRange = Vector3.zero;

    [Header("Flight control transforms and ranges")] [SerializeField]
    List<Transform> _throttle;


    [Header("Flight control transforms and ranges")] [SerializeField]
    Vector3 _throttleRange = Vector3.zero;

    [SerializeField]
    ShipMovementInput _shipMovementInput;

    iMovementControls ControlInput => _shipMovementInput.MovementControls;


    // Update is called once per frame
    void Update()
    {
        _joystick.localRotation = Quaternion.Euler(
            ControlInput.PitchInput * _joystickRange.x,
            ControlInput.YawInput * _joystickRange.y,
            -ControlInput.RollInput * _joystickRange.z
        );
    }
}
