using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps; // ParticleSystem����ݩ`�ͥ�Ȥ򱣳֤���E���

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>(); // ����GameObject�˥����å�����E�ParticleSystem����ݩ`�ͥ�Ȥ�ȡ��
    }

    private void Update()
    {
        // ParticleSystem�����ڤ����������椷�Ƥ��ʤ�����
        if (ps && !ps.IsAlive())
        {
            DestroySelf(); // ����GameObject���Ɖ�����E᥽�åɤ���ӳ���
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); // ����GameObject���Ɖ�
    }

    // ����å��奨�ե����Ȥ���������E᥽�å�
    public void PlaySlashEffect()
    {
        if (ps != null)
        {
            Debug.Log("����å���ѩ`�ƥ�����E��ե����Ȥ���ɁE");
            ps.Play(); // �ѩ`�ƥ�����E����ƥ����ɁE
        }
    }
}
