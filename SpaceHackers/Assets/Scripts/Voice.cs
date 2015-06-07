using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voice : MonoBehaviour
{
    const int NUMBER_OF_RACES = 2;
    const int NUMBER_OF_VOICES_PER = 18;

    public List<AudioClip> voices;
    public AudioSource audioSource;

    public string myMessage = "Hello there my name is Sarah, nice to meet you good one!";
    [Range(0, NUMBER_OF_RACES-1)]
    public int alienID;
    public float delta = -0.2f;

    void Start()
    {
        voices = new List<AudioClip>();
        for (int k = 1; k <= NUMBER_OF_RACES; k++)
            for (int i = 1; i <= NUMBER_OF_VOICES_PER; i++)
                voices.Add(Resources.Load("Audio/Voices/AlienVoices/Race" + k + "/Voice" + i, typeof(AudioClip)) as AudioClip);
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
        StartCoroutine("SpeakVoice", myMessage);
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
            float k = (words[i].Length / maxLength) * (NUMBER_OF_VOICES_PER-1);
            PlayVoice((int)k + alienID * (NUMBER_OF_VOICES_PER - 1));
            yield return new WaitForSeconds(1f + delta);
        }
    }
}
