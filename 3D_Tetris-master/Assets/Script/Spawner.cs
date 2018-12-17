﻿using UnityEngine;
using System.Collections;

// Spawns new block in the game

public class Spawner : MonoBehaviour
{
    // Groups
    public GameObject[] groups;

    public void NextSpawner()
    {
        // Random Index
        int i = Random.Range(0, groups.Length);

        // Spawn Group at current Position
        Instantiate(groups[i],
                    transform.position,
                    Quaternion.identity);
    }

    void Start()
    {
        // Spawn initial Group
        NextSpawner();
    }
}

