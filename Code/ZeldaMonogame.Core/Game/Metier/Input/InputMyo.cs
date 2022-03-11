using Microsoft.Xna.Framework;
using MyoLib;
using MyoSharp.Poses;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ZeldaMonogame.Core.Game.Metier.Input
{
    /// <summary>
    /// Classe qui gère les du bracelet Myo
    /// </summary>
    class InputMyo : IGetterInput
    {
        private MyoManager myoManager; //Manager qui gère le bracelet
        private Pose current_pose; //Pose actuelle

        /// <summary>
        /// Constructeur
        /// </summary>
        public InputMyo()
        {
            myoManager = new MyoManager();
            myoManager.Init();
            myoManager.PoseChanged += Mgr_PoseChanged; //Ajoute l'event Mgr_PoseChanged
        }

        /// <summary>
        /// Capture la nouvelle pose de l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mgr_PoseChanged(object sender, MyoSharp.Device.PoseEventArgs e)
        {
            current_pose = e.Pose;
        }

        /// <summary>
        /// Retourne un vecteur correspondant à la direction pointée
        /// </summary>
        /// <returns>Vector2</returns>
        public Vector2 GetDirection()
        {
            myoManager.UnlockAll(MyoSharp.Device.UnlockType.Hold); //Dévérouille le bracelet Myo
            myoManager.StartListening(); //Ecoute le changement de pose
            
            if (current_pose == Pose.FingersSpread) //FingerSpread -> déplacement en haut
                return new Vector2(0, -1);

            if (current_pose == Pose.Fist) //Fist -> Déplacement vers le bas
                return new Vector2(0, 1);

            if (current_pose == Pose.WaveIn) //WaveIn -> Déplacement vers la gauche
                return new Vector2(-1, 0);

            if (current_pose == Pose.WaveOut) //WaveOut -> Déplacement vers la droite
                return new Vector2(1, 0);

            return Vector2.Zero;
        }
    }
}
