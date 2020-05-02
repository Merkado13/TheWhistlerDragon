using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IPooledObject
{
    
    private Vector3 direction;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float maxDistance = 100;
    private Vector3 initPos;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Vector3.Distance(initPos, transform.position) > maxDistance){
            this.gameObject.SetActive(false);
        }
        else
        {
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
    }


    public void OnObjectSpawn()
    {
        initPos = transform.position;
        direction = transform.forward;
    }



}
