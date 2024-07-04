using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps; // ParticleSystem����ݩ`�ͥ�Ȥ򱣳֤������

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>(); // ����GameObject�˥����å����줿ParticleSystem����ݩ`�ͥ�Ȥ�ȡ��
    }

    private void Update()
    {
        // ParticleSystem�����ڤ����������椷�Ƥ��ʤ�����
        if (ps && !ps.IsAlive())
        {
            DestroySelf(); // ����GameObject���Ɖ�����᥽�åɤ���ӳ���
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject); // ����GameObject���Ɖ�
    }

    // ����å��奨�ե����Ȥ���������᥽�å�
    public void PlaySlashEffect()
    {
        if (ps != null)
        {
            Debug.Log("����å���ѩ`�ƥ����륨�ե����Ȥ�����");
            ps.Play(); // �ѩ`�ƥ����륷���ƥ������
        }
    }
}
