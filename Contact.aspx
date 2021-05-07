<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="NegocioOnline.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1> Registro de Clientes</h1>
    <div class="col-xs-12" style="background-color:aliceblue">
        <div class="row">
            <br />
            NIT:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNit" runat="server"></asp:TextBox> 
            <br />
            <br />
        </div>

        <div class="row">
            Nombre:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Dirección:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Teléfono:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Correo:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrar Cliente" class="btn btn-primary btn-lg" OnClick="ButtonRegistrar_Click"/>
            <br />
            <br />
        </div>
    </div>

    <div class="col-xs-12" style="background-color:#FAFAD2"">
        <h3>Listado de Clientes</h3> 
        <asp:GridView ID="GridViewClientes" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
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
        
    <p>
        <asp:Label ID="LabelBuscarCliente" runat="server" Text="Ingrese NIT de Cliente:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtBuscarCliente" runat="server" Width="149px"></asp:TextBox>
        &nbsp;<span style="background-color: #FFFFFF"><asp:Button ID="ButtonBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" OnClick="ButtonBuscar_Click"/>
        </span>
    </p>

    <p>
        <asp:Label ID="LabelModificarNombre" runat="server" Text="Nombre Cliente:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarNombre" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarDireccion" runat="server" Text="Dirección:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarDireccion" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarTelefono" runat="server" Text="Teléfono:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarTelefono" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarCorreo" runat="server" Text="Correo:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarCorreo" runat="server" Width="182px"></asp:TextBox>
    </p>
        <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar" OnClick="ButtonGuardar_Click" />
    <p>
        &nbsp;</p>
        <p>
        <asp:Button ID="ButtonEliminar" runat="server" CssClass="btn btn-danger btn-lg"  Text="Eliminar Dato" OnClick="ButtonEliminar_Click"/>
    </p>
    </div>
</asp:Content>
