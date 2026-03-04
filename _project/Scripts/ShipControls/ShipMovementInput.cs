using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementInput : MonoBehaviour
{
    [SerializeField] ShipInputManager.InputType _inputType = ShipInputManager.InputType.PDesktop;
    
    public iMovementControls MovementControls { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        MovementControls = ShipInputManager.GetInputcontrols(_inputType);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        MovementControls = null;
    }
}
