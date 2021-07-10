using System;
using System.Collections.Generic;
using System.Text;

namespace ESRB_category_form
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class States
    {
        public string ID { get; set; }
        public string State { get; set; }
    }
}
