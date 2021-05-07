<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NegocioOnline._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1> ATMOS</h1>
    </div>

    <div class="row" style="background-color: #FAFAD2">
            <asp:GridView ID="GridViewProductos" runat="server"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewProductos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Existencia" HeaderText="Existencia" />
                    <asp:ImageField DataImageUrlField="Imagen" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText="Imagen producto">
                    <ControlStyle Height="100px" Width="100px"></ControlStyle>
                    </asp:ImageField>
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>

        <p> 
            <asp:Button ID="ButtonComprar" runat="server" CssClass="btn btn-success btn-xl"  Text="Comprar" OnClick="ButtonComprar_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonFacturar" runat="server" CssClass="btn btn-success btn-xl"  Text="Facturar" OnClick="ButtonFacturar_Click"/>
        </p>

    </div>

    <div class ="row" style="background-color: #DFF1CD">
        <p>
            <asp:Label ID="LabelNit" runat="server" Text="NIT:" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNit" runat="server" Visible="False"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonCliente" runat="server" Text="Buscar Cliente" OnClick="ButtonCliente_Click" Visible="False" />
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelNombre" runat="server" Visible="False" ></asp:Label>
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelDireccion" runat="server" Visible="False" ></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelTelefono" runat="server" Visible="False" ></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelCorreo" runat="server" Visible="False" ></asp:Label>
        </p>
        
        <p> 
            <asp:Label ID="LabelCodVenta" runat="server" Text="Código de Venta:" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCodVenta" runat="server" Visible="False"></asp:TextBox>
        </p>

        <p> 
            <asp:Label ID="LabelFechadeVenta" runat="server" Text="Fecha de venta:" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="CalendarFechaVenta" runat="server" Visible="False" OnSelectionChanged="CalendarFechaVenta_SelectionChanged"></asp:Calendar>
        </p>
     
        <p> 
            <asp:Label ID="LabelProductosComprados" runat="server" Text="Productos Comprados:" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridViewCompras" runat="server"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Visible="False">
            <Columns>
                <asp:BoundField DataField="CodProducto" HeaderText="Codigo" />
                <asp:BoundField DataField="DescripcionProducto" HeaderText="Descripcion" />
                <asp:BoundField DataField="CantidadVendida" HeaderText="Cantidad Comprada" />
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
        </p>

        <p> 
            <asp:Label ID="LabelTotal" runat="server" Text="Precio Total:" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTotal" runat="server" Enabled="False" Visible="False"></asp:TextBox>
        </p>

        <p>
            <asp:Button ID="ButtonPagar" runat="server" CssClass="btn btn-success btn-xl"  Text="Pagar" OnClick="ButtonPagar_Click" Visible="False"/>
        </p>
    </div>
</asp:Content>