using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    private State currentState; 

    private Vector2 directionPlayer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ChangeState(State.isIdle);
    }

    private void FixedUpdate()
    {
        _rb.velocity = directionPlayer * ManagerStatsPlayer.Instance.speedMove;
        if(_rb.velocity.x != 0)
        {
            ChangeState(State.isTurn);
        }
        if(_rb.velocity.y > 0 && _rb.velocity.x == 0)
        {
            ChangeState(State.isIdle);
        }
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
            directionPlayer = context.ReadValue<Vector2>();
            if (context.started)
            {
                if (directionPlayer.x < 0)
                {
                    transform.localScale = Vector3.one;
                }
                if (directionPlayer.x >= 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            if (context.canceled)
            {
                ChangeState(State.isIdle);
            }
    }

    private void ChangeState(State newState)
    {
        _animator.SetBool(AnimList.isIdle, false);
        _animator.SetBool(AnimList.isTurn, false);

        currentState = newState;

        if (newState == State.isIdle)
        {
            _animator.SetBool(AnimList.isIdle, true);
        }
        else if (newState == State.isTurn)
        {
            _animator.SetBool(AnimList.isTurn, true);
        }

    }
}

enum State
{
    isIdle,
    isTurn
}
