using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;

public class BattleText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; //対象のテキスト(Inspecterから指定)

    // 点滅させる対象
    [SerializeField] private Behaviour _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle = 1;

    private double _time;


    // 次の文字を表示するまでの時間[s]
    [SerializeField] private float _delayDuration = 0.1f;

    // 演出処理に使用する内部変数
    private bool _isRunning;
    private float _remainTime;
    private int _currentMaxVisibleCharacters;

    public void Start()
    {
        _isRunning = false;
    }

    public void Show(string s)
    {
        text.maxVisibleCharacters = 0;
        // 演出を開始するように内部状態をセット
        text.SetText(s);

        _isRunning = true;
        _remainTime = _delayDuration;
        _currentMaxVisibleCharacters = 0;
        _target.enabled = false;

    }

    private void Update()
    {
        // 演出実行中でなければ何もしない
        if (!_isRunning)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;

            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat((float)_time, _cycle);

            // 内部時刻timeにおける明滅状態を反映
            _target.enabled = repeatValue >= _cycle * 0.5f;

            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentMaxVisibleCharacters = 1000;
        }

        // 次の文字表示までの残り時間更新
        _remainTime -= Time.deltaTime;
        if (_remainTime > 0) return;

        // 表示する文字数を一つ増やす
        text.maxVisibleCharacters = ++_currentMaxVisibleCharacters;
        _remainTime = _delayDuration;

        // 文字を全て表示したら待機状態に移行
        if (_currentMaxVisibleCharacters >= text.text.Length)
            _isRunning = false;
    }
}