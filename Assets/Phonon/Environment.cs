﻿//
// Copyright (C) Valve Corporation. All rights reserved.
//

using System;

namespace Phonon
{
    public class Environment
    {
        public IntPtr GetEnvironment()
        {
            return environment;
        }

        public Error Create(ComputeDevice computeDevice, PropagationSettings simulationSettings, Scene scene, ProbeManager probeManager)
        {
            var error = PhononCore.iplCreateEnvironment(Context.GetContext(), computeDevice.GetDevice(),
                simulationSettings, scene.GetScene(), probeManager.GetProbeManager(), ref environment);
            if (error != Error.None)
            {
                throw new Exception("Unable to create environment [" + error.ToString() + "]");
            }

            return error;
        }

        public void Destroy()
        {
            if (environment != IntPtr.Zero)
                PhononCore.iplDestroyEnvironment(ref environment);
        }

        IntPtr environment = IntPtr.Zero;
    }
}