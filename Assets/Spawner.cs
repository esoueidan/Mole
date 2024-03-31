using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numSpheres = 10;
    public float spawnRadius = 5f;
    public float spawnInterval = 2f;

    private Coroutine spawningCoroutine;

    void Start()
    {
        spawningCoroutine = StartCoroutine(SpawnSpheresRoutine());
    }

    IEnumerator SpawnSpheresRoutine()
    {

            
            for (int i = 0; i < numSpheres; i++)
            {
                DestroyPreviousSpheres();
                Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
                Vector3 spawnPos = transform.position + randomOffset;

                GameObject Mole = Instantiate(spherePrefab, spawnPos, Quaternion.identity);
                //sphere.AddComponent<SphereClickHandler>();
                yield return new WaitForSeconds(spawnInterval);
            }
            
    }

    void DestroyPreviousSpheres()
    {
        GameObject[] Moles = GameObject.FindGameObjectsWithTag("Mole");
        foreach (GameObject Mole in Moles)
        {
            Destroy(Mole);
        }
    }

    void OnDisable()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }
    }
}
