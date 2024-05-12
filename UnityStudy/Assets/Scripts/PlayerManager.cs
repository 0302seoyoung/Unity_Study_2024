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
}
