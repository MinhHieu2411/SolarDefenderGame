using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInputManager : MonoBehaviour
{
    public enum InputType
    {
        PDesktop,
        PMobile,
        Bot
    }
    
    public static iMovementControls GetInputcontrols(InputType inputType)
    {
        return inputType switch
        {
            InputType.PDesktop => new DesktopMovementControls(),
            InputType.PMobile => null,
            InputType.Bot => null,
            _ => throw new ArgumentOutOfRangeException(nameof(inputType), inputType, null)
        };
    }
}
