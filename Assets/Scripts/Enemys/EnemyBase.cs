using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected enum EnemyState
    {
        Die,
        Hit,
        Run,
    }

    public int health;
    public int damage;
    public float ememySpeed;
    protected GameObject player;
    protected Animator enemyAnimator;
    protected EnemyState enemyState;
    public bool moveToPlayer;
    bool getDamage = false;

    IEnumerator WaitNSecAndGone(int n)
    {
        yield return new WaitForSeconds(n);
        Managers.resourceManagerProperty.Destroy(gameObject);
    }


    virtual protected void OnDie()
    {
        if(health <= 0)
        {
            health = -1;
            StartCoroutine(WaitNSecAndGone(1));
            
        }
    }

    virtual protected void OnHit()
    {
        EnemyMoveToPlayer(ememySpeed);
    }

    virtual protected void OnRun()
    {
        if (moveToPlayer) EnemyMoveToPlayer(ememySpeed);
        if (health <= 0)
        {
            enemyAnimator.SetBool("Dead", true);
            enemyState = EnemyState.Die;
        }
    }

    virtual protected void EnemyMoveToPlayer(float speed)
    {
        Vector3 destinationToPlayer = player.transform.position - transform.position;
        if (destinationToPlayer.x < 0) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else gameObject.GetComponent<SpriteRenderer>().flipX = false;
        if (destinationToPlayer.magnitude > 0.8f)transform.position += destinationToPlayer.normalized * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon" && health > 0)
        {
            enemyAnimator.SetTrigger("Hit");
            getDamage = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon" && health > 0)
        {
            if (getDamage == true)
            {
                getDamage = false;
                StartCoroutine(GetDamage());
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon" && health > 0)
        {
            getDamage = false;
        }
    }
    IEnumerator GetDamage()
    {
        if (health > 0)
        {
            enemyAnimator.SetTrigger("Hit");
            yield return new WaitForSeconds(0.5f);
            getDamage = true;
        }
    }    


    virtual protected void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Die:
                OnDie();
                break;
            case EnemyState.Hit:
                OnHit();
                break;
            case EnemyState.Run:
                OnRun();
                break;
        }
    }

    protected virtual void Init()
    {
        enemyState = EnemyState.Run;
        player = GameObject.Find("Player");
        enemyAnimator = gameObject.GetComponent<Animator>();
        if (gameObject.transform.parent.name == "EnemyMaker") moveToPlayer = true;
    }

    virtual protected void Start()
    {
        Init();
    }

    

}
