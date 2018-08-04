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
		public List<IListable> add;
		public List<IListable> rem;

		public virtual void Add(IListable item) { add.Add(item); }
		public virtual void Remove(IListable item) { rem.Add(item); }

		public virtual void LoadContent()
		{
			listables = new List<IListable>();
			add = new List<IListable>();
			rem = new List<IListable>();
		}

		public virtual List<T> Get<T>()
		{
			return listables.Where(x => x.GetType().GetInterfaces().Contains(typeof(T))).Cast<T>().ToList();
		}

		public virtual void Update(GameTime gameTime)
		{
			//Apply Add and Remove functions, reason that we wait is because if you modify a list while its being used ex. foreach loop it throws and exception
			listables.AddRange(add);
			listables.RemoveAll(x => rem.Contains(x));
			add.Clear();
			rem.Clear();

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
