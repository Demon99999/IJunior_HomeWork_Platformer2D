using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed=3f;
    [SerializeField] private float _jumpForse = 7f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _jumpLimits = 0.05f;

    private const string Walk = "Walk";
    private const string Jump = "Jump";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
        JumpUp();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime * -1,0,0);
            _animator.SetBool(Walk,true);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(Walk,true);
        }

        else
        {
            _animator.SetBool(Walk,false);
        }
    }

    private void JumpUp()
    {
        if (Input.GetKey(KeyCode.Space) && Mathf.Abs(_rigidbody2D.velocity.y) < _jumpLimits)
        {
            _animator.SetTrigger(Jump);
            _rigidbody2D.velocity=new Vector2(_rigidbody2D.velocity.x * Time.deltaTime,_jumpForse);
        }
    }
}
