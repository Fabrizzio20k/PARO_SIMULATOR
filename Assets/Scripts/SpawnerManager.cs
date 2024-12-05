using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;

    private List<SpawnerEnemies> spawners = new List<SpawnerEnemies>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RegisterSpawner(SpawnerEnemies spawner)
    {
        if (!spawners.Contains(spawner))
        {
            spawners.Add(spawner);
        }
    }
    public void RegisterEnemy(GameObject enemy)
    {
        if (!spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Add(enemy);
        }
    }
    public void StopAllSpawners()
    {
        foreach (var spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
    public void DestroyAllEnemies()
    {
        foreach (var enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
        spawnedEnemies.Clear();
    }
}
