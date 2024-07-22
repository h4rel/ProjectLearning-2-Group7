using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押すと、アニメーションを切り換える
public class OnKeyPress_ChangeAnime : MonoBehaviour
{

	public string upAnime = "";     // 上向き：Inspectorで指定
	public string downAnime = "";   // 下向き：Inspectorで指定
	public string rightAnime = "";  // 右向き：Inspectorで指定
	public string leftAnime = "";   // 左向き：Inspectorで指定

	string nowMode = "";
	string oldMode = "";
	bool isMoving = false;

	Animator animator;

	void Start()
	{
		nowMode = downAnime;
		oldMode = "";
		animator = this.GetComponent<Animator>(); // Animatorコンポーネントを取得
	}

	void Update()
	{
		isMoving = false;

		if (Input.GetKey("up"))
		{
			nowMode = upAnime;
			isMoving = true;
		}
		if (Input.GetKey("down"))
		{
			nowMode = downAnime;
			isMoving = true;
		}
		if (Input.GetKey("right"))
		{
			nowMode = rightAnime;
			isMoving = true;
		}
		if (Input.GetKey("left"))
		{
			nowMode = leftAnime;
			isMoving = true;
		}
	}

	void FixedUpdate()
	{
		if (nowMode != oldMode)
		{
			oldMode = nowMode;
			animator.Play(nowMode);
		}

		if (!isMoving)
		{
			animator.speed = 0; // アニメーションを停止
		}
		else
		{
			animator.speed = 1; // アニメーションを再開
		}
	}
}
