using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ときどき、反転する
public class Sometime_Flip : MonoBehaviour {

	public int maxCount = 50; // 頻度：Inspectorで指定

	int count = 0; // カウンター用
	bool flipFlag = false;

	void Start () {	// 最初に行う
		count = 0;	// カウンターをリセット
	}

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		count = count + 1; // カウンターに1を足して
		if (count >= maxCount) { // もし、maxCountになったら
			this.transform.Rotate(0, 0, 180); // 180度回転して曲がる
			count = 0; // カウンターをリセット
			// そのとき絵が180度回転するので、上下を反転させる
			flipFlag = !flipFlag;
			this.GetComponent<SpriteRenderer>().flipY = flipFlag; 
		}
	}
}