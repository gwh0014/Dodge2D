using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    float spawnInterval = 1f;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void SpawnFallingObject()
    {
        float xPos = Random.Range(-8f, 8f);
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0f);
        GameObject newObject = Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);

        
        newObject.transform.localScale = Vector3.one * Random.Range(0.5f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnFallingObject();
            timer = 0f;
        }
    }
}
