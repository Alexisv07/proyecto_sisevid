﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSentido.aspx.cs" Inherits="proyecto_sisevid.FrmSentido" %>

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
        <script src="~/Scripts/MiEstilo.js"></script>
		<link rel="stylesheet" href="~/Content/Sentido.css" />
</head>
<body>
<form id="form1" runat="server">
  <div class="container-xl">
	<div class="table-responsive">
		<div class="table-wrapper">
			<div class="table-title">
				<div class="row">
					<div class="col-sm-6">
						<h2><b>Gestor de Sentido</b></h2>
					</div>
					<div class="col-sm-6">
						<a href="#addEmployeeModal" class="btn btn-success" data-toggle="modal"><i class="material-icons">&#xE147;</i> <span>Agregar Sentido</span></a>
						<a href="#deleteEmployeeModal" class="btn btn-danger" data-toggle="modal"><i class="material-icons">&#xE15C;</i> <span>Delete</span></a>						
					</div>
				</div>
			</div>
			<table class="table table-striped table-hover">
				<thead>
					<tr>
						<th>
							<span class="custom-checkbox">
								<input type="checkbox" id="selectAll">
								<label for="selectAll"></label>
							</span>
						</th>
						<th>Id</th>
						<th></th>
						<th>Nombre</th>
						<th></th>
						<th>Actions</th>
					</tr>
				</thead>
				<tbody>
                    <% for(int i = 0; i <  arregloSentido.Length; i++ ){%>
                        <tr>
						<td>
							<span class="custom-checkbox">
								<input type="checkbox" id="checkbox1" name="options[]" value="1">
								<label for="checkbox1"></label>
							</span>
                        </td>
                        <td><% Response.Write(arregloSentido[i].Id); %></td>
                         <td></td>
                        <td><% Response.Write(arregloSentido[i].Nom); %></td>
                         <td></td>
                        <td>
							<a href="#editEmployeeModal" class="edit" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Edit">&#xE254;</i></a>
							<a href="#deleteEmployeeModal" class="delete" data-toggle="modal"><i class="material-icons" data-toggle="tooltip" title="Delete">&#xE872;</i></a>
						</td>
					</tr>
                     <%} %>
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
<!-- Edit Modal HTML -->
  <div id="addEmployeeModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">
			<form>
				<div class="modal-header">						
					<h4 class="modal-title">Sentido</h4>
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
				</div>
				<div class="modal-body">					
					<div class="form-group">
						<label>Id</label>
                        <asp:TextBox ID="txtId" runat="server" class="form-control"></asp:TextBox>
                      <!--Enabled="false" sirve para bloquear un cuadro de texto-->
					</div>
					<div class="form-group">
						<label>Nombre</label>
                        <asp:TextBox ID="txtNom" runat="server" class="form-control" ></asp:TextBox>
					</div>
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
					<asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Page_Load" OnCommand="btnGuardar" class="btn btn-outline-success"/>
					<asp:Button ID="Button2" runat="server" Text="Modificar" OnClick="Page_Load" OnCommand="btnModificar" class="btn btn-outline-warning"/>
					<asp:Button ID="Button3" runat="server" Text="Consultar" OnClick="Page_Load" OnCommand="btnConsultar" class="btn btn-outline-primary"/>
					<asp:Button ID="Button4" runat="server" Text="Borrar" OnClick="Page_Load" OnCommand="btnBorrar" class="btn btn-outline-danger"/>
				</div>
			</form>
		</div>
	</div>
</div>
<!-- Edit Modal HTML -->
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
						<label>Id</label>
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                      <!--Enabled="false" sirve para bloquear un cuadro de texto-->
					</div>
					<div class="form-group">
						<label>Nombre</label>
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" ></asp:TextBox>
					</div>
				</div>
				<div class="modal-footer">
					<input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
					<input type="submit" class="btn btn-info" value="Save">
                    
				</div>
			</form>
		</div>
	</div>
</div>
<!-- Delete Modal HTML -->
  <div id="deleteEmployeeModal" class="modal fade">
	<div class="modal-dialog">
		<div class="modal-content">

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
			
		</div>
	</div>
</div>
    </form>
</body>
</html>

