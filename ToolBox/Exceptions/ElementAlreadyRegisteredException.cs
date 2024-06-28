using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox
{
    public class ElementAlreadyRegisteredException : Exception
    {
        public ElementAlreadyRegisteredException()
        {
            Tool.ShowErrorMessage("The element is already registered");
        }
    }
}
