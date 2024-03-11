using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoSingleton<AudioManager>
{

    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public Button muteButton;
    public AudioSource audioSource;
    public AudioSource SelfaudioSource;
    public GameObject SettingPanel;
    public bool muted = false;
    [SerializeField] AudioClip MergeClip;
    [SerializeField] AudioClip EndClip;


    public void SettingButton()
    {
        if (SettingPanel.activeSelf == true)
        {
            SettingPanel.SetActive(false);
        }
        else
        {
            SettingPanel.SetActive(true);
        }
    }

    public void VolumeSlider()
    {

        if (muted)
        {
            muteButton.image.sprite = muteSprite;
            audioSource.mute = true;
            muted = false;
        }
        else
        {
            muteButton.image.sprite = unmuteSprite;
            audioSource.mute = false;
            muted = true;
        }

    }
    public void MergeSound()
    {
        SelfaudioSource.clip = MergeClip;
        SelfaudioSource.Play();
    }
    public void EndSound()
    {
        SelfaudioSource.clip = EndClip;
        SelfaudioSource.Play();
        
    }

}
