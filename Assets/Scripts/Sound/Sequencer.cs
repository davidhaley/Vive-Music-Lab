using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Sequencer : MonoBehaviour
{
    public GameObject kick;
    public GameObject snare;
    public GameObject hat;
    public GameObject bass;
    public GameObject arp;

    private Button[] kicks;
    private Button[] snares;
    private Button[] hats;
    private Button[] basses;
    private Button[] arps;

    private GvrAudioSource kickAudio;
    private GvrAudioSource snareAudio;
    private GvrAudioSource hatAudio;
    private GvrAudioSource bassAudio;
    private GvrAudioSource arpAudio;

    //private GvrAudioSource masterSyncAudio;

    public float bpm = 120f;
    public int numBeatsPerSegment = 1;
    private double nextEventTime;
    private bool running = false;
    private int columnCounter = 0;
    private int beatColumn;
    private bool col1NotPlayed = true;
    private bool col2NotPlayed;
    private bool col3NotPlayed;
    private bool col4NotPlayed;

    private void Awake()
    {
        GetAllButtons();
        AddEventListeners();
        //LoadMasterSyncAudio();
        LoadAudioSource(kick);
        LoadAudioSource(snare);
        LoadAudioSource(hat);
    }

    private void Start()
    {
        LoadAudioClips();
        nextEventTime = AudioSettings.dspTime;
        beatColumn = columnCounter + 1;
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
            if (Queued(kicks, column))
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column))
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column))
            {
                hatAudio.Play();
                yield return null;
            }
        }
        else if (column == 1)
        {
            if (Queued(kicks, column))
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column))
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column))
            {
                hatAudio.Play();
                yield return null;
            }
        }
        else if (column == 2)
        {
            if (Queued(kicks, column))
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column))
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column))
            {
                hatAudio.Play();
                yield return null;
            }
        }
        else if (column == 3)
        {
            if (Queued(kicks, column))
            {
                kickAudio.Play();
                yield return null;
            }

            if (Queued(snares, column))
            {
                snareAudio.Play();
                yield return null;
            }

            if (Queued(hats, column))
            {
                hatAudio.Play();
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

        foreach (Button arp in arps)
        {
            arp.gameObject.AddComponent<SequencerButton>();
            arp.gameObject.AddComponent<ButtonImageColor>();
            arp.onClick.AddListener(() => { OnClickArp(arp); });
        }
    }

    //void LoadMasterSyncAudio()
    //{
    //    masterSyncAudio = GameObject.FindGameObjectWithTag("SequencerCanvas").AddComponent<GvrAudioSource>();
    //    masterSyncAudio.clip = Resources.Load<AudioClip>("Sounds/Booth2LivePerformance/Drums");
    //    masterSyncAudio.mute = true;
    //    masterSyncAudio.loop = true;
    //    masterSyncAudio.playOnAwake = true;
    //}

    void LoadAudioSource(GameObject go)
    {
        GvrAudioSource gvrAudioSource = go.AddComponent<GvrAudioSource>();
        gvrAudioSource.loop = false;
        gvrAudioSource.playOnAwake = false;
        //gvrAudioSource.timeSamples = masterSyncAudio.timeSamples;
    }

    void LoadAudioClips()
    {
        kickAudio = kick.GetComponent<GvrAudioSource>();
        kickAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Kick");

        snareAudio = snare.GetComponent<GvrAudioSource>();
        snareAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Snare");

        hatAudio = hat.GetComponent<GvrAudioSource>();
        hatAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Hat");
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

    void OnClickArp(Button arp)
    {
        if (IsReady(arp))
        {
            QueueForPlay(arp);
            ChangeColor(arp);
        }
        else if (!IsReady(arp))
        {
            RemoveFromQueue(arp);
            ChangeColor(arp);
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
        arps = arp.GetComponentsInChildren<Button>();
    }

    bool IsReady(Button button)
    {
        return button.GetComponent<SequencerButton>().Ready;
    }

    private void RemoveFromQueue(Button button)
    {
        button.GetComponent<SequencerButton>().Ready = true;
        Debug.Log("removed from queue: " + button);
    }

    private void QueueForPlay(Button button)
    {
        Debug.Log(Array.IndexOf(kicks, button));
        button.GetComponent<SequencerButton>().Ready = false;
        running = true;
        Debug.Log("queued for play: " + button);
    }

    public void Running()
    {
        
    }
}



