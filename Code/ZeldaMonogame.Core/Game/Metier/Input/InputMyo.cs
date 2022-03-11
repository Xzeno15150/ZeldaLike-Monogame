using Microsoft.Xna.Framework;
using MyoLib;
using MyoSharp.Poses;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ZeldaMonogame.Core.Game.Metier.Input
{
    class InputMyo : IGetterInput
    {
        private MyoManager myoManager;

        public InputMyo()
        {
            myoManager = new MyoManager();
            myoManager.Init();
            //mgr.UnlockAll(MyoSharp.Device.UnlockType.Hold);
            // mgr.MyoConnected += Mgr_MyoConnected;
            //mgr.MyoLocked += Mgr_MyoLocked;
            //mgr.MyoUnlocked += Mgr_MyoUnlocked;
            //mgr.PoseChanged += Mgr_PoseChanged;
            //mgr.HeldPoseTriggered += Mgr_HeldPoseTriggered;
            //mgr.PoseSequenceCompleted += Mgr_PoseSequenceCompleted;
            myoManager.MyoConnected += Mgr_MyoConnected1;
            myoManager.StartListening();
            ReadKey();
        }

        private void Mgr_MyoConnected1(object sender, MyoSharp.Device.MyoEventArgs e)
        {
            myoManager.SubscribeToAccelerometerData(0, (source, args) => {
                if (e.Myo.Pose != Pose.Unknown)
                {
                    WriteLine($"{traductions[e.Myo.Pose]}");
                }
            }
            );
        }

        private void Mgr_PoseSequenceCompleted(object sender, PoseSequenceEventArgs e)
        {
            WriteLine($"Sequence completed : {e.Poses.Select(p => p.ToString()).Aggregate("", (chaine, s) => $"{chaine} {s}")}");
        }

        private Dictionary<Pose, string> traductions = new Dictionary<Pose, string>()
        {
            [Pose.Fist] = "Vers le bas",
            [Pose.FingersSpread] = "Vers la haut",
            [Pose.WaveOut] = "Vers la droite",
            [Pose.WaveIn] = "Vers la gauche",
            [Pose.DoubleTap] = "Anything",
            [Pose.Rest] = "Immobile"
        };

        private void Mgr_HeldPoseTriggered(object sender, MyoSharp.Device.PoseEventArgs e)
        {
            WriteLine($"HeldPose : {traductions[e.Pose]}");
        }

        private void Mgr_PoseChanged(object sender, MyoSharp.Device.PoseEventArgs e)
        {
            WriteLine($"{traductions[e.Pose]}");
        }

        private void Mgr_MyoUnlocked(object sender, MyoSharp.Device.MyoEventArgs e)
        {
            WriteLine($"{e.Myo} has been unlocked");
        }

        private void Mgr_MyoLocked(object sender, MyoSharp.Device.MyoEventArgs e)
        {
            WriteLine($"{e.Myo} has been locked");
        }

        private async void Mgr_MyoConnected(object sender, MyoSharp.Device.MyoEventArgs e)
        {
            WriteLine($"{e.Myo} connected ({e.Myo.Arm}, {e.Myo.Handle})");
            myoManager.Unlock(MyoSharp.Device.UnlockType.Hold);
        }
        public Vector2 GetDirection()
        {
            throw new NotImplementedException();
        }
    }
}
