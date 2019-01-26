namespace Tiptong.Framework.Domain.Tests
{
    using System;
    using Xunit;

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
            var areEqualWithUnassignableTypes = entityLeft.Equals(entityRight);

            // Assert
            Assert.False(areEqualWithUnassignableTypes);
        }

        [Fact]
        public void Entities_With_Different_Identities_Comparison_Fails()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity
            {
                Id = 13
            };

            var entityRight = new MockIntegerEntity
            {
                Id = 21
            };

            // Act
            var areEqualWithDifferentIdentities = entityLeft.Equals(entityRight);
            var areEqualWithDifferentIdentitiesOps = entityLeft == entityRight;
            var areNotEqualWithDifferentIdentitiesOps = entityLeft != entityRight;

            // Assert
            Assert.False(areEqualWithDifferentIdentities);
            Assert.False(areEqualWithDifferentIdentitiesOps);
            Assert.True(areNotEqualWithDifferentIdentitiesOps);

        }

        [Fact]
        public void Entities_With_Same_Identities_Comparison_Succeeds()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity
            {
                Id = 13,
                Name = "First Entity"
            };

            var entityRight = new MockIntegerEntity
            {
                Id = 13,
                Name = "Second Entity"
            };

            // Act
            var areEqualWithSameIdentities = entityLeft.Equals(entityRight);
            var areEqualWithSameIdentitiesOps = entityLeft == entityRight;
            var areNotEqualWithSameIdentitiesOps = entityLeft != entityRight;


            // Assert
            Assert.True(areEqualWithSameIdentities);
            Assert.True(areEqualWithSameIdentitiesOps);
            Assert.False(areNotEqualWithSameIdentitiesOps);
        }        

        [Fact]
        public void Both_Null_Entities_Ops_Comparison_Succeeds()
        {
            // Arrange
            MockIntegerEntity entityLeft = null;
            MockIntegerEntity entityRight = null;

            // Act
            var areEqualWithNullValues = entityLeft == entityRight;
            var areNotEqualWithNullValues = entityLeft != entityRight;


            // Assert
            Assert.True(areEqualWithNullValues);
            Assert.False(areNotEqualWithNullValues);
        }

        [Fact]
        public void Entities_With_Same_Identities_Have_Same_Hash_Codes()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity
            {
                Id = 13,
                Name = "First Entity"
            };

            var entityRight = new MockIntegerEntity
            {
                Id = 13,
                Name = "Second Entity"
            };

            // Act
            var hashLeft = entityLeft.GetHashCode();
            var hashRight = entityRight.GetHashCode();


            // Assert
            Assert.Equal(hashLeft, hashRight);
        }

        [Fact]
        public void Entities_With_Different_Identities_Have_Different_Hash_Codes()
        {
            // Arrange
            var entityLeft = new MockIntegerEntity
            {
                Id = 13,
                Name = "Entity"
            };

            var entityRight = new MockIntegerEntity
            {
                Id = 21,
                Name = "Entity"
            };

            // Act
            var hashLeft = entityLeft.GetHashCode();
            var hashRight = entityRight.GetHashCode();


            // Assert
            Assert.NotEqual(hashLeft, hashRight);
        }

        [Fact]
        public void Entity_With_Invalid_Identity_Has_Zero_Hash_Code()
        {
            // Arrange
            var entity = new MockIntegerEntity
            {
                Id = -13
            };

            // Act
            var hash = entity.GetHashCode();


            // Assert
            Assert.Equal(0, hash);
        }

        [Fact]
        public void Entity_Has_Friendly_String()
        {
            // Arrange
            var entity = new MockIntegerEntity
            {
                Id = 13
            };

            // Act
            var hash = entity.ToString();


            // Assert
            Assert.Equal("[MockIntegerEntity 13]", hash);
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
