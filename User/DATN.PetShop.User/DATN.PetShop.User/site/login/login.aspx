<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DATN.PetShop.User.site.login.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="page-content-tab" id="main" runat="server">

        <div class="breadcrumb-area pt-95 pb-95 bg-img" style="background-image: url(assets/img/banner/banner-2.jpg);">
            <div class="container">
                <div class="breadcrumb-content text-center">
                    <h2>Đăng nhập / Đăng ký</h2>
                    <ul>
                        <li><a href="site/home/home.aspx">Trang chủ</a></li>
                        <li class="active">Đăng nhập / Đăng ký</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="login-register-area pt-95 pb-100">
            <div class="container">
                <div class="row">
                    <div class="col-lg-7 col-md-12 ml-auto mr-auto">
                        <div class="login-register-wrapper">
                            <div class="login-register-tab-list nav">
                                <a class="active" data-toggle="tab" href="#lg1">
                                    <h4>Đăng nhập </h4>
                                </a>
                                <a data-toggle="tab" href="#lg2">
                                    <h4>Đăng ký </h4>
                                </a>
                            </div>
                            <div class="tab-content">
                                <div id="lg1" class="tab-pane active">
                                    <div class="login-form-container">
                                        <div class="login-register-form">
                                            <form action="#" method="post">
                                                <input type="text" data_value="userName" placeholder="Email / Số điện thoại">
                                                <input type="password" data_value="password" placeholder="Mật khẩu">
                                                <div class="button-box">
                                                    <div class="login-toggle-btn">
                                                        <input type="checkbox">
                                                        <label>Nhớ mật khẩu</label>
                                                        <a href="#">Quên mật khẩu?</a>
                                                    </div>
                                                    <button type="button" jsaction="signIn" value ="_id">Đăng nhập</button>

                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                <div id="lg2" class="tab-pane">
                                    <div class="login-form-container">
                                        <div class="login-register-form">
                                            <form action="#" method="post">
                                                <input type="text" data_value="userNameRegister" placeholder="Tên người dùng">
                                                <input type="email" data_value="email" placeholder="Email">
                                                <input type="password" data_value="passwordRegister" placeholder="Mật khẩu">
                                                <input type="number" data_value="phone" placeholder="Số điện thoại">
                                                <input type="text" data_value="address" placeholder="Địa chỉ">

                                                <div class="button-box">
                                                    <button type="button" jsaction="register"><span>Đăng ký</span></button>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
