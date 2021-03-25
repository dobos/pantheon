using System;
using System.Collections.Generic;
using System.Text;

namespace AddressList
{
    /// <summary>
    /// Provides an interface to get and set object fields as a dictionary
    /// </summary>
    public interface IFields
    {
        public Dictionary<string, object> GetFields();
        public void SetFields(Dictionary<string, object> fields);
    }
}
