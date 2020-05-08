using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBehaviour : MonoBehaviour
{

    public float speed = 1.0f;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject fireball; 

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.LookAt(target);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fireball(Clone)") {
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.name == "GoldMountain")
        {
            this.gameObject.SetActive(false);            

        }

    }
    

}
