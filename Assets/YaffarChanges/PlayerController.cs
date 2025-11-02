using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private CharacterController _player;
    private float _moveSpeed;
    private Vector3 _moveAxis;
    private Vector3 _camForward, _camRight, _moveDir;
    private Camera _camera;

    [SerializeField] private float _gravity;
    [SerializeField] private float _fallVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<CharacterController>();
        _moveSpeed = 20f;
        _camera = Camera.main;
        _gravity = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        _moveAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (_moveAxis.magnitude > 1)
        {
            _moveAxis = _moveAxis.normalized * _moveSpeed;
        }
        else
        {
            _moveAxis = _moveAxis * _moveSpeed;
        }

        cameraDirection();
        _moveDir = _moveAxis.x * _camRight + _moveAxis.z * _camForward;
        transform.LookAt(transform.position + _moveDir);
        setGravity();
        _player.Move(_moveDir * Time.deltaTime);
    }
    private void cameraDirection()
    {
        _camForward = _camera.transform.forward.normalized;
        _camRight = _camera.transform.right.normalized;
        _camForward.y = 0;
        _camRight.y = 0;


    }
    
    private void setGravity()
    {
        if (_player.isGrounded)
        {
            _fallVelocity = -_gravity * Time.deltaTime;
        }
        else
        {
            _fallVelocity -= _gravity * Time.deltaTime;
            //Vector3 fallVector = new Vector3(0, _fallVelocity, 0);
            //_player.Move(fallVector * Time.deltaTime);
        }
        _moveDir.y = _fallVelocity;
    }
}
