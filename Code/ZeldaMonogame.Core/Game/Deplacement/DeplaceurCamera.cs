using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    class DeplaceurCamera : Deplaceur
    {
        private int _widthMap;
        private int _heightMap;

        private static readonly double ZOOM = 1.5;
        private static int _widthCamera = (int) (1280 / ZOOM);
        private static int _heightCamera = (int)(720 / ZOOM);

        private Vector2 _cameraPosition;
        public OrthographicCamera Camera { get; private set; }


        public DeplaceurCamera(GameWindow Window, GraphicsDevice GraphicsDevice)
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, _widthCamera, _heightCamera);
            Camera = new OrthographicCamera(viewportAdapter);
        }

        private void InitPosition(int x, int y)
        {
            _cameraPosition = new Vector2(x, y);
        }

        public void SetMapTaille(int width, int height)
        {
            _widthMap = width;
            _heightMap = height;
        }

        protected override bool Move(Vector2 movement)
        {
            _cameraPosition += movement;
            Camera.LookAt(_cameraPosition);
            return true;

            // TODO déplacer seulement s'il n'y a pas de collisions avec le monde, si le personnage est au milieu de l'écran (que ce soit en x ou y)
        }

        protected override int Speed => 200;

        /*public ISet<Offsets> GetOffsets
        {
            get => new HashSet<Offsets>();
        }

        public enum Offsets
        {
            miniX = _widthCamera / 2,
            miniY = _heightCamera / 2,
            maxiX = DeplaceurCamera._widthMap - (_widthCamera / 2),
            maxiY = _heightMap - _heightCamera / 2,
        }*/
    }
}
