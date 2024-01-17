using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Sprite farmer0Sprite;
    public Sprite farmer1Sprite;
    public Sprite farmer2Sprite;
    public Sprite farmer3Sprite;

    public RuntimeAnimatorController farmer0Controller;
    public RuntimeAnimatorController farmer1Controller;
    public RuntimeAnimatorController farmer2Controller;
    public RuntimeAnimatorController farmer3Controller;

    public enum PlayerState
    {
        Die,
        Run,
        Stand,
    }

    float m_playerSpeed = 10.0f;
    PlayerState m_state = PlayerState.Stand;

    void UpdateDie()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetBool("IsDead", true);
    }
    void UpdateRun()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetBool("IsRun", true);

        if (!(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.D)))
        {
            ani.SetBool("IsRun", false);

        }
    }
    void UpdateStand()
    {
        Animator ani = GetComponent<Animator>();
        ani.SetBool("IsRun", false);
    }


    void Start()
    {
        Managers.inputManagerProperty.MoveActionForPlayer -= playerMove;
        Managers.inputManagerProperty.MoveActionForPlayer += playerMove;

        Managers.inputManagerProperty.SkillActionForPlayer -= PlayerQSkill;
        Managers.inputManagerProperty.SkillActionForPlayer += PlayerQSkill;
    }

    void Update()
    {
        switch (m_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;
            case PlayerState.Run:
                UpdateRun();
                break;
            case PlayerState.Stand:
                UpdateStand();
                break;
        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * m_playerSpeed * Time.deltaTime;
            m_state = PlayerState.Run;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * m_playerSpeed * Time.deltaTime;
            transform.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            m_state = PlayerState.Run;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * m_playerSpeed * Time.deltaTime;
            m_state = PlayerState.Run;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * m_playerSpeed * Time.deltaTime;
            transform.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            m_state = PlayerState.Run;
        }
    }

    void PlayerQSkill()
    {
        Debug.Log("Q 스킬 시전");
    }
}
