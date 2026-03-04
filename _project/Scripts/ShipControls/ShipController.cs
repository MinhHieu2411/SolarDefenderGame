using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    //[InlineEditor(InlineEditorObjectFieldModes.Boxed)]
    [SerializeField] ShipMovementInput _shipMovementInput;


    [Header("Ship movement values")]
    [SerializeField][Range(1000f, 20000f)] float _thrustForce = 24000f; //toc do (nhanh/cham)
    [SerializeField][Range(1000f, 20000f)] float _pitchForce = 2400f; //mui tau huong len/xuong
    [SerializeField][Range(3000f, 20000f)] float _rollForce = 8400f;// nghieng trai/phai
    [SerializeField][Range(1000f, 20000f)] float _yawForce = 2400f;// mui tau huong trai/phai

    Rigidbody _rigidBody;
    // no goi la cuong do luc cho
    [Header("Ship movement input")]
    [SerializeField][Range(-1f, 1f)] float _thrustInput=0f;
    [SerializeField][Range(-1f, 1f)] float _pitchInput=0f;
    [SerializeField][Range(-1f, 1f)] float _rollInput=0f;
    [SerializeField][Range(-1f, 1f)] float _yawInput = 0f;

    iMovementControls ControlInput => _shipMovementInput.MovementControls;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        //an chuot
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        _thrustInput = ControlInput.ThrustInput;
        _pitchInput = ControlInput.PitchInput;
        _rollInput = ControlInput.RollInput;
        _yawInput = ControlInput.YawInput;
        //mo lai chuot
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FixedUpdate()
    {
        if(!Mathf.Approximately(0f, _pitchInput))
        {
            _rigidBody.AddTorque(transform.right * (_pitchForce * _pitchInput * Time.fixedDeltaTime));
        }
        if(!Mathf.Approximately(0f, _rollInput))
        {
            _rigidBody.AddTorque(transform.forward * (-_rollForce * _rollInput * Time.fixedDeltaTime));
        }
        if (!Mathf.Approximately(0f, _yawInput))
        {
            _rigidBody.AddTorque(transform.up * (_yawForce * _yawInput * Time.fixedDeltaTime));
        }
        //ga
        if (!Mathf.Approximately(0f, _thrustInput))
        {
            _rigidBody.AddForce(transform.forward * (_thrustForce * _thrustInput * Time.fixedDeltaTime));
        }
    }
}
