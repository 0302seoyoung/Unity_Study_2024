using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public static ShootComponent i;
    [SerializeField] WEAPON wType = WEAPON.NORMAL;  //���� ���� Ÿ��
    [SerializeField] GameObject[] weapon;           //������ ���� ������Ʈ �迭
    GameObject currentWeapon;                       //���� ���⸦ ��Ƶ� ����
    WeaponComponent wc;                             //���� ������ WeaponComponent�� ��Ƶ�


    private void Awake()
    {
        i = this;
    }
    private void Start()
    {
        SetWeapon(wType);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            wc.Shot(); //�߻�
        }
    }

    public void SetWeapon(WEAPON _t) //���� �ٲܶ� ȣ��
    {
        wType = _t;
        UiManager.i.WeaponTitle((int)_t);
        if (currentWeapon) //currentWeapon�� null���� �ƴ��� �Ǵ�
        {
            Destroy(currentWeapon); //null�� �ƴ϶�� ����
        }

        currentWeapon = Instantiate(weapon[(int)_t], transform.position, Quaternion.identity, transform);
        currentWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0);
        wc = currentWeapon.GetComponent<WeaponComponent>();
        //_t�� �ش��ϴ� ���⸦ �ڽ����� ����
    }
}
