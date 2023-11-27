using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSpawner : MonoBehaviour
{
    [SerializeField] float TimeBetweenSpawns;
    [SerializeField] GameObject DrunkPrefab;
    [SerializeField] Transform[] SpawnLocations;
    float TimePassed;
    // Start is called before the first frame update
    void Start()
    {
        TimePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimePassed += Time.deltaTime;
        if (TimePassed > TimeBetweenSpawns)
        {
            int index = Random.Range(0, SpawnLocations.Length - 1);
            Instantiate(DrunkPrefab, SpawnLocations[index].position, Quaternion.identity);
            TimePassed = 0;
        }
    }
}