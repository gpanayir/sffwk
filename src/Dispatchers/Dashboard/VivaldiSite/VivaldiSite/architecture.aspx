<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
    <style>
  .frm_text_type_1
  {
  	color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif";
  	}
 </style>

    <div class="article_wrap" style="margin: 10px; width: 660px">
        <div class="frm_title frm_title_3" style="margin-top: 30px; width: 500px">
            Software Factory Architecture
        </div>
        <div>
            <span>
                <img class="img_src" src="/img/architexture_01.jpg" alt="" style="float: left; height: 69px;
                    width: 174px; margin-right: 10px" />
            </span>
            <p style="color: #666666; font-weight: bold; font-family: Arial, Helvetica, sans-serif">
                PelSoft adecua la arquitectura de software necesaria para cada situación. Cuenta
                con un marco de trabajo propietario de patrones y buenas prácticas utilizadas en
                muchos proyectos.
            </p>
            <p class="MsoNormal">
                No todos los proyectos de software necesitan ser encarados con el mismo enfoque
                arquitectónico. Pero si todos deben ser orientados con la visión futura de que en
                algún momento podrán ser acoplables, expandirse o integrarse para poder coexistir
                exitosamente con otras soluciones existentes o futuras.<o:p></o:p></p>
            
            <span>
                <img class="img_src" src="/img/fwk01.png" alt="" style="margin-left:250px; float: left; height: 260px;
                    width: 460px; margin-right: 10px" />
            </span>
        </div>
    </div>
    <div class="clear"></div>
    <div class="frm_title frm_title_3" style="margin-top: 30px; width: 500px">
            Arquitectura diferente para cada solución
        </div>
    <div class="clear"></div>
       <div class="article_wrap" style="margin: 10px; margin-right:100px">
        <table class="hor-minimalist-b" style="margin-left: 100px">
            <tr>
                <td  class ="frm_text_type_1">
                   N-Tear
                </td>
                <td>
                    <span>
                        <img class="img_src" src="/img/ntier.gif" alt="" style="margin: 6px; float: left; height: 240px; width: 300px;" />
                    </span>
                </td>
            </tr>
            
          
            <tr>
               <td  class ="frm_text_type_1">
                   Encolamiento con MSMQ WCF-Based</td>
                <td>
                      <span>
                        <img class="img_src" src="/img/msmqarch.png" alt="" style="margin: 6px; float: left; height: 240px; width: 300px;" />
                    </span></td>
            </tr>
          
                <tr>
               <td class ="frm_text_type_1">
                   Restful Crud Operation WCF-based</td>
                <td>
                      <span>
                        <img class="img_src" src="/img/rest2.jpg" alt="" style="margin: 6px; float: left; height: 240px; width: 300px;" />
                    </span></td>
            </tr>

            <tr>
               <td class ="frm_text_type_1">
                   WCF</td>
                <td>
                      <span>
                        <img class="img_src" src="/img/wcf.jpg" alt="" style="margin: 6px; float: left; height: 240px; width: 300px;" />
                    </span></td>
            </tr>
        </table>
    </div>
</asp:Content>
