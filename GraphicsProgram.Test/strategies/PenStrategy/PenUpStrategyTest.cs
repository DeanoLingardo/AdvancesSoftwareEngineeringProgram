using System;
using System.Collections.Generic;
using System.Text;
using GraphicsProgram.strategies.PenStrategy;
using Xunit;

namespace GraphicsProgram.Test.strategies.PenStrategy
{
    public class PenUpStrategyTest
    {
        private IPenStrategy _penStrategy;
        public PenUpStrategyTest()
        {
            _penStrategy = new PenUpStrategy();
        }

        //<method_name>_<What_your_testing>_<What is expected>
        [Fact]
        public void AppliesTo_GivenInvalidPenOperation_ReturnsFalse()
        {
            //Arrange
            const string penOperation = "Pendown";
            //Act
            var actualResult = _penStrategy.AppliesTo(penOperation);
            //Assert
            Assert.False(actualResult);
        }

        //<method_name>_<What_your_testing>_<What is expected>
        [Fact]
        public void AppliesTo_GivenValidPenOperation_ReturnsTrue()
        {
            //Arrange
            const string penOperation = "Penup";
            //Act
            var actualResult = _penStrategy.AppliesTo(penOperation);
            //Assert
            Assert.True(actualResult);
        }

        [Fact]
        public void ApplyPenState_IsPenUp_ReturnsFalse()
        {
            //Arrange

            //Act
            var actualResult = _penStrategy.ApplyPenState();
            //Assert
            Assert.False(actualResult);
        }
    }
}
