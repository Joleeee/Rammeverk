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

		public virtual List<T> Get<T>()
		{
			return listables.Where(x => x.GetType().GetInterfaces().Contains(typeof(T))).Cast<T>().ToList();
		}

		public virtual void Update(GameTime gameTime)
		{
			List<IUpdateable> updateables = Get<IUpdateable>();
			foreach (var updateable in updateables)
			{
				updateable.Update(this, gameTime);
			}

			List<IHittable> hittables = Get<IHittable>();
			foreach (var hittable in hittables)
			{
				foreach (var hittable2 in hittables)
				{
					if (hittable != hittable2 && hittable.HitBox.Overlaps(hittable2.HitBox))
					{
						hittable.Hit(this, hittable2);
					}
				}
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			List<IDrawable> drawables = Get<IDrawable>();
			foreach (var drawable in drawables)
			{
				drawable.Draw(spriteBatch, this);
			}
		}
	}
}
