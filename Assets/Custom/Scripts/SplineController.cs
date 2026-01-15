using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class SplineController : MonoBehaviour
{
    [SerializeField] private SplineAnimate splineAnimate;
    [SerializeField] private float reversingSecond;
    [SerializeField] private float reversingStep = 0.01f;
    public void Reverse()
    {
        StartCoroutine(ReverseTime());
    }

    internal void ResetState()
    {
        splineAnimate.Pause();
        splineAnimate.NormalizedTime = 0;
        splineAnimate.Play();
    }

    private IEnumerator ReverseTime()
    {
        float remainingSecond = reversingSecond;
        splineAnimate.Pause();
        while (remainingSecond > 0)
        {
            yield return null;
            // Manually reduce the normalized time
            float newTime = splineAnimate.NormalizedTime - (Time.deltaTime * reversingStep);

            // Clamp to ensure it doesn't go below 0
            splineAnimate.NormalizedTime = Mathf.Max(newTime, 0f);

            remainingSecond -= Time.deltaTime;
        }
        splineAnimate.Play();
    }
}
