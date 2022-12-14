using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SpexE_Comm.Service.Services
{
    public interface IFirebaseCloudStorageService
    {
        Task<string> UploadFileInFirebase(string fileName, Stream stream);
    }
}
