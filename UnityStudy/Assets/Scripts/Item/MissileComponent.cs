using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileComponent : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5; //�̻��� �ӵ�

    public void MissileMove(Vector3 enemy)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = enemy * speed; // enemy �������� �̵�
    }

    private void OnTriggerEnter(Collider other) // �浿 ����
    {
        if(other.CompareTag("Enemy")) // Tag�� "Enemy"�� ���
        {
            //���� TakeDamage()
            Destroy(gameObject);  //������Ʈ ����
        }
    }
}
