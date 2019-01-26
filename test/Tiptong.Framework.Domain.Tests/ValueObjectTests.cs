namespace Tiptong.Framework.Domain.Tests
{
    using System;
    using Xunit;
    using Shouldly;

    public class ValueObjectTests
    {
        [Fact]
        public void Comparison_With_Null_Object_Is_Inequal()
        {
            // Arrange
            Address left = new Address();
            Address right = null;

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);
            var comparisonEqualOps = left == right;
            var comparisonInequalOps = left != right;

            // Assert
            comparison.ShouldBe(false);
            comparisonObject.ShouldBe(false);
            comparisonEqualOps.ShouldBe(false);
            comparisonInequalOps.ShouldBe(true);
        }

        [Fact]
        public void Comparison_With_Reference_Equal_Object_Is_Equal()
        {
            // Arrange
            Address left = new Address();
            Address right = left;

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);
            var comparisonEqualOps = left == right;
            var comparisonInequalOps = left != right;

            // Assert
            comparison.ShouldBe(true);
            comparisonObject.ShouldBe(true);
            comparisonEqualOps.ShouldBe(true);
            comparisonInequalOps.ShouldBe(false);
        }

        [Fact]
        public void Comparison_With_Object_Having_Same_Property_Values_Is_Equal()
        {
            // Arrange
            Address left = new Address
            {
                Street = "Street",
                City = "City",
                Country = "Country"
            };

            Address right = new Address
            {
                Street = "Street",
                City = "City",
                Country = "Country"
            };

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);
            var comparisonEqualOps = left == right;
            var comparisonInequalOps = left != right;

            // Assert
            comparison.ShouldBe(true);
            comparisonObject.ShouldBe(true);
            comparisonEqualOps.ShouldBe(true);
            comparisonInequalOps.ShouldBe(false);
        }

        [Fact]
        public void Comparison_With_Object_Having_Different_Property_Values_Is_Inequal()
        {
            // Arrange
            Address left = new Address
            {
                Street = "Street Left",
                City = "City Left",
                Country = "Country Left"
            };

            Address right = new Address
            {
                Street = "Street Right",
                City = "City Right",
                Country = "Country Right"
            };

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);
            var comparisonEqualOps = left == right;
            var comparisonInequalOps = left != right;

            // Assert
            comparison.ShouldBe(false);
            comparisonObject.ShouldBe(false);
            comparisonEqualOps.ShouldBe(false);
            comparisonInequalOps.ShouldBe(true);
        }

        [Fact]
        public void Comparison_Objects_Without_Any_Properties_Is_Equal()
        {
            // Arrange
            Default left = new Default();
            Default right = new Default();

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);
            var comparisonEqualOps = left == right;
            var comparisonInequalOps = left != right;

            // Assert
            comparison.ShouldBe(true);
            comparisonObject.ShouldBe(true);
            comparisonEqualOps.ShouldBe(true);
            comparisonInequalOps.ShouldBe(false);
        }

        [Fact]
        public void Comparison_Objects_With_Different_Types_Is_Inequal()
        {
            // Arrange
            Default left = new Default();
            Address right = new Address();

            // Act
            var comparison = left.Equals(right);
            var comparisonObject = left.Equals((object)right);

            // Assert
            comparison.ShouldBe(false);
            comparisonObject.ShouldBe(false);
        }

        [Fact]
        public void Hash_Is_Same_For_Equal_Objects()
        {
            // Arrange
            Address left = new Address
            {
                Street = "Street",
                City = string.Empty,
                Country = null
            };

            Address right = new Address
            {
                Street = "Street",
                City = string.Empty,
                Country = null
            };

            // Act
            var leftHash = left.GetHashCode();
            var rightHash = right.GetHashCode();

            // Assert
            leftHash.ShouldBe(rightHash);
        }

        [Fact]
        public void Hash_Is_Different_For_Inequal_Objects()
        {
            // Arrange
            Address left = new Address
            {
                Street = "Street Left",
                City = string.Empty,
                Country = null
            };

            Address right = new Address
            {
                Street = "Street Right",
                City = string.Empty,
                Country = null
            };

            // Act
            var leftHash = left.GetHashCode();
            var rightHash = right.GetHashCode();

            // Assert
            leftHash.ShouldNotBe(rightHash);
        }

        private class Address : ValueObject<Address>
        {
            public string Street { get; set; }

            public string City { get; set; }

            public string Country { get; set; }
        }

        private class Default : ValueObject<Default>
        {

        }
    }
}
