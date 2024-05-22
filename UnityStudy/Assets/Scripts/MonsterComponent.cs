using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterComponent : MonoBehaviour
{
    public int maxHealth; //�ִ� ü��
    public Transform target; //ai�� ���� �÷��̾� ����ٴϱ� Ÿ��

    Rigidbody rigid;
    [SerializeField] int hp = 100;          //�� �����
    [SerializeField] int maxHp = 100;       //�ִ� �����
    [SerializeField] int atk = 10;          //�� ���ݷ�
    [SerializeField] float atkRate = 0.2f;  //���� ����
    bool canAttack = true;                  //���� ���� ���� �Ǵ� ����
    public bool isDead { get; private set; } = false;    //���� �Ǵ� ����
    bool isKnock = false;

    [SerializeField] ENEMY eType;
    [SerializeField] GameObject dmgText;                    //�ǰ� �� ������ ��Ʈ
    [SerializeField] float dmgTextYPos = 0.5f;              //������ ��Ʈ ���� ������

    BoxCollider boxCollider;
    NavMeshAgent nav;
    SkinnedMeshRenderer smr;
    [SerializeField] Material[] mat = new Material[2];      //������ �ǰ� �� ������ �� ���͸����� ��Ƶ� �迭

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

    private void OnEnable()
    {
        hp = maxHp; //hp �ʱ�ȭ
        isDead = false; //���� ���� ��ȯ
    }

    
    private void TakeDamage(int dmg, bool cri = false)
    {
        if(isDead) return;
        hp -= dmg; //hp ����
        StartCoroutine(SetHitColor());

        //if (_st == STATUS.KNOCK)
        {
            if (!isKnock)
            {
                StartCoroutine(KnockBack());
            }
        }

        Vector3 p = transform.position;
        GameObject temp = Instantiate(dmgText, new Vector3(p.x, p.y + dmgTextYPos, p.z), Quaternion.identity);    //������ �ؽ�Ʈ ����


        temp.GetComponentInChildren<TextMesh>().text = "-" + dmg;       //�ؽ�Ʈ ����

        if (cri)
        {
            temp.transform.localScale = new Vector3(3, 3, 3);
            temp.GetComponentInChildren<TextMesh>().color = Color.yellow;
        }

        Destroy(temp, 0.5f);

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
}

