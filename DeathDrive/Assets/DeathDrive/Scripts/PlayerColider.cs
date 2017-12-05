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
    EnemyHealth enemyHealth;
    EnemyMovement enemyMovement;
    

    void Awake()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyAudio = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy")
        {
            if (enemyHealth.currentHealth > 0)
            {
                enemyHealth.TakeDamage(attackDamage);
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

}
