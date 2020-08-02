<%@ Page Title="PDF, PS, EPS, PCL, DOC, DOCX, DOCM, DOT, DOTX, DOTM, MOBI, XLS, XLSX, XLSM, XLTX, XLTM, XLSB, PPT, PPTX, PPS, PPSX, POTM, PPSM, POTX, PPTM, VSD, VDX, VSS, VSX, VST, VTX, VSDX, VDW, VSSX, VSTX, VSTM, VSDM, VSSM, MPP, MPT, MSG, EML, OST, PST, ONE, EMLX, ODT, OTT, ODS, ODP, OTP, OTS, ODG, RTF, TXT, TEX, CSV, TSV, HTML, MHT, XML, XPS, DXF, DWG, DWF, IFC, STL, DGN, BMP, GIF, JPG, JPEG, PNG, TIFF, DJVU, SVG, WEBP, DNG, JP2, J2C, J2K, JPF, JPX, JPM, DCM, EPUB, ICO, WMF, EMF, PSD, CGM and files online Viewer - GroupDocs.App" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewerFileApp.aspx.cs" Inherits="GroupDocs.Viewer.Live.Demos.UI.ViewerApp.ViewerFileApp" %>

<asp:Content ID="HeadContents1" ContentPlaceHolderID="HeadContents" runat="server">

	<meta charset="UTF-8">
	<meta name="author" content="groupdocs.app" />
	<meta name="keywords" content="<%=metakeywords %>" />
	<link rel="canonical" href="https://products.groupdocs.app/viewer/total" />
	<link rel="icon" type="image/png" sizes="16x16" href="https://products.groupdocs.app/images/groupdocs1616.png">
	<meta property="og:site_name" content="Free Online <%=fileFormat  %>Viewer" />
	<meta property="og:title" content="<%=metatitle %>" />
	<meta property="og:description" content="<%=metadescription %>" />
	<meta property="og:image" content="https://products.groupdocs.app/images/groupdocsapp.png" />
	<meta property="og:type" content="website" />
	<meta property="og:url" content="https://products.groupdocs.app/viewer/total" />
	<meta name="twitter:card" content="summary_large_image">
	<meta name="twitter:site" content="@groupdocsapp">
	<meta name="twitter:creator" content="@groupdocsapp">
	<meta name="twitter:title" content="<%=metatitle %>">
	<meta name="twitter:description" content="<%=metadescription %>">
	<meta name="twitter:image:src" content="https://products.groupdocs.app/images/groupdocsapp.png" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<script lang="javascript" type="text/javascript">
		function TriggerFileUpload() {
			$('#<%=btnView.ClientID %>').click();
		}

		var size = 2;

		var id = 0;

		function ProgressBar() {

			if (document.getElementById('<%=FileUpload1.ClientID %>').value != "") {

				document.getElementById("progressbar").style.display = "block";


				id = setInterval("progress()", 10);

				return true;
			}
		}

		function progress() {

			size = size + 1;

			if (size > 299) {

				clearTimeout(id);

			}

			document.getElementById("progressbar").style.width = size + "%";
		}
	</script>    
	<!-- GroupDocs.Apps UI Template Starts Here -->
	<asp:Panel ID="pnlTest" runat="server">
		<div class="container-fluid GroupDocsApps pb5">
			<div class="container">
				<div class="row">

					<div class="col-md-12 pt-5 pb-5" style="padding-bottom: 0px!important;">
						<asp:HiddenField ID="hdnGroupDocsProductName" runat="server" />
						<h1 id="hheading" runat="server">Free Online Document Viewer</h1>
						<h2 style="font-size: 22px !important; color: #fff !important;" id="hdescription" runat="server">View, Export as Images & Download your Word, PDF, PowerPoint, Excel and more than 90 types of documents & images, 100% free online!</h2>
						<input type="hidden" id="hfIsToFormat" value="0" runat="server" />
						<h1 runat="server" visible="false" id="hFeatureTitle"></h1>
						<h4 runat="server" visible="false" id="hPageTitle"></h4>
						<div>
							<div class="uploadfile">

								<div class="filedropdown">
									<div class="filedrop">
										<label class="dz-message needsclick"><% = Resources["DropOrUploadFile"] %></label>
										<input type="file" class="uploadfileinput" name="FileUpload1" id="FileUpload1" onchange="TriggerFileUpload()" runat="server" />
										<br />
										<asp:RequiredFieldValidator ID="rfvFile" SetFocusOnError="true" ValidationGroup="uploadFile" runat="server"
											ErrorMessage="*" ControlToValidate="FileUpload1" Display="Dynamic"
											ForeColor="Red"></asp:RequiredFieldValidator>

										<asp:RegularExpressionValidator ValidationGroup="uploadFile" ID="ValidateFileType"
											ControlToValidate="FileUpload1" runat="server" ForeColor="Red"
											Display="Dynamic" Enabled="true" />

										<asp:HiddenField ID="hdnAllowedFileTypes" runat="server" Value="" />

										<asp:HiddenField ID="hdnDownloadFileName" runat="server" Value="" />
										<asp:HiddenField ID="hdnDownloadFileURL" runat="server" Value="" />

										<div class="fileupload">
											<div class="progress">
												<div class="progress-bar progress-bar-striped progress-bar-success progress-bar-animated" id="progressbar" role="progressbar" style="width: 0%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
											</div>
											<span class="filename"><a onclick='removefile()'>
												<label for="uploadfileinput" class="custom-file-upload"></label>
												<i class="fa fa-times"></i></a></span>
										</div>
									</div>


									<p runat="server" id="pMessage" style="width: 65%; position: relative; color: red; margin: 50px auto 30px;">
									</p>
									<asp:HiddenField ID="hfToFormat" Value="~" runat="server" />
									<div class="convertbtn" style="display: none;">
										<asp:Button class="btn btn-success btn-lg" ID="btnView" ValidationGroup="uploadFile" runat="server" OnClientClick="return ProgressBar()" OnClick="btnView_Click" />
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</asp:Panel>

	<div class="col-md-12 pt-5 bg-gray tc" style="padding-bottom: 0px!important;" id="dvAllFormats" runat="server">
		<div class="container">
			<div class="col-md-12 pull-left">
				<h2 class="h2title">GroupDocs.Viewer App</h2>
				<p>GroupDocs.Viewer App Supported Document Formats</p>
				<div class="diagram1 d2 d1-net">
					<div class="d1-row">
						<div class="d1-col d1-left">
							<header>Microsoft Office, Visio &amp; Project</header>
							<ul>
								<li><strong>Word:</strong> DOC, DOCX, DOT, DOTX, DOCM, DOTM, RTF</li>
								<li><strong>Excel:</strong> XLS, XLSX, XLSM, XLSB, XLTM, XLTX</li>
								<li><strong>PowerPoint:</strong> PPT, PPTX, PPS, POTM, POTX,&nbsp;PPSX, PPSM, PPTM</li>
								<li><strong>Visio:</strong> VSD, VDX, VSS, VSSX, VSX, VST, VSTX, VTX, VSDX, VDW, VSDM, VSSM, VSTM</li>
								<li><strong>Project:</strong> MPP, MPT</li>
								<li><strong>Outlook:</strong> MSG, EML, EMLX</li>
								<li><strong>Outlook Data Files: </strong>PST, OST</li>
								<li><strong>OneNote:</strong> ONE</li>
							</ul>
						</div>
						<!--/left-->
						<div class="d1-col d1-right">
							<header>OpenDocument &amp; Other Formats</header>
							<ul>
								<li><strong>OpenDocument Formats:</strong> ODT, OTT, ODS, ODP, OTP, OTS</li>
								<li><strong>Adobe &amp; Fixed Layout:</strong> PSD, PDF, XPS</li>
								<li><strong>Images:</strong> BMP, GIF, JPG, PNG, TIFF, multi-page TIFF, WebP, DNG</li>
								<li><strong>Jpeg2000:</strong> JP2, J2C, J2K, JPF, JPX, JPM</li>
								<li><strong>AutoCAD Drawings:</strong> DXF, DWG, IFC, STL</li>
								<li><strong>Metafiles:</strong> EMF, WMF</li>
								<li><strong>Web:</strong> HTML, MHT, MHTML</li>
								<li><strong>Text:</strong> TXT, CSV</li>
								<li><strong>Other:</strong>&nbsp;SVG, DjVu, DICOM, MOBI, ICO, EPUB, XML, TEX, PS, EPS,&nbsp;DWF, ISFF-based DGN, CGM</li>
							</ul>
						</div>
						<!--/right-->
					</div>
					<!--/row-->
					<div class="d1-logo">
						<img src="../img/groupdocs-viewer-net.png" alt=".NET Viewer APIs"><header>GroupDocs.Viewer</header>
						<footer><small>App</small></footer>
					</div>
					<!--/logo-->
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
		<div class="col-md-6 cardbox tc col-md-offset-3 b6">
			<h3 runat="server" id="hExtension1"></h3>
			<p runat="server" id="hExtension1Description"></p>
		</div>
	</div>


	<!-- HowTo Section -->
	<div class="col-md-12 tl bg-darkgray howtolist">
		<div class="container tl dflex">

			<div class="col-md-4 howtosectiongfx">
				<img src="/img/howto.png">
			</div>
			<div class="howtosection col-md-8">
				<div>
					<h2><i class="fa fa-question-circle "></i>&nbsp;<b>How to view a <%=howto %></b></h2>
					<ul>
						<li>Click inside the file drop area to upload <%=fileFormat  %>files or drag & drop a <%=fileFormat  %>file.</li>
						<li>Your <%=fileFormat  %>file will be automatically rendered for you to view instantly.</li>
						<li>Download the <%=fileFormat  %>file in original, image or PDF format.</li>
						<li>View and navigate between pages.</li>
						<li>View pages thumbnails.</li>
						<li>Set page view zoom-in or zoom-out.</li>
					</ul>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-12 pt-5 app-features-section" style="padding-bottom: 0px!important;">
		<div class="container tc pt-5">
			<div class="col-md-4">
				<div class="imgcircle fasteasy">
					<img src="../../img/fast-easy.png" />
				</div>
				<h4>Fast and Easy <%=fileFormat  %>Viewer</h4>
				<p>Upload your <%=fileFormat  %>document and you will be redirected to the <%=fileFormat  %>Viewer with great user experience and many more features.</p>
				<p id="h4para" runat="server" visible="false">.</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle anywhere">
					<img src="../../img/anywhere.png" />
				</div>
				<h4>View <%=fileFormat  %>from Anywhere</h4>
				<p>It works from all platforms including Windows, Mac, Android and iOS. All <%=fileFormat  %>files are processed on our servers. No plugin or software installation required for you..</p>
			</div>

			<div class="col-md-4">
				<div class="imgcircle quality">
					<img src="../../img/quality.png" />
				</div>
				<h4>Viewer Quality</h4>
				<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a>All <%=fileFormat  %>files are processed using GroupDocs APIs.</p>
			</div>
		</div>
	</div>
	<script>   

		$('.fileupload').hide();

		$('.uploadfileinput').change(function () {
			//return;
			var file = $('.uploadfileinput')[0].files[0].name;
			var ext = file.split('.').pop();
			ext = ext.toLowerCase();
			if (document.getElementById('<%=hdnAllowedFileTypes.ClientID %>').value.includes(ext)) {

				$('.filename label').text(file);
				$('.fileupload').show();
			}

		});
		function removefile() {
			$('.fileupload').hide();
			document.getElementById('progressbar').style.width = "0%";
			$('.uploadfileinput').show();

		}
		function ConvertAnotherFile() {
			$('.fileupload').hide();
			document.getElementById('progressbar').style.width = "0%";
			$('.filedropdown').show();
			$('.fileformatsico').show();

		}

		function AssignBtnToText(obj) {
			var t = $(obj).text();
			document.getElementById('ctl00_MainContent_OptionSelector_btnTo').innerHTML = t;
			document.getElementById("ctl00_MainContent_OptionSelector_hdnToValue").value = t;

		}

	</script>
	<script>
		if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

			var swiper = new Swiper('.swiper-container', {
				slidesPerView: 5,
				spaceBetween: 20,
				// init: false,
				pagination: {
					el: '.swiper-pagination',
					clickable: true,
				},
				navigation: {
					nextEl: '.swiper-button-next',
					prevEl: '.swiper-button-prev',
				},
				breakpoints: {
					868: {
						slidesPerView: 4,
						spaceBetween: 20,
					},
					668: {
						slidesPerView: 2,
						spaceBetween: 0,
					}
				}
			});
		}
	</script>
</asp:Content>
