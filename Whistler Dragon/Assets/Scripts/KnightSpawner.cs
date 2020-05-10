using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform knightsSpawn1;
    [SerializeField]
    private Transform knightsSpawn2;
    [SerializeField]
    private Transform knightsSpawn3;
    private Transform spawn;
    private float knightsPerSec = 0.7f;
    private float lastTimeSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnKnights();
    }

    private bool canSpawn()
    {
        float currentTime = Time.time;
        if (1 / knightsPerSec <= currentTime - lastTimeSpawn)
        {
            lastTimeSpawn = currentTime;
            return true;
        }

        return false;
    }



    private void SpawnKnights()
    {

        if (canSpawn())
        {
            int rand = (int)Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    spawn = knightsSpawn1;
                    break;
                case 1:
                    spawn = knightsSpawn2;
                    break;
                case 2:
                    spawn = knightsSpawn3;
                    break;
            }

            ObjectPooler.Instance.SpawnFromPool("knight", spawn.position, spawn.rotation);
        }

    }
}
