using System.Collections;
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
    private MicrophoneInput micro;

    private float raycastMaxDistance = 10;

    Animator anim; 


    private void Awake()
    {
        controls = GetComponent<IInputedControls>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = controls.GetPlayerRotation(transform.rotation, rotationSpeed * Time.deltaTime);
        ShootFireBall();
        RechargeFireFromCaldron();
        Vector3 rotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, rotation.y, 0);
    }

    private void ShootFireBall()
    {
        if (controls.isShotInputActivated())
        {

            int frequency = micro.frequency;

            Debug.Log("SHOOOOOt");

            if (canShoot() && hasFireToShot())
            {

                // A single whistle blow ranges from 500 to 5000 Hz
                float size = 0.41f;
                if (controls.isInputValid())
                {
                    if (controls.isBigShot())
                    {
                        size = 2f;
                    }
                    else if(controls.isSmallShot())
                    {
                        size = 0.41f;
                    }
                    anim.SetBool("firing", true);

                    ObjectPooler.Instance.SpawnFromPool("fireball", transform.position, transform.rotation, new Vector3(size, size, size));
                    UpdateFireAmount(-fireCostPerFireBall);
                }
                else
                {
                    anim.SetBool("firing", false);
                }

            }
            

            //Debug.Log("FRECUENCIA:" + frequency);
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
            anim.SetBool("recharging", true);
        }
        else {
            anim.SetBool("recharging", false);
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
                //Debug.Log("Is looking at couldron");
            }
        }

        if(debug)
            Debug.DrawRay(transform.position, transform.forward * raycastMaxDistance, Color.yellow);

        

        return isLooking;
    }


    
}
