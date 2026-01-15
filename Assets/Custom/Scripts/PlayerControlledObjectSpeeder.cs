using UnityEngine;
using UnityEngine.Splines;

public class PlayerControlledObjectSpeeder : MonoBehaviour
{
    [SerializeField] private SplineAnimate animator;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    public void SetPercentage(float percentage)
    {
        float newSpeed = Mathf.Lerp(maxSpeed, minSpeed, percentage);
        float currentProgress = animator.NormalizedTime;
        animator.MaxSpeed = newSpeed;
        animator.NormalizedTime = currentProgress; // Restore position
    }
}
