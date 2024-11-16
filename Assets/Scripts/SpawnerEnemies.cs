
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    private Transform target;
    private float spawnCooldown = 3f;
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (spawnCooldown > 0f)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) < 21f)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                spawnCooldown = 3f;
            }
        }
    }
}
