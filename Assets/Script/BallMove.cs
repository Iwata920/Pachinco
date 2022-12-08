using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float _xMove;
    [SerializeField] private float _yMove;
    [SerializeField] private float _zMove;
     

    Vector3 pos;
    [SerializeField] GameObject plane;
    float _yPos;

    private bool _isHit;
    float speed = 2;
    

    private void Start()
    {
        _yPos = plane.transform.position.y;
        this.transform.position = new Vector3(transform.position.x, _yPos + this.transform.localScale.y , transform.position.z);
    }


    private void Update()
    {
        this.transform.position += new Vector3(_xMove, 0, _zMove) * Time.deltaTime * speed;
        /*
        if (!_isHit) {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(-1, 0,0);
            gameObject.transform.position += velocity * Time.deltaTime * 3;
            //transform.Translate(0, 0, -0.05f);
        } else {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(_xMove, 0 , _yMove);
            gameObject.transform.position += velocity * Time.deltaTime * 3;
            //transform.Translate(pos.x / 10000, 0, pos.z / 10000);
        }*/
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bat")
        {
            GameObject �o�b�g = collision.gameObject;

            float �o�b�g�̊p�x = �o�b�g.transform.eulerAngles.y;

            float ���ˊp = Mathf.Abs(�o�b�g�̊p�x * 2);
            float ���ˊp = ���ˊp * (�o�b�g�̊p�x < 0 ? -1 : 1);

            float ���ˊp�Q���W�A�� = ���ˊp * Mathf.Deg2Rad;

            float x = Mathf.Cos(���ˊp�Q���W�A��);
            float y = Mathf.Sin(���ˊp�Q���W�A��);

            _xMove = x;
            _zMove = -y;


            /*
            pos = collision.transform.eulerAngles;
            Quaternion quaternion = collision.gameObject.transform.rotation;
            //Debug.Log(pos);
            //Debug.Log(quaternion);
            _xMove = quaternion.x;
            _yMove = quaternion.y;
            _zMove = quaternion.z;
            _isHit = true;


            // �I�C���[�p����Quaternion���쐬����
            Quaternion q = Quaternion.Euler(pos.x, pos.y, pos.z);
            Debug.Log(q);
            // Quaternion����I�C���[�p���쐬����
            Vector3 eulerAngles = quaternion.eulerAngles;
            */
        }
    }
}
