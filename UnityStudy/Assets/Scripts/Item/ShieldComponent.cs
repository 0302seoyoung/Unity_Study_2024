using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    [SerializeField] float shieldHp = 30f;   //���� ü��

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            shieldHp -= other.GetComponent<MonsterComponent>().atk;
            if (shieldHp < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
