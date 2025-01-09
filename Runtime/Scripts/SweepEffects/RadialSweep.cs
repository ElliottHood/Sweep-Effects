using UnityEngine;

[CreateAssetMenu(menuName = "Sweep Effects/Radial")]
public class RadialSweep : SweepEffect
{
    public float speed = 25f;

    public override float GetDelay(Vector3 origin, Vector3 targetPosition)
    {
        float distance = Vector3.Distance(origin, targetPosition);
        return distance / speed;
    }
}
