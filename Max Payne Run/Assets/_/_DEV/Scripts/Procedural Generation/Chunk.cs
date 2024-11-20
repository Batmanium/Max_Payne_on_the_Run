using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject bottlePrefab;
    [SerializeField] GameObject painKillerPrefab;

    [SerializeField] float bottleSpawnChance = .3f;
    [SerializeField] float painKillerSpawnChance = .5f;
    [SerializeField] float painKillerSeparationLenght = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

     List<int> availableLanes = new List<int>() { 0, 1, 2 };
    private void Start()
    {
        SpawnFences();
        SpawnBottle();
        SpawnPainKiller();
    }

    void SpawnFences()
    {

        int fencesToSpawn = Random.Range(0, lanes.Length);

        for(int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
    void SpawnBottle()
    {
        if (Random.value > bottleSpawnChance || availableLanes.Count <= 0) return;
        
        int selectedLane = SelectLane();

         Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
         Instantiate(bottlePrefab, spawnPosition, Quaternion.identity, this.transform);
    }    
    
    void SpawnPainKiller()
    {
        if (Random.value > painKillerSpawnChance || availableLanes.Count <= 0) return;
        
        int selectedLane = SelectLane();

        int maxPainKillerstoSpawn = 6;
        int painKillersToSpawn = Random.Range(1, maxPainKillerstoSpawn);

        float topOfChunkZPos = transform.position.z + (painKillerSeparationLenght * 2f);

        for (int i = 0; i < painKillersToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * painKillerSeparationLenght);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Instantiate(painKillerPrefab, spawnPosition, Quaternion.identity, this.transform);
        }


    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }


}
