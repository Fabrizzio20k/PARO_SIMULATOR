
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    private Transform target;
    private float spawnCooldown = 3f;
    [SerializeField] private GameObject enemyPrefab;

    private Globals globals;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        globals = GameObject.Find("Globals").GetComponent<Globals>();
    }
    void Update()
    {
        if (spawnCooldown > 0f)
        {
            spawnCooldown -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) < 21f && globals.getQuantity() < 10)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                spawnCooldown = 2.5f;
                globals.addNPC(1);
            }
        }
    }
}
