<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="description" content="The description of my page" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <a href="<%= Url.Action("Index","Home")%>">Back</a>
    </div>
    </form>
</body>
</html>
