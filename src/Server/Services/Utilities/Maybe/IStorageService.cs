using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public interface IStorageService
    {
        // Read
        byte[] ReadBinaryResource(string id);

        string ReadTextResource(string id);

        // Write
        void WriteBinaryResource(string id, byte[] toWrite);

        void WriteTextResource(string id, string toWrite);

        void AppendTextResource(string id, string toWrite);

        // Clear
        void ClearTextResource(string id);

        // Delete
        void DeleteResource(string id);
    }   
}
