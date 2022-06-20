<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="DATN.PetShop.Admin.site.dashboard.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
     <!-- Page Content-->
            <div class="page-content-tab">

                <div class="container-fluid">
                    <!-- Page-Title -->
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="page-title-box">
                                <div class="float-end">
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item"><a href="#">NTPet</a>
                                        </li><!--end nav-item-->
                                        <li class="breadcrumb-item"><a href="#">Thống kê</a>
                                        </li><!--end nav-item-->
                                        <li class="breadcrumb-item active">Doanh thu</li>
                                    </ol>
                                </div>
                                <h4 class="page-title">Thống kê doanh thu</h4>
                            </div><!--end page-title-box-->
                        </div><!--end col-->
                    </div>
                    <!-- end page title end breadcrumb -->
                    <div class="row">
                        
                        <div class="col-lg-4">
                            <div class="card"> 
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col align-self-center">
                                            <div class="media">
                                                <img src="assets/images/logos/money-beg.png" alt="" class="align-self-center" height="40">
                                                <div class="media-body align-self-center ms-3"> 
                                                    <h6 class="m-0 font-24 fw-bold">$1850.00</h6>
                                                    <p class="text-muted mb-0">Tổng doanh thu</p>                                                                                                                                               
                                                </div><!--end media body-->
                                            </div><!--end media-->
                                        </div><!--end col-->  
                                        <div class="col-auto align-self-center">                                              
                                            <div class="">
                                                <div id="Revenu_Status_bar" class="apex-charts mb-n4"></div>
                                            </div>
                                        </div><!--end col-->                                      
                                    </div><!--end row-->                                                                                                                                  
                                </div><!--end card-body-->                                
                            </div><!--end card-->  
                            <div class="row">
                                <div class="col-12 col-lg-6"> 
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row align-items-center">
                                                <div class="col text-center">                                                                        
                                                    <span class="h5  fw-bold">$24,500</span>      
                                                    <h6 class="text-uppercase text-muted mt-2 m-0 font-11">Doanh thu hôm nay</h6>                
                                                </div><!--end col-->
                                            </div> <!-- end row -->
                                        </div><!--end card-body-->
                                    </div> <!--end card-body-->                     
                                </div><!--end col-->
                                <div class="col-12 col-lg-6"> 
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row align-items-center">
                                                <div class="col text-center">                                                                        
                                                    <span class="h5  fw-bold">520</span>      
                                                    <h6 class="text-uppercase text-muted mt-2 m-0 font-11">Đơn hàng hôm nay</h6>                
                                                </div><!--end col-->
                                            </div> <!-- end row -->
                                        </div><!--end card-body-->
                                    </div> <!--end card-body-->                     
                                </div><!--end col-->
                                <div class="col-12 col-lg-6"> 
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row align-items-center">
                                                <div class="col text-center">                                                                        
                                                    <span class="h5  fw-bold">82.8%</span>      
                                                    <h6 class="text-uppercase text-muted mt-2 m-0 font-11">Tỷ lệ bán hàng</h6>                
                                                </div><!--end col-->
                                            </div> <!-- end row -->
                                        </div><!--end card-body-->
                                    </div> <!--end card-body-->                     
                                </div><!--end col-->
                                <div class="col-12 col-lg-6"> 
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row align-items-center">
                                                <div class="col text-center">                                                                        
                                                    <span class="h5  fw-bold">$80.5</span>      
                                                    <h6 class="text-uppercase text-muted mt-2 m-0 font-11">giá trị trung bình</h6>                
                                                </div><!--end col-->
                                            </div> <!-- end row -->
                                        </div><!--end card-body-->
                                    </div> <!--end card-->                     
                                </div><!--end col-->                                
                            </div><!--end row-->  
                            <div class="card"> 
                                <div class="card-header">
                                    <div class="row align-items-center">
                                        <div class="col">                      
                                            <h4 class="card-title">Xem hóa đơn</h4>                      
                                        </div><!--end col-->                                        
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class="card-body">
                                    <div class="row align-items-center">
                                        <div class="col-auto">                      
                                            <i class="las la-file-invoice-dollar font-36 text-muted"></i>                
                                        </div><!--end col-->   
                                        <div class="col">                      
                                            <div class="input-group">
                                                <select class="form-select">
                                                    <option selected>--- Select ---</option>
                                                    <option value="May 2022">Tháng 5, 2022</option>
                                                    
                                                </select>  
                                                <button class="btn btn-soft-primary btn-sm" type="button"><i class="las la-search"></i></button>
                                            </div>                         
                                        </div><!--end col-->                                        
                                    </div>  <!--end row-->                                                                                                                                                         
                                </div><!--end card-body-->                                
                            </div><!--end card-->                             
                        </div><!-- end col-->  
                        <div class="col-lg-8">
                            <div class="card">
                                <div class="card-header">
                                    <div class="row align-items-center">
                                        <div class="col">                      
                                            <h4 class="card-title">Tình trạng doanh thu</h4>                      
                                        </div><!--end col-->
                                        <div class="col-auto"> 
                                            <div class="dropdown">
                                                <a href="#" class="btn btn-sm btn-outline-light dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                   Tháng này<i class="las la-angle-down ms-1"></i>
                                                </a>
                                                <div class="dropdown-menu dropdown-menu-end">
                                                    <a class="dropdown-item" href="#">Hôm nay</a>
                                                    <a class="dropdown-item" href="#">Tuần trước</a>
                                                    <a class="dropdown-item" href="#">Tháng trước</a>
                                                    <a class="dropdown-item" href="#">Năm trước</a>
                                                </div>
                                            </div>               
                                        </div><!--end col-->
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class="card-body">                                     
                                    <div class="">
                                        <div id="Revenu_Status" class="apex-charts"></div>
                                    </div>                                                                                                                          
                                </div><!--end card-body--> 
                            </div><!--end card-->   
                        </div><!-- end col-->                                    
                    </div><!--end row-->
                    <!--end row-->  
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="card">
                                <div class="card-header">
                                    <div class="row align-items-center">
                                        <div class="col">                      
                                            <h4 class="card-title">Thu nhập hằng ngày</h4>                      
                                        </div><!--end col-->                                        
                                    </div>  <!--end row-->                                  
                                </div><!--end card-header-->
                                <div class="card-body">
                                    <div class="table-responsive">
                                        <table class="table mb-0">
                                            <thead class="thead-light">
                                                <tr>
                                                    <th class="border-top-0">Ngày</th>                                                            
                                                    <th class="border-top-0">Tổng hóa đơn</th>
                                                    <th class="border-top-0">Tổng tiền</th>
                                                    <th class="border-top-0">Chi tiêu</th>
                                                    <th class="border-top-0">Thu nhập</th>
                                                </tr><!--end tr-->
                                            </thead>
                                            <tbody>
                                                <tr>                                                        
                                                    <td>Ngày 1 tháng 2</td>                                                            
                                                    <td>50</td>
                                                    <td>600.000</td>
                                                    <td class="text-danger">100.000</td>
                                                    <td>500.000</td>
                                                </tr><!--end tr-->     
                                               
                                                                     
                                            </tbody>
                                        </table> <!--end table-->                                               
                                    </div><!--end /div-->
                                </div><!--end card-body--> 
                            </div><!--end card--> 
                        </div> <!--end col-->   
                                                                      
                    </div><!--end row-->

                </div><!-- container -->

                 <!--Start Rightbar-->
                 <!--Start Rightbar/offcanvas-->
                 <div class="offcanvas offcanvas-end" tabindex="-1" id="Appearance" aria-labelledby="AppearanceLabel">
                     <div class="offcanvas-header border-bottom">
                       <h5 class="m-0 font-14" id="AppearanceLabel">Appearance</h5>
                       <button type="button" class="btn-close text-reset p-0 m-0 align-self-center" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                     </div>
                     <div class="offcanvas-body">  
                         <h6>Account Settings</h6>
                         <div class="p-2 text-start mt-3">
                             <div class="form-check form-switch mb-2">
                                 <input class="form-check-input" type="checkbox" id="settings-switch1">
                                 <label class="form-check-label" for="settings-switch1">Auto updates</label>
                             </div><!--end form-switch-->
                             <div class="form-check form-switch mb-2">
                                 <input class="form-check-input" type="checkbox" id="settings-switch2" checked>
                                 <label class="form-check-label" for="settings-switch2">Location Permission</label>
                             </div><!--end form-switch-->
                             <div class="form-check form-switch">
                                 <input class="form-check-input" type="checkbox" id="settings-switch3">
                                 <label class="form-check-label" for="settings-switch3">Show offline Contacts</label>
                             </div><!--end form-switch-->
                         </div><!--end /div-->
                         <h6>General Settings</h6>
                         <div class="p-2 text-start mt-3">
                             <div class="form-check form-switch mb-2">
                                 <input class="form-check-input" type="checkbox" id="settings-switch4">
                                 <label class="form-check-label" for="settings-switch4">Show me Online</label>
                             </div><!--end form-switch-->
                             <div class="form-check form-switch mb-2">
                                 <input class="form-check-input" type="checkbox" id="settings-switch5" checked>
                                 <label class="form-check-label" for="settings-switch5">Status visible to all</label>
                             </div><!--end form-switch-->
                             <div class="form-check form-switch">
                                 <input class="form-check-input" type="checkbox" id="settings-switch6">
                                 <label class="form-check-label" for="settings-switch6">Notifications Popup</label>
                             </div><!--end form-switch-->
                         </div><!--end /div-->               
                     </div><!--end offcanvas-body-->
                 </div>
                 <!--end Rightbar/offcanvas-->
                 <!--end Rightbar-->
            </div>
            <!-- end page content -->
</asp:Content>
