using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnLevel();
    }

    public GameObject[] Levels;
    int levelIndex;
    GameObject currLevel;

    void DespawnLevel()
    {
        Destroy(currLevel);
    }

    void SpawnLevel()
    {
        currLevel = GameObject.Instantiate(Levels[levelIndex]);

        // TODO: Reset Ball Position
    }

    public void LevelComplete()
    {
        DespawnLevel();
        levelIndex++;
        SpawnLevel();
    }
}
