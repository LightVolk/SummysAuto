using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummysAuto.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }

        public string Action { get; set; }

        public string Glyph { get; set; }

        public string Text { get; set; }

        public int? ServiceId { get; set; }

        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder();
                if(ServiceId!=null&&ServiceId!=0)
                {
                    param.Append(String.Format($"{ServiceId}"));
                }
                return param.ToString().Substring(0, param.Length);
            }
        }
    }
}
