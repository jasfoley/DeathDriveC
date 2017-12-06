using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour {

    public int attackDamage = 100;
    public int countValue = 1;
    public AudioClip deathClip;
    bool enemyInRange;
    float timer;

    Animator anim;
    AudioSource enemyAudio;
    GameObject enemy;
    EnemyMovement enemyMovement;
    

    void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player")
        {
                anim.SetTrigger("Dead");
           
                enemyAudio.clip = deathClip;
                enemyAudio.Play();

                enemyMovement.enabled = false;
                GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                Destroy(gameObject, 2f);
                KillCount.count += countValue;
            
        }



    }

}
