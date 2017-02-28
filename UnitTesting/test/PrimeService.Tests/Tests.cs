﻿using Prime.Services;
using Xunit;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;
         public PrimeService_IsPrimeShould()
         {
             _primeService = new PrimeService();
         }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void ReturnFalseGivenValueOf1(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Theory] 
        [InlineData(2)] 
        [InlineData(3)] 
        [InlineData(5)] 
        [InlineData(7)] 
        public void ReturnTrueGivenPrimesLessThan10(int value) 
        { 
            var result = _primeService.IsPrime(value); 
 
            Assert.True(result, $"{value} should be prime"); 
        } 
 
        [Theory] 
        [InlineData(4)] 
        [InlineData(6)] 
        [InlineData(8)] 
        [InlineData(9)] 
        public void ReturnFalseGivenNonPrimesLessThan10(int value) 
        { 
            var result = _primeService.IsPrime(value); 
 
            Assert.False(result, $"{value} should not be prime"); 
        } 
    }
}