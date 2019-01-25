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
        public void Generates_Valid_Identity(Type entityType)
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
