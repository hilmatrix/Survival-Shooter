using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;

    [SerializeField]
    MonoBehaviour factory = null;

    IFactory Factory { get { return factory as IFactory; } }

    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnEnemy = Random.Range(0, 3);
        int spawnPointIndex = Random.Range(0, 3);

        Factory.FactoryMethod(spawnEnemy, spawnPointIndex);
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
