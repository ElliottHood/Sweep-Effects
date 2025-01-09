using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public abstract class SweepListener : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSweepEffect;

    public void TriggerEffect(Vector3 origin, float delay)
    {
        StartCoroutine(PlayEffectWithDelay(delay));
    }

    private IEnumerator PlayEffectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Effect();
        OnSweepEffect.Invoke();
    }

    protected abstract void Effect();
}
