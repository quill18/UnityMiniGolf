using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HOLE COMPLETE!!!");

        // TODO: Maybe wait until you congrats the player?

        GameObject.FindObjectOfType<LevelManager>().LevelComplete();
    }
}
