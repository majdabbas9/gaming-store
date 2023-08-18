using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class EditProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false || ((bool)Session["Admin1"] == false))
        {
            Response.Redirect("ViewProduct.aspx");
        }
        LabelMSG.Text = "";
        if (!IsPostBack)
        {
            FillGrid();
            FillDDl();
            DropDownListT.Items.Add("ShowAll");
        }
    }
    protected void ButtonShow_Click(object sender, EventArgs e)
    {
        if (DropDownListT.SelectedValue.ToString() == "ShowAll")
        {
            FillGrid();
        }
        else
        {
        string TypeName = DropDownListT.SelectedValue.ToString();
        string TypeID = ClassTypes.GetID(TypeName);
        string str = "EditProdoctBy2.aspx?TypeID={0}";
        str = string.Format(str,TypeID);
        Response.Redirect(str);
        }
    }
    public void FillGrid()
    {
        GridViewP.DataSource = ClassProduct.GetAll();
        GridViewP.DataBind();
    }
    public DataTable FillTypes()
    {
        return ClassTypes.GetAll();
    }
    protected void GridViewP_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            UpdateProduct(e.RowIndex);
            GridViewP.EditIndex = -1;
            
            
                FillGrid();
            
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    protected void GridViewP_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewP.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void GridViewP_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label lb = (Label)GridViewP.Rows[e.RowIndex].FindControl("LabelPID");
            string str = string.Format("SELECT * FROM [Product] WHERE ProductID={0}", lb.Text);
            DataTable dt = Dbase.SelectFromTable(str, "DB.accdb");
            string f = dt.Rows[0]["Photo"].ToString();
            string strRealPath = Request.PhysicalApplicationPath;
            System.IO.File.Delete(strRealPath + f);
            ClassProduct.Delete(lb.Text);           
               
           
          
            
                FillGrid();
            
           
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    protected void GridViewP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Insert"))
            {
                insert();
               
                    FillGrid();
                
                FillDDl();
            }
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    protected void GridViewP_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewP.EditIndex = -1;
                   FillGrid();
   
    }
    public void UpdateProduct(int Rowindex)
    {      
        try
        {
            Label lb1 = (Label)GridViewP.Rows[Rowindex].FindControl("LabelPID");
            TextBox TextBoxW = (TextBox)GridViewP.Rows[Rowindex].FindControl("TextBoxW");
            TextBox TextBoxQ = (TextBox)GridViewP.Rows[Rowindex].FindControl("TextBoxQ");
            TextBox TextBoxP = (TextBox)GridViewP.Rows[Rowindex].FindControl("TextBoxP");
            TextBox TextBoxPN = (TextBox)GridViewP.Rows[Rowindex].FindControl("TextBoxPN");
            if (!ClassProduct.TheCarrentName(lb1.Text).Equals(TextBoxPN.Text))
            {
                if (ClassProduct.DoesThisProductNameExist(TextBoxPN.Text))
                {
                    LabelMSG.Text = "This Product Name Exsit";
                    return;
                }
            }
            DropDownList DDLT = (DropDownList)GridViewP.Rows[Rowindex].FindControl("DropDownListEditType");
            DataTable dt = ClassProduct.GetByID(lb1.Text);
            string f = dt.Rows[0]["Photo"].ToString();
            string strRealPath = Request.PhysicalApplicationPath;
            FileUpload FU = (FileUpload)GridViewP.Rows[Rowindex].FindControl("FileUploadEdit");
            if (FU.HasFile)
            {
                if (!System.IO.Directory.Exists(strRealPath))
                {
                    LabelMSG.Text = "This Image Does not Exist";
                    return;
                }
                else
                {
                    System.IO.File.Delete(strRealPath + f);
                    strRealPath += "Images\\";
                    FU.SaveAs(strRealPath + FU.FileName);
                    Label lb = (Label)GridViewP.Rows[Rowindex].FindControl("LabelPID");
                    ClassProduct p = new ClassProduct();
                    p.Warranty = int.Parse(TextBoxW.Text);
                    p.Quantity = int.Parse(TextBoxQ.Text);
                    p.Price = int.Parse(TextBoxP.Text);
                    p.Photo = "Images\\" + FU.FileName;
                    p.ProductName = TextBoxPN.Text;
                    p.TypesID = DDLT.SelectedValue.ToString();
                    p.Update(lb.Text);
                }
                
            }
            else
            {
                Label lb2 = (Label)GridViewP.Rows[Rowindex].FindControl("LabelPID");
                ClassProduct p1 = new ClassProduct();
                p1.Warranty = int.Parse(TextBoxW.Text);
                p1.Quantity = int.Parse(TextBoxQ.Text);
                p1.Price = int.Parse(TextBoxP.Text);
                p1.Photo =f;
                p1.ProductName = TextBoxPN.Text;
                p1.TypesID = DDLT.SelectedValue.ToString();
                p1.Update(lb2.Text);
            }

            

        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    public void insert()
    {
        try
        {
            string TypesID;
            DropDownList DDL=(DropDownList)GridViewP.FooterRow.FindControl("DropDownListFooterType");
            TextBox TextBoxTF = (TextBox)GridViewP.FooterRow.FindControl("TextBoxTF");
            if (TextBoxTF.Text == "")
            {
                TypesID =DDL.SelectedValue.ToString();
            }
            else
            {
                if (!ClassTypes.IsExist(TextBoxTF.Text))
                {
                    ClassTypes.Insert(TextBoxTF.Text);
                }
                TypesID = ClassTypes.GetID(TextBoxTF.Text);
            }
            TextBox TextBoxW = (TextBox)GridViewP.FooterRow.FindControl("TextBoxW");         
            TextBox TextBoxQ = (TextBox)GridViewP.FooterRow.FindControl("TextBoxQ");
            TextBox TextBoxP = (TextBox)GridViewP.FooterRow.FindControl("TextBoxP");
            TextBox TextBoxPN = (TextBox)GridViewP.FooterRow.FindControl("TextBoxPN");
            if (ClassProduct.DoesThisProductNameExist(TextBoxPN.Text))
            {
                LabelMSG.Text = "This Product Name Exsit";
                return;
            }

            string strRealPath = Request.PhysicalApplicationPath;
            strRealPath += "Images\\";
            FileUpload FU = (FileUpload)GridViewP.FooterRow.FindControl("FileUploadFooter");
            if (FU.HasFile)
            {
                if (!System.IO.Directory.Exists(strRealPath))
                {
                    LabelMSG.Text = "This Image Does not Exist";
                    return;
                }
                if (System.IO.File.Exists(strRealPath + FU.FileName))
                {
                    LabelMSG.Text = "this image Exist";
                    return;
                }
                else
                {
                    FU.SaveAs(strRealPath + FU.FileName);
                }
            }
            else
            {
                LabelMSG.Text = "you need to browse an image";
                return;
            }
            ClassProduct p = new ClassProduct();
            p.Warranty = int.Parse(TextBoxW.Text);
            p.Price = int.Parse(TextBoxP.Text);
            p.Photo = "Images\\" + FU.FileName;
            p.Quantity = int.Parse(TextBoxQ.Text);
            p.TypesID = TypesID;
            p.ProductName = TextBoxPN.Text;
            p.Insert();
        }
        catch (Exception ex)
        {
            LabelMSG.Text = ex.Message;
        }
    }
    public void FillDDl()
    {
        DropDownListT.DataSource = ClassTypes.GetAll();
        DropDownListT.DataBind();
    }
    protected void ButtonSeach_Click(object sender, EventArgs e)
    {

        string str = "EditProdoctBy2.aspx?ProductName={0}";
        str = string.Format(str,TextBoxSearch.Text);
        Response.Redirect(str);
    }
    
}