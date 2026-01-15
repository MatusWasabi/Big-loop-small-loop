using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScaler : MonoBehaviour
{
    [SerializeField] private Transform transformToScale;
    [SerializeField] private float bigSize;
    [SerializeField] private float smallSize;
    private static List<ObstacleScaler> instances = new List<ObstacleScaler>();

    private void OnEnable()
    {
        if (transformToScale == null)
        {
            transformToScale = gameObject.transform;
        }

        instances.Add(this);
    }

    private void OnDisable()
    {
        instances.Remove(this);
    }

    private void Resize(float percentage)
    {
        float scaleSize = Mathf.Lerp(bigSize, smallSize, percentage);
        transformToScale.DOScale(scaleSize, 0.1f);
    }

    public static void SetSizePercentage(float percentage)
    {
        foreach (ObstacleScaler instance in instances)
        {
            instance.Resize(percentage);
        }
    }

}

