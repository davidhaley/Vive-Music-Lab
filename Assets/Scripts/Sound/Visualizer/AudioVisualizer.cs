using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{

    public AudioSource audioSource;
    public float[] samplesLeft = new float[512];
    public float[] samplesRight = new float[512];
    public float[] freqBands = new float[8];
    public float[] bandBuffer = new float[8];
    public float[] bufferDecrease = new float[8];
    public float magnitude = 10;

    private float[] freqBandHighest = new float[8];
    public float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];

    public float amplitude;
    public float amplitudeBuffer;
    private float amplitudeHighest;
    public float audioProfile = 5f;

    public enum channel
    {
        Stereo,
        Left,
        Right
    }

    public channel channelSelect = new channel();

    private void Start()
    {
        AudioProfile(audioProfile);
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    private void AudioProfile(float audioProfile)
    {
        for (int i = 0; i < 8; i++)
        {
            freqBandHighest[i] = audioProfile;
        }
    }

    private void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;

        for (int i = 0; i < 8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }

        if (currentAmplitude > amplitudeHighest)
        {
            amplitudeHighest = currentAmplitude;
        }

        amplitude = currentAmplitude / amplitudeHighest;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeHighest;
    }

    private void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBands[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBands[i];
            }

            audioBand[i] = (freqBands[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samplesLeft, 0, FFTWindow.Blackman);
        audioSource.GetSpectrumData(samplesRight, 1, FFTWindow.Blackman);
    }

    private void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBands[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBands[g];
                bufferDecrease[g] = 0.005f;
            }
            else if (freqBands[g] < bandBuffer[g])
            {
                if ((bandBuffer[g] -= bufferDecrease[g]) < 0)
                {
                    bandBuffer[g] = 0;
                    Debug.Log("Warning: Bandbuffer minus the decrease would be less than 0. Assigning 0 to Bandbuffer.");
                }
                else if ((bandBuffer[g] -= bufferDecrease[g]) > 0)
                {
                    bandBuffer[g] -= bufferDecrease[g];
                    bufferDecrease[g] *= 1.4f;
                }
            }
        }
    }

    private void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = ((int)Mathf.Pow(2, i) * 2);

            if (sampleCount == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                if (channelSelect == channel.Stereo)
                {
                    average += (samplesLeft[count] + samplesRight[count]) * (count + 1);
                }
                else if (channelSelect == channel.Left)
                {
                    average += (samplesLeft[count]) * (count + 1);
                }
                else if (channelSelect == channel.Right)
                {
                    average += (samplesRight[count]) * (count + 1);
                }

                count++;
            }

            average /= count;

            freqBands[i] = average * magnitude;
        }
    }
}
