using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnManager Instance;

    [SerializeField] private List<Spawner> spawners = new List<Spawner>();

    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();

    [SerializeField] private GameObject DDoSPrefab;

    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int enemiesPerWave;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerWave; i++)
            {
                int randomSpawnerIndex = Random.Range(0, spawners.Count);
                spawners[randomSpawnerIndex].Spawn(prefabs[Random.Range(0, prefabs.Count)]);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public void StartDDoS()
    {

    }
    
}
