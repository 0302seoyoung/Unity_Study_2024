using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] HpItems;      //ü�� ȸ�� ������
    [SerializeField] GameObject[] Items;        //����, �ͷ�, ����
    [SerializeField] GameObject[] WeaponItems;  //���� ������

    [SerializeField] bool isSpawn = true;
    [SerializeField] float itemRate = 3f;

    Vector3 playerPos; //player ��ġ 

    Vector3 pos;
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        StartCoroutine(spawnItem(HpItems, itemRate));
        StartCoroutine(spawnItem(Items, itemRate));
        StartCoroutine(spawnItem(WeaponItems, itemRate));
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

            if ((playerPos - hit.point).magnitude < 5)
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
    IEnumerator spawnItem(GameObject[] item, float time)
    {
        while (isSpawn)
        {
            int index = Random.Range(0, item.Length);       //���� ����
            yield return new WaitForSeconds(time);          //���� �ð���ŭ ��ٸ���

            Instantiate(item[index], setPoint(), Quaternion.identity);  //������ ���� ����
        }
    }
}
