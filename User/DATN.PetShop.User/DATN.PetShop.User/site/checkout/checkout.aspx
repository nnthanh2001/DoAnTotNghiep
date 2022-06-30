<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="DATN.PetShop.User.site.checkout.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph" runat="server">
    <div class="breadcrumb-area pt-95 pb-95 bg-img" style="background-image: url(assets/img/banner/banner-2.jpg);">
        <div class="container">
            <div class="breadcrumb-content text-center">
                <h2>Checkout</h2>
                <ul>
                    <li><a href="site/home/home.aspx.cs">Trang chủ</a></li>
                    <li class="active">Thanh toán</li>
                </ul>
            </div>
        </div>
    </div>
    <!-- shopping-cart-area start -->
    <div class="checkout-area pt-95 pb-70">
        <div class="container">
            <h3 class="page-title">Kiểm tra thông tin thanh toán</h3>
            <div class="row">
                <div class="col-lg-7">
                    <div class="checkout-wrapper">
                        <div id="faq" class="panel-group">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>1</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-1">Chọn phương thức thanh toán</a></h5>
                                </div>
                                <div id="payment-1" class="panel-collapse collapse show">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-lg-6 col-md-12">
                                                <div class="checkout-register">
                                                    <h5 class="checkout-sub-title">Thanh toán online</h5>
                                                    <p></p>
                                                    <form>
                                                        <label>Email Address </label>
                                                        <input type="email" name="email">
                                                        <button class="checkout-btn" type="submit">Xác nhận thanh toán</button>
                                                    </form>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-md-12">
                                                <div class="checkout-login">
                                                    <h5 class="checkout-sub-title">Thanh toán sau khi nhận hàng</h5>
                                                    <form>
                                                        <div class="login-form">
                                                            <label>Email Address </label>
                                                            <input type="email" name="email">
                                                        </div>
                                                        <div class="login-form">
                                                            <label>Password </label>
                                                            <input type="email" name="email">
                                                        </div>
                                                    </form>
                                                    <div class="login-forget">
                                                        <button class="checkout-btn" type="submit">Login</button>
                                                        <a href="#">Forgot your password?</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>2</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-2">billing information</a></h5>
                                </div>
                                <div id="payment-2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="billing-information-wrapper">
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>First Name</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Last Name</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Company</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Email Address</label>
                                                        <input type="email">
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 col-md-12">
                                                    <div class="billing-info">
                                                        <label>Address</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>city</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>State/Province</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Zip/Postal Code</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-select card-mrg">
                                                        <label>Country</label>
                                                        <select>
                                                            <option value="1">United State</option>
                                                            <option value="2">Azerbaijan</option>
                                                            <option value="3">Bahamas</option>
                                                            <option value="4">Bahrain</option>
                                                            <option value="5">Bangladesh</option>
                                                            <option value="6">Barbados</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Telephone</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                                <div class="col-lg-6 col-md-6">
                                                    <div class="billing-info">
                                                        <label>Fax</label>
                                                        <input type="text">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="ship-wrapper">
                                                <div class="single-ship">
                                                    <input type="radio" name="address" value="address" checked="">
                                                    <label>Ship to this address</label>
                                                </div>
                                                <div class="single-ship">
                                                    <input type="radio" name="address" value="dadress">
                                                    <label>Ship to different address</label>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="#"><i class="ti-arrow-up"></i>back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit">Get a Quote</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>3</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-3">shipping information</a></h5>
                                </div>
                                <div id="payment-3" class="panel-collapse collapse ">
                                    <div class="panel-body">
                                        <div class="shipping-information-wrapper">
                                            <div class="shipping-info-2">
                                                <span>Address will go here. </span>
                                                <span>T: 012 345 678 </span>
                                            </div>
                                            <div class="edit-address">
                                                <a href="#">Edit Address</a>
                                            </div>
                                            <div class="billing-select">
                                                <select class="email s-email s-wid">
                                                    <option>Select Your Address</option>
                                                    <option>Add New Address</option>
                                                    <option>Boot Experts, Bangladesh</option>
                                                </select>
                                            </div>
                                            <div class="ship-wrapper">
                                                <div class="single-ship">
                                                    <input type="checkbox" checked="" value="address" name="address">
                                                    <label>Use Billing Address</label>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="#"><i class="ti-arrow-up"></i>back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit">Continue</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>4</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-4">Shipping method</a></h5>
                                </div>
                                <div id="payment-4" class="panel-collapse collapse ">
                                    <div class="panel-body">
                                        <div class="shipping-method-wrapper">
                                            <div class="shipping-method">
                                                <p>Flat Rate</p>
                                                <p>Fixed $40.00</p>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="#"><i class="ti-arrow-up"></i>back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit">Continue</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>5</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-5">payment information</a></h5>
                                </div>
                                <div id="payment-5" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="payment-info-wrapper">
                                            <div class="ship-wrapper">
                                                <div class="single-ship">
                                                    <input type="radio" checked="" value="address" name="address">
                                                    <label>Check / Money order </label>
                                                </div>
                                                <div class="single-ship">
                                                    <input type="radio" value="dadress" name="address">
                                                    <label>Credit Card (saved) </label>
                                                </div>
                                            </div>
                                            <div class="payment-info">
                                                <div class="row">
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="billing-info">
                                                            <label>Name on Card </label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6 col-md-6">
                                                        <div class="billing-select card-mrg">
                                                            <label>Credit Card Type</label>
                                                            <select>
                                                                <option>American Express</option>
                                                                <option>Visa</option>
                                                                <option>MasterCard</option>
                                                                <option>Discover</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-info">
                                                            <label>Credit Card Number </label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="expiration-date">
                                                    <label>Expiration Date </label>
                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6">
                                                            <div class="billing-select month-mrg">
                                                                <select>
                                                                    <option>Month</option>
                                                                    <option>January</option>
                                                                    <option>February</option>
                                                                    <option>March</option>
                                                                    <option>April</option>
                                                                    <option>May</option>
                                                                    <option>June</option>
                                                                    <option>July</option>
                                                                    <option>August</option>
                                                                    <option>September</option>
                                                                    <option>October</option>
                                                                    <option>November</option>
                                                                    <option>December</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6">
                                                            <div class="billing-select">
                                                                <select>
                                                                    <option>Year</option>
                                                                    <option>2015</option>
                                                                    <option>2016</option>
                                                                    <option>2017</option>
                                                                    <option>2018</option>
                                                                    <option>2019</option>
                                                                    <option>2020</option>
                                                                    <option>2021</option>
                                                                    <option>2022</option>
                                                                    <option>2023</option>
                                                                    <option>2024</option>
                                                                    <option>2025</option>
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-info">
                                                            <label>Card Verification Number</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="#"><i class="ti-arrow-up"></i>back</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit">Continue</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h5 class="panel-title"><span>6</span> <a data-toggle="collapse" data-parent="#faq" href="#payment-6">Order Review</a></h5>
                                </div>
                                <div id="payment-6" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="order-review-wrapper">
                                            <div class="order-review">
                                                <div class="table-responsive">
                                                    <table class="table">
                                                        <thead>
                                                            <tr>
                                                                <th class="width-1">Product Name</th>
                                                                <th class="width-2">Price</th>
                                                                <th class="width-3">Qty</th>
                                                                <th class="width-4">Subtotal</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <div class="o-pro-dec">
                                                                        <p>Fusce aliquam</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-price">
                                                                        <p>$236.00</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-qty">
                                                                        <p>2</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-subtotal">
                                                                        <p>$236.00</p>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="o-pro-dec">
                                                                        <p>Primis in faucibus</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-price">
                                                                        <p>$265.00</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-qty">
                                                                        <p>3</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-subtotal">
                                                                        <p>$265.00</p>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="o-pro-dec">
                                                                        <p>Etiam gravida</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-price">
                                                                        <p>$363.00</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-qty">
                                                                        <p>2</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-subtotal">
                                                                        <p>$363.00</p>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="o-pro-dec">
                                                                        <p>Quisque in arcu</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-price">
                                                                        <p>$328.00</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-qty">
                                                                        <p>2</p>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="o-pro-subtotal">
                                                                        <p>$328.00</p>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <td colspan="3">Subtotal </td>
                                                                <td colspan="1">$4,001.00</td>
                                                            </tr>
                                                            <tr class="tr-f">
                                                                <td colspan="3">Shipping & Handling (Flat Rate - Fixed</td>
                                                                <td colspan="1">$45.00</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">Grand Total</td>
                                                                <td colspan="1">$4,722.00</td>
                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                </div>
                                                <div class="billing-back-btn">
                                                    <span>Forgot an Item?
                                                           
                                                        <a href="#">Edit Your Cart.</a>

                                                    </span>
                                                    <div class="billing-btn">
                                                        <button type="submit">Continue</button>
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
                <div class="col-lg-5">
                    <div class="payment-info-wrapper">
                                            <div class="ship-wrapper">
                                                <div class="single-ship">
                                                    <input type="radio" checked="" value="address" name="address">
                                                    <label>Thanh toán online </label>
                                                </div>
                                                <div class="single-ship">
                                                    <input type="radio" value="dadress" name="address">
                                                    <label>Thanh toán sau khi nhận hàng </label>
                                                </div>
                                            </div>
                                            <div class="payment-info">
                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Họ và tên (Full name)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Email (Email address)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Địa chỉ giao hàng (Address) </label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-12 col-md-12">
                                                        <div class="billing-select card-mrg">
                                                            <label>Số điện thoại (Phone number)</label>
                                                            <input type="text">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="billing-back-btn">
                                                <div class="billing-back">
                                                    <a href="site/checkout/checkout.aspx"><i class="ti-arrow-up"></i>Quay lại trang trước</a>
                                                </div>
                                                <div class="billing-btn">
                                                    <button type="submit" href="thanh-toan">Tiếp tục</button>
                                                </div>
                                            </div>
                                        </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<%--<div class="col-inner has-border">
<div class="checkout-sidebar sm-touch-scroll">
<h3 id="order_review_heading">Đơn hàng của bạn</h3>
<div id="order_review" class="woocommerce-checkout-review-order">
<table class="shop_table woocommerce-checkout-review-order-table">
	<thead>
		<tr>
			<th class="product-name">Sản phẩm</th>
			<th class="product-total">Tạm tính</th>
		</tr>
	</thead>
	<tbody>
						<tr class="cart_item">
					<td class="product-name">
						Đồ chơi cho chó kêu chút chít PAW hình bánh Hamburger&nbsp;						 <strong class="product-quantity">×&nbsp;1</strong>											</td>
					<td class="product-total">
						<span class="woocommerce-Price-amount amount"><bdi>50.000&nbsp;<span class="woocommerce-Price-currencySymbol">₫</span></bdi></span>					</td>
				</tr>
					</tbody>
	<tfoot>

		<tr class="cart-subtotal">
			<th>Tạm tính</th>
			<td><span class="woocommerce-Price-amount amount"><bdi>50.000&nbsp;<span class="woocommerce-Price-currencySymbol">₫</span></bdi></span></td>
		</tr>

		
		
		
		
		
		<tr class="order-total">
			<th>Tổng</th>
			<td><strong><span class="woocommerce-Price-amount amount"><bdi>50.000&nbsp;<span class="woocommerce-Price-currencySymbol">₫</span></bdi></span></strong> </td>
		</tr>

		
	</tfoot>
</table>

<div id="payment" class="woocommerce-checkout-payment">
			<ul class="wc_payment_methods payment_methods methods">
			<li class="wc_payment_method payment_method_bacs">
	<input id="payment_method_bacs" type="radio" class="input-radio" name="payment_method" value="bacs" checked="checked" data-order_button_text="">

	<label for="payment_method_bacs">
		Chuyển khoản ngân hàng 	</label>
	</li>
<li class="wc_payment_method payment_method_cod">
	<input id="payment_method_cod" type="radio" class="input-radio" name="payment_method" value="cod" data-order_button_text="">

	<label for="payment_method_cod">
		Thanh toán khi nhận hàng 	</label>
	</li>
		</ul>
		<div class="form-row place-order">
		<noscript>
			Trình duyệt của bạn không hỗ trợ JavaScript, hoặc nó bị vô hiệu hóa, hãy đảm bảo bạn nhấp vào <em>Cập nhật giỏ hàng</em> trước khi bạn thanh toán. Bạn có thể phải trả nhiều hơn số tiền đã nói ở trên, nếu bạn không làm như vậy.			<br/><button type="submit" class="button alt" name="woocommerce_checkout_update_totals" value="Cập nhật tổng">Cập nhật tổng</button>
		</noscript>

			<div class="woocommerce-terms-and-conditions-wrapper">
		<div class="woocommerce-terms-and-conditions" style="display: none; max-height: 200px; overflow: auto;">  <div id="page-header-2049040616" class="page-header-wrapper">
  <div class="page-title light simple-title">

    
    <div class="page-title-inner container align-center text-center flex-row-col medium-flex-wrap">
              <div class="title-wrapper uppercase flex-col">
          <h1 class="entry-title mb-0">
            chính sách đổi hàng / trả hàng          </h1>
        </div>
                    <div class="title-content flex-col">
        <div class="title-share pt-half pb-half"><div class="social-icons share-icons share-row relative"><a href="https://www.facebook.com/sharer.php?u=https://www.petmart.vn/" data-label="Facebook" onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip facebook" title="Share on Facebook" aria-label="Share on Facebook"><i class="icon-facebook"></i></a><a href="https://twitter.com/share?url=https://www.petmart.vn/" onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip twitter" title="Share on Twitter" aria-label="Share on Twitter"><i class="icon-twitter"></i></a><a href="mailto:enteryour@addresshere.com?subject=PET%20MART&amp;body=Check%20this%20out:%20https://www.petmart.vn/" rel="nofollow" class="icon button circle is-outline tooltip email" title="Email to a Friend" aria-label="Email to a Friend"><i class="icon-envelop"></i></a><a href="https://pinterest.com/pin/create/button/?url=https://www.petmart.vn/&amp;media=&amp;description=PET%20MART" onclick="window.open(this.href,this.title,'width=500,height=500,top=300px,left=300px');  return false;" rel="noopener noreferrer nofollow" target="_blank" class="icon button circle is-outline tooltip pinterest" title="Pin on Pinterest" aria-label="Pin on Pinterest"><i class="icon-pinterest"></i></a></div></div>      </div>
    </div>

       </div>
    </div>
  
	<div id="gap-1470293922" class="gap-element clearfix" style="display:block; height:auto;">
		
<style>
#gap-1470293922 {
  padding-top: 30px;
}
</style>
	</div>
	
