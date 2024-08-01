
namespace Coffeeshop.Model

{
    public partial class Product
    {
        public string Image { get { return Image != "" ? $"/Image/{Image}" : null; } }
    }
}
