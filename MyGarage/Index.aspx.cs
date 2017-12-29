using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        //Get list of all products in DB
        ProductModel productModel = new ProductModel();
        List<Product> products = productModel.GetAllProducts();

        //Make sure products exists in database
        if (products != null)
        {
            //create a new panel with an Imagebutton and 2 lables for each product
            foreach (Product product in products)
            {
                Panel productPanel = new Panel();
                ImageButton imageButton = new ImageButton();
                Label lblName = new Label();
                Label lblPrice = new Label();

                //set childControls' properties
                imageButton.ImageUrl = "~/Images/Products/" + product.Image;
                imageButton.CssClass = "productImage";
                imageButton.PostBackUrl = "~/Pages/Product.aspx?id=" + product.Id;

                lblName.Text = product.Name;
                lblName.CssClass = "productName";

                lblPrice.Text = "$ " + product.Price;
                lblPrice.CssClass = "productPrice";

                //Add child controls to Pannel
                productPanel.Controls.Add(imageButton);
                productPanel.Controls.Add(new Literal{Text = "<br />"});
                productPanel.Controls.Add(lblName);
                productPanel.Controls.Add(new Literal{ Text = "<br />" });
                productPanel.Controls.Add(lblPrice);

                //Add dynamic Panels to static Parent panel
                pnlProducts.Controls.Add(productPanel);
            }
        }
        else
        {
            //No Products found
            pnlProducts.Controls.Add(new Literal {Text = "No products found!"});
        }
        
    }
}