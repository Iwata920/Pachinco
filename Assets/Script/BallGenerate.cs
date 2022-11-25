using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class BallGenerate : MonoBehaviour
{
    private ObjectPool _ObjectPool;
    private Rigidbody _rigidbody;
    private PachiController pachiController;

    float _countTime = default;
    [SerializeField] private Text _BallCountText;    //玉の数用テキスト

    [SerializeField] private int _BallMaxCount;      //生成する玉の最大数
    [SerializeField] private GameObject _Ball;       //生成する玉
    [SerializeField] private int _coolTime;          //次の玉を打ち出すための時間
    [SerializeField] private float _power;           //玉を打ち出す力
    private bool _stop = false;
     
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        pachiController = GameObject.FindGameObjectWithTag("pachi").GetComponent<PachiController>();
    }

    private void Start()
    {
        _ObjectPool = GetComponent<ObjectPool>();
        //プールの生成
        _ObjectPool.CreatePool(_Ball, _BallMaxCount);
        //玉の数をテキストに表示
        _BallCountText.text = _BallMaxCount.ToString();
        _ = TimeCount();
    }

    private void Update()
    {
        _BallCountText.text = _BallMaxCount.ToString();
    }
    private async Task TimeCount()
    {
        while (!_stop)
        {
            //現在の玉の数にテキストを更新
            if (_BallMaxCount > 0 && pachiController.GetSetPushPower > 0)
            {
                await Task.Delay(200);
                //玉を生成し
                CreateBall();
                //玉の数を減らす
                _BallMaxCount--;
                //次の玉を打ち出すまでに一定時間待つ
                await Task.Delay(_coolTime);
            }
            else
            {
                await Task.Delay(1);
            }
        }
    }

    private void IsStop()
    {
        _stop = true;
    }

    /// <summary>
    /// 玉の生成処理
    /// </summary>
    public void CreateBall()
    {
        float pushPower = pachiController.GetSetPushPower;
        float ramdomPower = Random.Range(0.95f, 1.05f);
        Debug.Log(ramdomPower);
        //ボールをプールから取得
        GameObject ball = _ObjectPool.GetObject();
        //玉の位置と回転をセット
        ball.transform.SetPositionAndRotation(transform.position, transform.rotation);
        //玉に重力と初速を与える
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(pushPower * _power * ramdomPower * Vector3.up, ForceMode.Impulse);
    }
    
    public int GetSetBallCount
    {
        get { return _BallMaxCount ; }
        set { _BallMaxCount = value; }
    }
}
