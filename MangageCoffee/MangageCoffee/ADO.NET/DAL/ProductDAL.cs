using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangageCoffee.DTO;

namespace MangageCoffee.ADO.NET.DAL
{
    public class ProductDAL
    {
        DB_Main db = null;
        public ProductDAL()
        {
            db = new DB_Main();
        }
        public DataSet getData()
        {
            string sqlString = "select * from Products Where Available = 'True'";
            return db.ExecuteQueryDataSet(sqlString, CommandType.Text);
        }
        public List<Class_product> getProductList()
        {
            List<Class_product> products = new List<Class_product>();
            DataSet ds = getData();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Class_product product = new Class_product
                {
                    Id = Convert.ToInt32(row["ProductID"]),
                    Name_Product = row["Name"].ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Category = row["Category"].ToString(),
                    Status = (row["Status"]).ToString(),
                    CreatedBy = Convert.ToInt32(row["CreatedBy"]),
                    OriginalPrice = Convert.ToDouble(row["OriginalPrice"]),
                    ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                    Available = Convert.ToBoolean(row["Available"])

                };
                products.Add(product);
            }

            return products;
        }

        // add new product
        public bool addNewProduct(Class_product product, ref string error)
        {
            string sqlString = "INSERT INTO Products (Name, Price, Quantity, Category, Status, CreatedBy, OriginalPrice, ImagePath,Available) " +
                               "VALUES (@Name, @Price, @Quantity, @Category, @Status, @CreatedBy, @OriginalPrice, @ImagePath,@Available)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", product.Name_Product),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@Category", product.Category),
                new SqlParameter("@Status", product.Status),
                new SqlParameter("@CreatedBy", product.CreatedBy),
                new SqlParameter("@OriginalPrice", product.OriginalPrice),
                new SqlParameter("@ImagePath", product.ImagePath),
                new SqlParameter("@Available", product.Available)
            };

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        }

        // update product
        public bool updateProduct(Class_product product, ref string error)
        {
            string sqlString = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity, " +
                               "Category = @Category, Status = @Status, CreatedBy = @CreatedBy, OriginalPrice = @OriginalPrice, " +
                               "ImagePath = @ImagePath, Available = @Available " +
                               "WHERE ProductID = @ProductID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductID", product.Id),
                new SqlParameter("@Name", product.Name_Product),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@Quantity", product.Quantity),
                new SqlParameter("@Category", product.Category),
                new SqlParameter("@Status", product.Status),
                new SqlParameter("@CreatedBy", product.CreatedBy),
                new SqlParameter("@OriginalPrice", product.OriginalPrice),
                new SqlParameter("@ImagePath", product.ImagePath),
                new SqlParameter("@Available", product.Available)
            };

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error, parameters);
        }

        // delete product
        public bool deleteProduct(int productId, ref string error)
        {
            string sqlDeleteMenuItems = "DELETE FROM MenuItems WHERE ProductID = @ProductID";
            SqlParameter[] parameters1 = new SqlParameter[]
            {
                    new SqlParameter("@ProductID", productId)
            };

            bool menuItemsDeleted = db.MyExecuteNonQuery(sqlDeleteMenuItems, CommandType.Text, ref error, parameters1);

            if (!menuItemsDeleted)
                return false;

            string sqlDeleteProduct = "DELETE FROM Products WHERE ProductID = @ProductID";
            SqlParameter[] parameters2 = new SqlParameter[]
            {
        new SqlParameter("@ProductID", productId)
            };

            return db.MyExecuteNonQuery(sqlDeleteProduct, CommandType.Text, ref error, parameters2);
        }

        public bool UpdateProductQuantity(int productId, int quantity, ref string error)
        {
            return db.UpdateProductQuantity(productId, quantity, ref error);
        }

        public bool MarkProductUnavailable(int productId, ref string error)
        {
            string sqlString = $"UPDATE Products SET Available = 0 WHERE ProductID = {productId}";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool SetProductStatus1(int productId, ref string error)
        {
            string sqlString = $"UPDATE Products SET Status = 'False' WHERE ProductID = {productId}";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
        public bool SetProductStatus2(int productId, ref string error)
        {
            string sqlString = $"UPDATE Products SET Status = 'True' WHERE ProductID = {productId}";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref error);
        }
    }
}
