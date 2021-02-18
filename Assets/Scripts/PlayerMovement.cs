using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D _myRigidBody;
    private Vector3 _change;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            _animator.SetBool("moving", true);
            MoveCharacter();
            _animator.SetFloat("moveX", _change.x);
            _animator.SetFloat("moveY", _change.y);
        } else {
            _animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        _myRigidBody.MovePosition(
            transform.position + _change.normalized * speed * Time.deltaTime
        );
    }
}
