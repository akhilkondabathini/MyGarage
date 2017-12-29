using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Management_ManageProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetImages();

            //Check if the url contains an id parameter
            if(!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                FillPage(id);
            }

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ProductModel productModel = new ProductModel();
        Product product = CreateProduct();

        //Check if the url contains an id parameter
        if (!String.IsNullOrWhiteSpace(Request.QueryString["id"]))
        {
            //Id exists -->     Update existing row
            int id = Convert.ToInt32(Request.QueryString["id"]);
            lblResult.Text = productModel.UpdateProduct(id, product);

        }
        else
        {
            //Id doesnot exists -->     Crate a new row

            lblResult.Text = productModel.InsertProduct(product);
        }
    }

    private void FillPage(int id)
    {
        //Get selected Product from DB
        ProductModel productModel = new ProductModel();
        Product product = productModel.GetProduct(id);

        //Fill Textboxes
        txtDescription.Text = product.Description;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString();

        //set dropdownlist values
        ddlImage.SelectedValue = product.Image;
        ddlType.SelectedValue = product.TypeId.ToString();


    }

    private void GetImages()
    {
        try
        {
            //Get all file paths
            string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

            //Get all Filenames and add them to array list

            ArrayList imageList = new ArrayList();
            foreach(string image in images)
            {
                string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                imageList.Add(imageName);
            }

            //set the arraylist as the dropdownview's datasource and refresh

            ddlImage.DataSource = imageList;
            ddlImage.AppendDataBoundItems = true;
            ddlImage.DataBind();
        }
        catch(Exception e)
        {
            lblResult.Text = e.ToString();
        }
    }

    private Product CreateProduct()
    {
        Product product = new Product();

        product.Name = txtName.Text;
        product.Price = Convert.ToDecimal(txtPrice.Text);
        product.TypeId = Convert.ToInt32(ddlType.SelectedValue);
        product.Description = txtDescription.Text;
        product.Image = ddlImage.SelectedValue;

        return product;

    }

   
}