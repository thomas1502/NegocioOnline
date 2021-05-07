<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="NegocioOnline.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Control de Ventas </h1>
    <p> 
            <asp:Label ID="LabelVentas" runat="server" Text="Ventas Realizadas:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:GridView ID="GridViewVentas" runat="server"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridViewVentas_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
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
        <asp:Label ID="LabelProductos" runat="server" Text="Listado de Productos Comprados:"></asp:Label>
        <asp:GridView ID="GridViewProductos" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </p>

    <p>
    <asp:Label ID="LabelBuscarEstado" runat="server" Text="Ingresar Código de Compra:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtBuscarEstado" runat="server" Width="149px"></asp:TextBox>
        &nbsp;<span style="background-color: #FFFFFF"><asp:Button ID="ButtonBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" OnClick="ButtonBuscar_Click"/>
        </span>
    </p>

    <p>
        <asp:Label ID="LabelModificarEstado" runat="server" Text="Estado de Compra:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarEstado" runat="server" Width="182px"></asp:TextBox>
    </p>

    <p>
        <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar" OnClick="ButtonGuardar_Click"/>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
