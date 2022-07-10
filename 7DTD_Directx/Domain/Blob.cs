using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _7DTD_Directx.Domain
{
    [Table("Blobs", Schema = "Config")]
    public class Blob
    {
        public Guid BlobID { get; private set; }

        public string Name { get; private set; }

        public byte[] Bytes { get; private set; }


        protected Blob()
        {

        }


        public Blob(string name, byte[] bytes)
        {
            BlobID = Guid.NewGuid();
            Name = name;
            Bytes = bytes;
        }
    }
}
