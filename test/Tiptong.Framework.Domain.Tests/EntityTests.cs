using System;
using Moq;
using Xunit;
using Tiptong.Framework.Domain;
using Tiptong.Framework.Domain.Contracts;

namespace Tiptong.Framework.Domain.Tests
{
    public class EntityTests
    {
        [Fact]
        public void Test1()
        {
            var entity = new Mock<IEntity<int>>();

            entity.SetIdentity(4);

            Assert.Equal(entity.Id, 5);
        }
    }
}
