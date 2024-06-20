using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public enum WEAPON //���� ���� => ���Ź����� ���� 
{
    NORMAL,
    FLAME,
    SHOTGUN,
    E_LASER
}
public abstract class WeaponComponent : MonoBehaviour  //�߻� Ŭ������ ����
{
    [SerializeField] protected float atk;                //���ݷ�
    [SerializeField] protected float rate;             //���ݼӵ�
    [SerializeField] protected float cri;              //ũ��Ƽ�� Ȯ��
   

    [SerializeField] protected WEAPON wType;          //���� ����
    protected bool canShoot = true;                   //�߻� ���� �Ǵ� ����
    [SerializeField] int ammo = 0;                    //�Ѿ˷�
    [SerializeField] protected bool isAuto = false; //�ڵ��߻�

    public int AMMO { get { return ammo; } }          //���� ���� ź�� �߼�
    //get���� �ٷ� ammo�� ��ȯ�ؼ� ��

    private void Update()
    {
        atk = PlayerManager.i.atk;
    }
    public abstract void Shot();                     //�������� �Լ�
                                                     //���� �������� ��� ����� �ٸ��� ������
                                                     //�߻�Ŭ������ ��ӹ޾Ƽ� ����� ����
  
    
    protected IEnumerator ShotRate() //���ݼӵ��� ���� ������ �߰�
    {
        canShoot = false;
        yield return new WaitForSeconds(rate);
        canShoot = true;
    }
    private void OnTriggerEnter(Collider other) //���⸦ ����Ʈ�� �����ϱ� ������ ���Ϳ� ���Ⱑ �浹 �� �������� �ֵ��� ����
    {
        if (other.CompareTag("Enemy"))
        {
            DamageEnemy(other.gameObject); //������ �ִ� �κ�
        }
    }

    protected void DamageEnemy(GameObject obj) // ũ��Ƽ�ÿ� ���� ������ ���� => ������ �ִ� �κ�
    {
        float dmg = atk; //������ <���߿� ���ݷ� ���� ������ ���� ���� ����>
        if(cri >= Random.Range(0f, 100f)) //ũ��Ƽ�� ���� ��
        {
            dmg *= 2;   //������ �ι�
        }
        
        //obj�� ���� ��ü�� TakeDamage(dmg) �Լ� ȣ��
        obj.GetComponent<MonsterComponent>().TakeDamage(dmg);
    }

    protected void ReduceAmmo()
    {
        ammo--;
        if(ammo == 0)
        {
            Debug.Log("dsfs");
            isAuto = false;
            gameObject.GetComponentInParent<ShootComponent>().SetWeapon(WEAPON.NORMAL); //źâ 0�� �Ǹ� �븻�� ��ü
            Destroy(gameObject);
        }
    }
}
