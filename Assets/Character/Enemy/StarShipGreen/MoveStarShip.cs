using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStarShip : MonoBehaviour
{

    [Header("Speed Starship")]
    public float verticalSpeed = 3f;
    public float maxHorizontalSpeed = 4f;
    public float minHorizontalSpeed = 2f;
    public float direction = 1;
    public float horizontalSpeed;

    [Header("Limit Horizontal")]
    public float limitDistanceRight = 3f;
    public float limitDistanceLeft = -3f;

    private StateShip currentState;
    public Vector3 positionStart;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        positionStart = transform.position;
    }

    private void OnEnable()
    {
        horizontalSpeed = UnityEngine.Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
    }

    private void FixedUpdate()
    {
        OnMove();
        Destroy(gameObject, 4f);
    }

    private void OnMove()
    {
        
        Vector2 moveDir = new Vector2(direction * horizontalSpeed, -verticalSpeed);
        _rb.velocity = moveDir;


        if(transform.position.x >= positionStart.x + limitDistanceRight)
        {
            direction = -1;
            ChangeState(StateShip.isTurnLeft);
        }
        else if(transform.position.x <= positionStart.x + limitDistanceLeft)
        {
            direction = 1;
            ChangeState(StateShip.isTurnRight);
        }
    }

    private void ChangeState(StateShip newState)
    {
        _animator.SetBool(AnimList.isIdle, false);
        _animator.SetBool(AnimList.isTurnRight, false);
        _animator.SetBool(AnimList.isTurnLeft, false);

        currentState = newState;

        if (newState == StateShip.isIdle)
        {
            _animator.SetBool(AnimList.isIdle, true);
        }
        else if (newState == StateShip.isTurnRight)
        {
            _animator.SetBool(AnimList.isTurnRight, true);
        }
        else if (newState == StateShip.isTurnLeft)
        {
            _animator.SetBool(AnimList.isTurnLeft, true);
        }
    }
}

public enum StateShip
{
    isIdle,
    isTurnRight,
    isTurnLeft
}
