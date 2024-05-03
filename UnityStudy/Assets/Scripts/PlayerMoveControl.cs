using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    public Vector3 inputVec;
    public float speed; //�÷��̾� �ӵ�
    public float health; //�÷��̾� ü��

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>(); //�ʱ�ȭ
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        speed = PlayerManager.i.moveSpeed;      //PlayerManager��ũ��Ʈ���� �޾ƿ���
        health=PlayerManager.i.hp;              //PlayerManager��ũ��Ʈ���� �޾ƿ���
    }


    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal"); //A,D�� �¿� �̵�
        inputVec.z = Input.GetAxisRaw("Vertical"); //W, S�� �յ� �̵�

        Vector3 nextVec = inputVec.normalized * speed * Time.deltaTime; // normalized: ���Ͱ��� 1�� ���� nextVec: �������� �̵��ϴ� ����
        rigid.MovePosition(rigid.position + nextVec); // �� ��ġ + �������� �̵��ϴ� ����

        anim.SetBool("isWalk", nextVec != Vector3.zero);    //�����̸� �ȴ� �ִϸ��̼�
        transform.LookAt(transform.position + nextVec);     //�ٶ󺸴� �������� ȸ��
    }

    private void OnTriggerEnter(Collider collision) // �浹 ����
    {
        if(!collision.CompareTag("Enemy")) // Enemy�� �ƴϸ� return
            return;

        //float dmg = collision.GetComponent<Enemy>().dmg;
        //TakeDamage(dmg);
    }

    void FreezeRotation() 
    {
        rigid.velocity= Vector3.zero;  //���� �浹 �� �� ���ӵ� ������ �߰�
    }

    void FixedUpdate()
    {
        FreezeRotation();
    }
    //player enemy�� �浹������ �̵� ������ �̵������ϴ� �� ����

    public float TakeDamage(float dmg) // ������ ���
    {
        health -= dmg; // �������� ������ ü�� ����
        Debug.Log("Player: " + health); // ���� �÷��̾� ü��

        if (health <= 0) // ü���� 0 ���ϸ� Dead
        {
            Dead();
        }
        return health;
    }

    public void Dead() // ������Ʈ ��Ȱ��ȭ
    {
        gameObject.SetActive(false);
    }
}
