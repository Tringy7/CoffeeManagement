using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.ADO.NET.DAL;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.BLL
{
    public class BL_Product
    {
        DB_Main db = null;
        ProductDAL productDAL = null;
        public BL_Product()
        {
            db = new DB_Main();
            productDAL = new ProductDAL();
        }
       
        public List<Class_product> getProductList()
        {
          return productDAL.getProductList();
        }

        // add new product
        public bool addNewProduct(Class_product product, ref string error)
        {
           return productDAL.addNewProduct(product, ref error);
        }

        // update product
        public bool updateProduct(Class_product product, ref string error)
        {
           return productDAL.updateProduct(product, ref error);
        }

        // delete product
        public bool deleteProduct(int productId, ref string error)
        {
            return productDAL.deleteProduct(productId, ref error);
        }

        public bool UpdateProductQuantity(int productId, int quantity, ref string error)
        {
            return db.UpdateProductQuantity(productId, quantity, ref error);
        }

        public bool MarkProductUnavailable(int productId, ref string error)
        {
            return productDAL.MarkProductUnavailable(productId, ref error);
        }
        public bool SetProductStatus1(int productId, ref string error)
        {
           return productDAL.SetProductStatus1(productId, ref error);
        }
        public bool SetProductStatus2(int productId, ref string error)
        {
           return productDAL.SetProductStatus2(productId, ref error);  
        }
    }
}
