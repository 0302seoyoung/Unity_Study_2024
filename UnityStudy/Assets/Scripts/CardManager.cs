using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager i;
    int[] cardnum = {0, 0 ,0 };

    private void Awake()
    {
        i = this;
    }
    void Start()
    {

    }
    void Update()
    {
        
    }

    public void SelectedCard() //ī�� �̱� �˰��� 
    {
        GameObject CardPack = gameObject.transform.GetChild(1).gameObject;//card�� ���� ��ü ����
        while (true)
        {
            cardnum[0] = Random.Range(0, 5);
            cardnum[1] = Random.Range(0, 5);
            cardnum[2] = Random.Range(0, 5);

            if (cardnum[0] != cardnum[1] && cardnum[1] != cardnum[2] && cardnum[0] != cardnum[2])
            {
                break;//���� ī�尡 �ϳ��� �ȳ��;��� Ż��
            }
        }

        for(int j = 0; j <3; j++) //Ȱ��ȭ
        {
            CardPack.transform.GetChild(cardnum[j]).gameObject.SetActive(true);
        }
    }
}
