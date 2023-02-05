using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FoodSpawner : Monosingleton<FoodSpawner>
{
    public GameObject foodPrefab;
    public int poolSize = 10;
    [SerializeField] private Vector3 spawnArea = new Vector3(5, 0, 5);

    private List<GameObject> foodPool;
    private int currentIndex = 0;

    private void Start()
    {
        foodPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject foodGO = Instantiate(foodPrefab, transform);
            foodGO.SetActive(false);
            foodPool.Add(foodGO);
        }

        StartCoroutine(SpawnFood());
    }

    private IEnumerator SpawnFood()
    {
        while (true)
        {
            if (currentIndex < poolSize)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    if (!foodPool[i].activeInHierarchy)
                    {
                        ActivateFood(foodPool[i]);
                    }
                    yield return new WaitForSeconds(1.0f);
                }
            }

            
        }
    }

    private void ActivateFood(GameObject go)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            0,
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        go.transform.position = spawnPosition;
        go.SetActive(true);
    }


    public void DeactiveFood(GameObject go)
    {
        go.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position == foodPool[currentIndex].transform.position)
        {
            foodPool[currentIndex].SetActive(false); // alınan foodların setactivini false yap bir dahaki spana kadar
            //ScoreManager.instance.AddPoint();
        }
    }
}