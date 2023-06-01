<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SurveyWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified" style="background-image: url('photos/fd.jpg'); background-position: center center">
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" style="text-align: center; font-weight: 700; color: #0154a2;text-decoration: underline; font-size: x-large;" Text="Welcome To Survey Home Page " ></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Height="40px" style="border-color:aqua" Text="Fill Out Survey" Width="135px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
            
        
        
        <tr>
            <td style="width: 333px; height: 22px;"></td>
            <td style="width: 412px; height: 22px;"></td>
            <td style="height: 22px"></td>
        </tr> 


        <tr>
            <td style="width: 333px; height: 168px;"></td>
            <td style="width: 412px; height: 168px; margin-left: 40px;">
              

                <asp:Button ID="Button2" runat="server" Height="40px" Text="View Survey Results" style="border-color:aqua" Width="143px" OnClick="Button2_Click" />
                

                </td>
 
            <td style="height: 168px"></td>
        </tr>
    </table>
</asp:Content>
