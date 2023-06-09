using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(string imagePath);
    }
}
