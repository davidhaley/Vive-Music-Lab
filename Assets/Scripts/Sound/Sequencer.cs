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

    private Color toggleColor = new Color32(189, 255, 64, 255);
    private ButtonImageColor buttonImageColor;

    private void Awake()
    {
        kicks = kick.GetComponentsInChildren<Button>();
        snares = snare.GetComponentsInChildren<Button>();
        hats = hat.GetComponentsInChildren<Button>();
        basses = bass.GetComponentsInChildren<Button>();
        arps = arp.GetComponentsInChildren<Button>();

        foreach (Button kick in kicks)
        {
            kick.gameObject.AddComponent<ButtonImageColor>();
            kick.onClick.AddListener(() => { Kick(kick); });
        }

        foreach (Button snare in snares)
        {
            snare.gameObject.AddComponent<ButtonImageColor>();
            snare.onClick.AddListener(() => { Snare(snare); });
        }

        foreach (Button hat in hats)
        {
            hat.gameObject.AddComponent<ButtonImageColor>();
            hat.onClick.AddListener(() => { Hat(hat); });
        }

        foreach (Button bass in basses)
        {
            bass.gameObject.AddComponent<ButtonImageColor>();
            bass.onClick.AddListener(() => { Bass(bass); });
        }

        foreach (Button arp in arps)
        {
            arp.gameObject.AddComponent<ButtonImageColor>();
            arp.onClick.AddListener(() => { Arp(arp); });
        }

        LoadAudioSources(kick);
        LoadAudioSources(snare);
        LoadAudioSources(hat);
    }


    void Kick(Button kick)
    {
        buttonImageColor = kick.GetComponent<ButtonImageColor>();
        buttonImageColor.Toggle(kick, toggleColor);
        kickAudio.Play();
    }

    void Snare(Button snare)
    {
        buttonImageColor = snare.GetComponent<ButtonImageColor>();
        buttonImageColor.Toggle(snare, toggleColor);
        snareAudio.Play();
    }

    void Hat(Button hat)
    {
        buttonImageColor = hat.GetComponent<ButtonImageColor>();
        buttonImageColor.Toggle(hat, toggleColor);
        hatAudio.Play();
    }

    void Bass(Button bass)
    {
        buttonImageColor = bass.GetComponent<ButtonImageColor>();
        buttonImageColor.Toggle(bass, toggleColor);
        bassAudio.Play();
    }

    void Arp(Button arp)
    {
        buttonImageColor = arp.GetComponent<ButtonImageColor>();
        buttonImageColor.Toggle(arp, toggleColor);
        arpAudio.Play();
    }

    void LoadAudioSources(GameObject go)
    {
        GvrAudioSource gvrAudioSource = go.AddComponent<GvrAudioSource>();
        gvrAudioSource.loop = false;
        gvrAudioSource.playOnAwake = false;
    }

    private void Start()
    {
        kickAudio = kick.GetComponent<GvrAudioSource>();
        kickAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Kick");

        snareAudio = snare.GetComponent<GvrAudioSource>();
        snareAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Snare");

        hatAudio = hat.GetComponent<GvrAudioSource>();
        hatAudio.clip = Resources.Load<AudioClip>("Sounds/Booth3Sequencer/Hat");
    }
}