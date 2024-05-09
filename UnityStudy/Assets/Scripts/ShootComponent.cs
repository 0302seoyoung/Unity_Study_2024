using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] WEAPON wType = WEAPON.NORMAL;  //���� ���� Ÿ��
    [SerializeField] GameObject[] weapon;           //������ ���� ������Ʈ �迭
    GameObject currentWeapon;                       //���� ���⸦ ��Ƶ� ����
    WeaponComponent wc;                             //���� ������ WeaponComponent�� ��Ƶ�

    private void Start()
    {
        //SetWeapon(WEAPON.NORMAL);
    }

    void Update()
    {
        //if (Input.GetMouseButton(0)){
        //    wc.Shot(); //�߻�
        //}
    }

    public void SetWeapon(WEAPON _t) //���� �ٲܶ� ȣ��
    {
        wType = _t;
        if (currentWeapon) //currentWeapon�� null���� �ƴ��� �Ǵ�
        {
            Destroy(currentWeapon); //null�� �ƴ϶�� ����
        }

        currentWeapon = Instantiate(weapon[(int)_t], transform.position, Quaternion.identity, transform);
        //_t�� �ش��ϴ� ���⸦ �ڽ����� ����
    }
}
