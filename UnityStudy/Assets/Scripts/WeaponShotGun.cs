using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotGun : WeaponComponent
{
    BoxCollider bc;
    ParticleSystem fx;

    public override void Shot()
    {
        StartCoroutine(SetShotGun());
        StartCoroutine(ShotRate());

        SoundManager.i.weaponAudioPlay(2);
    }

    IEnumerator SetShotGun()
    {
        if (bc == null)
        {
            bc = GetComponent<BoxCollider>();
            fx = GetComponentInChildren<ParticleSystem>();//�ڽĿ� �ִ� ��ƼŬ �ý����� ������
        }

        fx.Play();              //FX ���
        bc.enabled = true;      //�浹 ���
        ReduceAmmo();           //�Ѿ� ���
        yield return new WaitForSeconds(0.2f);
        bc.enabled = false;     //�浹 �����
    }
}