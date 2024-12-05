
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    private Transform target;
    private float spawnCooldown = 3f;
    [SerializeField] private GameObject enemyPrefab;

    private Globals globals;

    private bool canSpawn = true;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        globals = GameObject.Find("Globals").GetComponent<Globals>();
        SpawnerManager.Instance.RegisterSpawner(this);
    }
    void Update()
    {
        if (!canSpawn) return;

        if (spawnCooldown > 0f)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) < 21f && globals.getQuantity() < 10)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                SpawnerManager.Instance.RegisterEnemy(newEnemy);
                spawnCooldown = 2.5f;
                globals.addNPC(1);
            }
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
}
