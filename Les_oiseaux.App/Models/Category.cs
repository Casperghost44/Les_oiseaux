using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_oiseaux.App.Models
{
    public class Category : IDatabaseModel
    {
        public virtual long? Id { get; set; }
        public virtual string Name { get; protected internal set; }
        public virtual IList<Product> Products { get; protected internal set; }

        protected Category()
        {
        }

        protected Category(string name)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            return new Category(name);
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}

