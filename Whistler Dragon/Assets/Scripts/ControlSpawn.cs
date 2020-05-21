using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpawn : MonoBehaviour
{
    [SerializeField]
    private int maxSpawns;
    private int spawnsLeft;
    private int spawns = 0;

    [SerializeField]
    GUIController controller;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnsLeft = maxSpawns;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnsLeft <= 0) {

            controller.Victory();
        }
    }

    public void Dead() {
        spawnsLeft--;
        
    }

    public int getSpawnsLeft() {
        return spawnsLeft;
    }

    public int getMaxSpawns()
    {
        return maxSpawns;
    }


}
