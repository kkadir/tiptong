using System;
using Xunit;
using Tiptong.Framework.Domain;
using Tiptong.Framework.Domain.Contracts;

namespace Tiptong.Framework.Domain.Tests
{
    public class EntityTests
    {
        [Theory]
        [InlineData(typeof(MockIntegerEntity))]
        [InlineData(typeof(MockGuidEntity))]
        [InlineData(typeof(MockLongEntity))]
        public void Identity_Strategy_Generates_Valid_Idenity(Type entityType)
        {
            // Arrange
            dynamic entity = Activator.CreateInstance(entityType);

            // Act
            var identity = entity.GenerateIdentity();

            // Assert
            Assert.True(entity.ValidateIdentity(identity));
        }

        [Fact]
        public void Cannot_Create_Entity_Without_Valid_Identity_Strategy()
        {
            // Arrange
            

            // Act
            Action act = () => new MockStringEntity();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Theory]
        [InlineData(typeof(MockIntegerEntity))]
        [InlineData(typeof(MockGuidEntity))]
        [InlineData(typeof(MockLongEntity))]
        public void Can_Set_Valid_Identity(Type entityType)
        {
            // Arrange
            dynamic entity = Activator.CreateInstance(entityType);
            dynamic identity = entity.GenerateIdentity();            

            // Act
            entity.SetIdentity(identity);

            // Assert
            Assert.Equal(identity, entity.Id);
        }

        [Theory]
        [InlineData(typeof(MockIntegerEntity))]
        [InlineData(typeof(MockGuidEntity))]
        [InlineData(typeof(MockLongEntity))]
        public void Cannot_Set_Invalid_Identity(Type entityType)
        {
            // Arrange
            dynamic entity = Activator.CreateInstance(entityType);
            dynamic identity = entity.GenerateIdentity();
            entity.SetIdentity(identity);

            Type type = identity.GetType();
            dynamic defaultIdentity = Activator.CreateInstance(type);

            // Act
            entity.SetIdentity(defaultIdentity);

            // // Assert
            Assert.Equal(identity, entity.Id);
            Assert.NotEqual(defaultIdentity, entity.Id);
        }

        [Theory]
        [InlineData(typeof(MockIntegerEntity))]
        [InlineData(typeof(MockGuidEntity))]
        [InlineData(typeof(MockLongEntity))]
        public void Can_Self_Validate_Identity(Type entityType)
        {
            // Arrange
            dynamic validEntity = Activator.CreateInstance(entityType);
            dynamic invalidEntity = Activator.CreateInstance(entityType);

            // Act
            validEntity.Id = validEntity.GenerateIdentity();
            invalidEntity.Id = Activator.CreateInstance(invalidEntity.Id.GetType());

            // Assert
            Assert.True(validEntity.HasValidIdentity());
            Assert.False(invalidEntity.HasValidIdentity());
        }

        [Fact]
        public void Null_Or_NonEntity_Comparison_Fails()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity();
            object entityNull = null;
            object nonEntity = String.Empty;

            // Act
            var areEqualWithNullObject = entityLeft.Equals(entityNull);
            var areEqualWithNonEntityObject = entityLeft.Equals(nonEntity);

            // Assert
            Assert.False(areEqualWithNullObject);
            Assert.False(areEqualWithNonEntityObject);
        }

        [Fact]
        public void Same_Reference_Comparison_Succeeds()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity();
            object entityRight = entityLeft;

            // Act
            var areEqualWithSameReferenceObject = entityLeft.Equals(entityRight);

            // Assert
            Assert.True(areEqualWithSameReferenceObject);
        }

        [Fact]
        public void Entities_With_Invalid_Identities_Comparison_Fails()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity
            {
                Id = 0
            };

            var entityRight = new MockIntegerEntity
            {
                Id = 0
            };

            // Act
            var areEqualWithInvalidIdentity = entityLeft.Equals((object)entityRight);

            // Assert
            Assert.False(areEqualWithInvalidIdentity);
        }

        [Fact]
        public void Entities_With_Not_Assignable_Types_Comparison_Fails()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity();
            entityLeft.SetIdentity(entityLeft.GenerateIdentity());

            var entityRight = new MockGuidEntity();
            entityRight.SetIdentity(entityRight.GenerateIdentity());

            // Act
            var areEqualWithUnassignableTypes = entityLeft.Equals((object)entityRight);

            // Assert
            Assert.False(areEqualWithUnassignableTypes);
        }

        private class MockIntegerEntity : Entity<int>
        {
            public string Name { get; set; }
        }

        private class MockGuidEntity : Entity<Guid>
        {
            public string Name { get; set; }
        }

        private class MockLongEntity : Entity<long>
        {
            public string Name { get; set; }
        }

        private class MockStringEntity : Entity<string>
        {
            public string Name { get; set; }
        }
    }
}
