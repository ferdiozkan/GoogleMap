using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var q = from p in db.TblKoordinats select p;

        string kod = " <div id='map' style='width: 640px; height: 480px;'></div>";

        kod += "\n\t<script type='text/javascript'>";
        kod += "\n\t\tvar locations = [\n\r";

        string noktalar = "";
        foreach (TblKoordinat item in q.ToList())
        {
            noktalar += "      ['<strong>Buraya Html Metin Yazabilirsiniz.</strong>', " + item.Koordinat.Trim('(').Trim(')') + ", ";
            if ((bool)item.Durum)
            {
                noktalar += "1],\n";
            }
            else
            {
                noktalar += "0],\n";
            }
        }

        kod += noktalar.TrimEnd(',');

        kod += "    ];";
        kod += "";
        kod += "    var map = new google.maps.Map(document.getElementById('map'), {";
        kod += "      zoom: 12,";
        kod += "      center: new google.maps.LatLng(39.78, 30.51),";
        kod += "      mapTypeId: google.maps.MapTypeId.ROADMAP";
        kod += "    });";
        kod += "";
        kod += "    var infowindow = new google.maps.InfoWindow();";
        kod += "    var marker, i;";
        kod += "    for (i = 0; i < locations.length; i++) {  ";
        kod += "      marker = new google.maps.Marker({";
        kod += "        position: new google.maps.LatLng(locations[i][1], locations[i][2]),";
        kod += "        map: map, icon: 'images/' + locations[i][3] + '.png'";
        kod += "      });";
        kod += "";
        kod += "      google.maps.event.addListener(marker, 'click', (function(marker, i) {";
        kod += "        return function() {";
        kod += "          infowindow.setContent(locations[i][0]);";
        kod += "          infowindow.open(map, marker);";
        kod += "        }";
        kod += "      })(marker, i));";
        kod += "    }";
        kod += "   </script>";

        Literal1.Text = kod;
    }
}