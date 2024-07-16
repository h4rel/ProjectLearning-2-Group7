using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        // AudioSourceが見つからない場合、警告を出す
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSourceコンポーネントが見つかりません。GameObjectにAudioSourceを追加してください。");
        }
        // AudioClipが設定されていない場合、警告を出す
        else if (audioSource.clip == null)
        {
            Debug.LogWarning("AudioSourceにAudioClipが設定されていません。AudioClipを設定してください。");
        }
    }

    void Update()
    {
        // AudioSourceとAudioClipが正しく設定されている場合にのみ再生する
        if (audioSource != null && audioSource.clip != null && Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }
}
