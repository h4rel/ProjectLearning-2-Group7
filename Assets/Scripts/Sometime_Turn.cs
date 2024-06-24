using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ときどき、曲がる
public class Sometime_Turn : MonoBehaviour {

	public float angle = 90; // 角度：Inspectorで指定
	public int maxCount = 50; // 頻度：Inspectorで指定

	int count = 0; // カウンター用

	void Start () {	// 最初に行う
		count = 0;	// カウンターをリセット
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		count = count + 1; // カウンターに1を足して
		if (count >= maxCount) { // もし、maxCountになったら
			this.transform.Rotate(0, 0, angle); // 回転して曲がる
			count = 0; // カウンターをリセット
		}
	}
}