using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class EmailValidationResult
    {
        public string email { get; set; }
        public string autocorrect { get; set; }
        public BoolTxt is_valid_format { get; set; }
        public BoolTxt is_free_email { get; set; }
        public BoolTxt is_disposable_email { get; set; }
        public BoolTxt is_role_email { get; set; }
        
        public BoolTxt is_mx_found { get; set; }
        public BoolTxt is_smtp_valid { get; set; }
        public float quality_score { get; set; }

        //public object is_catchall_email { get; set; }
    }

    public class BoolTxt
    {
        public bool Value { get; set; } = false;
        public string? Text { get; set; }
    }
}
