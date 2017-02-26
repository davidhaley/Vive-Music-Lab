using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;

public class Typer : MonoBehaviour
{
    public GameObject button;

    public float delayToStart;
    public float delayBetweenChars = 0.125f;
    public float delayAfterComma = 0.5f;
    public float delayAfterPeriod = 0.5f;

    private Text text;
    private GvrAudioSource audioSource;
    private string originText;
    private float originDelayBetweenChars;
    private float punctuationDelay;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;

    private bool finished = false;

    void Awake()
    {
        InitializeTyper();
        LoadAudio();

        button.gameObject.SetActive(false);
     }

    //Update text and start typewriter effect
    public void StartTyper()
    {
        if (!finished)
        {
            StopCoroutine(PlayText()); //stop Coroutime if one exists
            StartCoroutine(PlayText());
        }
    }

    IEnumerator PlayText()
    {
        yield return new WaitForSeconds(delayToStart);

        foreach (char c in originText)
        {
            delayBetweenChars = originDelayBetweenChars;

            audioSource.Play();

            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayBetweenChars = punctuationDelay);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;

                if (c == charComma)
                {
                    punctuationDelay = delayAfterComma;
                }
                else if (c == charPeriod)
                {
                    punctuationDelay = delayAfterPeriod;
                }
            }

            text.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }

        //When finished, show the button
        yield return new WaitForSeconds(delayBetweenChars);
        button.gameObject.SetActive(true);
        finished = true;
    }

    private void LoadAudio()
    {
        audioSource = gameObject.AddComponent<GvrAudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/UI/MouthClick");
        audioSource.playOnAwake = false;
        audioSource.loop = false;
        audioSource.bypassRoomEffects = true;
    }

    private void InitializeTyper()
    {
        text = GetComponent<Text>();

        originText = text.text;
        text.text = ""; //clean text

        originDelayBetweenChars = delayBetweenChars;
        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);
    }
}