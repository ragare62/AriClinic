using System;
using AriCliModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;

public partial class EstimateLineForm : System.Web.UI.Page 
{
    #region Variables declarations
    AriClinicContext ctx = null;
    User user = null;
    Estimate est = null;
    int estId = 0;
    EstimateLine estl = null;
    int estlId;
    Permission per = null;
    #endregion Variables declarations
    #region Init Load Unload events
    protected void Page_Init(object sender, EventArgs e)
    {
        ctx = new AriClinicContext("AriClinicContext");
        // security control, it must be a user logged
        if (Session["User"] == null)
            Response.Redirect("Default.aspx");
        else
        {
            user = CntAriCli.GetUser((Session["User"] as User).UserId, ctx);
            Process proc = (from p in ctx.Processes
                            where p.Code == "Estimate"
                            select p).FirstOrDefault<Process>();
            per = CntAriCli.GetPermission(user.UserGroup, proc, ctx);
            btnAccept.Visible = per.Modify;
        }
        //
        LoadComboInsurance();
        // 
        if (Request.QueryString["EstimateId"] != null)
        {
            estId = Int32.Parse(Request.QueryString["EstimateId"]);
            est = CntAriCli.GetEstimate(estId, ctx);
            
        }
        // 
        if (Request.QueryString["EstimateLineId"] != null)
        {
            estlId = Int32.Parse(Request.QueryString["EstimateLineId"]);
            estl = CntAriCli.GetEstimateLine(estlId, ctx);
            LoadData(estl);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        // close context to release resources
        if (ctx != null)
            ctx.Dispose();
    }
    #endregion Init Load Unload events
    
    #region Page events (clics)
    protected void btnAccept_Click(object sender, ImageClickEventArgs e)
    {
        if (!CreateChange())
            return;
        //string command = "CloseAndRebind('')";
        string command = "refreshOpener();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string command = "CancelEdit();";
        RadAjaxManager1.ResponseScripts.Add(command);
    }
    #endregion Page events (clics)

    #region Auxiliary functions
    protected bool DataOk()
    {
        return true;
    }
    protected bool CreateChange()
    {
        if (!DataOk())
            return false;
        if (estl == null)
        {
            estl = new EstimateLine();
            UnloadData(estl);
            ctx.Add(estl);
        }
        else
        {
            estl = CntAriCli.GetEstimateLine(estlId, ctx);
            UnloadData(estl);
        }
        ctx.SaveChanges();
        return true;
    }
    protected void LoadData(EstimateLine estl)
    {
        txtEstimateLineId.Text = estl.EstimateLineId.ToString();
        txtDescription.Text = estl.Description;
        txtAmount.Value = (double)estl.Amount;
        txtDiscount.Text = String.Format("{0:0.00}",estl.Discount);
        txtTotal.Value = (double)(estl.Amount - estl.Discount);
        Insurance iSelect = estl.InsuranceService.Insurance;
        InsuranceService iServ = estl.InsuranceService;
        if (iSelect != null)
        {
            rdcbInsurance.SelectedValue = iSelect.InsuranceId.ToString();
        }
        //
        if (iServ != null)
        {
            rdcInsuranceService.Items.Clear();
            rdcInsuranceService.Items.Add(new RadComboBoxItem(iServ.Service.Name, iServ.InsuranceServiceId.ToString()));
            rdcInsuranceService.SelectedValue = iServ.InsuranceServiceId.ToString();
        }
    }
    protected void UnloadData(EstimateLine estl)
    {
        estl.Description = txtDescription.Text;
        estl.Amount = (decimal)txtAmount.Value;
        estl.Discount = decimal.Parse(txtDiscount.Text);
        estl.InsuranceService = CntAriCli.GetInsuranceService(int.Parse(rdcInsuranceService.SelectedValue), ctx);
        if (est != null)
        {
            estl.Estimate = est;
        }
    }
    protected void LoadComboInsurance()
    {
        rdcbInsurance.Items.Clear();
        Insurance iselect = null;
        foreach (Insurance ins in CntAriCli.GetInsurances(ctx))
        {
            rdcbInsurance.Items.Add(new RadComboBoxItem(ins.Name, ins.InsuranceId.ToString()));
            if (ins.Internal) iselect = ins;
        }
        if (iselect != null)
        {
            ImageButton imgb = (ImageButton)this.FindControl("imgInsuranceService");
            imgb.OnClientClick = String.Format("searchInsuranceService({0});", iselect.InsuranceId);
            rdcbInsurance.SelectedValue = iselect.InsuranceId.ToString();
        }
    }
    #endregion Auxiliary functions
    #region Searching outside
    protected void rdcInsuranceService_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        // control insurance box
        if (e.Text == "")
            return;
        //
        
        Insurance ins = CntAriCli.GetInsurance(int.Parse(rdcbInsurance.SelectedValue), ctx);
        RadComboBox combo = (RadComboBox)sender;
        combo.Items.Clear();
        var rs = from x in ins.InsuranceServices
                 where x.Service.Name.Contains(e.Text)
                 select x;
        foreach (InsuranceService inss in rs)
        {
            combo.Items.Add(new RadComboBoxItem(inss.Service.Name, inss.InsuranceServiceId.ToString()));
        }
    }
    #endregion  

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {

    }

    protected void rdcInsuranceService_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (rdcInsuranceService.SelectedValue != "")
        {
            InsuranceService inss = CntAriCli.GetInsuranceService(int.Parse(rdcInsuranceService.SelectedValue), ctx);
            if (inss != null)
            {
                txtAmount.Value = (double)inss.Price;
                txtDiscount.Text = "0";
                txtTotal.Value = (double)inss.Price;
                txtDescription.Text = inss.Service.Name;
            }
        }
    }

    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        //
        string campoDiscount = txtDiscount.Text;
        decimal discount = 0;
        int pos = campoDiscount.IndexOf("%");
        if (pos > 0)
        {
            string resto = campoDiscount.Substring(0, pos);
            decimal porc = 0;
            if (decimal.TryParse(resto, out porc))
            {
                discount = ((decimal)txtAmount.Value * (decimal)porc) / (decimal)100.0;
                txtDiscount.Text = String.Format("{0:0.00}", discount);
                txtTotal.Value = txtAmount.Value - (double)discount;
            }
        }
        else
        {
            if (decimal.TryParse(txtDiscount.Text, out discount))
            {
                // refersh total
                txtTotal.Value = txtAmount.Value - (double)discount;
            }
            else
            {
                lblMessage.Text = "Valor de descuento no válido";
            }
        }
    }


}
