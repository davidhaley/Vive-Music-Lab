using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;

public class Typer : MonoBehaviour
{
    public Text text;
    public GameObject button;
    public Canvas canvas;
    public FadeButton fadeButton;
    public GameObject booth;
    private GvrAudioSource audioSource;

    private bool hideCanvas;

    public float delayToStart;
    public float delayBetweenChars = 0.125f;
    public float delayAfterComma = 0.5f;
    public float delayAfterPeriod = 0.5f;

    private string story;
    private float originDelayBetweenChars;
    private float delay;
    private bool lastCharPunctuation = false;
    private char charComma;
    private char charPeriod;
    private bool typing = false;

    void Awake()
    {
        text = GetComponent<Text>();
        canvas = GetComponentInParent<Canvas>();
        audioSource = GetComponent<GvrAudioSource>();

        button.gameObject.SetActive(false);

        originDelayBetweenChars = delayBetweenChars;

        charComma = Convert.ToChar(44);
        charPeriod = Convert.ToChar(46);
     }

    private void Update()
    {
        hideCanvas = fadeButton.faded;

        if (hideCanvas)
        {
            canvas.gameObject.SetActive(false);
        }

        if (booth.GetComponent<CanvasGroup>().alpha != 0f && !typing)
        {
            ChangeText(text.text, delayToStart);
            typing = true;
        }
    }

    public bool TyperReady()
    {
        return booth.GetComponent<CanvasGroup>().alpha != 0f;
    }

    //Update text and start typewriter effect
    public void ChangeText(string textContent, float delayBetweenChars = 0f)
    {
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = textContent;
        text.text = ""; //clean text
        Invoke("Start_PlayText", delayBetweenChars); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            delayBetweenChars = originDelayBetweenChars;

            audioSource.Play();

            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayBetweenChars = delay);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;

                if (c == charComma)
                {
                    delay = delayAfterComma;
                }
                else if (c == charPeriod)
                {
                    delay = delayAfterPeriod;
                }
            }

            text.text += c;
            yield return new WaitForSeconds(delayBetweenChars);
        }

        //When finished, show the button
        yield return new WaitForSeconds(delayBetweenChars);
        button.gameObject.SetActive(true);
    }
}