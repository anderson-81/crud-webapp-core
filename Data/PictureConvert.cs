using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace crud_webapp.Data
{
    public class PictureConvert
    {
		public async Task<byte[]> IFormFileToByte(IFormFile picture)
		{
           var memoryStream = new MemoryStream();
           await picture.CopyToAsync(memoryStream);
           return memoryStream.ToArray();
        }

        public async Task<string> ByteToBase64(byte[] bytes)
        {
            var base64 = Convert.ToBase64String(bytes);
            var imgSrc = String.Format("data:image/png;base64,{0}", base64);
            return imgSrc;
        }
    }
}