<div class="row dnw-box-shadow" id="row-960933877"><p></p>
<p>
	</p><div id="col-1407845153" class="col small-12 large-12">
				<div class="col-inner">
			
			<p></p>
<p></p><div class="container section-title-container"><h2 class="section-title section-title-bold"><b></b><span class="section-title-main">Chính sách đổi trả hàng</span><b></b></h2></div><p></p>
<p>Pet Mart&nbsp;khuyến khích khách hàng kiểm tra tình trạng của sản phẩm trước khi thanh toán để đảm bảo rằng hàng hóa được giao đúng chủng loại, số lượng theo đơn đặt hàng và tình trạng không bị lỗi, hỏng.&nbsp;Trong trường hợp khách hàng giao dịch trực tiếp tại cửa hàng và đã thanh toán hoặc ký xác nhận biên lai giao hàng tại nhà đồng nghĩa là sản phẩm mà khách hàng đã nhận tại thời điểm đó không có bất cứ vấn đề gì. Chúng tôi sẽ không giải quyết bất kỳ&nbsp;khiếu nại&nbsp;của khách hàng&nbsp;sau đó.</p>
<p>Qui định về đổi hàng: Pet Mart sẽ hỗ trợ khách hàng đổi sang sản phẩm giá trị tương đương và không hoàn lại tiền trong thời gian 24 giờ kể từ&nbsp;lúc&nbsp;mua hàng.</p>
<p>		</p></div>
					</div>

	<br>

	<div id="col-382424273" class="col small-12 large-12">
				<div class="col-inner">
			
			<p></p>
