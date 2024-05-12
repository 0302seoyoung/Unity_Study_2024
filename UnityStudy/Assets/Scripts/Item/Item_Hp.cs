using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Hp : ItemComponent
{
    [SerializeField] int recovery_Hp = 5; // ȸ���Ǵ� ü��
    public override void GetItem(GameObject obj)
    {
        obj.GetComponent<PlayerManager>().Recovery(recovery_Hp);
        // obj�� PlayerManager�� Recovery�� ����
    }
}
