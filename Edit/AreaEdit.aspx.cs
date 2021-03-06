﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using rapidInfoModel;

public partial class Edit_AreaEdit : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ID = Cmn.ToInt(Request.QueryString["id"]);
        ShowData(ID);
    }

    void ShowData(int id)
    {
        rapidInfoModel.Area a = rapidInfoModel.Area.GetData(id);

        if (a != null)
        {
            lblId.Text = a.Id.ToString();
            txtName.Text = a.Name;

            if (a.ParentId != null && a.ParentId != 0)
            {
                txtParentId.Value = a.ParentId.ToString();
                rapidInfoModel.Area parent = rapidInfoModel.Area.GetData(Cmn.ToInt(a.ParentId));

                txtParentName.Text = parent.Name;
            }
        }

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        rapidInfoModel.Area a = rapidInfoModel.Area.GetData(Cmn.ToInt(lblId.Text));
        if (a == null)
            a = new rapidInfoModel.Area();

        a.Name = txtName.Text;
        a.ParentId = Cmn.ToInt(txtParentId.Value);
        a.Save();

        WriteClientScript("parent.GetAreas();");
    }


}