using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class TextPrinter : MonoBehaviour
{
    [SerializeField] private TMP_Text text; //対象のテキスト(Inspecterから指定)

    [SerializeField] private Canvas canvas; //今回は関係ありません

    [SerializeField] private string s; //反映したい文字列(Inspecterから指定)

    private string[] str;
    private int id = 0;
    private int sz;
 
    // 次の文字を表示するまでの時間[s]
    [SerializeField] private float _delayDuration = 0.1f;

    // 演出処理に使用する内部変数
    private bool _isRunning;
    private float _remainTime;
    private int _currentMaxVisibleCharacters;

    public void Start()
    {
        canvas.enabled = false;
        _isRunning = false;
        str = s.Split('@');
        sz = str.Count();
    }

    public void Show()
    {
        text.maxVisibleCharacters = 0;
        // 演出を開始するように内部状態をセット
        if (id >= sz)
        {
            canvas.enabled = false;
            return;
        }
        if (id == 0)
        {
            canvas.enabled = true;
        }
        text.SetText(str[id]);
        id++;

        _isRunning = true;
        _remainTime = _delayDuration;
        _currentMaxVisibleCharacters = 0;

    }

    private void Update()
    {
        // 演出実行中でなければ何もしない
        if (!_isRunning)
        {
            if (Input.GetKeyDown(KeyCode.F)) Show();

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