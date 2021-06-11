﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="Dideco.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        .img {
            background-image: url("https://s3-us-west-2.amazonaws.com/s.cdpn.io/210284/four.gif");
            background-size: cover;
            background-position: center;
            position: absolute;
            top: 0px;
            right: 0px;
            bottom: 0px;
            left: 0px;
        }

        #fourohfour {
            width: 100%;
            height: 100%;
            color: white;
            position: absolute;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
        }

            #fourohfour .text {
                background-image: radial-gradient(50% 50%, ellipse closest-corner, rgba(0, 0, 0, 0) 1%, #000000 100%);
                width: 100%;
                height: 100%;
                text-align: center;
                position: absolute;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
            }

                #fourohfour .text h1 {
                    font-size: 30px;
                    padding-top: 230px;
                    
                    background-repeat: no-repeat;
                    background-position: center 120px;
                }
    </style>
    <title>Municipalidad de Puchuncaví</title>
</head>
<body>
    <form id="form1" runat="server">
        <section id="fourohfour">
            <div class='img'></div>
            <div class='text'>
                <h1>Tuvimos un problema. Por favor contacta al administrador</h1>
            </div>
        </section>
    </form>
</body>
</html>
