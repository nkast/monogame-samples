﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShadowsSample.Components
{
    public class GameSettingsComponent : DrawableGameComponent
    {
        private static readonly int[] KernelSizes = { 2, 3, 5, 7, 9 };

        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        private KeyboardState _lastKeyboardState;

        public bool AnimateLight;
        public Vector3 LightDirection;
        public FixedFilterSize FixedFilterSize;
        public bool VisualizeCascades;
        public bool StabilizeCascades;
        public bool FilterAcrossCascades;
        public float SplitDistance0;
        public float SplitDistance1;
        public float SplitDistance2;
        public float SplitDistance3;
        public float Bias;
        public float OffsetScale;

        public int FixedFilterKernelSize
        {
            get { return KernelSizes[(int) FixedFilterSize]; }
        }

        public GameSettingsComponent(Game game)
            : base(game)
        {
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Game.Content.Load<SpriteFont>("GameFont");
        }

        public override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.L) && !_lastKeyboardState.IsKeyDown(Keys.L))
                AnimateLight = !AnimateLight;

            _lastKeyboardState = keyboardState;
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_spriteFont, "Animate light? " + AnimateLight + " (L)",
                new Vector2(10, 70),
                Color.Red);
            _spriteBatch.End();
        }
    }

    public enum FixedFilterSize
    {
        Filter2x2,
        Filter3x3,
        Filter5x5,
        Filter7x7,
        Filter9x9
    }
}