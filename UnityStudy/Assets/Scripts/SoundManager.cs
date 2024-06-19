using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager i;

    public AudioSource audioSource_weapon;
    public AudioSource audioSource_monster;


    public AudioClip[] weaponAudio; //���� ����� �迭
    public AudioClip mosterAudio; //���� ����� �迭

    private void Awake()
    {
        i = this;
    }

    public void weaponAudioPlay(int i)
    {
        audioSource_weapon.clip = weaponAudio[i];  //����� Ŭ�� �ٲٱ�
        audioSource_weapon.Play();     //����� �÷���
    }

    public void monsterAudioPlay()
    {
        audioSource_monster.clip = mosterAudio;  //����� Ŭ�� �ٲٱ�
        audioSource_monster.Play();     //����� �÷���
    }
}
