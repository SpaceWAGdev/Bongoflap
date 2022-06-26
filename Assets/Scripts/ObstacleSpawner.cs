using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField][InspectorName("Obstacles")] GameObject[] obstacles;
    [Header("Spawn Settings")]
    [SerializeField][InspectorName("Delay")] float delay = 1f;
    [SerializeField][InspectorName("Speed change per tick")] float deltaX = 1f;
    List<GameObject> spawnedObstacles = new List<GameObject>();
    bool canSpawn = true;

    void Start()
    {

    }

    void FixedUpdate()
    {
        spawnedObstacles = new List<GameObject>();
        foreach (Transform t in transform){
            spawnedObstacles.Add(t.gameObject);
        }

        if (canSpawn)
        {
            Spawn();
            StartCoroutine(Delay());
        }

        foreach (GameObject obstacle in spawnedObstacles)
        {
            if (obstacle)
            {
                if (obstacle.transform.position.x < -12)
                {
                    Destroy(obstacle);
                    continue;
                }
                Debug.Log(spawnedObstacles.Count);
                obstacle.transform.position += obstacle.transform.TransformDirection(Vector2.left * deltaX);
            }

        }

    }

    IEnumerator Delay()
    {
        canSpawn = false;
        yield return new WaitForSeconds(delay);
        canSpawn = true;
    }

    void Spawn()
    {
        Instantiate(obstacles[_PickRandom(obstacles.Length)], this.transform);
    }

    int _PickRandom(int size) => Random.Range(0, size);
}
