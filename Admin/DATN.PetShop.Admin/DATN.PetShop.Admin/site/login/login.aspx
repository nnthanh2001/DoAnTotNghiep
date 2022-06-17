<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DATN.PetShop.Admin.site.login.login1" %>
<html lang="en">

    <head>
        <!-- <meta charset="utf-8" />
    <title> | Hyper - Responsive Bootstrap 5 Admin Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta content="A fully featured admin theme which can be used to build CRM, CMS, etc." name="description" />
    <meta content="Coderthemes" name="author" />
    App favicon
    <link rel="shortcut icon" href="assets/images/favicon.ico"> -->
         <base href="/" />
        <meta charset="utf-8" />
        <title>Unikit - Admin & Dashboard Template</title>
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta content="Premium Multipurpose Admin & Dashboard Template" name="description" />
        <meta content="" name="author" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />

        <!-- App favicon -->
        <link rel="shortcut icon" href="assets/images/favicon.ico">



        <!-- App css -->
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/icons.min.css" rel="stylesheet" type="text/css" />
        <link href="assets/css/app.min.css" rel="stylesheet" type="text/css" />

    </head>

    <body id="body" class="auth-page" style="background-image: url('assets/images/p-1.png'); background-size: cover; background-position: center center;">
        <!-- Log In page -->
        <div class="container-md">
            <div class="row vh-100 d-flex justify-content-center">
                <div class="col-12 align-self-center">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4 mx-auto">
                                <div class="card">
                                    <div class="card-body p-0 auth-header-box">
                                        <div class="text-center p-3">
                                            <a href="index.html" class="logo logo-admin">
                                                <img src="../../assets/images/logos/NT.svg" height="100" alt="logo" class="auth-logo">
                                            </a>
                                            <h4 class="mt-3 mb-1 fw-semibold text-white font-18">Chào bạn đến với PET SHOP</h4>
                                            <p class="text-muted  mb-0">Đăng nhập để tiếp tục</p>
                                        </div>
                                    </div>
                                    <div class="card-body pt-0">
                                        <form class="my-4" action="index.html">
                                            <div class="form-group mb-2">
                                                <label class="form-label" for="username">Tên đăng nhập</label>
                                                <input type="text" class="form-control" id="username" name="username" data_value="userName" placeholder="Nhập tên đăng nhập">
                                                <p id="demo"></p>
                                            </div>
                                            <!--end form-group-->

                                            <div class="form-group">
                                                <label class="form-label" for="userpassword">Mật khẩu</label>
                                                <input type="password" class="form-control" name="password" id="userpassword" data_value="password" placeholder="Nhập mật khẩu">
                                            </div>
                                            <!--end form-group-->

                                            <div class="form-group row mt-3">
                                                <div class="col-sm-6">
                                                    <div class="form-check form-switch form-switch-success">
                                                        <input class="form-check-input" type="checkbox" id="customSwitchSuccess">
                                                        <label class="form-check-label" for="customSwitchSuccess">Ghi nhớ tài khoản</label>
                                                    </div>
                                                </div>
                                                <!--end col-->
                                                <div class="col-sm-6 text-end">
                                                    <a href="auth-recover-pw.html" class="text-muted font-13"><i class="dripicons-lock"></i>Quên mật khẩu?</a>
                                                </div>
                                                <!--end col-->
                                            </div>
                                            <!--end form-group-->

                                            <div class="form-group mb-0 row">
                                                <div class="col-12">
                                                    <div class="d-grid mt-3">
                                                        <button type="button" class="btn  btn-primary" jsaction="signIn">Đăng nhập</button>
                                                      
                                                    </div>

                                                </div>
                                                <!--end col-->
                                            </div>
                                            <!--end form-group-->
                                        </form>
                                        <!--end form-->

                                    </div>
                                    <!--end card-body-->
                                </div>
                                <!--end card-->
                            </div>
                            <!--end col-->
                        </div>
                        <!--end row-->
                    </div>
                    <!--end card-body-->
                </div>
                <!--end col-->
            </div>
            <!--end row-->
        </div>
        <!--end container-->

        <!-- App js -->
        <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
        <script src="assets/js/app.js"></script>
        <script src="assets/js/owner/restful/Restful.min.js"></script>
        <script src="assets/js/owner/view/Authentication/signIn/signIn.js"></script>
        <script src="assets/js/owner/view/product/editProduct/editProduct.js"></script>
        <script src="assets/js/owner/view/product/addProduct/addProduct.js"></script>
        <script src="assets/js/owner/wrapper/wrapper.js"></script>

        <%-- <script>
     $(function () {
         event();
     });
     function event() {
         $("#username").off("keyup").on("keyup", function () {
             var value = $(this).val();
             alert(value)
         })
     }
 </script>

        <script>

            function getdata() {
                let x = document.getElementById("username").value;
                let y = document.getElementById("userpassword").value;
                console.log({ x })
                console.log({ y })

            }
            function myFunction() {
                let x = document.getElementById("username").value;
                let y = document.getElementById("userpassword").value;
                if (x.trim() == "") {
                    document.getElementById("username").style.border = "1px solid red"
                } else {
                    document.getElementById("username").style.border = ""
                }
                var regex = "^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
                if (regex.Test(y) == "") {
                    document.getElementById("userpassword").style.border = "1px solid red"

                } else {
                    document.getElementById("userpassword").style.border = ""
                }
            }
        </script>--%>
    </body>

    </html>