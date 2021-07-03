using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QSpace.Data.DbEntities
{
    public class BaseDbEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public BaseDbEntity(){
            IsDeleted = false;
        }

    }
}
