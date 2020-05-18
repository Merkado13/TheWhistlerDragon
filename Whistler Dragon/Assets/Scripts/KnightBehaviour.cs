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

    [SerializeField]
    private Sound sound;
    [SerializeField]
    private Sound sound2;

    GUIController controller;



    bool keepGoing = true;
    float keepAlive = 3;
    float alive = 0;
    bool dead = false;

    float deadTime = 0;
    float death = 0.5f; 

    Animator animator;
    GameObject GUIC;    
    AudioSource audioSource;

    bool played = false;
    bool played2 = false; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();        
        audioSource = GetComponent<AudioSource>(); 
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
            if (!played)
            {
                //audioSource.clip = sound.clip;
                audioSource.PlayOneShot(sound.clip);
                played = true;
            }
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
            if (!played2)
            {                
                audioSource.PlayOneShot(sound2.clip);
                played2 = true;
            }

        }

    }

    public void OnObjectSpawn()
    {
        GUIC = GameObject.Find("GUIController");
        controller = GUIC.GetComponent<GUIController>();

    }
}
