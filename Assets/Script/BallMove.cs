using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _xMove;
    [SerializeField] private float _yMove;
    [SerializeField] private float _zMove;
     private float _xBat;

    Vector3 pos;
    [SerializeField] GameObject plane;
    float _yPos;

    private bool _isHit;
    float speed = 1;
    

    private void Start()
    {
        _yPos = plane.transform.position.y;
        this.transform.position = new Vector3(transform.position.x, _yPos + this.transform.localScale.y / 2, transform.position.z);
    }


    private void Update()
    {

        if (!_isHit) {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(_xMove, _yMove, _zMove);
            gameObject.transform.position += velocity * Time.deltaTime * 10;
        } else {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(-_xMove, _yMove, -_zMove);
            gameObject.transform.position += velocity * Time.deltaTime * 10;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bat")
        {         
            Quaternion quaternion = collision.gameObject.transform.rotation;
            _xMove = quaternion.x;
            _zMove = quaternion.z;
            _isHit = true;
        }
    }
}
