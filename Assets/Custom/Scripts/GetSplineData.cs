using UnityEngine;
using UnityEngine.Splines;

public class GetSplineData : MonoBehaviour
{
    [SerializeField] private SplineContainer container;

    [ContextMenu("Spline Data")]
    public void GetData()
    {
        container.Spline.TryGetIntData("Hello world?", out var data);
        Debug.Log(data[0].Value.ToString());
    }

    [ContextMenu("Create Objects")]
    public void CreatePathObject()
    {
        var splines = container.Splines;
        foreach (var spline in splines)
        {
            if (!spline.TryGetObjectData("Prefab", out var prefabData))
            {
                Debug.LogError("Prefab data not found");
                return;
            }

            for (int i = 0; i < spline.Count; i++)
            {
                GameObject obj = null;
                if (prefabData[i].Value != null)
                {
                    obj = (GameObject)prefabData[i].Value;
                }
                else
                {
                    obj = (GameObject)(prefabData.DefaultValue);
                }

                if (obj == null) continue;

                if (obj is not GameObject prefab)
                {
                    Debug.LogWarning($"Object at knot {i} is not a GameObject");
                    continue;
                }

                Vector3 worldPos = container.transform.TransformPoint(spline[i].Position);


                Instantiate(prefab, worldPos, Quaternion.identity);
            }
        } 
    }
}
