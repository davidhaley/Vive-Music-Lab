using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

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
        List<GameObject> listButtons = CreateListButtons();

        GetAllButtons();
        AddEventListeners(listButtons);
        LoadAudioSources(listButtons);
        LoadAudioClips();
        MakeInteractable(listButtons);
    }

    private void OnDisable()
    {
        running = false;
    }

    private void Start()
    {
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

    public void OnClickButton(Button button)
    {
        if (IsReady(button))
        {
            QueueForPlay(button);
            ChangeColor(button);
        }
        else if (!IsReady(button))
        {
            RemoveFromQueue(button);
            ChangeColor(button);
        }
    }

    private void GetAllButtons()
    {
        kicks = kick.GetComponentsInChildren<Button>();
        snares = snare.GetComponentsInChildren<Button>();
        hats = hat.GetComponentsInChildren<Button>();
        basses = bass.GetComponentsInChildren<Button>();
        pianoPads = pianoPad.GetComponentsInChildren<Button>();
    }

    private void AddEventListeners(List<GameObject> gameObjectList)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            Button[] buttons = gameObject.GetComponentsInChildren<Button>();

            foreach (Button button in buttons)
            {
                button.onClick.AddListener(() => { OnClickButton(button); });
            }
        }
    }

    private void LoadAudioSources(List<GameObject> gameObjectList)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.playOnAwake = false;

            //Steam Audio
            Phonon.PhononEffect phononEffect = gameObject.AddComponent<Phonon.PhononEffect>();
            phononEffect.enableReflections = true;
            phononEffect.directBinauralEnabled = true;
        }
    }

    private void LoadAudioClips()
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

    private void MakeInteractable(List<GameObject> gameObjectList)
    {
        foreach (GameObject gameObject in gameObjectList)
        {
            Button[] buttons = gameObject.GetComponentsInChildren<Button>();

            foreach (Button button in buttons)
            {
                button.gameObject.AddComponent<SequencerButton>();
                button.gameObject.AddComponent<ButtonImageColor>();
                button.gameObject.AddComponent<Interactable>();
                button.gameObject.AddComponent<UIElement>();
            }
        }
    }
    
    private void RemoveFromQueue(Button button)
    {
        button.GetComponent<SequencerButton>().Ready = true;
    }

    private void ChangeColor(Button button)
    {
        ButtonImageColor buttonImageColor = button.GetComponent<ButtonImageColor>();
        Color toggleColor = new Color32(189, 255, 64, 255);
        buttonImageColor.Toggle(button, toggleColor);
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

    private bool IsReady(Button button)
    {
        return button.GetComponent<SequencerButton>().Ready;
    }
    
    private void QueueForPlay(Button button)
    {
        button.GetComponent<SequencerButton>().Ready = false;
        running = true;
    }

    private List<GameObject> CreateListButtons()
    {
        List<GameObject> gameObjectList = new List<GameObject> { };
        gameObjectList.AddMany(kick, snare, hat, bass, pianoPad);
        return gameObjectList;
    }
}