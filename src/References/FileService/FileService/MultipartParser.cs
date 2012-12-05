using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace FileService
{
    public class MultipartParser
    {
        public MultipartParser(Stream stream)
        {
            this.Parse(stream, Encoding.UTF8);
        }

        public MultipartParser(Stream stream, Encoding encoding)
        {
            this.Parse(stream, encoding);
        }

        private void Parse(Stream stream, Encoding encoding)
        {
            Success = false;
            FileDataList = new List<FileData>();

            // Read the stream into a byte array
            byte[] data = ToByteArray(stream);

            // Copy to a string for header parsing
            string content = encoding.GetString(data);

            // The first line should contain the delimiter
            int delimiterEndIndex = content.IndexOf("\r\n");
            if (delimiterEndIndex < 0)
                return;

            Success = true;

            string delimiter = content.Substring(0, content.IndexOf("\r\n"));

            // Get delimiter bytes
            byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);            

            // Get start and end indexes for each part
            // Each part starts where the last one ends and ends when the next delimiter starts + \r\n

            // Get the first one
            List<KeyValuePair<int, int>> parts = new List<KeyValuePair<int, int>>();

            int endIndex = -1;
            do
            {
                int startIndex = endIndex + 1 + delimiterBytes.Length;
                endIndex = IndexOf(data, delimiterBytes, startIndex);
                if (startIndex < 0 || endIndex < 0 || startIndex > data.Length || endIndex > data.Length)
                    break;

                parts.Add(new KeyValuePair<int, int>(startIndex, endIndex));
            }
            while (true);


            foreach (KeyValuePair<int,int> pair in parts)
            {
                FileData fileData = ParseSingleFile(data, pair.Key, pair.Value, encoding);
                if (fileData.Success)
                    FileDataList.Add(fileData); 
            }                                
        }

        FileData ParseSingleFile(byte[] data, int startIndex, int endIndex, Encoding encoding)
        {
            FileData ans = new FileData();
            ans.Success = false;

            string content = encoding.GetString(data, startIndex, endIndex-startIndex);

            // Look for Content-Type
            Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
            Match contentTypeMatch = re.Match(content);

            // Look for filename
            re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
            Match filenameMatch = re.Match(content);

            // Did we find the required values?
            if (contentTypeMatch.Success && filenameMatch.Success)
            {
                // Set properties
                ans.ContentType = contentTypeMatch.Value.Trim();
                ans.Filename = filenameMatch.Value.Trim();

                // Get the start & end indexes of the file contents
                int localStartIndex = startIndex + contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;

                int contentLength = endIndex - localStartIndex;

                // Extract the file contents from the byte array
                byte[] fileData = new byte[contentLength];

                Buffer.BlockCopy(data, localStartIndex, fileData, 0, contentLength);

                ans.FileContents = fileData;
                ans.Success = true;
            }

            return ans;
        }

        private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
        {
            int index = 0;
            int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);

            if (startPos != -1)
            {
                while ((startPos + index) < searchWithin.Length)
                {
                    if (searchWithin[startPos + index] == serachFor[index])
                    {
                        index++;
                        if (index == serachFor.Length)
                        {
                            return startPos;
                        }
                    }
                    else
                    {
                        startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                        if (startPos == -1)
                        {
                            return -1;
                        }
                        index = 0;
                    }
                }
            }

            return -1;
        }

        private byte[] ToByteArray(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        public class FileData
        {
            public bool Success
            {
                get;
                set;
            }

            public string ContentType
            {
                get;
                set;
            }

            public string Filename
            {
                get;
                set;
            }

            public byte[] FileContents
            {
                get;
                set;
            }
        }


        public bool Success
        {
            get;
            set;
        }

        public List<FileData> FileDataList
        {
            get;
            private set;
        }

    }
}
