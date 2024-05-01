using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject MolePrefab;
    public GameObject BombPrefab;
    public GameObject PrincessPrefab;
    public int numSpheres = 60;
    public float spawnRadius = 15f;
    public float spawnInterval = 6;
    public float timer;
    public bool  isPaused;

    private Coroutine spawningCoroutine;

    void Start()
    {   
        spawnInterval = DifState.difficulty;
        spawningCoroutine = StartCoroutine(SpawnSpheresRoutine());
    }

    IEnumerator SpawnSpheresRoutine()
    {
            for (int i = 0; i < numSpheres; i++)
            {
                DestroyPreviousSpheres();
                Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
                Vector3 spawnPos = transform.position + randomOffset;
                Vector3 direction = spawnPos - Camera.main.transform.position;
                Quaternion rotation = Quaternion.LookRotation(-direction);
            int x = Random.Range(1, 21);
                //Debug.Log(x);
                if(x>=5 && x<10){
                    GameObject Bomb = Instantiate(BombPrefab, spawnPos, rotation);
                }
                else if(x==10){
                    GameObject Princess = Instantiate(PrincessPrefab, spawnPos, rotation);
                }
                else{
                    GameObject Mole = Instantiate(MolePrefab, spawnPos, rotation);
                }
                timer = 0;
                while (timer < spawnInterval)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
            }
            
    }

    void DestroyPreviousSpheres()
    {
        GameObject[] Moles = GameObject.FindGameObjectsWithTag("Mole");
        foreach (GameObject Mole in Moles)
        {
            Destroy(Mole);
        }
        GameObject[] Bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject Bomb in Bombs)
        {
            Destroy(Bomb);
        }
        GameObject[] Princesses = GameObject.FindGameObjectsWithTag("Princess");
        foreach (GameObject Princess in Princesses)
        {
            Destroy(Princess);
        }
    }
}
