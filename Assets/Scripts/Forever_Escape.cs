using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、逃げる
public class Forever_Escape : MonoBehaviour {

	public string targetObjectName; // 目標オブジェクト名：Inspectorで指定
	public float speed = 1; // スピード：Inspectorで指定

	GameObject targetObject;
	Rigidbody2D rbody;

	void Start () { // 最初に行う
		// 目標オブジェクトを見つけておく
		targetObject = GameObject.Find(targetObjectName);
		// 重力を0にして、衝突時に回転させない
		rbody = GetComponent<Rigidbody2D>();
		rbody.gravityScale = 0;
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		// 目標オブジェクトの方向を調べて
		Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
		// その逆方向へ指定した量で進む
		float vx = dir.x * -speed;
		float vy = dir.y * -speed;
		rbody.velocity = new Vector2(vx, vy); 
		// 移動の向きで左右に向きを変える
        this.GetComponent<SpriteRenderer>().flipX = (vx < 0); 
	}
}
