using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance { get; set; }

    public List<GameObject> bricksInScene = new List<GameObject>();

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
        if (bricksInScene.Count == 0)
        {
            //Victory screen
            SceneManager.LoadScene("Victory");
        }
    }

    public void AddToList(GameObject brick)
    {
        print(brick);
        bricksInScene.Add(brick);
    }

    internal void RemoveFromList(GameObject brick)
    {
        bricksInScene.Remove(brick);
    }

}
