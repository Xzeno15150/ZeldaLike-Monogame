using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public class GestionnaireDeplacement : IUpdateable
    {
        private DeplaceurCamera _cameraManager;
        private DeplaceurEntite _deplaceurPersonnage;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public GestionnaireDeplacement(GameWindow gameWindow, GraphicsDevice graphicsDevice, PersonnagePrincipal personnagePrincipal)
        {
            _cameraManager = new DeplaceurCamera(gameWindow, graphicsDevice);
            _deplaceurPersonnage = new DeplaceurEntite(personnagePrincipal);
        }

        public void SetTailleMap(int width, int height)
        {
            _cameraManager.SetMapTaille(width, height);
            _deplaceurPersonnage.SetMapTaille(width, height);
        }

        public void Update(GameTime gameTime)
        {
            var directions = GetInput.GetDirectionsFromInput();

            if(_deplaceurPersonnage.Deplacer(gameTime, directions))
            {
                if(_deplaceurPersonnage.IsOutOfCameraOffsets(_cameraManager.Offsets)) {

                    _cameraManager.Deplacer(gameTime, directions);
                }
            }
        }

    }

    internal class GetInput
    {
        public static ISet<Direction> GetDirectionsFromInput()
        {
            var keyboard = Keyboard.GetState();

            var directions = new HashSet<Direction>();

            if (keyboard.IsKeyDown(Keys.Z))
                directions.Add(Direction.Haut);
            if (keyboard.IsKeyDown(Keys.S))
                directions.Add(Direction.Bas);
            if (keyboard.IsKeyDown(Keys.Q))
                directions.Add(Direction.Gauche);
            if (keyboard.IsKeyDown(Keys.D))
                directions.Add(Direction.Droite);

            return directions;
        }
    }
}
