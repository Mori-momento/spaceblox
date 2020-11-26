using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcubespawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    private float spawnTime;
    GameObject newObstacle;
    float halfScreenWidth;
    float halfScreenHieght;
    [SerializeField] private float maxRotation;
    [SerializeField] private Vector2 spawnIntervalMinMax;
    // Start is called before the first frame update
    void Start()
    {
        halfScreenHieght = Camera.main.orthographicSize;
        halfScreenWidth = Camera.main.aspect * halfScreenHieght;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        if (Time.time > spawnTime)
        {
            float spawnInterval = Mathf.Lerp(spawnIntervalMinMax.y, spawnIntervalMinMax.x,difficulty.GetDifficultyPercent());
            spawnTime = Time.time + spawnInterval;

            Vector2 cubeScale = Vector2.one * Random.Range(1f, halfScreenWidth*0.7f);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-halfScreenWidth + cubeScale.x, halfScreenWidth - cubeScale.x), halfScreenHieght + cubeScale.y, 0);
            Vector3 randomRotation = Vector3.forward * Random.Range(-maxRotation,maxRotation);

            newObstacle = (GameObject)Instantiate(obstacle, randomSpawnPosition, Quaternion.Euler(randomRotation));
            newObstacle.transform.localScale = Vector2.one * cubeScale;
           
        }
    }
}
