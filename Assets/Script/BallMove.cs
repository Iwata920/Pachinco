using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
     private float _xMove;
     private float _zMove;

    private float _xSpeed;
    private float _zSpeed;

    Rigidbody rigidbody;

    Vector3 pos;
    [SerializeField] GameObject plane;
    float _yPos;

    private bool _isHit;
    [SerializeField]
    float speed = 2;
    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //_yPos = plane.transform.position.y;
        //this.transform.position = new Vector3(transform.position.x, _yPos + this.transform.localScale.y , transform.position.z);
    }


    private void Update()
    {
        //if(_isHit)
        //{
        //    _xSpeed = _xMove * Time.deltaTime * speed;
        //    _zSpeed = _zMove * Time.deltaTime * speed;
        //    Debug.Log("縦のスピード" + _xSpeed);
        //    Debug.Log("横のスピード" + _zSpeed);
        //    //this.transform.position += new Vector3(_xMove, 0, _zMove) * Time.deltaTime * speed;
        //    rigidbody.AddForce(_xSpeed, 0f, _zSpeed) ;
        //    _isHit = false;
        //}
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bat")
        {
            //rigidbody.isKinematic = true;
     
            GameObject バット = collision.gameObject;

            float バットの角度 = バット.transform.eulerAngles.y;

            float 入射角 = Mathf.Abs(バットの角度 * 2);
            float 反射角 = 入射角 * (バットの角度 < 0 ? -1 : 1);

            float 反射角＿ラジアン = 反射角 * Mathf.Deg2Rad;

            float x = Mathf.Cos(反射角＿ラジアン);
            float y = Mathf.Sin(反射角＿ラジアン);

            _xMove = x;
            _zMove = -y;
            _isHit = true;

            _xSpeed = _xMove * speed;
            _zSpeed = _zMove * speed;
            Debug.Log("縦のスピード" + _xSpeed);
            Debug.Log("横のスピード" + _zSpeed);
            //this.transform.position += new Vector3(_xMove, 0, _zMove) * Time.deltaTime * speed;
            rigidbody.AddForce(_xSpeed, 0f, _zSpeed);
        }
    }
}
