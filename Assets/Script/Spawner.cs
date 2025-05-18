using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform topPos;
    [SerializeField] private Transform highPos;
    [SerializeField] private Transform lowPos;
    private float spawnTime = 1f;
    [SerializeField] private float spawnRate = 2f;

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnRate)
        {
            SpawnObstacles();
            spawnTime = 0f; // Reset the spawn time
        }
    }

    private void SpawnObstacles()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        if (randomIndex == 0 || randomIndex == 1 )
        {
            GameObject obstacle = Instantiate(obstacles[randomIndex], lowPos.position, Quaternion.identity);
        }

        else if (randomIndex == 2)
        {
            // Random high or top position for eagle
            Transform[] eaglePositions = new Transform[] { highPos, topPos };
            int posIndex = Random.Range(0, eaglePositions.Length);

            Instantiate(obstacles[randomIndex], eaglePositions[posIndex].position, Quaternion.identity);
        }
    }
}
