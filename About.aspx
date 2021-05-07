<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NegocioOnline.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %>Registro de productos</h1>

    <div class="col-xs-12" style="background-color:aliceblue">
        <div class="row">
            <br />
            Código Producto:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox> 
            <br />
            <br />
        </div>

        <div class="row">
            Nombre Producto:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Descripción:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Marca:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="cmbMarca" runat="server">
                <asp:ListItem>Nike</asp:ListItem>
                <asp:ListItem>Adidas</asp:ListItem>
                <asp:ListItem>New Balance</asp:ListItem>
                <asp:ListItem>Balenciaga</asp:ListItem>
                <asp:ListItem>Skechers</asp:ListItem>
                <asp:ListItem>Crocs</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
        </div>

        <div class="row">
            Precio:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Existencia:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtExistencia" runat="server"></asp:TextBox>
            <br />
            <br />
        </div>

        <div class="row">
            Selecciona una imagen:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:FileUpload ID="FileUploadImagen" runat="server" />
            <asp:Label ID="LabelEstado" runat="server"></asp:Label>
            <br />
            <br />
        </div>

        <div class="row">
            <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrar producto" class="btn btn-primary btn-lg" OnClick="ButtonRegistrar_Click"/>
            <br />
            <br />
        </div>
    </div>

    <div class="col-xs-12" style="background-color:#FAFAD2"">
        <h3>Listado de Productos</h3> 
        <asp:GridView ID="GridViewProductos" runat="server"  BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Existencia" HeaderText="Existencia" />
                <asp:ImageField DataImageUrlField="Imagen" ControlStyle-Width="100" ControlStyle-Height = "100" HeaderText="Imagen">
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
        <asp:Label ID="LabelBuscarProducto" runat="server" Text="Ingresar Código de Producto:"></asp:Label>
        &nbsp;<asp:TextBox ID="txtBuscarProducto" runat="server" Width="149px"></asp:TextBox>
        &nbsp;<span style="background-color: #FFFFFF"><asp:Button ID="ButtonBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" OnClick="ButtonBuscar_Click"/>
        </span>
    </p>

    <p>
        <asp:Label ID="LabelModificarNombre" runat="server" Text="Nombre Producto:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarNombre" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarDescripcion" runat="server" Text="Descripción Producto:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarDescripcion" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarPrecio" runat="server" Text="Precio Producto:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarPrecio" runat="server" Width="182px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="LabelModificarExistencia" runat="server" Text="Existencia Producto:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtModificarExistencia" runat="server" Width="182px"></asp:TextBox>
    </p>
        <asp:Button ID="ButtonGuardar" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar" OnClick="ButtonGuardar_Click"/>
    <p>
        &nbsp;</p>
        <p>
        <asp:Button ID="ButtonEliminar" runat="server" CssClass="btn btn-danger btn-lg"  Text="Eliminar Dato" OnClick="ButtonEliminar_Click"/>
    </p>
    </div>

</asp:Content>
