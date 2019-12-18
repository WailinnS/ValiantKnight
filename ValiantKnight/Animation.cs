using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValiantKnight
{
    public abstract class Animation<T> //abstarct so that it must be invoked.
        where T: Enum //enums for types of animation to display.
    {
        protected struct SpriteSheetInfo //will hold all the sprite info
        {
            public List<Frame> Frames { get; set; }
            public Texture2D SpriteSheet { get; set; }
        }
     
        //take in any animation action and give the corrispoinding sprite sheet,
        protected Dictionary<T, SpriteSheetInfo> AnimationFrames { get; set; }
        
        
        
        protected TimeSpan UpdateTime { get; set; }
        protected TimeSpan ElapsedTime { get; set; }

        //holds the animation that will be displayed
        protected T AnimationType { get; set; }
        protected int CurrentFrame { get; set; }

        //where to draw the sprite on screen
        protected Vector2 Position { get; set; }

        protected SpriteEffects Effect { get; set; }
       

        /// <summary>
        /// Used to Draw the animation
        /// </summary>
        /// <param name="spriteBatch">use a sprite batch</param>
        /// <param name="gameTime">uses a game time</param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            ElapsedTime += gameTime.ElapsedGameTime;
            
            if(ElapsedTime > UpdateTime)
            {
                CurrentFrame++;
                if(CurrentFrame > AnimationFrames[AnimationType].Frames.Count - 1)
                {
                    CurrentFrame = 0;
                }
                ElapsedTime = TimeSpan.Zero;
            }
           
            spriteBatch.Draw(texture: AnimationFrames[AnimationType].SpriteSheet,
                             position: Position,
                             sourceRectangle: AnimationFrames[AnimationType].Frames[CurrentFrame].SourceRectangle,
                             color: Color.White,
                             rotation: 0.0f,
                             origin: AnimationFrames[AnimationType].Frames[CurrentFrame].Origin,
                             scale: Vector2.One,
                             effects: Effect,
                             layerDepth: 0.0f);

        }


    }
}
