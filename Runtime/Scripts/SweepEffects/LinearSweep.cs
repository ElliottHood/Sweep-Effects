using UnityEngine;

[CreateAssetMenu(menuName = "Sweep Effects/Linear")]
public class LinearSweepEffect : SweepEffect
{
    public Vector3 speed = new Vector3(25, 0, 0);

    public override float GetDelay(Vector3 origin, Vector3 targetPosition)
    {
        float xDelay = speed.x == 0 ? 0 : Mathf.Abs(targetPosition.x - origin.x) / speed.x;
        float yDelay = speed.y == 0 ? 0 : Mathf.Abs(targetPosition.y - origin.y) / speed.y;
        float zDelay = speed.z == 0 ? 0 : Mathf.Abs(targetPosition.z - origin.z) / speed.z;
        return xDelay + yDelay + zDelay;
    }
}
