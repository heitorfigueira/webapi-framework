using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Framework.DataAccess.Entities
{
    public abstract class EntityBaseIdType<T> where T : notnull
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
=