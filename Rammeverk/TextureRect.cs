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
		public double _current;
		public int current { get { return (int)_current; } set { _current = value; } }
		public Rectangle currentRectangle { get { return frames[current]; } }
		public Point size;
		public TextureRect(Texture2D texture, Point? start = null, Point? size = null, int frames = 1, int startFrame = 0)
		{
			this.texture = texture;
			Point _start = start == null ? new Point(0, 0) : (Point)start;
			Point _size = size == null ? texture.Bounds.Size : (Point)size;
			this.frames = MakeFrames(_start, _size, frames);
			this.current = startFrame;
			this.size = _size;
		}
		/// <summary>
		/// Wraps the desired frame around the min and max
		/// </summary>
		public void SetFrame(double frame, int minFrame, int maxFrame)
		{
			maxFrame += 1; //idk why
			int range = maxFrame - minFrame;
			_current = minFrame + ((frame - minFrame) % range);
		}
		
		public void Animate(double toAdd, int minFrame, int maxFrame)
		{
			SetFrame(_current + toAdd, minFrame, maxFrame);
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
