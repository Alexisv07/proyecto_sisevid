<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmEvidencia.aspx.cs" Inherits="proyecto_sisevid.FrmEvidencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round"/>
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"/>
        <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="~/Content/Evidencia.css" />
        <script src="~/Scripts/MiEstilo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
            <div class="container-xl">
                <div class="table-responsive">
                    <div class="table-wrapper">
                        <div class="table-title">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h2><b>Evidencias</b></h2>
                                </div>
                                <div class="col-sm-6">
                                    <a href="#Evidencia" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Evidencia</span></a>
                                    <a href="#deleteEmployeeModal" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Delete</span></a>
                                </div>
                            </div>
                        </div>
                        <table class="table table-striped table-hover" >
                            <thead>
                                <tr>
                                    <th>
                                        <span class="custom-checkbox">
                                            <input type="checkbox" id="selectAll">
                                            <label for="selectAll"></label>
                                        </span>
                                    </th>
                                    <th>Id</th>
						            <th>FechaRegristro</th>
						            <th>FechaCreacion</th>
						            <th>descripcion</th>
						            <th>NombreArchivo</th>
					                <th>LinkArchivo</th>
						            <th>Observacion</th>
						            <th>tipoEidencia</th>
						            <th>Articulo</th>
						            <th>literal</th>
						            <th>numeral</th>
						            <th>Subnumeral</th>
						            <th>Sub_Subnumeral</th>
                                    </tr>
                            </thead>
                            <tbody>
                                <%try
                                        {  %>
                                <% for (int i = 0; i < arregloEvidencia.Length; i++)
                                    {%>
                                <tr>
                                    <td style="white-space: nowrap;>
                                        <span class="custom-checkbox">
                                            <input type="checkbox" id="checkbox1" name="options[]" value="1">
                                            <label for="checkbox1"></label>
                                        </span>
                                    </td>
                                    <td><% Response.Write(arregloEvidencia [i].id);  %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fecharegistro);  %></td>
						            <td><% Response.Write(arregloEvidencia [i].FechaCreacion); %></td>
						            <td><% Response.Write(arregloEvidencia [i].descripcion); %></td>
						            <td><% Response.Write(arregloEvidencia [i].NomArchivo); %></td>
						            <td><% Response.Write(arregloEvidencia [i].LinkArchivo); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Observacion); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fkidtipoevidencia); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fkidarticulo); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fkidliteral); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fkidnumeral); %></td>
						            <td><% Response.Write(arregloEvidencia [i].Fkidsubnumeral); %></td>
						            <td style="white-space: nowrap;><% Response.Write(arregloEvidencia [i].Fkidsub_subnumeral); %></td>
                                    <td>
                                        <a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
                                        <a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
                                    </td>
                                </tr>
                                <%} %>
                                <%}
						            catch (Exception exp)
						            {
						            }
					            %>
                            </tbody>
                        </table>
                        <div class="clearfix">
                            <div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
                            <ul class="pagination">
                                <li class="page-item disabled"><a href="#">Previous</a></li>
                                <li class="page-item"><a href="#" class="page-link">1</a></li>
                                <li class="page-item"><a href="#" class="page-link">2</a></li>
                                <li class="page-item active"><a href="#" class="page-link">3</a></li>
                                <li class="page-item"><a href="#" class="page-link">4</a></li>
                                <li class="page-item"><a href="#" class="page-link">5</a></li>
                                <li class="page-item"><a href="#" class="page-link">Next</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
