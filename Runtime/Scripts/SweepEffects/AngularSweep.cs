using UnityEngine;

[CreateAssetMenu(menuName = "Sweep Effects/Angular")]
public class AngularSweepEffect : SweepEffect
{
    public float angularSpeed = 45f; // Degrees per second
    public float distanceSpeed = 10f; // Units per second

    public override float GetDelay(Vector3 origin, Vector3 targetPosition)
    {
        // Calculate the direction from origin to target
        Vector3 directionToTarget = (targetPosition - origin).normalized;

        // Default forward direction (can be changed if needed)
        Vector3 forwardDirection = Vector3.forward;

        // Calculate the angle difference (in degrees)
        float angleDifference = Vector3.SignedAngle(forwardDirection, directionToTarget, Vector3.up);

        // Calculate the distance between the origin and the target
        float signedDistance = Vector3.Distance(origin, targetPosition);

        // Calculate the angular delay (time to sweep to the angle)
        float angularDelay = Mathf.Abs(angleDifference) / angularSpeed;

        // Calculate the distance delay (time to reach the target distance)
        float distanceDelay = Mathf.Abs(signedDistance) / distanceSpeed;

        // Combine the delays (you can modify this formula if needed)
        return angularDelay + distanceDelay;
    }
}
