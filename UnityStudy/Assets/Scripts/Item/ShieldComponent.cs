using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    [SerializeField] float shieldHp = 30f;   //���� ü��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //���� ������ ���� ��������ŭ ���� ü�±��
            //���� ü���� 0�� �Ǹ� ���ֱ�
        }
    }
    void DestroyShield()
    {
        Destroy(gameObject);
    }
}
