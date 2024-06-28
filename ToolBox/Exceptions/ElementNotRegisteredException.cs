using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    public class ElementNotRegisteredException : Exception
    {
        public ElementNotRegisteredException()
        {
            Tool.ShowErrorMessage("The element is not registered");
        }
    }
}
