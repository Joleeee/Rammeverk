using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public class TextureRect
	{
		public Texture2D texture;
		public Rectangle[] frames;
		public int current;
		public Rectangle currentRectangle { get { return frames[current]; } }
		public TextureRect(Texture2D texture, Point? start = null, Point? size = null, int frames = 1, int startFrame = 0)
		{
			this.texture = texture;
			Point _start = start == null ? new Point(0, 0) : (Point)start;
			Point _size = size == null ? new Point(0, 0) : (Point)size;
			this.frames = MakeFrames(_start, _size, frames);
			this.current = startFrame;
		}

		public Rectangle[] MakeFrames(Point start, Point size, int frames)
		{
			Rectangle[] rects = new Rectangle[frames];
			for (int i = 0; i < frames; i++)
			{
				var x = start.X + size.X * i;
				rects[i] = new Rectangle(x, start.Y, size.X, size.Y);
			}
			return rects;
		}
	}
}
