using DG.Tweening;
using UnityEngine;

public class GrowSweepListener : SweepListener
{
    [SerializeField] private Ease ease = Ease.OutElastic;
    [SerializeField] private float duration = 0.7f;
    [SerializeField] private float amplitude = 0.3f;
    [SerializeField] private float period = 1;
    private Vector3 startLocalScale;
    private bool active;

    private void Awake()
    {
        startLocalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    protected override void Effect()
    {
        active = !active;
        transform.DOScale(active ? startLocalScale : Vector3.zero, duration)
            .SetEase(ease, amplitude, period);
    }
}
