using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public static PowerupManager Instance { get; private set; }

    private List<GameObject> powerupsInScene = new List<GameObject>();

    private void Awake()
    {
        //Singleton first-time run
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        print(powerupsInScene.Count);
    }

    public void AddToList(GameObject powerup)
    {
        powerupsInScene.Add(powerup);
    }

    internal void RemoveFromList(GameObject powerup)
    {
        powerupsInScene.Remove(powerup);
    }
}
