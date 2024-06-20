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
        //SelectedCard();
    }
    void Update()
    {
        
    }

    public void SelectedCard() //ī�� �̱� �˰��� 
    {
        GameObject CardPack = gameObject.transform.GetChild(1).gameObject;//card�� ���� ��ü ����
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
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

    public void CardOff()
    {
        GameObject CardPack = gameObject.transform.GetChild(1).gameObject;//card�� ���� ��ü ����

        for (int j = 0; j < 3; j++) {
            CardPack.transform.GetChild(cardnum[j]).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
