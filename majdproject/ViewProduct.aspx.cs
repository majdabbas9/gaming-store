using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            fillDDl();
            DropDownListT.Items.Add("ShowAll");
        }
        LabelMSG.Text="";
    }
    public void fillDDl()
    {
        DropDownListT.DataSource = ClassTypes.GetAll();
        DropDownListT.DataBind();
    }
    public void fillGrid()
    {
        Session["Searched"] = false;
        Session["ShowAll"] =false;
        string TypeName = DropDownListT.SelectedValue.ToString();
        if (TypeName.Equals("ShowAll"))
        {
            fillgrid();
        }
        else
        {
            string strID = ClassTypes.GetID(TypeName);
            GridViewST.DataSource = ClassProduct.GetAllByTypeQuantity(strID);
            GridViewST.DataBind();
        }
    }
    public void fillgrid()
    {
        Session["Searched"] = false;
        Session["ShowAll"] = true;
        GridViewST.DataSource = ClassProduct.GetAllQuantity();
        GridViewST.DataBind();
    }
    protected void ButtonShow_Click(object sender, EventArgs e)
    {
        fillGrid();
    }
    protected void GridViewST_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((Session["LoggedIn"] == null) || ((bool)Session["LoggedIn"]) == false)
        {
            LabelMSG.Text = "You need to login";
        }
        else
        {
            if (e.CommandName.Equals("AddTomycart"))
            {
                if (Session["UserID"] != null)
                {
                    string UserID = Session["UserID"].ToString();
                    string productID = e.CommandArgument.ToString();
                    ClassCart.AddToCart(productID, UserID);
                    Response.Redirect("MyCart.aspx");
                }
                else
                {
                    return;
                }
            }
            if (e.CommandName.Equals("Like"))
            {
                if (Session["UserID"] != null)
                {

                    string UserID = Session["UserID"].ToString();
                    string productID = e.CommandArgument.ToString();
                    if (ClassReViews.DidTheUserReviewed(productID, UserID))
                    {
                        string reviewID = ClassReViews.GiveMeID(productID, UserID);
                        if (ClassReViews.IsLiked(productID, UserID))
                        {
                            return;
                        }
                        ClassReViews.Update(true, reviewID);
                        ClassProduct.UpdateReview(productID, true);
                        if ((Session["Searched"] == null)||(!(bool)Session["Searched"]))
                        {

                            if ((bool)(Session["ShowAll"]))
                            {
                                fillgrid();
                            }
                            else
                            {
                                fillGrid();
                            }
                        }
                        else
                        {
                            
                            FillGridBySearched();
                        }
                    }
                    else
                    {
                        ClassReViews.Insert(true, UserID, productID);
                        ClassProduct.NewReview(productID, true);
                        if ((Session["Searched"] == null) || (!(bool)Session["Searched"]))
                        {

                            if ((bool)(Session["ShowAll"]))
                            {
                                fillgrid();
                            }
                            else
                            {
                                fillGrid();
                            }
                        }
                        else
                        {

                            FillGridBySearched();
                        }
                    }
                }
            }
            if (e.CommandName.Equals("DisLike"))
            {
                if (Session["UserID"] != null)
                {
                    string UserID = Session["UserID"].ToString();
                    string productID = e.CommandArgument.ToString();
                    if (ClassReViews.DidTheUserReviewed(productID, UserID))
                    {
                        string reviewID = ClassReViews.GiveMeID(productID, UserID);
                        if (!ClassReViews.IsLiked(productID, UserID))
                        {
                            return;
                        }
                        ClassReViews.Update(false, reviewID);
                        ClassProduct.UpdateReview(productID, false);
                        if ((Session["Searched"] == null) || (!(bool)Session["Searched"]))
                        {

                            if ((bool)(Session["ShowAll"]))
                            {
                                fillgrid();
                            }
                            else
                            {
                                fillGrid();
                            }
                        }
                        else
                        {

                            FillGridBySearched();
                        }
                    }
                    else
                    {
                        ClassReViews.Insert(false, UserID, productID);
                        ClassProduct.NewReview(productID, false);
                        if ((Session["Searched"] == null) || (!(bool)Session["Searched"]))
                        {

                            if ((bool)(Session["ShowAll"]))
                            {
                                fillgrid();
                            }
                            else
                            {
                                fillGrid();
                            }
                        }
                        else
                        {

                            FillGridBySearched();
                        }
                    }
                }
            }
        }
        if (e.CommandName.Equals("AddReplay"))
        {
            string str = "AddReplay.aspx?ProductID="+e.CommandArgument.ToString();
            Response.Redirect(str);
        }
        if (e.CommandName.Equals("ShowAllReplays"))
        {
            string str = "ShowAllReplays.aspx?ProductID=" + e.CommandArgument.ToString();
            Response.Redirect(str);
        }
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        FillGridBySearched();
    }
    public void FillGridBySearched()
    {
        Session["Searched"] = true;
        GridViewST.DataSource = ClassProduct.GetByProductName(TextBoxSearch.Text);
        GridViewST.DataBind();
    }

}