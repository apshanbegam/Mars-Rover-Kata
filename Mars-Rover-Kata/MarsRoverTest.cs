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
    }

}

