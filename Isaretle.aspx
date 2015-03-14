<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Isaretle.aspx.cs" Inherits="Isaretle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src='http://maps.google.com/maps?file=api&amp;v=2&amp;key=Api Keyinizi Buraya Yazmayı Unutmayın' type='text/javascript'></script>
    <script type=text/javascript>
        function Goster() {
            if (GBrowserIsCompatible()) {
                this.counter = 0;
                var map = new GMap2(document.getElementById('map'));
                map.addControl(new GSmallMapControl());
                map.addControl(new GMapTypeControl());
                map.setCenter(new GLatLng(39.78426800449773, 30.518817901611328), 13);//Harita açılışta hangi noktada ve nekadar yakın mesafede olacak(zoom) 
                GEvent.addListener(map, 'click', function (marker, point) {
                    if (marker) {
                        map.removeOverlay(marker);
                    }
                    else {
                        map.addOverlay(new GMarker(point));
                        document.getElementById('TxtKoordinat').value = point;
                    } 
                });
            }
        }
    </script>
</head>
<body onload="Goster();">
    <form id="form1" runat="server">
            <a href="Default.aspx" >GÖSTER</a>

        <div id="map" style="width: 600px; height: 400px"></div>
        Koordinat :
            <br />
        <asp:TextBox ID="TxtKoordinat" Width="300px" runat="server"></asp:TextBox>
            <br />
            <asp:DropDownList ID="CbmDurum" runat="server">
                <asp:ListItem Value="0">Satılık</asp:ListItem>
                <asp:ListItem Value="1">Kiralık</asp:ListItem>
            </asp:DropDownList>
            <br />
        <asp:Button ID="btnEkle" runat="server" Text="Ekle" onclick="btnEkle_Click" />    
    </form>
</body>
</html>
