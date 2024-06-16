using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum STATUS
{
    NORMAL,
    KNOCK
}

public class MonsterComponent : MonoBehaviour
{
    public int maxHealth; //�ִ� ü��
    public Transform target; //ai�� ���� �÷��̾� ����ٴϱ� Ÿ��

    public bool isDead = false; // ���� �Ǵ� ����

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    SkinnedMeshRenderer smr;
    
    [SerializeField] int hp = 100; //�� ü�¼���
    [SerializeField] int hpMax = 100; //�ִ� ü�¼���
    [SerializeField] int atk = 10; //���ݷ� ����
    [SerializeField] float atkRate = 0.2f; //���ݼӵ� ����
    [SerializeField] Material[] mat = new Material[2];      //������ �ǰ� �� ������ �� ���͸����� ��Ƶ� �迭

    bool isKnock = false;
    bool hit = true;


    void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        smr = GetComponentInChildren<SkinnedMeshRenderer>();

        isDead = false;
    }

    private void OnEnable()
    {
       hp = hpMax; //hp �ʱ�ȭ
       isDead = false; //���� ���� ��ȯ
        
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



    
    public void TakeDamage(int dmg, STATUS _st = STATUS.NORMAL, bool cri = false)
    {
        if (isDead) return;

        hp -= dmg; //hp ����
        StartCoroutine(SetHitColor());
        
        if (_st == STATUS.KNOCK)
        {
            if (!isKnock)
            {
                StartCoroutine(KnockBack());
            }
        }
        Vector3 p = transform.position;

        SoundManager.i.monsterAudioPlay(0);
    }
    IEnumerator SetHitColor()
    {
        smr.material = mat[1];      //��Ʈ ���͸���� ����
        yield return new WaitForSeconds(0.1f);
        smr.material = mat[0];      //���� ���͸���� ����
    }

    IEnumerator KnockBack()
    {
        isKnock = true;
        rigid.AddForce(-transform.forward * 1000);
        yield return new WaitForSeconds(0.5f);
        isKnock = false;
    }

    IEnumerator hitrate()//���� �ӵ� ����
    {
        hit = false;
        yield return new WaitForSeconds(1f);
        hit = true;
    }

    private void OnCollisionStay(Collision collision)//���Ϳ� �浹���� �� ����
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isDead)
            {
                return;
            }
            if (hit)
            {
                PlayerMoveControl.i.TakeDamage(atk);
                StartCoroutine(hitrate());
            }
        }
    }
}
