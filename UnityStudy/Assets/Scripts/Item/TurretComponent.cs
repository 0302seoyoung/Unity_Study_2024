using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    MonsterComponent target;          //���ʹ� Ÿ�� ����
    [SerializeField] Transform head;        //�ͷ� �Ӹ�
    [SerializeField] Transform shootPos;    //�̻��� �߻� ��ġ
    [SerializeField] GameObject missile;    //�̻��� ������Ʈ

    [SerializeField] float dTime = 10f;     //�ͷ� ���� �ð�
    [SerializeField] float atkRate = 0.3f;  //�߻� ����
    [SerializeField] float rotSpeed = 10;   //ȸ�� �ӵ�

    private void Start() // �ͷ� ����
    {
        Destroy(gameObject, dTime);
    }

    private void Update() // Ÿ���� ���� ��� Ÿ�� ����
    {
        if (target)
        {
            if (target.isDead)
            {
                target = null;
                StopCoroutine(ShootMissile());
            }
        }
    }

    private void FixedUpdate() // ���� ���� ����
    {
        if (target) 
            RotateHead();
    }

    private void OnTriggerStay(Collider other) //OnTriggerStay: Collider ���� �ȿ� �ִ� ���� ����
    {
        if (target) return; // Ÿ���� �ִٸ� ����

        // Ÿ�� ����, �̻��� �߻�
        if (other.CompareTag("Enemy"))
        {
            target = other.GetComponent<MonsterComponent>();
            StartCoroutine(ShootMissile());
        }
    }

    private void OnTriggerExit(Collider other) //OnTriggerExit: Collider ���� ������ ������ ����
    {
        // Ÿ�� ���� �ʱ�ȭ, �̻��� �߻� ����
        if (other.CompareTag("Enemy"))
        {
            if (target.gameObject == other.gameObject)
            {
                target = null;
                StopCoroutine(ShootMissile());
            }
        }
    }

    void RotateHead() // ���� ����
    {
        Vector3 dir = target.transform.position - transform.position; // ���� ����
        Quaternion rot = Quaternion.LookRotation(dir); // ȸ�� ����
        head.rotation = Quaternion.Slerp(head.rotation, rot, Time.deltaTime * rotSpeed);
        // head���� rot�� rotSpeed�� �ӵ��� ȸ��

    }


    IEnumerator ShootMissile() //�̻��� ����, �ڷ�ƾ���� �߻� ���� ����
    {
        while (target)
        {
            yield return new WaitForSeconds(atkRate); // �߻� ����
            GameObject temp = Instantiate(missile, shootPos.position, shootPos.rotation);
            // missile ������Ʈ ����
            temp.GetComponent<MissileComponent>().MissileMove(shootPos.forward);
        }
    }
}