<p></p><div class="container section-title-container"><h2 class="section-title section-title-bold"><b></b><span class="section-title-main">Điều kiện đổi trả hàng</span><b></b></h2></div><p></p>
<ol>
<li>Quý khách có thể đổi lại hàng đã mua trong vòng 24 giờ kể từ lúc mua mà không phải chịu bất kỳ một khoản phí nào. Tuy nhiên, quý khách phải giữ hoá đơn mua hàng gốc tại Pet Mart.</li>
<li>Sản phẩm phải trong tình trạng nguyên vẹn như khi Pet Mart giao sản phẩm cho khách hàng, chưa sử dụng, chưa bóc hộp hoặc tem &amp; còn mới 100% kể từ lúc mua &amp; còn nguyên đóng gói. Đối với thực phẩm và mỹ phẩm chưa được sử dụng hoặc không có mùi lạ.</li>
<li>Sản phẩm đổi trả trực tiếp tại cửa hàng nơi quý khách mua sản phẩm (Không đổi tại nhà khách hàng. Không gửi trực tiếp cho nhà sản xuất).</li>
<li>Sản phẩm đổi mới sẽ có giá trị ngang bằng hoặc lớn hơn sản phẩm đã mua trước đó. Pet Mart không hoàn lại tiền khi khách hàng đã mua sản phẩm.</li>
<li>Đối với sản phẩm đã mua &amp; đã mở hộp ra kiểm tra tại cửa hàng sẽ không được đổi sang sản phẩm khác.</li>
<li>Không nhận trả lại hàng nếu các sản phẩm nằm trong các chương trình khuyến mại. Trong các trường hợp khác quyền quyết định sẽ thuộc về Pet Mart.</li>
<li>Khi nhân viên của Pet Mart đã kiểm tra kỹ &amp; chấp nhận tình trạng hàng hoá đổi trả lại thì việc đổi hàng sẽ được tiến hành một cách tự động.</li>
</ol>
<p>Để biết thêm thông tin chi tiết, quý khách vui lòng liên hệ Bộ phận chăm sóc khách hàng Pet Mart&nbsp;để được trợ giúp. Xin cảm ơn!</p>
<p>		</p></div>
					</div>

	<p></p>
