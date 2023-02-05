using UnityEngine;


public class SpawnEnemies : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;
   [SerializeField] private int numberOfEnemies;
   [SerializeField] private Vector3 spawnArea;
   [SerializeField] private GameObject player;

  
   [HideInInspector] public GameObject[] enemies;

    void Start()
    {
        enemies = new GameObject[numberOfEnemies];
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            enemies[i] = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
    }

    void Update()
    {
        int aliveEnemies = 0;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            if (enemies[i] != null && enemies[i].transform.position.y > 0)
            {
                aliveEnemies++;
            }
            else
            {
                enemies[i].SetActive(false);
            }
        }

        if (aliveEnemies < 1)
        {
            GameManager.Instance.WinGame();
            GameManager.Instance.Buttonactive();
            enabled = false;
            
        }
        else // game managerdan eriş
        {
            if (player.transform.position.y<0)
            {
                GameManager.Instance.LoseGame();
                player.SetActive(false);
                
                GameManager.Instance.Buttonactive();
            }
        }
    }
    
}
