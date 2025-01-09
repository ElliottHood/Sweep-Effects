using UnityEngine;

public abstract class SweepEffect : ScriptableObject
{
    public abstract float GetDelay(Vector3 origin, Vector3 targetPosition);

    public virtual void TriggerEffect(Vector3 origin, SweepListener[] subscribers)
    {
        foreach (var subscriber in subscribers)
        {
            float delay = GetDelay(origin, subscriber.transform.position);
            subscriber.TriggerEffect(origin, delay);
        }
    }
}
