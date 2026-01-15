using DG.Tweening;
using UnityEngine;

public class PlayerObjectScaler : MonoBehaviour
{
    [SerializeField] private Transform objectToScale;
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    public void SetSizePercentage(float percentage)
    {
        float scaleSize = Mathf.Lerp(minSize, maxSize, percentage);
        objectToScale.DOScale(scaleSize, 0.1f);
    }
}
