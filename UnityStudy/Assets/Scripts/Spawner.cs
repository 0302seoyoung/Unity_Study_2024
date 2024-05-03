using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// x : -25 ~ 25
    /// z : -25 ~ 25
    /// Invoke�� �ڷ�ƾ�� ������ => invoke�� �ξ� ���ſ�, ��Ȱ��ȭ�õ� ����
    ///                          => �ڷ�ƾ�� ��Ȱ��ȭ�� ����, �Ű� ������ ���� �� ����
    /// </summary>

    [SerializeField] bool isSpawn = true;
    [SerializeField] float bunnyRate = 1f;
    [SerializeField] float bearRate = 3f;
    [SerializeField] float helephantRate = 5f;

    Vector3 playerPos; //player ��ġ 

    Vector3 pos;      
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        //���� �������� ��ȯ
        StartCoroutine(SpawnE(ENEMY.BUNNY, bunnyRate));
        StartCoroutine(SpawnE(ENEMY.BEAR, bearRate));
        StartCoroutine(SpawnE(ENEMY.HELEPHANT, helephantRate));
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position; //player�� ��ġ�� �޾ƿ�
    }
    Vector3 setPoint() //�ٴ����� �ƴ��� ����
    {
        while (true)
        {
            while (true)
            {
                pos = new Vector3(Random.Range(-24, 24), 10, Random.Range(-24, 24));      //������ ��ġ ����

                ray.origin = pos;                                                          //���� ��������
                ray.direction = Vector3.down;                                              //���� ����

                if (Physics.Raycast(ray, out hit, 20))                                      //  ������ ������ ���ǵ� ray / hit�� ���� ������ ��ǥ
                                                                                            // /ray�� ������ �ִ� �Ÿ�
                {
                    if (hit.collider.CompareTag("Floor")) break;                           //�ٴڿ� ������ ��ǥ�� ��ȯ
                }
            }

            if((playerPos - hit.point).magnitude < 5)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        return hit.point;       //������ ���� ���� ��ȯ
    }

    IEnumerator SpawnE(ENEMY _t, float time) // �簣���� ��ȯ�ǵ��� �ڷ�ƾ �Լ��� �ۼ�
    {
        while (isSpawn)
        {
            yield return new WaitForSeconds(time);
            EnemyPoolManager.i.EnemySpawn(_t, setPoint());
        }
    }
}
