using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValiantKnight
{
    public class Frame
    {
        public Vector2 Origin { get; }
        public Rectangle SourceRectangle { get; }

        public Frame(Vector2 origin, Rectangle sourceRectangle)
        {
            Origin = origin;
            SourceRectangle = sourceRectangle;
        }
    }
}
