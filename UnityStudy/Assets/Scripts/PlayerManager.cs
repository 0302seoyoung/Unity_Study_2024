using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager i;      //static ����

    [SerializeField] public float moveSpeed = 2.5f;    //�ӵ�
    [SerializeField] public float hp = 100f;           //ü��
    [SerializeField] public float maxHp = 100f;        //�ִ� ü��
    [SerializeField] public float cri;                 //ũ��������
    [SerializeField] public float atkspd;              //���� �ӵ�

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
            //ȭ������ ����
            Destroy(other.gameObject);
        }
    }
}
