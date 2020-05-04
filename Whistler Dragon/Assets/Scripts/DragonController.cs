﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField]
    private bool debug = false;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private IInputedControls controls;

    [SerializeField]
    private float fireballsPerSecond = 1;
    private float lastTimeShoot = 0;

    private const float MAX_FIRE = 100.0f;
    private float currentFireAmount = 100.0f;

    [SerializeField]
    private float fireCostPerFireBall = 5;

    [SerializeField]
    private GUIController controller;

    [SerializeField]
    private float fireAmountPerSecondFromCauldron = 10;

    [SerializeField]
    private Transform knightsSpawn1;
    [SerializeField]
    private Transform knightsSpawn2;
    [SerializeField]
    private Transform knightsSpawn3;
    private Transform spawn; 
    private float knightsPerSec = 0.7f;
    private float lastTimeSpawn = 0;


    private float raycastMaxDistance = 10;

    

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
        spawnKnights();
        RechargeFireFromCaldron();
    }

    private void ShootFireBall()
    {
        if (controls.isShotInputActivated())
        {
            if (canShoot() && hasFireToShot()){
                ObjectPooler.Instance.SpawnFromPool("fireball", transform.position, transform.rotation);
                UpdateFireAmount(-fireCostPerFireBall);
         
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
        return currentFireAmount >= fireCostPerFireBall;
    }


    private void UpdateFireAmount(float offset)
    {
        currentFireAmount = Mathf.Clamp(currentFireAmount + offset, 0, MAX_FIRE);
        controller.UpdateFireBar(currentFireAmount/MAX_FIRE);
    }

    private void RechargeFireFromCaldron()
    {
        if (isLookingAtCauldron())
        {
            UpdateFireAmount(fireAmountPerSecondFromCauldron * Time.deltaTime);
        }
    }

    private bool isLookingAtCauldron()
    {
        bool isLooking = false;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastMaxDistance))
        {
            if (hit.transform.name == "Cauldron")
            {
                isLooking = true;
            }
        }

        if(debug)
            Debug.DrawRay(transform.position, transform.forward * raycastMaxDistance, Color.yellow);

        return isLooking;
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



    private void spawnKnights() {

        if (canSpawn())
        {
            int rand = (int) Random.Range(0, 3);
            switch (rand) {
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
