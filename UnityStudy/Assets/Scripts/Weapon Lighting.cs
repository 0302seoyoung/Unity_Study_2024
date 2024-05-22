using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Weaponlighting : WeaponComponent
{
    BoxCollider bc;
    ParticleSystem fx;
    public override void Shot()
    {
        if (!isAuto)
        {
            isAuto = true;
            StartCoroutine(SetLightning());
        }
        else isAuto = false;
    }

    IEnumerator SetLightning() //setlightning 함수 
    {
        if (bc == null) //초기화
        {
            bc = GetComponent<BoxCollider>();
            fx = GetComponent<ParticleSystem>();
        }
        while (isAuto)
        {
            if (!fx.isPlaying)
            {
                fx.Play();
            } //이펙트 실행
            bc.enabled = true;
            ReduceAmmo();

            yield return new WaitForSeconds(rate);

            bc.enabled = false;

        }

        fx.Stop();  //이펙트 중지
    }

}

   