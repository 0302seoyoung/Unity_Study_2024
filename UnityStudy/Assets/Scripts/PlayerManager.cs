using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;      //static ����

    [SerializeField] public float moveSpeed = 2.5f;    //�ӵ�
    [SerializeField] public float hp = 100f;           //ü��
    [SerializeField] public float maxHp = 100f;        //�ִ� ü��
    [SerializeField] public float atk = 10f;                //������
    [SerializeField] public float cri = 5f;                 //ũ��������
    [SerializeField] public float atkspd = 1f;              //���� �ӵ�
    [SerializeField] public int exp = 0;                    //Exp
    [SerializeField] public int Maxexp = 100;               //MaxExp

    [SerializeField] GameObject shield_PreFab;
    [SerializeField] GameObject turret_Prefab;

    private void Awake()
    {
        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Recovery(int value) //hp ȸ��
    {
        hp += value;
        if (hp > maxHp) hp = maxHp;
    }
    public void ShieldOn()  //���� ����
    {
        GameObject shield = Instantiate(shield_PreFab, transform.position+new Vector3(0, 0.93f, 0), Quaternion.identity);
        shield.transform.SetParent(this.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemShield")) //���� �������� �Ծ��� ��
        {
            ShieldOn(); //���� �����ϱ�
            Destroy(other.gameObject);  //���� ������ ���ֱ�
        }
        else if (other.CompareTag("ItemTurret"))    //�ͷ� �������� �Ծ��� ��
        {
            Instantiate(turret_Prefab, transform.position, Quaternion.identity);    //�ͷ� ����
            Destroy(other.gameObject);  //�ͷ� ������ ���ֱ�
        }
        else if (other.CompareTag("ItemFlame"))
        {
            //ȭ������ ����
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ItemTazer"))
        {
            //ȭ������ ����
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ItemShotgun"))
        {
            //���� ����
            ShootComponent.i.SetWeapon(WEAPON.SHOTGUN);
            Destroy(other.gameObject);
        }
    }

    public void cardAtkUP() //ī�忡�� ���ݷ� ����
    {
        atk += 5;
    }
    public void cardAtkSPDUP() //ī�忡�� ���� ����
    {
        atkspd *= 0.9f;
    }

    public void cardCriUp() //ī�忡�� ġ��Ÿ Ȯ�� ����
    {
        cri += 5;
    }

    public void cardSpdUP() //ī�忡�� �̵��ӵ� ����
    {
        moveSpeed *= 1.1f;
    }
    public void cardMaxHpUP() //ī�忡�� �ִ� ü�� ����
    {
        maxHp += 10;
        GameObject.Find("Hp").GetComponent<Slider>().maxValue = maxHp;
    }
    public void plusExp()
    {
        exp += 10;
    }
}
