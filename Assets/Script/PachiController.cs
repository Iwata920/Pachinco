using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PachiController : MonoBehaviour
{
    private PachiInput pachiInput;
    private float _pushPower = default;

    private PlayerInput _input;

    private void Awake()
    {
        pachiInput = new PachiInput();
        _input = new PlayerInput();
    }

    private void Update()
    { 
        _pushPower = pachiInput.inGame.power.ReadValue<Vector2>().x;
        Debug.Log("ƒQƒbƒg‚·‚é‘O" + _pushPower);
        _input._pushPower = 0f;
        _input._select = 0f;
    }
    public float GetSetPushPower
    {
        get { return _pushPower; }
        set { _pushPower = value; }
    }

    
    private void OnEnable()
    {
        pachiInput.Enable();
    }

    private void OnDisable()
    {
        pachiInput.Disable();
    }

}

[System.Serializable]
public class PlayerInput{
    public float _pushPower;
    public float _select;
}

