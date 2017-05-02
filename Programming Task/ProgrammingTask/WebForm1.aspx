<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProgrammingTask.WebForm1" %>

<!DOCTYPE html>

<style type="text/css"> 
    #container {     
        display:table;     
        border-collapse:collapse;   
        height:200px;   
        width:100%; 
    }          
    #layout {     
        display:table-row;    
    }            
    #content {     
        display:table-cell;   
        text-align:center;  
        vertical-align:middle;     
    }            
    #movieText {
     width:500px;
     margin:0px auto;
     text-align:left;
     padding:15px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Programming Task</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="container">
        <div id ="layout">
            <div id ="content">
                 
                <div id ="movieText">
                    Enter the title of a movie you'd like to search for!
                    <br />
                    <br />
                    <asp:textbox ID="TextBoxMovieName" runat="server"></asp:textbox>
                    <br />
                    <br />
                    <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" />
                    <br />
                    <br />
                    <br />
                    <asp:label ID="LabelResponse" runat="server" text=""></asp:label>
                </div>
            </div>
            
        </div>
    </div>
    </form>
</body>
</html>
