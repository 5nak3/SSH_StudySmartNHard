<%@ Page Language="C#" MasterPageFile="~/BeforeLogin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SSH_ASPJ.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Carousel -->
    <div id="carousel-example-generic" class="carousel slide carousel-fade" data-ride="carousel">

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active one">
                <!-- <img src="#" alt="" /> -->
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>We can't help everyone, but everyone can help someone.<br />
                            <span class="yellow">That's what SSH aims to do xD </span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink1" NavigateUrl="Account/Login.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink2" NavigateUrl="Account/RegistrationSelection.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <div class="item two">
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>A <b class="yellow">Goal</b> without <b class="yellow">a plan</b><br />
                            <span class="span">is just a wish</span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink3" NavigateUrl="Account/Login.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink4" NavigateUrl="Account/RegistrationSelection.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <div class="item three">
                <div class="main-text hidden-xs">
                    <div class="col-md-12 text-center">
                        <h1>You cannot<b class="yellow"> believe</b> in <b class="yellow">God</b><br />
                            <span class="span">until you believe in yourself.</span></h1>
                        <div class="">
                            <asp:HyperLink ID="HyperLink5" NavigateUrl="Account/Login.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Login</asp:HyperLink>
                            <asp:HyperLink ID="HyperLink6" NavigateUrl="Account/RegistrationSelection.aspx" runat="server" CssClass="btn btn-clear btn-sm btn-min-block">Registration</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span></a><a class="right carousel-control"
                href="#carousel-example-generic" role="button" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
    </div>
    <!-- Carousel -->
    <!-- Service Section -->
    <section id="services" class="padding100">
        <div class="container">
            <div class="row">
                <h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s"><span><strong>F</strong>eatures</span></h2>
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-laptop animated wow fadeInDown"></i>
                    <div class="sc-inner">
                        <h4>Secure Logins & Privacy Control</h4>
                        <p>This web application uses <strong>STRICT</strong> Session Management & <strong>STRONG</strong> Authentication</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-user-plus animated wow fadeInDown" data-wow-delay="0.2s"></i>
                    <div class="sc-inner">
                        <h4>Friend System</h4>
                        <p>Finding your peers to add would be as <strong>Easy</strong> as ABC</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-users animated wow fadeInDown" data-wow-delay="0.4s"></i>
                    <div class="sc-inner">
                        <h4>Mentorship Program</h4>
                        <p>Mentee can post question to mentor vice versa. They can also answer each other questions. Allows mentor to notify mentees about any opportunities for them to develop.</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-gear animated wow fadeInUp" data-wow-delay="0.6s"></i>
                    <div class="sc-inner">
                        <h4>Admin Console</h4>
                        <p>Admin have to login. Only the admin is able to go into the admin console. Once in the admin console, the admin can view log files, manage users and do other admin jobs.</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-expeditedssl animated wow fadeInUp" data-wow-delay="0.8s"></i>
                    <div class="sc-inner">
                        <h4>Password Manager</h4>
                        <p>Student can enter and store their passwords in a secure system and access other web applications with stored credentials in one-click. OTP would be used as an additional authentication mean to make sure that request is done by the actual student. </p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-digg animated wow fadeInUp" data-wow-delay="0.10s"></i>
                    <div class="sc-inner">
                        <h4>Daily Article</h4>
                        <p>Everyday, an article will be pulled from the news front page for visitors to the website to view, read and discuss.</p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
            <div class="row">
                <div class="col-md-4">
                    <i class="fa fa-university animated wow fadeInUp" data-wow-delay="0.6s"></i>
                    <div class="sc-inner">
                        <h4>Sharing of Study Spots</h4>
                        <p>A user will post his review about any good study spots he found in the school and outside and will be able to review other people’s posts too.</p>
                    </div>
                </div>
                <!-- ./ end service box -->
                <div class="col-md-4">
                    <i class="fa fa-leanpub animated wow fadeInUp" data-wow-delay="0.8s"></i>
                    <div class="sc-inner">
                        <h4>E-Classroom</h4>
                        <p>Students can study <strong>TOGETHER</strong> by using our virtual classroom and draw solutions out instead of just typing </p>
                    </div>
                </div>
                <!-- ./ end service box -->
            </div>
            <!-- ./ end row -->
        </div>
    </section>
    <!-- ./ End Service Section -->
    <!-- Page Content -->

    <!-- /.container -->
    <!-- Products Section -->
    <section id="products" class="products-list padding100">
        <div class="container">
            <div class="row">
                <div class="section-title col-sm-8 col-sm-offset-2 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                    <h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">
                        Our <span class="common">' Features ' </span>in a nutshell.</h2>
                </div>
            </div>
            <!-- ./end row -->
            <div class="row">
                <div class="col-sm-12 animated wow fadeInUp" data-wow-delay="0.6s">
                    <div id="screens" class="owl-carousel">

                        <div>
                            <img src="BootStrap_Temp_Content/img/products/3.jpg" class="img-responsive" alt="screens">
                        </div>

                        <div>
                            <img src="BootStrap_Temp_Content/img/products/3.jpg" class="img-responsive" alt="screens">
                        </div>

                        <div>
                            <img src="BootStrap_Temp_Content/img/products/3.jpg" class="img-responsive" alt="screens">
                        </div>

                        <div>
                            <img src="BootStrap_Temp_Content/img/products/3.jpg" class="img-responsive" alt="screens">
                        </div>

                        <div>
                            <img src="BootStrap_Temp_Content/img/products/3.jpg" class="img-responsive" alt="screens">
                        </div>
                    </div>
                    <!-- ./ end slider -->
                </div>
            </div>
            <!-- ./ end row -->
        </div>
    </section>
    <!-- Download Section -->
    <section id="download" class="padding100">
        <div class="container">
            <div class="row">
                <div class="section-title col-sm-8 col-sm-offset-2 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                    <h2 class="animated wow fadeInLeft" data-wow-delay="0.4s">Waiting for what <span class="common">' JOIN US NOW'</span></h2>
                </div>
            </div>
            <!-- ./end row -->
        </div>
    </section>
    <!--End Download Section end-->
</asp:Content>