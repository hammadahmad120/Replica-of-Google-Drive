using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FolderDTO
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int ParentFolderId { get; set; }
        public int CreatedBy { get; set; }

        public String CreatedOn { get; set; }
        public Boolean IsActive { get; set; }
       
    }
}
