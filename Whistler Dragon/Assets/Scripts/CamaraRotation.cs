using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraRotation : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    public float turnRestrictionDegrees = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = camera.transform.rotation.eulerAngles;
        float rotationY = rotation.y;

        if (rotationY > 270)
        {
            if(rotationY - 360 < -turnRestrictionDegrees)
            {
                rotationY = -turnRestrictionDegrees;
            }
        }
        else
        {
            if(rotationY > turnRestrictionDegrees)
            {
                rotationY = turnRestrictionDegrees;
            }
        }

        transform.rotation = Quaternion.Euler(0,rotationY, 0);
 
    }
}
