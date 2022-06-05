using System;
using Mars.Models.Enums;
namespace Mars.Models
{
	public class PlateauCoordinate
	{
		
		public int CoordinateX { get; set; }
		public int CoordinateY { get; set; }
		public Direction Orientation { get; set; }

		public PlateauCoordinate(int coordinateX, int coordinateY, Direction orientation)
		{
			CoordinateX = coordinateX;
			CoordinateY = coordinateY;
			Orientation = orientation;
		}
	}
}

