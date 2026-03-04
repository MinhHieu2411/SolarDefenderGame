public abstract class MovementControlsBase : iMovementControls
{

    public abstract float YawInput { get; }
    public abstract float PitchInput { get; }
    public abstract float RollInput { get; }
    public abstract float ThrustInput { get; }
}
