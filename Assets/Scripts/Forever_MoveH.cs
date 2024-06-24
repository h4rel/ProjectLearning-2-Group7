using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ずっと、移動する（水平）
public class Forever_MoveH : MonoBehaviour {

	public float speed = 1; // スピード：Inspectorで指定

	void FixedUpdate() { // ずっと行う（一定時間ごとに）
		this.transform.Translate(speed / 50, 0, 0); // 水平移動する
	}
}
