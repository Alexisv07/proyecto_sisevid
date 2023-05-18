<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmIndicador.aspx.cs" Inherits="proyecto_sisevid.FrmIndicador" %>

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
        <link rel="stylesheet" href="~/Content/Indicador.css" />
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
                                    <h2><b>Indicadores</b></h2>
                                </div>
                                <div class="col-sm-6">
                                    <a href="#Indi" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Evidencia</span></a>
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
						            <th>Código</th>
						            <th>Nombre</th>
						            <th>Objetivo</th>
						            <th>Alcance</th>
					                <th>Formula</th>
						            <th>Tipo Indi</th>
						            <th>Uni de Medición</th>
						            <th>Meta</th>
						            <th>Id Sentido</th>
						            <th>Id Frecuencia</th>
                                    </tr>
                            </thead>
                            <tbody>
                                <%try
                                        {  %>
                                <% for (int i = 0; i < arregloIndicador.Length; i++)
                                    {%>
                                <tr>
                                    <td style="white-space: nowrap;>
                                        <span class="custom-checkbox">
                                            <input type="checkbox" id="checkbox1" name="options[]" value="1">
                                            <label for="checkbox1"></label>
                                        </span>
                                    </td>
                                    <td><% Response.Write(arregloIndicador [i].Id);  %></td>
						            <td><% Response.Write(arregloIndicador [i].Codigo);  %></td>
						            <td><% Response.Write(arregloIndicador [i].Nombre); %></td>
						            <td><% Response.Write(arregloIndicador [i].Objetivo); %></td>
						            <td><% Response.Write(arregloIndicador [i].Alcance); %></td>
						            <td><% Response.Write(arregloIndicador [i].Formula); %></td>
						            <td><% Response.Write(arregloIndicador [i].Fkidtipoindicador); %></td>
						            <td><% Response.Write(arregloIndicador [i].Fkidunidadmedicion); %></td>
						            <td><% Response.Write(arregloIndicador [i].Meta); %></td>
						            <td><% Response.Write(arregloIndicador [i].Fkidsentido); %></td>
						            <td><% Response.Write(arregloIndicador [i].Fkidfrecuencia); %></td>
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
<div id="Indi" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
				<div class="modal-header">						
					<h4 class="modal-title">Indicadores</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">
                    <div class="form-group">
                        <div class="container">
                          <!-- Nav tabs -->
                          <ul class="nav nav-tabs" role="tablist">
                            <li class="nav-item">
                              <a class="nav-link active" data-toggle="tab" href="#home">Dato Indicador</a>
                            </li>
                            <li class="nav-item">
                              <a class="nav-link" data-toggle="tab" href="#menu1">Roles Por Usuario</a>
                            </li>

                          </ul>

                          <!-- Tab panes -->
                          <div class="tab-content">
                            <div id="home" class="container tab-pane active"><br>
					            <div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-6">
						                    <label>Id</label>
                                            <asp:TextBox ID="txtId" placeholder="Este Campo solo es para consulta" runat="server" class="form-control"></asp:TextBox>
					                     </div>
                                        <div class="col-sm-6">
						                    <label>Código</label>
                                            <asp:TextBox ID="TextCod" runat="server" class="form-control"></asp:TextBox>
					                    </div>
                                    </div>
					            </div>
                                <div class="form-group">
					                <div class="row">
                                        <div class="col-sm-6">
						                    <label>Nombre</label>
                                            <asp:TextBox  ID="txtFechaR" runat="server" class="form-control"></asp:TextBox>
					                    </div>
								        <div class="col-sm-6">
						                    <label>Objetivo</label>
                                            <asp:TextBox  ID="txtObje" runat="server" class="form-control"></asp:TextBox>
					                    </div>
                                    </div>
                                </div>
								<div class="form-group">
					                <div class="row">
                                        <div class="col-sm-6">
						                    <label>Alcance</label>
                                            <asp:TextBox  ID="TextAlc" runat="server" class="form-control"></asp:TextBox>
					                    </div>
								        <div class="col-sm-6">
						                    <label>Formula</label>
                                            <asp:TextBox  ID="TextFormu" runat="server" class="form-control"></asp:TextBox>
					                    </div>
                                     </div>
                                </div>
								<div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-6">
						                    <label>Tipo Indicador</label>
                                            <asp:TextBox  ID="txtTipoIndi" runat="server" class="form-control"></asp:TextBox>
					                    </div>
								        <div class="col-sm-6">
						                    <label>Uni de Medición</label>
                                            <asp:TextBox  ID="txtUndMedi" runat="server" class="form-control"></asp:TextBox>
					                    </div>
                                    </div>
								</div>
								<div class="form-group">
                                    <div class="row">
                                        <div class="col-sm-6">
						                    <label>Id Sentido</label>
                                            <asp:TextBox  ID="TextIdSneti" runat="server" class="form-control"></asp:TextBox>
					                    </div>
								        <div class="col-sm-6">
						                    <label>Id Frecuencia</label>
                                            <asp:TextBox  ID="TextIdFrecu" runat="server" class="form-control"></asp:TextBox>
					                    </div>
                                    </div>
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