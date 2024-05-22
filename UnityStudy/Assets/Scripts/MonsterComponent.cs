using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterComponent : MonoBehaviour
{
    public int maxHealth; //최대 체력
    public Transform target; //ai를 통한 플레이어 따라다니기 타겟

    Rigidbody rigid;
    [SerializeField] int hp = 100;          //적 생명력
    [SerializeField] int maxHp = 100;       //최대 생명력
    [SerializeField] int atk = 10;          //적 공격력
    [SerializeField] float atkRate = 0.2f;  //공격 간격
    bool canAttack = true;                  //공격 가능 상태 판단 변수
    public bool isDead { get; private set; } = false;    //죽음 판단 변수
    bool isKnock = false;

    [SerializeField] ENEMY eType;
    [SerializeField] GameObject dmgText;                    //피격 시 데미지 폰트
    [SerializeField] float dmgTextYPos = 0.5f;              //데미지 폰트 높이 오프셋

    BoxCollider boxCollider;
    NavMeshAgent nav;
    SkinnedMeshRenderer smr;
    [SerializeField] Material[] mat = new Material[2];      //원본과 피격 시 변경해 줄 매터리얼을 담아둘 배열

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
    //플레이어와 충돌시 ai nav와 물리작용으로 이동 방해 방지

    void Update()
    {
        target = GameObject.Find("Player").transform;
        nav.SetDestination(target.position);
    }
    //플레이어 따라다니는 ai

    private void OnEnable()
    {
        hp = maxHp; //hp 초기화
        isDead = false; //죽음 상태 전환
    }

    
    private void TakeDamage(int dmg, bool cri = false)
    {
        if(isDead) return;
        hp -= dmg; //hp 감소
        StartCoroutine(SetHitColor());

        //if (_st == STATUS.KNOCK)
        {
            if (!isKnock)
            {
                StartCoroutine(KnockBack());
            }
        }

        Vector3 p = transform.position;
        GameObject temp = Instantiate(dmgText, new Vector3(p.x, p.y + dmgTextYPos, p.z), Quaternion.identity);    //데미지 텍스트 생성


        temp.GetComponentInChildren<TextMesh>().text = "-" + dmg;       //텍스트 갱신

        if (cri)
        {
            temp.transform.localScale = new Vector3(3, 3, 3);
            temp.GetComponentInChildren<TextMesh>().color = Color.yellow;
        }

        Destroy(temp, 0.5f);

    }
    IEnumerator SetHitColor()
    {
        smr.material = mat[1];      //히트 매터리얼로 변경
        yield return new WaitForSeconds(0.1f);
        smr.material = mat[0];      //원본 매터리얼로 변경
    }
    IEnumerator KnockBack()
    {
        isKnock = true;
        rigid.AddForce(-transform.forward * 1000);
        yield return new WaitForSeconds(0.5f);
        isKnock = false;
    }
}

