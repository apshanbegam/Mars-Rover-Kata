using NUnit.Framework;
using FluentAssertions;
using System;
using Mars.Models;
using Mars.Models.Enums;
using Mars.Models.Interfaces;
namespace Mars.Tests
{
    public class MarsRoverTest
    {

        private Rover? rover;
        private RectangularPlateau? rectangleP;
        public string? RectangularPlateauPosition;
        public bool BoundaryValidation;
        [SetUp]
        public void Setup()
        {
            rover = new Rover(new PlateauCoordinate(1, 2, Direction.N));
            rectangleP = new RectangularPlateau(5, 5);
        }

        [Test]
        public void GetPositionShouldBeCurrentPosition()
        {
            rover = new Rover(new PlateauCoordinate(1, 2, Direction.N));
            rover.GetPosition().Should().Be("1 2 N");
        }

        [Test]
        public void ValidInstructionsShouldReturnValidValues()
        {
            rover = new Rover(new PlateauCoordinate(1, 2, Direction.N));
            rover.MarsRover("LMLMLMLMM");
            rover.GetPosition().Should().Be("1 3 N");

            rover = new Rover(new PlateauCoordinate(3, 3, Direction.E));
            rover.MarsRover("MMRMMRMRRM");
            rover.GetPosition().Should().Be("5 1 E");
        }

        [Test]
        public void BeyondRectanglePlateauRangeShouldReturnFalse()
        {
            rover = new Rover(new PlateauCoordinate(1, 3, Direction.N));
            RectangularPlateauPosition=rover.MarsRover("RMLMMMMM");
            BoundaryValidation = rectangleP.ValidateBoundaries(RectangularPlateauPosition);
            BoundaryValidation.Should().Be(false);


            RectangularPlateauPosition = rover.MarsRover("RMRMMMMMMMMMMMMMM");
            BoundaryValidation = rectangleP.ValidateBoundaries(RectangularPlateauPosition);
            BoundaryValidation.Should().Be(false);

        }

        [Test]
        public void RectanglePlateauRangeShouldReturnTrue()
        {
            rover = new Rover(new PlateauCoordinate(1, 3, Direction.N));
            RectangularPlateauPosition = rover.MarsRover("MMRMMRMRRM");
            BoundaryValidation = rectangleP.ValidateBoundaries(RectangularPlateauPosition);
            BoundaryValidation.Should().Be(true);
        }
    }

}

