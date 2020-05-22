using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [SerializeField]
    private int maxSpawns;
    private int spawnsLeft;

    [SerializeField]
    private GUIController controller; 

    // Start is called before the first frame update
    void Start()
    {
        spawnsLeft = maxSpawns;
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
        Debug.Log(spawnsLeft);
    }

    public int getMaxSpawns() {
        return maxSpawns;
    }

    public int getSpawnsLeft() {
        return spawnsLeft;
    }
}
