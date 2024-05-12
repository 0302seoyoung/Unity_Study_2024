using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider item) 
    {
        if (item.CompareTag("Player")) // �������� �ÿ��̾�� �����ϸ� ������ ���ǰ� ������ ����
        {
            GetItem(item.gameObject);
            Destroy(gameObject);
        }
    }

    public abstract void GetItem(GameObject obj);  // �������� ȿ��
    // abstract: �߻� �Լ�, ��� ���� ������ ����
}
