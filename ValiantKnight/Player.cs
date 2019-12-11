﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValiantKnight
{ 

    class Player : Animation<Player.AnimationTypes>
    {
        /// <summary>
        /// What kind of animations the player can do
        /// </summary>
        public enum AnimationTypes
        {
            Idle,
            Run,
            Attack
        }

        /// <summary>
        /// Makes a player with default animation of Idle then
        /// sets the update time, elapsed time,
        /// current frame, and position.
        /// </summary>
        /// <param name="vector2">Where do you want the player?</param>
        public Player(Vector2 vector2)
        {
            UpdateTime = TimeSpan.FromMilliseconds(100);
            ElapsedTime = TimeSpan.Zero;
            CurrentFrame = 0;
            AnimationType = AnimationTypes.Idle;
            Effect = SpriteEffects.None;
            Position = vector2;
        }

        //used with update to prevent reset of frames.
        private bool pressed = false;
        /// <summary>
        /// chooses the animation according to button press.
        /// </summary>
        /// <param name="keyboardState">needs Keyboard.getstate()</param>
        public void Update(KeyboardState keyboardState)
        {
            if(keyboardState.IsKeyDown(Keys.Space))
            {
                UpdateTime = TimeSpan.FromMilliseconds(50);
                AnimationType = AnimationTypes.Attack;
                pressed = true;
            }

            if(keyboardState.IsKeyDown(Keys.Right))
            {
                AnimationType = AnimationTypes.Run;
                Effect = SpriteEffects.None;
                Position = new Vector2(Position.X + 2, Position.Y);
                pressed = true;
            }
            else if(keyboardState.IsKeyDown(Keys.Left))
            {
                AnimationType = AnimationTypes.Run;
                Effect = SpriteEffects.FlipHorizontally;
                Position = new Vector2(Position.X - 2, Position.Y);
                pressed = true;
            }

            if(keyboardState.GetPressedKeys().Length == 0 && pressed)
            {
                UpdateTime = TimeSpan.FromMilliseconds(100);
                AnimationType = AnimationTypes.Idle;

                CurrentFrame = 0;
                pressed = false;
            }
        }




        /// <summary>
        /// Loads all the spritesheet info and animations for the player
        /// </summary>
        /// <param name="spriteSheet"></param>
        public void LoadTextures(Texture2D spriteSheet)
        {
            AnimationFrames = new Dictionary<AnimationTypes, Animation<AnimationTypes>.SpriteSheetInfo>()
            {
                [AnimationTypes.Idle] = new SpriteSheetInfo()
                {
                    SpriteSheet = spriteSheet,
                    Frames = new List<Frame>()
                    {
                        new Frame(Vector2.Zero, new Rectangle(0, 567, 79, 63)),
                        new Frame(Vector2.Zero, new Rectangle(79, 567, 79, 63)),
                        new Frame(Vector2.Zero, new Rectangle(158, 567, 79, 63)),
                        new Frame(Vector2.Zero, new Rectangle(237, 567, 79, 63)),
                        new Frame(Vector2.Zero, new Rectangle(316, 567, 79, 63)),
                        new Frame(Vector2.Zero, new Rectangle(395, 567, 79, 63))
                    }
                },
                [AnimationTypes.Run] = new SpriteSheetInfo()
                {
                    SpriteSheet = spriteSheet,
                    Frames = new List<Frame>()
                    { 
                        new Frame(Vector2.Zero, new Rectangle(0,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(79,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(158,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(237,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(316,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(395,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(474,693,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(553,693,79,63))
                    }

                },
                [AnimationTypes.Attack] = new SpriteSheetInfo()
                {
                    SpriteSheet = spriteSheet,
                    Frames = new List<Frame>()
                    {
                        new Frame(Vector2.Zero, new Rectangle(0,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(79,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(158,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(237,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(316,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(395,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(474,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(553,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(632,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(711,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(790,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(869,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(948,0,79,63)),
                        new Frame(Vector2.Zero, new Rectangle(1027,0,79,63))
                    }

                }

            };
            
        }

    }
        
}
