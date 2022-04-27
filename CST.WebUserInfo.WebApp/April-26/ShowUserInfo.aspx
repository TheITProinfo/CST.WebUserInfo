<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUserInfo.aspx.cs" Inherits="CST.WebUserInfo.WebApp.April_26.ShowUserInfo" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Css/tableStyle1.css" rel="stylesheet" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <table>

        <thead>
           
            <tr>
                <td>UserID</td>

                <td>UserName</td>
                <td>UserPassword</td>
                <td>UserMobile</td>

                <td>UserEmail</td>
                <td>Status</td>
                <td>CreateDate</td>
            </tr>

            <% =StrHtml%>
            </thead>
                </table>

            

        </div>
    </form>
</body>
</html>
