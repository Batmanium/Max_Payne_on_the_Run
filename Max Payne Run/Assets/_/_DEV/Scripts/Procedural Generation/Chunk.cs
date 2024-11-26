using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject bottlePrefab;
    [SerializeField] GameObject pillsPrefab;

    [SerializeField] float bottleSpawnChance = .3f;
    [SerializeField] float pillsSpawnChance = .5f;
    [SerializeField] float pillsSeparationLenght = 2f;

    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;

     List<int> availableLanes = new List<int>() { 0, 1, 2 };
    private void Start()
    {
        SpawnFences();
        SpawnBottle();
        SpawnPills();
    }

    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
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
         Bottle newBottle = Instantiate(bottlePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Bottle>();
         newBottle.Init(levelGenerator);
    }    
    
    void SpawnPills()
    {
        if (Random.value > pillsSpawnChance || availableLanes.Count <= 0) return;
        
        int selectedLane = SelectLane();

        int maxPillstoSpawn = 6;
        int pillsToSpawn = Random.Range(1, maxPillstoSpawn);

        float topOfChunkZPos = transform.position.z + (pillsSeparationLenght * 2f);

        for (int i = 0; i < pillsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * pillsSeparationLenght);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPositionZ);
            Pills newPills = Instantiate(pillsPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Pills>();
            newPills.Init(scoreManager);
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
