using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SequencerButton))]
public class Sequencer : MonoBehaviour
{
    public GameObject kick;
    public GameObject snare;
    public GameObject hat;
    public GameObject bass;
    public GameObject pianoPad;

    private Button[] kicks;
    private Button[] snares;
    private Button[] hats;
    private Button[] basses;
    private Button[] pianoPads;

    private AudioSource kickAudio;
    private AudioSource snareAudio;
    private AudioSource hatAudio;
    private AudioSource bassAudio;
    private AudioSource pianoPadAudio;

    public float bpm = 120f;
    public int numBeatsPerSegment = 1;
    [HideInInspector]
    public bool running = false;

    private double nextEventTime;
    private int columnCounter = 0;
    private int beatColumn;

    private void Awake()
    {
        GetAllButtons();
        AddEventListeners();
        LoadAudioSource(kick);
        LoadAudioSource(snare);
        LoadAudioSource(hat);
        LoadAudioSource(bass);
        LoadAudioSource(pianoPad);
    }

    private void OnDisable()
    {
        running = false;
    }

    private void Start()
    {
        LoadAudioClips();
        nextEventTime = AudioSettings.dspTime;
    }

    private void Update()
    {
        if (!running)
        {
            return;
        }

        double time = AudioSettings.dspTime;
        if (time + 1f > nextEventTime)
        {
            if (columnCounter == 0)
            {
                StartCoroutine(PlayColumn(columnCounter));
            }
            else if (columnCounter == 1)
            {
                StartCoroutine(PlayColumn(columnCounter));
            }
            else if (columnCounter == 2)
            {
                StartCoroutine(PlayColumn(columnCounter));
            }
            else if (columnCounter == 3)
            {
                StartCoroutine(PlayColumn(columnCounter));
            }

            columnCounter += 1;

            if (columnCounter == 4)
            {
                columnCounter = 0;
            }

            nextEventTime += 60.0f / bpm * numBeatsPerSegment;
        }
    }

