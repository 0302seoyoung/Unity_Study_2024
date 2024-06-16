using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    public static PlayerMoveControl i;
    public Vector3 inputVec;
    public float speed; //�÷��̾� �ӵ�
    //health�� ���� �� �޾Ƽ� ����ϴ� �� ok => hp���� ���� ������ �����������ϴµ� ������

    Rigidbody rigid;
    Animator anim;

    void Awake()
    {
        i = this;
        rigid = GetComponent<Rigidbody>(); //�ʱ�ȭ
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        speed = PlayerManager.i.moveSpeed;      //PlayerManager��ũ��Ʈ���� �޾ƿ���
    }


    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal"); //A,D�� �¿� �̵�
        inputVec.z = Input.GetAxisRaw("Vertical"); //W, S�� �յ� �̵�

        Vector3 nextVec = inputVec.normalized * speed * Time.deltaTime; // normalized: ���Ͱ��� 1�� ���� nextVec: �������� �̵��ϴ� ����
        rigid.MovePosition(rigid.position + nextVec); // �� ��ġ + �������� �̵��ϴ� ����

        anim.SetBool("isWalk", nextVec != Vector3.zero);    //�����̸� �ȴ� �ִϸ��̼�
        LookMouse();
    }
    void LookMouse()    //���콺�� �ٶ󺸴� �Լ�
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
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
        PlayerManager.i.hp -= dmg; // �������� ������ ü�� ����
        UiManager.i.hpBar(PlayerManager.i.hp);
        Debug.Log("Player: " + PlayerManager.i.hp); // ���� �÷��̾� ü��

        if (PlayerManager.i.hp <= 0) // ü���� 0 ���ϸ� Dead
        {
            Dead();
        }
        return PlayerManager.i.hp;
    }

    public void Dead() // ������Ʈ ��Ȱ��ȭ
    {
        gameObject.SetActive(false);
    }
}
