using System;
using UnityEngine;
[Serializable]
public class DesktopMovementControls : MovementControlsBase
{
    [SerializeField] float _deadZoneRadius = 0.1f;
    Vector2 ScreenCenter => new Vector2(Screen.width *0.5f, Screen.height * 0.5f);

    public override float YawInput
    {
        get
        {
            Vector3 mousePos = Input.mousePosition;
            float yaw = (mousePos.x - ScreenCenter.x) / ScreenCenter.x;
            return Mathf.Abs(yaw) > _deadZoneRadius ? yaw : 0f;
        }
    }
    public override float PitchInput
    {
        get
        {
            Vector3 mousePos = Input.mousePosition;
            float pitch = -(mousePos.y - ScreenCenter.y) / ScreenCenter.y; // co the sua len xuong
            return Mathf.Abs(pitch) > _deadZoneRadius ? pitch : 0f; 
        }
    }
    public override float RollInput
    {
        get
        {
            if(Input.GetKey(KeyCode.A))
                return -1f;
            return (Input.GetKey(KeyCode.D)) ? 1f : 0f;
        }
    }
    public override float ThrustInput => Input.GetAxis("Vertical");
}