    private IEnumerator PlayColumn(int column)
    {
        if (column == 0)
        {
            if (Queued(kicks, column) && !kickAudio.isPlaying)
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column) && !snareAudio.isPlaying)
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column) && !hatAudio.isPlaying)
            {
                hatAudio.Play();
                yield return null;
            }

            if (Queued(basses, column) && !bassAudio.isPlaying)
            {
                bassAudio.Play();
                yield return null;
            }

            if (Queued(pianoPads, column) && !pianoPadAudio.isPlaying)
            {
                pianoPadAudio.Play();
                yield return null;
            }
        }
        else if (column == 1)
        {
            if (Queued(kicks, column) && !kickAudio.isPlaying)
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column) && !snareAudio.isPlaying)
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column) && !hatAudio.isPlaying)
            {
                hatAudio.Play();
                yield return null;
            }

            if (Queued(basses, column) && !bassAudio.isPlaying)
            {
                bassAudio.Play();
                yield return null;
            }

            if (Queued(pianoPads, column) && !pianoPadAudio.isPlaying)
            {
                pianoPadAudio.Play();
                yield return null;
            }
        }
        else if (column == 2)
        {
            if (Queued(kicks, column) && !kickAudio.isPlaying)
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column) && !snareAudio.isPlaying)
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column) && !hatAudio.isPlaying)
            {
                hatAudio.Play();
                yield return null;
            }

            if (Queued(basses, column) && !bassAudio.isPlaying)
            {
                bassAudio.Play();
                yield return null;
            }

            if (Queued(pianoPads, column) && !pianoPadAudio.isPlaying)
            {
                pianoPadAudio.Play();
                yield return null;
            }
        }
        else if (column == 3)
        {
            if (Queued(kicks, column) && !kickAudio.isPlaying)
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column) && !snareAudio.isPlaying)
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column) && !hatAudio.isPlaying)
            {
                hatAudio.Play();
                yield return null;
            }

            if (Queued(basses, column) && !bassAudio.isPlaying)
            {
                bassAudio.Play();
                yield return null;
            }

            if (Queued(pianoPads, column) && !pianoPadAudio.isPlaying)
            {
                pianoPadAudio.Play();
                yield return null;
            }
        }
    }

    private bool Queued(Button[] buttons, int column)
    {
        if (buttons[column + 1].GetComponent<SequencerButton>().Queued())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AddEventListeners()
    {
        foreach (Button kick in kicks)
        {
            kick.gameObject.AddComponent<SequencerButton>();
            kick.gameObject.AddComponent<ButtonImageColor>();
            kick.onClick.AddListener(() => { OnClickKick(kick); });
        }

        foreach (Button snare in snares)
        {
            snare.gameObject.AddComponent<SequencerButton>();
            snare.gameObject.AddComponent<ButtonImageColor>();
            snare.onClick.AddListener(() => { OnClickSnare(snare); });
        }

        foreach (Button hat in hats)
        {
            hat.gameObject.AddComponent<SequencerButton>();
            hat.gameObject.AddComponent<ButtonImageColor>();
            hat.onClick.AddListener(() => { OnClickHat(hat); });
        }

        foreach (Button bass in basses)
        {
            bass.gameObject.AddComponent<SequencerButton>();
            bass.gameObject.AddComponent<ButtonImageColor>();
            bass.onClick.AddListener(() => { OnClickBass(bass); });
        }

        foreach (Button pianoPad in pianoPads)
        {
            pianoPad.gameObject.AddComponent<SequencerButton>();
            pianoPad.gameObject.AddComponent<ButtonImageColor>();
            pianoPad.onClick.AddListener(() => { OnClickPianoPad(pianoPad); });
        }
    }

    void LoadAudioSource(GameObject go)
    {
        AudioSource gvrAudioSource = go.AddComponent<AudioSource>();
        gvrAudioSource.loop = false;
        gvrAudioSource.playOnAwake = false;
    }

    void LoadAudioClips()
    {
        kickAudio = kick.GetComponent<AudioSource>();
        kickAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Kick");

        snareAudio = snare.GetComponent<AudioSource>();
        snareAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Snare");

        hatAudio = hat.GetComponent<AudioSource>();
        hatAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Hat");

        bassAudio = bass.GetComponent<AudioSource>();
        bassAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Bass");

        pianoPadAudio = pianoPad.GetComponent<AudioSource>();
        pianoPadAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/PianoPad");
    }

    void OnClickKick(Button kick)
    {
        if (IsReady(kick))
        {
            QueueForPlay(kick);
            ChangeColor(kick);
        }
        else if (!IsReady(kick))
        {
            RemoveFromQueue(kick);
            ChangeColor(kick);
        }
    }

    void OnClickSnare(Button snare)
    {
        if (IsReady(snare))
        {
            QueueForPlay(snare);
            ChangeColor(snare);
        }
        else if (!IsReady(snare))
        {
            RemoveFromQueue(snare);
            ChangeColor(snare);
        }
    }

    void OnClickHat(Button hat)
    {
        if (IsReady(hat))
        {
            QueueForPlay(hat);
            ChangeColor(hat);
        }
        else if (!IsReady(hat))
        {
            RemoveFromQueue(hat);
            ChangeColor(hat);
        }
    }

    void OnClickBass(Button bass)
    {
        if (IsReady(bass))
        {
            QueueForPlay(bass);
            ChangeColor(bass);
        }
        else if (!IsReady(bass))
        {
            RemoveFromQueue(bass);
            ChangeColor(bass);
        }
    }

    void OnClickPianoPad(Button pianoPad)
    {
        if (IsReady(pianoPad))
        {
            QueueForPlay(pianoPad);
            ChangeColor(pianoPad);
        }
        else if (!IsReady(pianoPad))
        {
            RemoveFromQueue(pianoPad);
            ChangeColor(pianoPad);
        }
    }

    void ChangeColor(Button button)
    {
        ButtonImageColor buttonImageColor = button.GetComponent<ButtonImageColor>();
        Color toggleColor = new Color32(189, 255, 64, 255);
        buttonImageColor.Toggle(button, toggleColor);
    }

    void GetAllButtons()
    {
        kicks = kick.GetComponentsInChildren<Button>();
        snares = snare.GetComponentsInChildren<Button>();
        hats = hat.GetComponentsInChildren<Button>();
        basses = bass.GetComponentsInChildren<Button>();
        pianoPads = pianoPad.GetComponentsInChildren<Button>();
    }

    bool IsReady(Button button)
    {
        return button.GetComponent<SequencerButton>().Ready;
    }

    public void RemoveFromQueue(Button button)
    {
        button.GetComponent<SequencerButton>().Ready = true;
    }

    private void QueueForPlay(Button button)
    {
        button.GetComponent<SequencerButton>().Ready = false;
        running = true;
    }
}



