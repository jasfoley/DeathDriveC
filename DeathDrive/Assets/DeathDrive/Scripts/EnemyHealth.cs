using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    EnemyMovement enemyMovement;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool damaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }



    public void TakeDamage(int amount)
    {

        damaged = true;

        currentHealth -= amount;


        enemyAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        enemyMovement.enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2f);
        //ScoreManager.score += scoreValue;
    }

}