<p></p></div>
</div>
					<p class="form-row validate-required">
				<label class="woocommerce-form__label woocommerce-form__label-for-checkbox checkbox">
				<input type="checkbox" class="woocommerce-form__input woocommerce-form__input-checkbox input-checkbox" name="terms" id="terms">
											<span class="woocommerce-terms-and-conditions-checkbox-text">Tôi đồng ý với các điều khoản của Pet Mart.</span>&nbsp;<span class="required">*</span>
									</label>
				<input type="hidden" name="terms-field" value="1">
			</p>
			</div>
	
		
		<button type="submit" class="button alt" name="woocommerce_checkout_place_order" id="place_order" value="Đặt hàng" data-value="Đặt hàng">Đặt hàng</button>
		
		<input type="hidden" id="woocommerce-process-checkout-nonce" name="woocommerce-process-checkout-nonce" value="743c4cd0ac"><input type="hidden" name="_wp_http_referer" value="/?wc-ajax=update_order_review">	</div>
</div>

</div>
<div class="woocommerce-privacy-policy-text"><p>Chúng tôi sẽ gọi điện lại để tư vấn và xác nhận đơn hàng của quý khách trước khi giao. Thông tin của quý khách sẽ được sử dụng để xử lý đơn hàng này theo <a href="https://www.petmart.vn/chinh-sach-bao-mat" class="woocommerce-privacy-policy-link" target="_blank">chính sách riêng tư</a> của Pet Mart.</p>
</div> </div>
</div>--%>