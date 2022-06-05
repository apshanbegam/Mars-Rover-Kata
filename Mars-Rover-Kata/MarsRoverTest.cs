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

        [SetUp]
        public void Setup()
        {
            rover = new Rover(new PlateauCoordinate(1, 2, Direction.N));
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
            rover.MarsRover("LMLMLMLMM").Should().Be(1);
            rover.GetPosition().Should().Be("1 3 N");

            rover = new Rover(new PlateauCoordinate(3, 3, Direction.E));
            rover.MarsRover("MMRMMRMRRM").Should().Be(Math.Round(Math.Sqrt(8), 2));
            rover.GetPosition().Should().Be("5 1 E");
        }

        [Test]
        public void BeyondPlateauRangeShouldReturnExemption()
        {
            rover = new Rover(new PlateauCoordinate(1, 3, Direction.N));
            rover.MarsRover("RMLMMMMM").Should().Be(-1);
        }
    }

}

