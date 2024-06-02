using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Item_Hp : ItemComponent
{
    [SerializeField] int recovery_Hp = 5; // ȸ���Ǵ� ü��
    public override void GetItem(GameObject obj)
    {
        Debug.Log("ddd");
        obj.GetComponent<PlayerManager>().Recovery(recovery_Hp);
        // obj�� PlayerManager�� Recovery�� ����
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
