namespace Tiptong.Framework.Domain.Strategies
{
    using System;
    using Tiptong.Framework.Domain.Contracts;

    public sealed class GuidIdentityStrategy : IIdentityStrategy<Guid>
    {
        public Guid GenerateIdentity()
        {
            byte[] uid = Guid.NewGuid().ToByteArray();
            byte[] binDate = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            byte[] sequentialGuid = new byte[uid.Length];

            // 1. Set the first 6-bytes and the 8th byte same as the generated GUID bytes
            sequentialGuid[3] = uid[0];
            sequentialGuid[2] = uid[1];
            sequentialGuid[1] = uid[2];
            sequentialGuid[0] = uid[3];
            sequentialGuid[5] = uid[4];
            sequentialGuid[4] = uid[5];
            sequentialGuid[7] = uid[6];

            // 2. Set the first nibble of the 7th byte to '1100' for validation issues
            sequentialGuid[6] = (byte)(0xc0 | (0xf & uid[7]));

            // 3. Set the last 8-bytes sequentially from binary date
            sequentialGuid[9] = binDate[0];
            sequentialGuid[8] = binDate[1];
            sequentialGuid[15] = binDate[2];
            sequentialGuid[14] = binDate[3];
            sequentialGuid[13] = binDate[4];
            sequentialGuid[12] = binDate[5];
            sequentialGuid[11] = binDate[6];
            sequentialGuid[10] = binDate[7];

            return new Guid(sequentialGuid);
        }

        public bool ValidateIdentity(Guid identity)
        {
            // 1. Get the 7th byte
            byte b = identity.ToByteArray()[6];

            // 2. Check if the first nibble is 1100
            return (0xc0 & b) == 0xc0;
        }
    }
}