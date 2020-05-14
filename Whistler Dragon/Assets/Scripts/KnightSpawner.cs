using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSpawner : MonoBehaviour
{
    [SerializeField]
    public List<Transform> transforms;
   
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
            int rand = (int)Random.Range(0, 6);
            spawn = transforms[rand];
            string knight;
            int rand2 = (int)Random.Range(0, 4);
            switch (rand2) {

                case 0:
                    knight = "knight4";
                    break;
                case 1:
                    knight = "knight2";
                    break;
                case 2:
                    knight = "knight3";
                    break;
                default:
                    knight = "knight";
                    break;        
          
            }


            ObjectPooler.Instance.SpawnFromPool(knight, spawn.position, spawn.rotation);
        }

    }
}
