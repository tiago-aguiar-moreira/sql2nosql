using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SQL2NoSQL.Core.Model
{
    public class Rule
    {
        public Type FieldType { get; set; }
        public string FieldName { get; set; }
        public string Mask { get; set; }
    }
}
