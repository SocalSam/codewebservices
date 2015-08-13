#region system
using System;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion
#region Xaml
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#endregion
/**** Make sure to have a using
***** that points to your
***** ServiceReference */
using restfulxaml.ServiceReference;

namespace restfulxaml
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal cities.NewDataSet cn;
        public MainPage()
        {
            this.InitializeComponent();   
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            /****************************************/
            /*   Create the binding                 */
            BasicHttpBinding binding = new BasicHttpBinding();
            /*   Set message size if required       */
            binding.MaxReceivedMessageSize = 20000000;
            /*  Set the Endpoint                    */
            EndpointAddress address = new EndpointAddress("http://www.webservicex.com/globalweather.asmx");
            /****************************************/
            /*  Get the task                        */
            GlobalWeatherSoapClient gwsc = new GlobalWeatherSoapClient(binding, address);
            /*  Always a good idea to test for
            *   Exceptions                          */
            try
            {
                Task<string> getCities = gwsc.GetCitiesByCountryAsync("");
                /************************************/
                /* Place a call to another method 
                *  to do work, this event or        
                *  function while the task finishes 
                *  METHOD CALL HERE                 */
                // Method
                /*   This event cannot complete w/o   
                *    the await getCities task         
                *    being completed                */
                string citys = await getCities;
                /*  You get the XML data &           
                *   deserialize it.                  
                *   You do need to create a class    
                *   that gives you access to the XML */
                XmlSerializer result = new XmlSerializer(typeof(cities.NewDataSet));
                cn = (cities.NewDataSet)result.Deserialize(new StringReader(citys));
                /*  After deserialization, use       
                *   Lamda & Linq                     */
                var Countries = cn.Table.Select(m => m.Country).Distinct();
                /****************************************
                /*  Add countries to the combo box   */
                cmbxCountry.ItemsSource = Countries;
                /****************************************/
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private void cmbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Cities = cn.Table.Where(m => m.Country == cmbxCountry.SelectedItem as String).Select(c=>c.City); //Selecting only one country using a lamda.            
            cmbxCity.ItemsSource = Cities;            
        }
        private void cmbxCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            //Use this event to get weather
        }
    }
}
