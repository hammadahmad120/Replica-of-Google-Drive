using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class FileDTO
    {

        public int id { get; set; }
        public String Name { get; set; }
        public int ParentFolderId { get; set; }
        public String FileExt { get; set; }
        public String FileUniqueName { get; set; }
        public int FileSizeInKB { get; set; }
        public int CreatedBy { get; set; }

        public String UploadedOn { get; set; }
        public Boolean IsActive { get; set; }
        public String ContentType { get; set; }
    }
}
