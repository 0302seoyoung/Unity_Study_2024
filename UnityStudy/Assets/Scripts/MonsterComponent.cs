using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterComponent : MonoBehaviour
{
    public int maxHealth; //�ִ� ü��
    public Transform target; //ai�� ���� �÷��̾� ����ٴϱ� Ÿ��

    public bool isDead = false; // ���� �Ǵ� ����

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;

    void Awake() 
    {
    }

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();

        isDead = false ;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }
    //�÷��̾�� �浹�� ai nav�� �����ۿ����� �̵� ���� ����

    void Update()
    {
        target = GameObject.Find("Player").transform;
        nav.SetDestination(target.position);
    }
    //�÷��̾� ����ٴϴ� ai
}
