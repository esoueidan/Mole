using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrackingControllers : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private GameObject spawnedPrefab;
    private ARTrackedImageManager trackedImageManager;

    void Start()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Spawn prefab when image is tracked
            SpawnPrefab(trackedImage);
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            // Remove prefab when image is no longer tracked
            RemovePrefab(trackedImage);
        }
    }

    void SpawnPrefab(ARTrackedImage trackedImage)
    {
        // Spawn prefab at the position and rotation of the tracked image
        spawnedPrefab = Instantiate(prefabToSpawn, trackedImage.transform.position, trackedImage.transform.rotation);
    }

    void RemovePrefab(ARTrackedImage trackedImage)
    {
        // Remove or deactivate the spawned prefab
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
        }
    }
}
