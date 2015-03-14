using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Isaretle : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEkle_Click(object sender, EventArgs e)
    {
        isaretle();
    }

    private void isaretle()
    {
        TblKoordinat nokta = new TblKoordinat();
        nokta.Koordinat = TxtKoordinat.Text;
        if (CbmDurum.SelectedValue == "0")
            nokta.Durum = true;
        else
            nokta.Durum = false;

        db.TblKoordinats.InsertOnSubmit(nokta);
        db.SubmitChanges();
    }
}