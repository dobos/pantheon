using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AddressList
{
    /// <summary>
    /// Implements a business card
    /// </summary>
    public class Card : IFields
    {
        private int id;
        private string name;
        private string address;

        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Person name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Person address
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Instantiates a new business card object
        /// </summary>
        public Card()
        {
            InitializeMembers();
        }

        /// <summary>
        /// Creates a deep copy of a business card object
        /// </summary>
        /// <param name="other"></param>
        public Card(Card other)
        {
            CopyMembers(other);
        }

        private void InitializeMembers()
        {
            this.id = -1;
            this.name = null;
            this.address = null;
        }

        private void CopyMembers(Card other)
        {
            this.id = other.id;
            this.name = other.name;
            this.address = other.address;
        }

        /// <summary>
        /// Return dictionary with fields. To support generic file I/O
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetFields()
        {
            // We could use reflection for this but this is faster
            return new Dictionary<string, object>()
            {
                { nameof(Id), Id },
                { nameof(Name), Name },
                { nameof(Address), Address },
            };
        }

        public void SetFields(Dictionary<string, object> fields)
        {
            throw new NotImplementedException();
        }
    }
}
