using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heimdall.Core.Model
{
    public class Rating
    {
        public string Source { get; set; }
        private double _Value;
        public string Value
        {
            get { return _Value.ToString(); }
            set
            {
                string str = value.ToString();
                string temp;

                if (str.Contains("%"))
                {
                    temp = str.Replace("%", "");
                    _Value = Convert.ToDouble(temp);
                }
                else if (str.Contains("/100"))
                {
                    temp = str.Replace("/100", "");
                    _Value = Convert.ToDouble(temp);
                }
                else if (str.Contains("/10"))
                {
                    temp = str.Replace("/10", "");
                    _Value = Convert.ToDouble(temp) * 10;
                }
            }
        }
    }
}
