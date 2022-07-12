﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="orderComplete.aspx.cs" Inherits="DATN.PetShop.User.site.orderComplete.orderComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <%-- <h1 style="text-align:center"><b text-align: center;>CẢM ƠN BẠN ĐÃ ĐẶT HÀNG</b></h1>
    <div><h3>Đơn đặt hàng của bạn đã được đặt và đang được xử lý. Bạn sẽ nhận được một email với thông tin chi tiết về đơn đặt hàng</h3></div>
    <h5 style="text-align:center"><a href="trang-chu"><u style="color:red">Quay lại trang chính</u></a></h5>--%>

    <head>
        <script type="text/javascript">    
            window.history.forward();
            function noBack() {
                window.history.forward();
            }
        </script>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title></title>
        <link href='https://fonts.googleapis.com/css?family=Lato:300,400|Montserrat:700' rel='stylesheet' type='text/css'>
        <style>
            @import url(//cdnjs.cloudflare.com/ajax/libs/normalize/3.0.1/normalize.min.css);
            @import url(//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css);
        </style>
        <link rel="stylesheet" href="https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/default_thank_you.css">
        <script src="https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/jquery-1.9.1.min.js"></script>
        <script src="https://2-22-4-dot-lead-pages.appspot.com/static/lp918/min/html5shiv.js"></script>
    </head>
    <body onload="noBack();" onpageshow="if (event.persisted) noBack();" onunload="">
        <header class="site-header" id="header">
            <h1 class="site-header__title" data-lead-id="site-header-title">THANK YOU!</h1>
        </header>

        <div class="main-content">
            <i class="fa fa-check main-content__checkmark" id="checkmark"></i>
            <p class="main-content__body" data-lead-id="main-content-body">Cảm ơn bạn rất nhiều đã chọn mua sản phẩm tại NTPet!</p>
            <p class="main-content__body" data-lead-id="main-content-body">Đơn đặt hàng của bạn đã được đặt và đang được xử lý. Bạn sẽ nhận được một email với thông tin chi tiết về đơn đặt hàng</p>
            <p class="main-content__body" data-lead-id="main-content-body">Chúc sen và boss thật nhiều sức khỏe! Xin cảm ơn</p>
            <p class="main-content__body" data-lead-id="main-content-body"><a href="trang-chu"><u style="color:red">Quay lại trang chủ</u></a></></p>
        </div>

        <footer class="site-footer" id="footer">
            <p class="site-footer__fineprint" id="fineprint">Pet Shop NTPET. Dịch vụ chăm sóc pet hàng đầu thế giới.</p>
        </footer>
    </body>


</asp:Content>
