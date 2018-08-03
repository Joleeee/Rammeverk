using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	class Loader
	{
		public static ContentManager ContentManager;
		public static T Load<T>(string assetName)
		{
			return ContentManager.Load<T>(assetName);
		}

		public static void LoadContent(ContentManager Content)
		{
			ContentManager = Content;
		}

		static string Particle = "particle";
		static string Player = "player";
	}
}
