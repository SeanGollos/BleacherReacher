using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    bool spawn = true;
    LevelHandler lh;

    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Valuable[] objectPrefabs;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        lh = FindObjectOfType<LevelHandler>();
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            //Do another check in case spawn has changed while we were waiting
            if (spawn)
            {
                SpawnObject();
                lh.IncrementActiveObjects();
            }
        }
    }
    private void SpawnObject()
    {
        Valuable chosenValuable;
        chosenValuable = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        Spawn(chosenValuable);
    }
    private void Spawn(Valuable valuable)
    {
        Valuable newObject = Instantiate(valuable, transform.position, transform.rotation) as Valuable;

        newObject.transform.parent = transform;
    }
    public void StopSpawning()
    {
        spawn = false;
    }
}
