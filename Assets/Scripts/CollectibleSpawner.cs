using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles; // array for Red, Green, Blue prefabs
    public float spawnInterval = 2f;  // how often to spawn
    public float spawnRange = 10f;    // area size for spawning

    void Start()
    {
        // spawn repeatedly every few seconds
        InvokeRepeating(nameof(SpawnCollectible), 1f, spawnInterval);
    }

    void SpawnCollectible()
    {
        // pick a random prefab
        int randomIndex = Random.Range(0, collectibles.Length);

        // random position within range
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            1f, // height
            Random.Range(-spawnRange, spawnRange)
        );

        // spawn it in the scene
        Instantiate(collectibles[randomIndex], randomPos, Quaternion.identity);
    }
}