<!-- Crud Modal HTML -->
<div id="Evidencia" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
				<div class="modal-header">						
					<h4 class="modal-title">Usuarios</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">
                    <div class="form-group">
                        <div class="container">
                          <!-- Nav tabs -->
                          <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                              <a class="nav-link active" data-toggle="tab" href="#home">Datos Usuario</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" data-toggle="tab" href="#menu1">Roles Por Usuario</a>
                            </li>

                          </ul>

                          <!-- Tab panes -->
                          <div class="tab-content">
                            <div id="home" class="container tab-pane active"><br>
					            <div class="form-group">
						            <label>Id</label>
                                    <asp:TextBox ID="txtId" placeholder="Este Campo solo es para consulta" runat="server" class="form-control"></asp:TextBox>
					            </div>
                                <div class="form-group">
					            <div class="row">
                                    <div class="col-sm-6">
						            <label>FechaRegristro</label>
                                    <asp:TextBox  ID="txtFechaR" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="col-sm-6">
						            <label>FechaCreacion</label>
                                    <asp:TextBox  ID="txtFechaC" runat="server" class="form-control"></asp:TextBox>
					            </div>
                                </div>
                                </div>
								<div class="form-group">
						            <label>Descripcion</label>
                                    <asp:TextBox  ID="txtDescripcion" runat="server" class="form-control"></asp:TextBox>
					            </div><br />
								<div class="form-group">
						            
                                    <asp:TextBox  ID="txtArchi" runat="server" class="form-control" placeholder="Cargar Archivo"></asp:TextBox>
                                    <asp:FileUpload ID="FileUpload1" runat="server" class="btn btn-outline-secondary; form-control" type="button" />
                                    <br /> <br />
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="btnSubir_Click" />
					            </div>
								<div class="form-group">
						            <label>LinkArchivo</label>
                                    <asp:TextBox  ID="txtlinkA" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>Observacion</label>
                                    <asp:TextBox  ID="txtObservacion" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>TipoEvidencia</label>
                                    <asp:TextBox  ID="txtTipoE" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>Articulo</label>
                                    <asp:TextBox  ID="txtArticulo" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>Literal</label>
                                    <asp:TextBox  ID="txtliteral" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>Numeral</label>
                                    <asp:TextBox  ID="txtNumeral" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>Subnumeral</label>
                                    <asp:TextBox  ID="txtSubnumeral" runat="server" class="form-control"></asp:TextBox>
					            </div>
								<div class="form-group">
						            <label>sub_subnumeral</label>
                                    <asp:TextBox  ID="txtsub_subn" runat="server" class="form-control"></asp:TextBox>
					            </div>
                                <div class="form-group">

                                </div>

                            </div>
                            <div id="menu1" class="container tab-pane fade"><br>

                                  <div class="form-group">
                                    <label for="exampleFormControlSelect1">Roles</label>
                                      <asp:DropDownList ID="DropDownList1" runat="server" class="form-control"></asp:DropDownList>
                                  </div>
                                  <div class="form-group">
                                    <label for="exampleFormControlSelect2">Roles del Usuario</label>
                                      <asp:ListBox ID="ListBox1" runat="server" multiple class="form-control"></asp:ListBox>
                                  </div>
                                <div class="form-group">

                                </div>
                            </div>
                          </div>
                        </div>
                    </div>
			
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel"/>

				</div>

		</div>
	</div>
</div>
            <!-- Edit Modal HTML
<div id="editEmployeeModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
			<form>
				<div class="modal-header">						
					<h4 class="modal-title">Edit Employee</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">					
					<div class="form-group">
						<label>Name</label>
						<input type="text" class="form-control" required>
					</div>
					<div class="form-group">
						<label>Email</label>
						<input type="email" class="form-control" required>
					</div>
					<div class="form-group">
						<label>Address</label>
						<textarea class="form-control" required></textarea>
					</div>
					<div class="form-group">
						<label>Phone</label>
						<input type="text" class="form-control" required>
					</div>					
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
					<input type="submit" class="btn btn-info" value="Save">
				</div>
			</form>
		</div>
	</div>
</div>-->
            <!-- Delete Modal HTML -->
            <div id="deleteEmployeeModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <form>
                            <div class="modal-header">
                                <h4 class="modal-title">Delete Employee</h4>
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body">
                                <p>Are you sure you want to delete these Records?</p>
                                <p class="text-warning"><small>This action cannot be undone.</small></p>
                            </div>
                            <div class="modal-footer">
                                <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                                <input type="submit" class="btn btn-danger" value="Delete">
                            </div>
                        </form>
                    </div>
                </div>
            </div>
    </form>

</body>
</html>

