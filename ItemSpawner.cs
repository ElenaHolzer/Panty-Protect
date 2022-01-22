using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemReference;

    private GameObject spawnedItem;

    [SerializeField]
    private Transform Spawnpoint1, Spawnpoint2, Spawnpoint3, Spawnpoint4, Spawnpoint5, Spawnpoint6, Spawnpoint7, Spawnpoint8;

    private int randomIndex;
    private int randomSpawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));

            randomIndex = Random.Range(0, itemReference.Length);
            randomSpawnpoint = Random.Range(1, 8);

            spawnedItem = Instantiate(itemReference[randomIndex]);

            if (randomSpawnpoint == 1)
            {
                spawnedItem.transform.position = Spawnpoint1.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 2)
            {
                spawnedItem.transform.position = Spawnpoint2.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 3)
            {
                spawnedItem.transform.position = Spawnpoint3.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 4)
            {
                spawnedItem.transform.position = Spawnpoint4.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 5)
            {
                spawnedItem.transform.position = Spawnpoint5.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 6)
            {
                spawnedItem.transform.position = Spawnpoint6.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else if (randomSpawnpoint == 7)
            {
                spawnedItem.transform.position = Spawnpoint7.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
            else
            {
                spawnedItem.transform.position = Spawnpoint8.position;
                spawnedItem.GetComponent<Droplet>().speed = Random.Range(-1, -6);
            }
        }
    }
}
