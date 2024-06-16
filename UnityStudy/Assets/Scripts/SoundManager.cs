using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager i;

    public AudioSource audioSource;

    public AudioClip[] weaponAudio; //���� ����� �迭
    public AudioClip[] mosterAudio; //���� ����� �迭

    private void Awake()
    {
        i = this;
    }

    public void weaponAudioPlay(int i)
    {
        audioSource.clip = weaponAudio[i];  //����� Ŭ�� �ٲٱ�
        audioSource.Play();     //����� �÷���
    }

    public void monsterAudioPlay(int i)
    {
        audioSource.clip = weaponAudio[i];  //����� Ŭ�� �ٲٱ�
        audioSource.Play();     //����� �÷���
    }
}
