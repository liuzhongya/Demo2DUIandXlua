using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoSingleton<Sound> {

    AudioSource m_Bg;
    AudioSource m_effect;
    public string ResourcesDir="";


    protected override void Awake()
    {
        base.Awake();
        m_Bg = GetComponent<AudioSource>();
        m_Bg.playOnAwake = false;
        m_Bg.loop = true;

        m_effect = GetComponent<AudioSource>();


    }

    public void PlayBg(string audioName)
    {
        string oldName;
        if (m_Bg.clip == null)
        {
            oldName = "";
        }
        else
            oldName = m_Bg.clip.name;
        if (oldName != audioName)
        {
            string path = ResourcesDir + "/" + audioName;
            AudioClip clip = Resources.Load<AudioClip>(path);
                
            if(clip!=null)
            {
                m_Bg.clip = clip;
                m_Bg.Play();
            }
        }
    }
    public void PlayEffect(string audioName)
    {
        string path = ResourcesDir + "/" + audioName;
        AudioClip clip = Resources.Load<AudioClip>(path);

        m_effect.clip = clip;
        m_effect.PlayOneShot(clip);

    }


}
