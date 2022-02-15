using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game
{
    class CameraManager
    {
        private int _widthMap;
        private int _heightMap;

        private static readonly double ZOOM = 1.5;
        private int _widthCamera = (int) (1280 / ZOOM);
        private int _heightCamera = (int)(720 / ZOOM);

        private Vector2 _cameraPosition;
        public OrthographicCamera Camera { get; private set; }

        public CameraManager(GameWindow Window, GraphicsDevice GraphicsDevice)
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, _widthCamera, _heightCamera);
            Camera = new OrthographicCamera(viewportAdapter);
            
        }

        private void InitPosition()
        {
            _cameraPosition = new Vector2((float) (_widthCamera / 2) , (float) (_heightCamera / 2));
        }

        public void SetMapTaille(int width, int height)
        {
            _widthMap = width;
            _heightMap = height;
            InitPosition();
        }

        public Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.S) && _cameraPosition.Y < _heightMap - _heightCamera / 2)
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Z) && _cameraPosition.Y > _heightCamera / 2)
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Q) && _cameraPosition.X > _widthCamera / 2)
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.D) && _cameraPosition.X < _widthMap - _widthCamera / 2)
            {
                movementDirection += Vector2.UnitX;
            }

            // Can't normalize the zero vector so test for it before normalizing
            if (movementDirection != Vector2.Zero)
            {
                movementDirection.Normalize();
            }

            return movementDirection;
        }

        public void MoveCamera(GameTime gameTime)
        {
            var speed = 200;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection();
            _cameraPosition += speed * movementDirection * seconds;
            Camera.LookAt(_cameraPosition);
        }
    }
}
