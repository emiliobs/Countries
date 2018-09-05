namespace Countries.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FilesHelpers
    {
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
