using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
	/// <summary>
	/// 跳ね返す強さの変数
	/// </summary>
	[SerializeField]
	private float bounce = 10f;

	/// <summary>
	/// 衝突した時
	/// </summary>
	private void OnCollisionEnter(Collision collision)
	{
		// 当たった相手のRigidbodyのx軸方向に力を加える。
		// 今回はx軸のマイナス方向に力を加えて跳ね返す。
		collision.rigidbody.AddForce(-bounce, 0f, 0f, ForceMode.Impulse);
	}
}
