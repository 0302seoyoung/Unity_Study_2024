using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponNormal : WeaponComponent
{
    [SerializeReference] float range = 50f;

    Ray ray;
    RaycastHit hit; //ray�� �浹
    LineRenderer line; //���׸���
    int hitenemy; //������ ���� �浹���� �� ������ �Լ�

    private void Start()
    {
      
        line = GetComponent<LineRenderer>(); //�ʱ�ȭ
        hitenemy = LayerMask.GetMask("Enemy"); //ray�� hit�� Enemy�±��� ������Ʈ ����
    }

    public override void Shot()
    {
        if (!canShoot) return;
            
        ray.origin = transform.position; //ray�� ������
        ray.direction = transform.forward; //ĳ������ z��

        line.startWidth = 0.1f;
        line.SetPosition(0, ray.origin);


        if (Physics.Raycast(ray, out hit, range, hitenemy))
        {
            Debug.Log("hit");
            line.SetPosition(1, hit.point);        //hit�� enemy���� �� �׸���
            DamageEnemy(hit.transform.gameObject);
        }
        else
        {
            line.SetPosition(1, ray.origin + ray.direction * range); // �ƴ� ��� ��Ÿ���ŭ �� �׸���
            Debug.Log("ray");
        }

        StartCoroutine(Linereset());
        StartCoroutine(ShotRate());

        SoundManager.i.weaponAudioPlay(0);  //���� �÷���
    }

    IEnumerator Linereset() //���� ������� �Լ�
    {
        float w = line.startWidth;
        float t = 0;

        while (true)
        {
            line.startWidth = Mathf.Lerp(w, 0, t += 3 * Time.deltaTime);

            if (line.startWidth == 0) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
