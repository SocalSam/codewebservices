using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restfulxaml
{
    public class cities
    {

        /// <remarks/>

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class NewDataSet
        {

            private NewDataSetTable[] tableField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Table")]
            public NewDataSetTable[] Table
            {
                get
                {
                    return this.tableField;
                }
                set
                {
                    this.tableField = value;
                }
            }
        }

        /// <remarks/>

        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NewDataSetTable
        {

            private string countryField;

            private string cityField;

            /// <remarks/>
            public string Country
            {
                get
                {
                    return this.countryField;
                }
                set
                {
                    this.countryField = value;
                }
            }

            /// <remarks/>
            public string City
            {
                get
                {
                    return this.cityField;
                }
                set
                {
                    this.cityField = value;
                }
            }
        }


    }
}
