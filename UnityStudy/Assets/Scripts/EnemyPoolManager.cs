using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ENEMY //���� Ÿ�Ժ��� �з� ���Ź� enum ���
{
    BUNNY,
    BEAR,
    HELEPHANT
}
public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager i;          //public static����
                                               //�����Ͽ� �ٸ� script������ ����� �� �ֵ�����

    [SerializeField]GameObject[] EnemyPrefabs; //���� ���� 3����
    int initEnemy = 2;                        //�ʹ� Enemy ���� 

    private void Awake()
    {
        i = this; //i�� �ڱ� �ڽ��� ����
    }

    private void Start()
    {
        CreateEnemy(ENEMY.BUNNY, initEnemy); //�������� 20������ ���� => ���⼭ _t�� �ǹ� ���� ��
    }

    void CreateEnemy(ENEMY _t, int cnt = 1) //Enemy ���� 
    {
        if(cnt > 1)
        {
            for (int i = 0; i < EnemyPrefabs.Length; i++)              //Enemy ���� ������ pool ���� ����
            {
                GameObject temp = new GameObject(EnemyPrefabs[i].name); // ���ο� GameObject ����:�ش� �̸����� ����
                temp.transform.SetParent(transform);
            }
            for (int i = 0;i < EnemyPrefabs.Length;i++) //�������� ���� 
            {
                for(int j = 0;j < cnt; j++)  //prefab�� ������� GameObject ����
                {
                    Instantiate(EnemyPrefabs[i], transform.GetChild(i)); //������ �´� pool �ȿ� ����
                }
            }
        }
        else
        {
            Instantiate(EnemyPrefabs[(int)_t], transform.GetChild((int)_t)); //�Ѹ��� ����
        }
    }

    public void EnemySpawn(ENEMY _t, Vector3 pos)//������ Enemy�� �����ͼ� ���
    {
        GameObject temp;//���� ������Ʈ�� ���� ����

        if(transform.GetChild((int)_t).childCount == 0) //�ش� EnemyPool�� �ƹ��͵� ������ ���� ����
        {
           CreateEnemy(_t); 
        }

        temp = transform.GetChild((int)_t).GetChild(0).gameObject; //�ش� EnemyPool���� �ϳ� ���� ������


        temp.transform.position = pos; //��ġ ����
        temp.transform.SetParent(null);// �θ� ���� ����
        temp.SetActive(true);          //Ȱ��ȭ

    }

    public void EnemyDestory(ENEMY _t, GameObject _e) //����� Enemy�� �ٽ� EnemyPool ����
    {
        _e.SetActive(false);                                 //��Ȱ��ȭ
        _e.transform.SetParent(transform.GetChild((int)_t)); //�ٽ�pool������ ������ ����
                                                             //=> transform�� script�� �ִ� ���� �������� �� 
    }
}
