using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    class isIntergerOrDoubleBL
    {
        public static Boolean isInteger(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static Boolean isDouble(string input)
        {
            try
            {
                Convert.ToDouble(input);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
