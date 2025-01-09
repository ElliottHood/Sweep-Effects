using UnityEngine;

[ExecuteInEditMode]
public class PrefabGrid : MonoBehaviour
{
#if UNITY_EDITOR

    [SerializeField] private GameObject prefab;
    [SerializeField] private RowSettings xSettings;
    [SerializeField] private RowSettings ySettings;
    [SerializeField] private RowSettings zSettings;

    [System.Serializable]
    public class RowSettings
    {
        public int count = 1;
        public float spacing = 1;
        public RowAlignment alignment = RowAlignment.Start; // Add enum for alignment
    }

    public enum RowAlignment
    {
        Start,
        Center,
        End
    }

    private void OnValidate()
    {
        // Mark dirty and delay grid generation to avoid unsafe calls during OnValidate
        UnityEditor.EditorApplication.delayCall += RefreshGrid;
    }

    void RefreshGrid()
    {
        if (Application.isPlaying && prefab != null || xSettings == null)
            return;

        // Clear existing instances
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);

            // Remove child GameObject safely
            DestroyImmediate(child.gameObject);
        }

        // Calculate the offsets for centering
        float offsetX = CalculateOffset(xSettings);
        float offsetY = CalculateOffset(ySettings);
        float offsetZ = CalculateOffset(zSettings);

        try
        {        // Instantiate prefabs in a grid based on row settings
            for (int x = 0; x < xSettings.count; x++)
            {
                for (int y = 0; y < ySettings.count; y++)
                {
                    for (int z = 0; z < zSettings.count; z++)
                    {
                        Vector3 position = new Vector3(
                            x * xSettings.spacing - offsetX,
                            y * ySettings.spacing - offsetY,
                            z * zSettings.spacing - offsetZ
                        );
                        GameObject newInstance = UnityEditor.PrefabUtility.InstantiatePrefab(prefab, transform) as GameObject;
                        // GameObject newInstance = Instantiate(prefab, transform);
                        newInstance.transform.localPosition = position;
                    }
                }
            }
        }
        catch
        {
            Debug.LogWarning("Make sure that the gameObject is a prefab");
        }

    }

    private float CalculateOffset(RowSettings settings)
    {
        float offset = 0f;
        switch (settings.alignment)
        {
            case RowAlignment.Center:
                offset = (settings.count - 1) * settings.spacing / 2f;
                break;
            case RowAlignment.End:
                offset = (settings.count - 1) * settings.spacing;
                break;
            case RowAlignment.Start:
            default:
                // No offset needed for 'Start' alignment
                offset = 0f;
                break;
        }
        return offset;
    }

#endif
}
