﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private IInputedControls controls;

    [SerializeField]
    private float fireballsPerSecond = 1;
    private float lastTimeShoot = 0;

    private float maxAmountFire = 100.0f;
    private float currentFireAmount = 100.0f;

    [SerializeField]
    private float fireCostPerFireBall = 5;

    private void Awake()
    {
        controls = GetComponent<IInputedControls>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = controls.GetPlayerRotation(transform.rotation, rotationSpeed * Time.deltaTime);
        ShootFireBall();
    }

    private void ShootFireBall()
    {
        if (controls.isShotInputActivated())
        {
            if (canShoot() && hasFireToShot()){
                ObjectPooler.Instance.SpawnFromPool("fireball", transform.position, transform.rotation);
                currentFireAmount -= fireCostPerFireBall;
            }
        }
    }

    private bool canShoot()
    {
        float currentTime = Time.time;
        if (1/fireballsPerSecond <= currentTime - lastTimeShoot)
        {
            lastTimeShoot = currentTime;
            return true;
        }

        return false;
    }

    private bool hasFireToShot()
    {
        return currentFireAmount > 0;
    }
}
