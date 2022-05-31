using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    Monster[] Monsters;
    public String nextLevelName;

    private void Start()
    {
        Monsters = FindObjectsOfType<Monster>();
    }
    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
        MoveToNextLevel();
    }

    private void MoveToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private bool MonstersAreAllDead()
    {
        foreach (var monster in Monsters)
        {
            if (monster.gameObject.activeSelf)
                return false;                         
        }

        return true;
    }
}
