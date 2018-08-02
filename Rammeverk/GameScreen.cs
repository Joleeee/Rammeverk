using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public class GameScreen
	{
		public List<IListable> listables;

		public virtual void Add(IListable item) { listables.Add(item); }

		public virtual void LoadContent()
		{
			listables = new List<IListable>();
		}

		public virtual void Update(GameTime gameTime)
		{
			List<IUpdateable> updateables;
			updateables = listables.Where(x => x.GetType().GetInterfaces().Contains(typeof(IUpdateable))).Cast<IUpdateable>().ToList();
			foreach (var updateable in updateables)
			{
				updateable.Update(this, gameTime);
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			List<IDrawable> drawables;
			drawables = listables.Where(x => x.GetType().GetInterfaces().Contains(typeof(IDrawable))).Cast<IDrawable>().ToList();
			foreach (var drawable in drawables)
			{
				drawable.Draw(spriteBatch, this);
			}
		}
	}
}
