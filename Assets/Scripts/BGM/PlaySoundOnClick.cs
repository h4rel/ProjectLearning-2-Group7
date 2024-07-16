using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource����ݩ`�ͥ�Ȥ�ȡ��
        audioSource = GetComponent<AudioSource>();

        // AudioSource��Ҋ�Ĥ���ʤ����ϡ���������
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource����ݩ`�ͥ�Ȥ�Ҋ�Ĥ���ޤ���GameObject��AudioSource��׷�Ӥ��Ƥ���������");
        }
        // AudioClip���O������Ƥ��ʤ����ϡ���������
        else if (audioSource.clip == null)
        {
            Debug.LogWarning("AudioSource��AudioClip���O������Ƥ��ޤ���AudioClip���O�����Ƥ���������");
        }
    }

    void Update()
    {
        // AudioSource��AudioClip���������O������Ƥ�����ϤˤΤ���������
        if (audioSource != null && audioSource.clip != null && Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }
}
