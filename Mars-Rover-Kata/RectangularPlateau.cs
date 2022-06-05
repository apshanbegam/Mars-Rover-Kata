using System;
using Mars.Models.Interfaces;

namespace Mars.Models
{
	public class RectangularPlateau : IPlateau
	{
		public int Length;

		public int Width;
		public RectangularPlateau(int length, int width)
		{
			Length = length;
			Width = width;
		}
	}
}

