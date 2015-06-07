using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voice : MonoBehaviour
{
    const int MAXV = 3;

    public List<AudioClip> voices;
    public AudioSource audioSource;

    [Range(1,3)]
    public int alienID;
    public float delta = -0.2f;

    void Start()
    {
        voices = new List<AudioClip>();
        for (alienID = 1; alienID <= 4; alienID++)
            for (int i = 0; i < 3; i++)
                voices.Add(Resources.Load("Audio/Voices/AlienVoice" + alienID + "-" + (i + 1), typeof(AudioClip)) as AudioClip);
        audioSource = GetComponent<AudioSource>();
        alienID = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Speak")) Speak(alienID);
        else if (Input.GetButtonDown("StopSpeaking")) StopSpeaking();
    }

    public void Speak(int ID)
    {
        StartCoroutine("SpeakVoice", "Hello there my name is Sarah, nice to meet you good one!");
    }

    public void StopSpeaking()
    {
        StopCoroutine("SpeakVoice");
    }

    void PlayVoice(int voiceID)
    {
        audioSource.clip = voices[voiceID];
        audioSource.Play();
    }

    IEnumerator TestSpeakVoice(int ID)
    {
        for (int i = 0; i < MAXV; i++)
        {
            PlayVoice(i + ID * MAXV);
            //yield return null;
            yield return new WaitForSeconds(1f+delta);
        }
        //Debug.Log("Finished speaking.");
    }

    IEnumerator SpeakVoice(string message)
    {
        string[] words = message.Split();
        float maxLength = 1;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > maxLength) maxLength = words[i].Length;
        }

        for (int i = 0; i < words.Length; i++)
        {
            float k = (words[i].Length / maxLength) * 2;
            PlayVoice((int)k + alienID * MAXV);
            yield return new WaitForSeconds(1f + delta);
        }
    }
}
