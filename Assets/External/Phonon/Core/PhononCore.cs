﻿//
// Copyright (C) Valve Corporation. All rights reserved.
//

using System;
using System.Runtime.InteropServices;

namespace Phonon
{
    //
    // Phonon API functions.
    //
    public static class PhononCore
    {
        //
        // Functions for OpenCL compute devices.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateComputeDevice(ComputeDeviceType deviceType, int numComputeUnits, [In, Out] ref IntPtr device);

        [DllImport("phonon")]
        public static extern void iplDestroyComputeDevice([In, Out] ref IntPtr device);

        //
        // Scene export callback functions.
        //

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void LoadSceneProgressCallback(float progress);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FinalizeSceneProgressCallback(float progress);

        //
        // Functions for scene export.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateScene(GlobalContext globalContext, IntPtr computeDevice, PropagationSettings simulationSettings, int numMaterials, [In, Out] ref IntPtr scene);

        [DllImport("phonon")]
        public static extern void iplDestroyScene([In, Out] ref IntPtr scene);

        [DllImport("phonon")]
        public static extern void iplSetSceneMaterial(IntPtr scene, int materialIndex, Material material);

        [DllImport("phonon")]
        public static extern Error iplCreateStaticMesh(IntPtr scene, int numVertices, int numTriangles, [In, Out] ref IntPtr staticMesh);

        [DllImport("phonon")]
        public static extern void iplDestroyStaticMesh([In, Out] ref IntPtr staticMesh);

        [DllImport("phonon")]
        public static extern void iplSetStaticMeshVertices(IntPtr scene, IntPtr staticMesh, Vector3[] vertices);

        [DllImport("phonon")]
        public static extern void iplSetStaticMeshTriangles(IntPtr scene, IntPtr staticMesh, Triangle[] triangles);

        [DllImport("phonon")]
        public static extern void iplSetStaticMeshMaterials(IntPtr scene, IntPtr staticMesh, int[] materialIndices);

