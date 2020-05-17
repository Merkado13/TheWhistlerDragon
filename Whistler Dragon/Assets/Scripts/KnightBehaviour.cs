using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightBehaviour : MonoBehaviour, IPooledObject
{

    public float speed = 1.0f;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject fireball;

    GUIController controller;



    bool keepGoing = true;
    float keepAlive = 3;
    float alive = 0;
    bool dead = false;

    float deadTime = 0;
    float death = 0.5f; 

    Animator animator;
    GameObject GUIC;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.playing == false)
        {
            this.gameObject.SetActive(false);
        }
        if (keepGoing)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.LookAt(target);
        }
        else if (dead)
        {
            deadTime += Time.deltaTime;

            if (deadTime > death) {
                this.gameObject.SetActive(false);
            }

        }
        else {

            alive += Time.deltaTime;

            if (alive > keepAlive)
            {
                this.gameObject.SetActive(false);
            }



        }
       
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fireball(Clone)") {


            animator.SetBool("dead", true);
            keepGoing = false;
            dead = true;
            collision.gameObject.SetActive(false);

        }
        if (collision.gameObject.name == "GoldMountain")
        {
            keepGoing = false;
            int random = (int)Random.Range(0, 3);
            animator.SetInteger("attack", random);
            //this.gameObject.SetActive(false);
            controller.UpdateGold(100);

        }

    }

    public void OnObjectSpawn()
    {
        GUIC = GameObject.Find("GUIController");
        controller = GUIC.GetComponent<GUIController>();

    }
}
