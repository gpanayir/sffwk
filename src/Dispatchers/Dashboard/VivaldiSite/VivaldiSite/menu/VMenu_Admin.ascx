﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VMenu_Admin.ascx.cs" Inherits="Vivaldi.Menues.VMenu_Admin" %>
 



<div id="Div1" class ="menuv_header_1" >
 <p>Servicios</p>
</div>


<div id="Div3" class ="menuv_header_2" >
 <p>Entornos</p>
</div>

<div id="menuv" class  ="menuv">
    <ul>
        <li><a class="menuv_a" href="/disp_init.aspx" title="Administrar dispatcher">Administrar dispatcher</a></li>
        <li><a class="menuv_a" href="/sec_main.aspx" title="Seguridad particular">Seguridad</a></li>
    
    </ul>

</div>

<div id="Div4" class ="menuv_header_2" >
 <p>Seguridad global</p>
</div>

<div id="Div2" class  ="menuv">
    <ul>
        <li><a class="menuv_a" href="/global_sec.aspx" title="Sepelio y Sepultura">Sepelio y Sepultura</a>
            <ul>
                <li><a class="menuv_a" href="/Modules/Svc/Sepelio.aspx" title="Necrológico">Necrológico</a></li>
                <li><a class="menuv_a" href="/Modules/Svc/Sepelio.aspx" title="Necrológico">Reglamento</a></li>
            </ul>
        </li>
        <li><a class="menuv_a" href="/Modules/Svc/Cementerio.aspx" title="Cementerio Parque">
            Cementerio Parque</a></li>
        <li><a class="menuv_a" href="/Modules/Svc/Biblioteca.aspx">Biblioteca pública</a></li>
        <li><a class="menuv_a" href="/Modules/Svc/Barrios.aspx">Barrios Health</a></li>
        <li><a class="menuv_a" href="/Modules/Svc/Sepelio.aspx">Ambulancias</a></li>
    </ul>

</div>
