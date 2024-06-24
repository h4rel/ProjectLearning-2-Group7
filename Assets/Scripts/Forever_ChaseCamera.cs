using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、カメラが追いかける
public class Forever_ChaseCamera : MonoBehaviour {

	void LateUpdate() { // ずっと行う（いろいろな処理の最後に）
		Vector3 pos = this.transform.position; // 自分の位置
		pos.z = -10; // カメラなので手前に移動させる
		Camera.main.gameObject.transform.position = pos;
	}
}