using System;
using System.Collections.Generic;
using Mars.Models.Interfaces;
using Mars.Models.Enums;
using System.Linq;

namespace Mars.Models
{
	public class Rover : IPosition
	{
		private PlateauCoordinate Position { get; set; }
		public static string? FinalPosition;

		public Rover(PlateauCoordinate position)
		{
			Position = position;
		}
		public string GetPosition()
		{
			return $"{Position.CoordinateX} {Position.CoordinateY} {Position.Orientation}";
		}

		public string MarsRover(string commands)
        {
			int x1 = Position.CoordinateX;
			int y1 = Position.CoordinateY;
			var DirectionCount = Enum.GetNames(typeof(Direction)).Count();

			foreach(var i in commands)
            {
				switch(i)
                {
					case 'L':

						Position.Orientation = (Direction)((int)(Position.Orientation - 1 + DirectionCount) % DirectionCount);
						break;

					case 'R':

						Position.Orientation = (Direction)((int)(Position.Orientation + 1) % DirectionCount);
						break;

					case 'M':
						switch (Position.Orientation)
						{
							case Direction.N:
								Position.CoordinateY++;
								break;
							case Direction.E:
								Position.CoordinateX++;
								break;
							case Direction.S:
								Position.CoordinateY--;
								break;
							case Direction.W:
								Position.CoordinateX--;
								break;
						}
						break;
				}
            }
			FinalPosition = $"{Position.CoordinateX} {Position.CoordinateY}";
			return FinalPosition;
			
		}

		


	}
}
	