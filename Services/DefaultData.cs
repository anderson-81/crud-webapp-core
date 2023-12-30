using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using crud_webapp.Data;
using Microsoft.AspNetCore.Hosting;

namespace crud_webapp.Services
{
    public class DefaultData
    {
        public PictureConvert pictureConvert;

        public bool ValidateCreate(Customer customer)
        {
            if (customer.Name == "John")
            {
                if (customer.Email == "john@crudwebapp.com")
                {
                    if (customer.Salary == 3000)
                    {
                        if (customer.Birthday == new DateTime(1974, 07, 07))
                        {
                            if (customer.Gender == "M")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool ValidateEdit(Customer customer)
        {
            if (customer.Name == "John Paul")
            {
                if (customer.Email == "john@crudwebapp.com")
                {
                    if (customer.Salary == 3300)
                    {
                        if (true)
                        {
                            if (customer.Gender == "M")
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public byte[] GetPicture(int opc)
        {
            /*
            var md5 = MD5.Create();

            if (opc == 1)
            {
                byte[] stream = GetPictureFromDatabase(opc);
                string hash = Encoding.Default.GetString(md5.ComputeHash(stream));
                if (hash == "�\u0002�H@~2(�1��D\f�\u001e")
                {
                    return stream;
                }
            }

            if (opc == 2)
            {
                byte[] stream = GetPictureFromDatabase(opc);
                string hash = Encoding.Default.GetString(md5.ComputeHash(stream));
                if (hash == "��|$'��\u0015��r}�gH\u001f")
                {
                    return stream;
                }
            }
            return null;
            */
            return this.GetPictureFromDatabase(opc);
        }

        private byte[] GetPictureFromDatabase(int opc)
        {
            try
            {
                return new ApplicationDbContext().PictureData.Where(p => p.Id == opc).Single().Image;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
