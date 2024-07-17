using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // シングルトンインスタンスを保持する静的プロパティ
    public static PlayerData Instance { get; private set; }

    // プレイヤー名を保持するプロパティ
    public string PlayerName { get; set; }

    // ルーム名を保持するプロパティ
    public string RoomName { get; set; }

    private void Awake()
    {
        // インスタンスがまだ存在しない場合は、現在のインスタンスを設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // シーンが変更されてもオブジェクトを破棄しない
        }
        else
        {
            Destroy(gameObject);  // 既にインスタンスが存在する場合は新しいオブジェクトを破棄
        }
    }
}
