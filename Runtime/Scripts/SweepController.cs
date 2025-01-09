using UnityEngine;

public class SweepController : MonoBehaviour
{
    [SerializeField] SweepEffect effect;
    [SerializeField] private Vector3 origin;
    private SweepListener[] subscribers;

    private void Awake()
    {
        subscribers = GetComponentsInChildren<SweepListener>(true);
    }

    public void TriggerEffect() => TriggerEffect(effect);

    public void TriggerEffect(SweepEffect effect)
    {
        if (effect != null)
        {
            effect.TriggerEffect(origin, subscribers);
        }
    }
}

