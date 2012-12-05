using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;

namespace FileService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class FileCollectorService : IFileCollectorService
    {
        public string UploadFile(Stream fileContents)
        {
            MultipartParser parser = new MultipartParser(fileContents);
            if (parser.Success)
            {
                int count = 0;
                foreach (MultipartParser.FileData singleFileData in parser.FileDataList)
                {
                    SaveFile("from_server_" + count.ToString() + "_" + singleFileData.Filename, singleFileData.ContentType, singleFileData.FileContents);
                    count++;
                }
            }


            //OldMultipartParser parser = new OldMultipartParser(fileContents);

            //if (parser.Success)
            //{
            //    // Save the file
            //    SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
            //}

            return "";
        }

        private void SaveFile(string filename, string contentType, byte[] fileContents)
        {
            File.WriteAllBytes(@"C:\Temp\" + "fromServer_" + filename, fileContents);
        }

     
    }
}
