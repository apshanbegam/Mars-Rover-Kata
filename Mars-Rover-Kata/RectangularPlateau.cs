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

		public bool ValidateBoundaries(string values)
		{
		string[] coordinates = values.Split(" ");
			int x = Math.Abs(Int32.Parse(coordinates[0]));
			int y = Math.Abs(Int32.Parse(coordinates[1]));

			return !(x > Length || y > Width);

		}
    }
}

