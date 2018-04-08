using System;
using System.Security.Cryptography;
using System.Text;

namespace MusicallyApi.Data
{
    public class Device
    {
        private Device() { }

        public string DeviceId { get; set; }

        public static Device Generate()
        {
            // DeviceId
            var deviceIdBuilder = new StringBuilder();
            var deviceGuid = Guid.NewGuid().ToString().Replace("-", "");

            deviceIdBuilder.Append("a0"); // Static.
            deviceIdBuilder.Append(deviceGuid); // Can be anything [0-9a-z]{32}.

            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(deviceGuid));
                var hashStr = Encoding.ASCII.GetBytes(BitConverter.ToString(hash).Replace("-", "").ToLower());

                deviceIdBuilder.Append(hashStr[12]); // Checksum byte 1.
                deviceIdBuilder.Append(hashStr[16]); // Checksum byte 2.
            }

            return new Device
            {
                DeviceId = deviceIdBuilder.ToString()
            };
        }
    }
}
