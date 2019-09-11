using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BDSA2019.Assignment02.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void flatten_given_123_and_456_returns_123456()
        {
            // Arrange
            var innerStream = new List<int>{1, 2, 3};
            var innerStream2 = new List<int>{4, 5, 6};
            var outerStream = new List<List<int>>{innerStream, innerStream2};

            // Act
            var output = Helpers.Flatten(outerStream);

            // Assert
            var expected = new List<int>{1,2,3,4,5,6};
            Assert.Equal(expected, output);
        }

        [Fact]
        public void filter_given_1_to_50_and_less_than_10_predicate_returns_1_to_9()
        {
            // Arrange
            Predicate<int> lessThanTen = (x) => x < 10;
            var input = Enumerable.Range(1, 50);
        
            // Act
            var output = Helpers.Filter(input, lessThanTen);
        
            // Assert
            var expected = Enumerable.Range(1, 9);
            Assert.Equal(expected, output);
        }
    }
}
