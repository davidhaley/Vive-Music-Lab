using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GvrAudioSource))]
public class AudioVisualizer : MonoBehaviour {

    public GvrAudioSource gvrAudioSource;
    public float[] samples = new float[512];
    public float[] freqBands = new float[8];
    public float[] bandBuffer = new float[8];

    public float greaterThanSmoother = 0.005f;
    public float lessThanSmoother = 1.58f;

    private float[] bufferDecrease = new float[8];
    private float magnitude = 10;

    private void Start()
    {
        gvrAudioSource = GetComponent<GvrAudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    private void GetSpectrumAudioSource()
    {
        gvrAudioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBands[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBands[g];
                bufferDecrease[g] = greaterThanSmoother;
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
                    bufferDecrease[g] *= lessThanSmoother;
                }
            }
        }
    }

    private void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++ )
        {
            float average = 0;
            int sampleCount = ((int)Mathf.Pow(2, i) * 2);

            if (sampleCount == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBands[i] = average * magnitude;
        }
    }
}
