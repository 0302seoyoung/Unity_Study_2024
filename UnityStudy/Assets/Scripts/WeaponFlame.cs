using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlame : WeaponComponent  //�ܹ��� 
{
    BoxCollider bc;
    ParticleSystem fx;


    private void OnEnable()
    {
        atk *= 0.1f;
    }
    public override void Shot()
    {
        if (!isAuto)
        {
            isAuto = true;
                StartCoroutine(SetFlame());
        }
        else
        {
            isAuto = false;
        }
    }

    IEnumerator SetFlame()
    {
        if(bc == null) //�ʱ�ȭ
        {
            bc = GetComponent<BoxCollider>();
            fx = GetComponentInChildren<ParticleSystem>();
        }


        while (isAuto)
        {
            if (!fx.isPlaying)
            {
                SoundManager.i.weaponAudioPlay(1);
                fx.Play();//��ƼŬ ����
            }
            bc.enabled = true;
            ReduceAmmo();
            yield return new WaitForEndOfFrame();
            bc.enabled = false;
        }
        
        fx.Stop();
    }
}

