using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColider : MonoBehaviour {

    public int attackDamage = 100;

    Animator anim;
    GameObject enemy;
    EnemyHealth enemyHealth;
    bool enemyInRange;
    float timer;

    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (enemyInRange)
        {
            Attack();
        }
    }


    void Attack()
    {

        if (enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }

}
