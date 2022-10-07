using System.Text;
using System.Xml;


namespace XMLWriterReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProduct = new List<Product>() { 
                new Product( "Acer","Суперигровой",300000), 
                new Product("Asus", "Офисный унылый", 30000), 
                new Product("Apple", "Престижный донельзя", 200000) 
            };
            Order ord = new Order(listProduct);
            XmlTextWriter? xmltw = null;
            try
            {
                xmltw = new XmlTextWriter("test.xml", Encoding.Unicode);
                xmltw.Formatting = Formatting.Indented;
                xmltw.Indentation = 4;
                xmltw.WriteStartDocument();
                xmltw.WriteStartElement("orders");
                foreach (Product product in ord._products)
                {
                    xmltw.WriteStartElement("Product");
                    xmltw.WriteAttributeString("name", product.Name);
                        xmltw.WriteElementString("description",product.Description);
                        xmltw.WriteElementString("price",product.Price.ToString());   
                    xmltw.WriteEndElement();
                }
                xmltw.WriteEndElement();
                xmltw.WriteEndDocument();
                                
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (xmltw != null)
                    xmltw.Close();
            }
        }
    }

    class Order 
    {
        static Random random = new Random();
        public int _id;
        public DateTime OrderDate { get; set; }
        public List<Product> _products = new List<Product>();
        public Order(List<Product> Products)
        {
            _products = Products;
            _id = DateTime.Now.Millisecond * random.Next(100);
        }
    }
    class Product 
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public Product( string name, string desc, int price) 
        {
            Name = name;
            Description = desc;
            Price = price;
        }


    }
}