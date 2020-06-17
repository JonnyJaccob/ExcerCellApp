using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Applicacion2Ejer
{
    public class FileData
    {
        /// When accessed, reads all data from the picked file and returns it.
        public byte[] DataArray { get; }

        /// Filename of the picked file; doesn't contain any path.
        public string FileName { get; }

        /// Full file path of the picked file; note that on some platforms the
        /// file path may not be a real, accessible path but may contain an
        /// platform specific URI; may also be null.
        public string FilePath { get; }

        /// Returns a stream to the picked file; this is the most reliable way
        /// to access the data of the picked file.
        public Stream GetStream(Stream x)
        {
            
            return x;
        }

        public static implicit operator FileData(Plugin.FilePicker.Abstractions.FileData v)
        {
            throw new NotImplementedException();
        }
    }
}
