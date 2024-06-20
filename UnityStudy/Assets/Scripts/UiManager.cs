using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager i;

    public Slider expSlider;

    private void Awake()
    {
        i =this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expBar();
    }

    public void hpBar(float hp)
    {
        GameObject.Find("Hp").GetComponent<Slider>().value = hp;
    }

    public void expBar()
    {
        expSlider.value = PlayerManager.i.exp;
        
        if(expSlider.value >= 100)  //����ġ�� 100�̻��̸�
        {
            expSlider.value = 0;    //�����̴� �ʱ�ȭ
            PlayerManager.i.exp = 0;    //����ġ �ʱ�ȭ
            CardManager.i.SelectedCard();   //ī��̱�
        }
    }
}
