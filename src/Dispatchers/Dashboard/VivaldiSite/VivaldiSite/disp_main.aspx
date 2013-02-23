<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
 <style>
  .frm_text_type_1
  {
  	color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif";
  	}
 </style>
    <div class="article_wrap" style="margin: 40px; width: 660px">
        <div class="frm_title frm_title_3" style="margin-top: 30px; width: 700px">
            Gestion de entornos y service dispatchers
        </div>
         <span>
                    <img class="img_src" src="/img/webaccess.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
        <div>
            <p class="frm_text_type_1">
                Desde este panel usted tendra acceso a la gestion de todos los despachadores de servicios registrado en este dasboard.
                Para poder realizar las diferentes actividades listadas a continuacion usted debe contar con los permisos necesarios.
                Para mayor informacion sobre comuniquese con el administrador del sitio. 
                Tambien puede hacer una lectura rapida de los permisos que tiene asignado en   Mi Perfil.-
            </p>
            <div class="clear">
            </div>
        </div>
        <br />
        <div>
            <div>
                <span>
                    <img class="img_src" src="/img/new-disp.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
                <p class="frm_title frm_sub_title_2" style="">
                    Registrar nuevo entorno/dispatcher
                </p>
                <p>
                  Esta acción permite crear un nuevo entorno para un despachador de servicio sea Web o Remoting. 
                  El despachador de servicio puede o no estar previamente instalado.
                </p>
                <p>Es recomendable que el despachador de servicio se encuentre instalado y en ejecucion, de modo 
                que pueda sincronizarce su metadata y configuracion con el entorno que esta registrando.
                </p>
            </div>
            <div>
                <span>
                    <img class="img_src" src="/img/login.jpg" alt="" style="float: left; height: 69px;
                        width: 174px; margin-right: 10px" />
                </span>
                <p class="frm_title frm_sub_title_2" style="">
                   <a  href="disp_singin.aspx"> Logging a un entorno existente </a> 
                </p>
                <p>
                    Ingrese a esta opción para gestionar las diferentes configuraciones de un entorno previamente registrado.
                </p>
            </div>
            
        </div>
    </div>

      <div class="article_wrap" style="margin: 10px; width: 660px;color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif">
          
      </div>
</asp:Content>