        [DllImport("phonon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iplFinalizeScene(IntPtr scene, FinalizeSceneProgressCallback progressCallback);

        [DllImport("phonon")]
        public static extern Error iplSaveFinalizedScene(IntPtr scene, string fileName);

        [DllImport("phonon", CallingConvention = CallingConvention.Cdecl)]
        public static extern Error iplLoadFinalizedScene(GlobalContext globalContext, PropagationSettings simulationSettings, string fileName, IntPtr computeDevice, LoadSceneProgressCallback progressCallback, [In, Out] ref IntPtr scene);

        [DllImport("phonon")]
        public static extern void iplDumpSceneToObjFile(IntPtr scene, string fileName);

        //
        // Custom ray tracer callback functions.
        //

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ClosestHitCallback(Vector3 origin, Vector3 direction, float minDistance, float maxDistance, [In, Out] ref float hitDistance, [In, Out] ref Vector3 hitNormal, [In, Out] ref int hitMaterialIndex, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AnyHitCallback(Vector3 origin, Vector3 direction, float minDistance, float maxDistance, [In, Out] ref int hitExists, IntPtr userData);

        //
        // Functions for setting up a custom ray tracer.
        //

        [DllImport("phonon", CallingConvention = CallingConvention.Cdecl)]
        public static extern void iplSetRayTracerCallbacks(IntPtr scene, ClosestHitCallback closetHitCallback, AnyHitCallback anyHitCallback, IntPtr userData);

        //
        // Functions to setup Environment.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateEnvironment(GlobalContext globalContext, IntPtr computeDevice, PropagationSettings simulationSettings, IntPtr scene, IntPtr probeManager, [In, Out] ref IntPtr environment);

        [DllImport("phonon")]
        public static extern void iplDestroyEnvironment([In, Out] ref IntPtr environment);

        [DllImport("phonon")]
        public static extern void iplSetNumBounces(IntPtr environment, int numBounces);

        //
        // Functions related to Audio Buffers.
        //

        [DllImport("phonon")]
        public static extern void iplMixAudioBuffers(int numBuffers, AudioBuffer[] inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern void iplInterleaveAudioBuffer(AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern void iplDeinterleaveAudioBuffer(AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern void iplConvertAudioBufferFormat(AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Error iplCreateAmbisonicsRotator(int order, [In, Out] ref IntPtr rotator);

        [DllImport("phonon")]
        public static extern void iplDestroyAmbisonicsRotator([In, Out] ref IntPtr rotator);

        [DllImport("phonon")]
        public static extern void iplSetAmbisonicsRotation(IntPtr rotator, Quaternion quaternion);

        [DllImport("phonon")]
        public static extern void iplRotateAmbisonicsAudioBuffer(IntPtr rotator, AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Vector3 iplCalculateRelativeDirection(Vector3 sourcePosition, Vector3 listenerPosition, Vector3 listenerAhead, Vector3 listenerUp);

        //
        // Functions for HRTF based 3D audio processing.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateBinauralRenderer(GlobalContext globalContext, RenderingSettings renderingSettings, Byte[] hrtfData, [In, Out] ref IntPtr renderer);

        [DllImport("phonon")]
        public static extern void iplDestroyBinauralRenderer([In, Out] ref IntPtr renderer);

        [DllImport("phonon")]
        public static extern Error iplCreatePanningEffect(IntPtr renderer, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyPanningEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplApplyPanningEffect(IntPtr effect, AudioBuffer inputAudio, Vector3 direction, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Error iplCreateBinauralEffect(IntPtr renderer, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyBinauralEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplApplyBinauralEffect(IntPtr effect, AudioBuffer inputAudio, Vector3 direction, HRTFInterpolation interpolation, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Error iplCreateVirtualSurroundEffect(IntPtr renderer, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyVirtualSurroundEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplApplyVirtualSurroundEffect(IntPtr effect, AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Error iplCreateAmbisonicsPanningEffect(IntPtr renderer, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyAmbisonicsPanningEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplApplyAmbisonicsPanningEffect(IntPtr effect, AudioBuffer inputAudio, AudioBuffer outputAudio);

        [DllImport("phonon")]
        public static extern Error iplCreateAmbisonicsBinauralEffect(IntPtr renderer, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyAmbisonicsBinauralEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplApplyAmbisonicsBinauralEffect(IntPtr effect, AudioBuffer inputAudio, AudioBuffer outputAudio);

        //
        // Functions for Environment renderer.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateEnvironmentalRenderer(GlobalContext globalContext, IntPtr environment, RenderingSettings renderingSettings, AudioFormat outputFormat, [In, Out] ref IntPtr renderer);

        [DllImport("phonon")]
        public static extern void iplDestroyEnvironmentalRenderer([In, Out] ref IntPtr renderer);

        //
        // Direct Sound.
        //

        [DllImport("phonon")]
        public static extern DirectSoundPath iplGetDirectSoundPath(IntPtr renderer, Vector3 listenerPosition, Vector3 listenerAhead, Vector3 listenerUp, Vector3 sourcePosition, float sourceRadius, OcclusionOption occlusionMethod);

        //
        // Convolution Effect.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateConvolutionEffect(IntPtr renderer, string name, SimulationType simulationType, AudioFormat inputFormat, AudioFormat outputFormat, [In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplDestroyConvolutionEffect([In, Out] ref IntPtr effect);

        [DllImport("phonon")]
        public static extern void iplSetConvolutionEffectName(IntPtr effect, string name);

        [DllImport("phonon")]
        public static extern void iplSetDryAudioForConvolutionEffect(IntPtr effect, Vector3 sourcePosition, AudioBuffer dryAudio);

        [DllImport("phonon")]
        public static extern void iplGetWetAudioForConvolutionEffect(IntPtr effect, Vector3 listenerPosition, Vector3 listenerAhead, Vector3 listenerUp, AudioBuffer wetAudio);

        [DllImport("phonon")]
        public static extern void iplGetMixedEnvironmentalAudio(IntPtr renderer, Vector3 listenerPosition, Vector3 listenerAhead, Vector3 listenerUp, AudioBuffer mixedWetAudio);

        //
        // Acoustic Probes callback.
        //

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ProbePlacementProgressCallback(float progress);

        //
        // Functions for creating and managing Acoutic Probes for baking.
        //

        [DllImport("phonon")]
        public static extern Error iplCreateProbeBox(IntPtr scene, Box box, ProbePlacementParameters placementParams, ProbePlacementProgressCallback progressCallback, [In, Out] ref IntPtr probeBox);

        [DllImport("phonon")]
        public static extern void iplDestroyProbeBox([In, Out] ref IntPtr probeBox);

        [DllImport("phonon")]
        public static extern int iplGetProbeSpheres(IntPtr probeBox, [In, Out] Sphere[] probeSpheres);

        [DllImport("phonon")]
        public static extern int iplSaveProbeBox(IntPtr probeBox, [In, Out] Byte[] data);

        [DllImport("phonon")]
        public static extern Error iplLoadProbeBox(Byte[] data, int size, [In, Out] ref IntPtr probeBox);

        [DllImport("phonon")]
        public static extern Error iplCreateProbeBatch([In, Out] ref IntPtr probeBatch);

        [DllImport("phonon")]
        public static extern void iplDestroyProbeBatch([In, Out] ref IntPtr probeBatch);

        [DllImport("phonon")]
        public static extern void iplAddProbeToBatch(IntPtr probeBatch, IntPtr probeBox, int probeIndex);

        [DllImport("phonon")]
        public static extern void iplFinalizeProbeBatch(IntPtr probeBatch);

        [DllImport("phonon")]
        public static extern int iplSaveProbeBatch(IntPtr probeBatch, [In, Out] Byte[] data);

        [DllImport("phonon")]
        public static extern Error iplLoadProbeBatch(Byte[] data, int size, [In, Out] ref IntPtr probeBatch);

        [DllImport("phonon")]
        public static extern Error iplCreateProbeManager([In, Out] ref IntPtr probeManager);

        [DllImport("phonon")]
        public static extern void iplDestroyProbeManager([In, Out] ref IntPtr probeManager);

        [DllImport("phonon")]
        public static extern void iplAddProbeBatch(IntPtr probeManager, IntPtr probeBatch);

        [DllImport("phonon")]
        public static extern void iplRemoveProbeBatch(IntPtr probeManager, IntPtr probeBatch);

        //
        // Baking related callback.
        //

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void BakeProgressCallback(float progress);

        //
        // Functions for baking environmental effects.
        //

        [DllImport("phonon")]
        public static extern void iplBakeReverb(IntPtr environment, IntPtr probeBox, BakingSettings bakingSettings, BakeProgressCallback progressCallback);

        [DllImport("phonon")]
        public static extern void iplBakePropagation(IntPtr environment, IntPtr probeBox, Sphere sourceInfluence, string sourceName, BakingSettings bakingSettings, BakeProgressCallback progressCallback);

        [DllImport("phonon")]
        public static extern void iplBakeStaticListener(IntPtr environment, IntPtr probeBox, Sphere listenerInfluence, string listenerName, BakingSettings bakingSettings, BakeProgressCallback progressCallback);

        [DllImport("phonon")]
        public static extern void iplCancelBake();

        [DllImport("phonon")]
        public static extern void iplDeleteBakedDataByName(IntPtr probeBox, string sourceName);

        [DllImport("phonon")]
        public static extern int iplGetBakedDataSizeByName(IntPtr probeBox, string sourceName);

        //
        // Functions for generating IRs for analysis and visualization.

        [DllImport("phonon")]
        public static extern Error iplCreateSimulationData(PropagationSettings simulationSettings, RenderingSettings renderingSettings, [In, Out] ref IntPtr simulationData);

        [DllImport("phonon")]
        public static extern void iplDestroySimulationData([In, Out] ref IntPtr simulationData);

        [DllImport("phonon")]
        public static extern int iplGetNumIrSamples(IntPtr simulationData);

        [DllImport("phonon")]
        public static extern int iplGetNumIrChannels(IntPtr simulationData);

        [DllImport("phonon")]
        public static extern void iplGenerateSimulationData(IntPtr simulationData, IntPtr environment, Vector3 listenerPosition, Vector3 listenerAhead, Vector3 listenerUp, Vector3[] sourcePositions);

        [DllImport("phonon")]
        public static extern void iplGetSimulationResult(IntPtr simulationData, int sourceIndex, int channel, float[] buffer);
    }
}
