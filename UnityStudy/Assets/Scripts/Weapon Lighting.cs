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

    IEnumerator SetLightning() //setlightning �Լ� 
    {
        if (bc == null) //�ʱ�ȭ
        {
            bc = GetComponent<BoxCollider>();
            fx = GetComponent<ParticleSystem>();
        }
        while (isAuto)
        {
            if (!fx.isPlaying)
            {
                fx.Play();
            } //����Ʈ ����
            bc.enabled = true;
            ReduceAmmo();

            yield return new WaitForSeconds(rate);

            bc.enabled = false;

        }

        fx.Stop();  //����Ʈ ����
    }

}

   