<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="QuanLyDuToan.Test.t" %>

<%--<html xmlns:v="urn:schemas-microsoft-com:vml"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns="http://www.w3.org/TR/REC-html40">

<head>
<meta http-equiv=Content-Type content="text/html; charset=utf-8">
<meta name=ProgId content=Excel.Sheet>
<meta name=Generator content="Microsoft Excel 14">
<link rel=File-List href="../Images/filelist.xml">
<!--[if !mso]>
<style>
v\:* {behavior:url(#default#VML);}
o\:* {behavior:url(#default#VML);}
x\:* {behavior:url(#default#VML);}
.shape {behavior:url(#default#VML);}
</style>
<![endif]-->
<style id="Mau C2-02-NS_9437_Styles">
<!--table
	{mso-displayed-decimal-separator:"\.";
	mso-displayed-thousand-separator:"\,";}
.font59437
	{color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;}
.xl159437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:12.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl639437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl649437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:"\@";
	text-align:center;
	vertical-align:middle;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl659437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl669437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl679437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl689437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl699437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl709437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl719437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl729437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl739437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl749437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl759437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl769437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl779437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl789437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl799437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl809437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl819437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl829437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl839437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl849437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl859437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl869437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl879437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:right;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl889437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl899437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl909437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl919437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl929437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl939437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl949437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl959437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:12.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:general;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl969437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl979437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl989437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl999437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1009437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1019437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1029437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1039437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1049437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1059437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1069437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:italic;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1079437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1089437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1099437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1109437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1119437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1129437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:underline;
	text-underline-style:single;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1139437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1149437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1159437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1169437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1179437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1189437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1199437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1209437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1219437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1229437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1239437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1249437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1259437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:none;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1269437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1279437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1289437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:normal;}
.xl1299437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1309437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1319437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1329437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1339437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1349437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:9.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:left;
	vertical-align:bottom;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1359437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt hairline windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1369437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:13.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	border-top:none;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1379437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:13.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:General;
	text-align:center;
	vertical-align:middle;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1389437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt solid windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1399437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:700;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt solid windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1409437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:none;
	border-bottom:.5pt hairline windowtext;
	border-left:.5pt solid windowtext;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
.xl1419437
	{padding:0px;
	mso-ignore:padding;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	mso-generic-font-family:auto;
	mso-font-charset:0;
	mso-number-format:"\#\,\#\#0";
	text-align:right;
	vertical-align:bottom;
	border-top:.5pt solid windowtext;
	border-right:.5pt solid windowtext;
	border-bottom:.5pt hairline windowtext;
	border-left:none;
	mso-background-source:auto;
	mso-pattern:auto;
	white-space:nowrap;}
-->
</style>
</head>

<body>
	<form id="form1" runat="server">
<!--[if !excel]>&nbsp;&nbsp;<![endif]-->
<!--The following information was generated by Microsoft Excel's Publish as Web
Page wizard.-->
<!--If the same item is republished from Excel, all information between the DIV
tags will be replaced.-->
<!----------------------------->
<!--START OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD -->
<!----------------------------->

<div id="Mau C2-02-NS_9437" align=center x:publishsource="Excel">

<table border=0 cellpadding=0 cellspacing=0 width=747 style='border-collapse:
 collapse;table-layout:fixed;width:561pt'>
 <col width=80 style='width:60pt'>
 <col width=48 style='mso-width-source:userset;mso-width-alt:1365;width:36pt'>
 <col width=99 style='mso-width-source:userset;mso-width-alt:2816;width:74pt'>
 <col width=66 style='mso-width-source:userset;mso-width-alt:1877;width:50pt'>
 <col width=64 style='mso-width-source:userset;mso-width-alt:1820;width:48pt'>
 <col width=48 style='mso-width-source:userset;mso-width-alt:1365;width:36pt'>
 <col width=60 style='mso-width-source:userset;mso-width-alt:1706;width:45pt'>
 <col width=78 style='mso-width-source:userset;mso-width-alt:2218;width:59pt'>
 <col width=16 style='mso-width-source:userset;mso-width-alt:455;width:12pt'>
 <col width=96 style='mso-width-source:userset;mso-width-alt:2730;width:72pt'>
 <col width=92 style='mso-width-source:userset;mso-width-alt:2616;width:69pt'>
 <tr height=19 style='mso-height-source:userset;height:14.25pt'>
  <td colspan=2 rowspan=2 height=56 class=xl1249437 width=128 style='border-right:
  .5pt solid black;border-bottom:.5pt solid black;height:42.0pt;width:96pt'>Không
  ghi vào<br>
    khu vực này</td>
  <td class=xl159437 width=99 style='width:74pt'></td>
  <td class=xl159437 width=66 style='width:50pt'></td>
  <td class=xl159437 width=64 style='width:48pt'></td>
  <td class=xl159437 width=48 style='width:36pt'></td>
  <td class=xl159437 width=60 style='width:45pt'></td>
  <td class=xl159437 width=78 style='width:59pt'></td>
  <td colspan=3 class=xl1109437 width=204 style='width:153pt'>Mẫu C2-02/NS</td>
 </tr>
 <tr height=37 style='mso-height-source:userset;height:27.75pt'>
  <td colspan=6 height=37 class=xl1369437 style='height:27.75pt;border-left:
  none'>GIẤY RÚT DỰ TOÁN NGÂN SÁCH</td>
  <td colspan=3 class=xl1289437 width=204 style='width:153pt'>(Thông tư số
  08/2013/TT-BTC ngày<br>
    10/01/2013 của Bộ Tài chính)</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl899437 style='height:15.0pt;border-top:none'>&nbsp;</td>
  <td class=xl899437 style='border-top:none'>&nbsp;</td>
  <td colspan=2 height=20 width=165 style='height:15.0pt;width:124pt'
  align=left valign=top><!--[if gte vml 1]><v:shapetype id="_x0000_t75"
   coordsize="21600,21600" o:spt="75" o:preferrelative="t" path="m@4@5l@4@11@9@11@9@5xe"
   filled="f" stroked="f">
   <v:stroke joinstyle="miter"/>
   <v:formulas>
    <v:f eqn="if lineDrawn pixelLineWidth 0"/>
    <v:f eqn="sum @0 1 0"/>
    <v:f eqn="sum 0 0 @1"/>
    <v:f eqn="prod @2 1 2"/>
    <v:f eqn="prod @3 21600 pixelWidth"/>
    <v:f eqn="prod @3 21600 pixelHeight"/>
    <v:f eqn="sum @0 0 1"/>
    <v:f eqn="prod @6 1 2"/>
    <v:f eqn="prod @7 21600 pixelWidth"/>
    <v:f eqn="sum @8 21600 0"/>
    <v:f eqn="prod @7 21600 pixelHeight"/>
    <v:f eqn="sum @10 21600 0"/>
   </v:formulas>
   <v:path o:extrusionok="f" gradientshapeok="t" o:connecttype="rect"/>
   <o:lock v:ext="edit" aspectratio="t"/>
  </v:shapetype><v:shape id="Rectangle_x0020_6" o:spid="_x0000_s2084" type="#_x0000_t75"
   style='position:absolute;margin-left:71.25pt;margin-top:1.5pt;width:12pt;
   height:12pt;z-index:1;visibility:visible;mso-wrap-style:square;
   v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image001.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout;
  position:absolute;z-index:1;margin-left:95px;margin-top:2px;width:16px;
  height:16px'><img width=16 height=16
  src="../Images/Mau%20C2-02-NS_9437_image002.png" v:shapes="Rectangle_x0020_6"></span><![endif]><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td colspan=2 height=20 class=xl1339437 width=165 style='height:15.0pt;
    width:124pt'><span style='mso-spacerun:yes'>         </span>Thực chi:<span
    style='mso-spacerun:yes'>   </span></td>
   </tr>
  </table>
  </span></td>
  <td class=xl879437>Tạm ứng:</td>
  <td align=left valign=top><!--[if gte vml 1]><v:shape id="Rectangle_x0020_7"
   o:spid="_x0000_s2085" type="#_x0000_t75" style='position:absolute;
   margin-left:10.5pt;margin-top:3pt;width:12pt;height:11.25pt;z-index:2;
   visibility:visible;mso-wrap-style:square;v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image001.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout;
  position:absolute;z-index:2;margin-left:14px;margin-top:4px;width:16px;
  height:15px'><img width=16 height=15
  src="../Images/Mau%20C2-02-NS_9437_image003.png" v:shapes="Rectangle_x0020_7"></span><![endif]><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td height=20 class=xl889437 width=48 style='height:15.0pt;width:36pt'><span
    style='mso-spacerun:yes'>         </span></td>
   </tr>
  </table>
  </span></td>
  <td colspan=2 height=20 width=138 style='height:15.0pt;width:104pt'
  align=left valign=top><!--[if gte vml 1]><v:shape id="Rectangle_x0020_10"
   o:spid="_x0000_s2088" type="#_x0000_t75" style='position:absolute;
   margin-left:78.75pt;margin-top:1.5pt;width:12.75pt;height:12pt;z-index:5;
   visibility:visible;mso-wrap-style:square;v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image004.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout;
  position:absolute;z-index:5;margin-left:105px;margin-top:2px;width:17px;
  height:16px'><img width=17 height=16
  src="../Images/Mau%20C2-02-NS_9437_image005.png" v:shapes="Rectangle_x0020_10"></span><![endif]><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td colspan=2 height=20 class=xl1349437 width=138 style='height:15.0pt;
    border-left:none;width:104pt'><span style='mso-spacerun:yes'>   
    </span>Chuyển khoản:</td>
   </tr>
  </table>
  </span></td>
  <td colspan=3 class=xl849437>Số:<asp:Label ID="m_lbl_so_unc" runat="server"></asp:Label>
	 </td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl869437 style='height:15.0pt'></td>
  <td class=xl869437></td>
  <td colspan=3 class=xl1339437><span style='mso-spacerun:yes'>        
  </span>Ứng trước đủ ĐK thanh toán:<span
  style='mso-spacerun:yes'>              </span></td>
  <td align=left valign=top><!--[if gte vml 1]><v:shape id="Rectangle_x0020_8"
   o:spid="_x0000_s2086" type="#_x0000_t75" style='position:absolute;
   margin-left:10.5pt;margin-top:1.5pt;width:12pt;height:11.25pt;z-index:3;
   visibility:visible;mso-wrap-style:square;v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image001.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout;
  position:absolute;z-index:3;margin-left:14px;margin-top:2px;width:16px;
  height:15px'><img width=16 height=15
  src="../Images/Mau%20C2-02-NS_9437_image003.png" v:shapes="Rectangle_x0020_8"></span><![endif]><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td height=20 class=xl889437 width=48 style='height:15.0pt;width:36pt'><span
    style='mso-spacerun:yes'>          </span></td>
   </tr>
  </table>
  </span></td>
  <td colspan=2 height=20 width=138 style='height:15.0pt;width:104pt'
  align=left valign=top><!--[if gte vml 1]><v:shape id="Rectangle_x0020_11"
   o:spid="_x0000_s2089" type="#_x0000_t75" style='position:absolute;
   margin-left:78.75pt;margin-top:1.5pt;width:12.75pt;height:11.25pt;z-index:6;
   visibility:visible;mso-wrap-style:square;v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image004.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout;
  position:absolute;z-index:6;margin-left:105px;margin-top:2px;width:17px;
  height:15px'><img width=17 height=15
  src="../Images/Mau%20C2-02-NS_9437_image006.png" v:shapes="Rectangle_x0020_11"></span><![endif]><span
  style='mso-ignore:vglayout2'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td colspan=2 height=20 class=xl1349437 width=138 style='height:15.0pt;
    border-left:none;width:104pt'><span style='mso-spacerun:yes'>   
    </span>Tiền mặt:</td>
   </tr>
  </table>
  </span></td>
  <td class=xl849437></td>
  <td class=xl849437></td>
  <td class=xl849437></td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl869437 style='height:15.0pt'></td>
  <td class=xl869437></td>
  <td colspan=3 class=xl1339437><span style='mso-spacerun:yes'>        
  </span>Ứng trước chưa đủ ĐK thanh toán:<span
  style='mso-spacerun:yes'>    </span></td>
  <td height=20 class=xl889437 width=48 style='height:15.0pt;width:36pt'><!--[if gte vml 1]><v:shape
   id="Rectangle_x0020_9" o:spid="_x0000_s2087" type="#_x0000_t75" style='position:absolute;
   margin-left:10.5pt;margin-top:2.25pt;width:12pt;height:11.25pt;z-index:4;
   visibility:visible;mso-wrap-style:square;v-text-anchor:top' o:gfxdata="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
" o:insetmode="auto">
   <v:imagedata src="../Images/Mau%20C2-02-NS_9437_image001.png"
    o:title=""/>
   <o:lock v:ext="edit" aspectratio="f"/>
   <x:ClientData ObjectType="Pict">
    <x:SizeWithCells/>
    <x:CF>Bitmap</x:CF>
    <x:AutoPict/>
   </x:ClientData>
  </v:shape><![endif]--><![if !vml]><span style='mso-ignore:vglayout'>
  <table cellpadding=0 cellspacing=0>
   <tr>
    <td width=14 height=3></td>
   </tr>
   <tr>
    <td></td>
    <td><img width=16 height=15
    src="../Images/Mau%20C2-02-NS_9437_image003.png" v:shapes="Rectangle_x0020_9"></td>
    <td width=18></td>
   </tr>
   <tr>
    <td height=2></td>
   </tr>
  </table>
  </span><![endif]><!--[if !mso & vml]><span style='width:36.0pt;height:15.0pt'></span><![endif]--></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl849437></td>
  <td class=xl849437></td>
  <td class=xl849437></td>
 </tr>
 <tr height=11 style='mso-height-source:userset;height:8.25pt'>
  <td height=11 class=xl159437 style='height:8.25pt'></td>
  <td class=xl159437></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl859437></td>
  <td class=xl159437></td>
  <td class=xl159437></td>
  <td class=xl159437></td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:14.1pt'>
  <td height=18 class=xl759437 colspan=2 style='height:14.1pt'>Đơn vị rút dự
  toán:</td>
  <td colspan=7 class=xl1189437>
					<asp:Label ID="m_lbl_don_vi_rut_du_toan" runat="server"></asp:Label>
				</td>
  <td class=xl759437>Mã ĐVQHNS:</td>
  <td class=xl769437>
					<asp:Label ID="m_lbl_ma_dvqhns" ForeColor="Black" runat="server"></asp:Label>
				</td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:14.1pt'>
  <td height=18 class=xl779437 style='height:14.1pt;border-top:none'>Tài khoản:</td>
  <td colspan=4 class=xl1029437>
								<asp:Label ID="m_lbl_tai_khoan" runat="server"></asp:Label>
							</td>
  <td colspan=2 class=xl1359437>Tại KBNN:</td>
  <td colspan=4 class=xl1029437>
					<asp:Label ID="m_lbl_tai_kbns" ForeColor="Black" Width="150px" runat="server"></asp:Label>
				</td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:14.1pt'>
  <td height=18 class=xl779437 style='height:14.1pt;border-top:none'>Mã cấp NS:</td>
  <td colspan=2 class=xl1029437>
					<asp:Label ID="m_lbl_ma_cap_ns" ForeColor="Black" Width="150px" runat="server"></asp:Label>
				</td>
  <td colspan=2 class=xl1359437>Tên CTMT, DA:</td>
  <td colspan=6 class=xl1019437>
					<asp:Label ID="m_lbl_ten_ctmt_da" ForeColor="Black" Width="273px" runat="server"></asp:Label>
				</td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:14.1pt'>
  <td colspan=7 height=18 class=xl1029437 style='height:14.1pt'>&nbsp;</td>
  <td colspan=2 class=xl1359437>Mã CTMT, DA:</td>
  <td colspan=2 class=xl1049437>
					<asp:Label ID="m_lbl_ma_ctmt_da_htct" ForeColor="Black" Width="150px" runat="server"></asp:Label>
				</td>
 </tr>
 <tr height=18 style='mso-height-source:userset;height:14.1pt'>
  <td colspan=2 height=18 class=xl1049437 style='height:14.1pt'>Năm NS:<span
  style='mso-spacerun:yes'>   </span><font class="font59437"><span
					style='mso-spacerun: yes'>
					<asp:Label ID="m_lbl_nam_ns" ForeColor="Black" runat="server"></asp:Label>
				</span></font></td>
  <td class=xl779437 style='border-top:none'>Số CKC, HĐK:</td>
  <td colspan=2 class=xl1029437>
					<asp:Label ID="m_lbl_so_ckc_hdk" ForeColor="Black" runat="server"></asp:Label>
				</td>
  <td colspan=2 class=xl1049437>Số CKC, HĐTH:</td>
  <td colspan=4 class=xl1029437>
					<asp:Label ID="m_lbl_so_ckc_hdth" ForeColor="Black" Width="271px" runat="server"></asp:Label>
				</td>
 </tr>
 <tr height=8 style='mso-height-source:userset;height:6.0pt'>
  <td height=8 class=xl639437 style='height:6.0pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
 </tr>
 <tr height=19 style='mso-height-source:userset;height:14.25pt'>
  <td colspan=3 rowspan=2 height=73 class=xl1199437 style='height:54.75pt'>Nội
  dung thanh toán</td>
  <td rowspan=2 class=xl1209437 width=66 style='width:50pt'>Mã
    NDKT</td>
  <td rowspan=2 class=xl1209437 width=64 style='width:48pt'>Mã
    Chương</td>
  <td rowspan=2 class=xl1209437 width=48 style='width:36pt'>Mã
    ngành<br>
    KT</td>
  <td rowspan=2 class=xl1209437 width=60 style='width:45pt'>Mã
    nguồn
    NSNN</td>
  <td colspan=2 rowspan=2 class=xl1209437 width=94 style='width:71pt'>Tồng số
  tiền</td>
  <td colspan=2 class=xl1209437 width=188 style='border-left:none;width:141pt'>Chia
  ra</td>
 </tr>
 <tr height=54 style='mso-height-source:userset;height:40.5pt'>
  <td height=54 class=xl689437 style='height:40.5pt;border-top:none;border-left:
  none'>Nộp thuế</td>
  <td class=xl699437 width=92 style='border-top:none;border-left:none;
  width:69pt'>Thanh toán
    cho đơn vị
    hưởng</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td colspan=3 height=20 class=xl649437 style='height:15.0pt'>(1)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(2)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(3)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(4)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(5)</td>
  <td colspan=2 class=xl649437 style='border-left:none'>(6)=(7)+(8)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(7)</td>
  <td class=xl649437 style='border-top:none;border-left:none'>(8)</td>
 </tr>
 <%if (m_ds != null && m_ds.Tables.Count > 0)%>
			<%{%>
			<%foreach (System.Data.DataRow dr in m_ds.Tables[0].Rows)%>
			<%{%>
			<tr height="20" style='mso-height-source: userset; height: 15.0pt'>
				<td colspan="3" height="20" class="xl1309437" style='border-right: .5pt solid black; height: 15.0pt'><%= dr[V_DM_GIAI_NGAN.NOI_DUNG_CHI] %></td>
				<td class="xl659437" style='border-left: none'><%= dr["TEN_DU_AN"] %></td>
				<td class="xl659437" style='border-left: none'><%=dr[GRID_GIAI_NGAN.MA_CHUONG].ToString() %></td>
				<td class="xl659437" style='border-left: none'><%=dr[GRID_GIAI_NGAN.MA_LOAI].ToString() %></td>
				<td class="xl659437" style='border-left: none'><%=dr[GRID_GIAI_NGAN.MA_KHOAN].ToString() %></td>
				<td colspan="2" class="xl1409437" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(dr["TONG"].ToString()) %></td>
				<td class="xl669437" style='border-left: none'><%=format_so_tien( dr["SO_TIEN_NOP_THUE"].ToString()) %></td>
				<td class="xl669437" style='border-left: none'><%=format_so_tien(dr["SO_TIEN_TT_CHO_DV_HUONG"].ToString()) %></td>
			</tr>
			<%}%>
			<%}%>
 <tr height="18" style='mso-height-source: userset; height: 14.1pt'>
				<td colspan="7" height="18" class="xl1219437" style='border-right: .5pt solid black; height: 14.1pt'>Tổng cộng</td>
				<td colspan="2" class="xl1389437" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(m_dc_tong_tien.ToString()) %></td>
				<td class="xl799437" style='border-left: none'><%=format_so_tien(m_dc_tong_tien_nop_thue.ToString()) %></td>
				<td class="xl799437" style='border-left: none'><%=format_so_tien(m_dc_tong_tien_thanh_toan_cho_don_vi_huong.ToString()) %></td>
			</tr>
 <tr height=10 style='mso-height-source:userset;height:7.5pt'>
  <td height=10 class=xl909437 style='height:7.5pt;border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl909437 style='border-top:none'>&nbsp;</td>
  <td class=xl919437 style='border-top:none'>&nbsp;</td>
  <td class=xl919437 style='border-top:none'>&nbsp;</td>
  <td class=xl919437 style='border-top:none'>&nbsp;</td>
  <td class=xl919437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=21 style='mso-height-source:userset;height:15.75pt'>
  <td colspan=8 height=21 class=xl999437 style='height:15.75pt'>Tổng số tiền
  ghi bằng chữ:<asp:Label ID="m_lbl_so_tien_ghi_bang_chu" runat="server"></asp:Label>
				</td>
  <td class=xl749437></td>
  <td colspan=2 class=xl979437 style='border-right:.5pt solid black'>PHẦN KBNN
  GHI</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1059437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl679437></td>
  <td class=xl929437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>1. Nộp thuế:</td>
  <td class=xl939437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl969437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl679437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Nợ TK:</td>
  <td class=xl839437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl639437 style='height:15.0pt'>Trong đó:</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Có TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=2 height=20 class=xl1129437 style='height:15.0pt'>NỘP THUẾ:</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Nợ TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1009437 style='height:15.0pt'>Tên đơn vị
  (Người nộp thuế):<asp:Label ID="m_lbl_nt_ten_don_vi" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Có TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl779437 style='height:15.0pt;border-top:none'>Mã số
  thuế:</td>
  <td colspan=2 class=xl1029437>
					<asp:Label ID="m_lbl_nt_ma_so_thue" runat="server" Width="80%"></asp:Label>
				</td>
  <td class=xl779437 style='border-top:none'>Mã NDKT:</td>
  <td class=xl789437 style='border-top:none'>
					<asp:Label ID="m_lbl_nt_ma_ndkt" runat="server" Width="80%"></asp:Label>
				</td>
  <td colspan=2 class=xl1039437>Mã Chương:</td>
  <td class=xl789437 style='border-top:none'>
					<asp:Label ID="m_lbl_nt_ma_chuong" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Nợ TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl779437 colspan=2 style='height:15.0pt'>Cơ quan quản lý
  thu:</td>
  <td colspan=3 class=xl1029437>
					<asp:Label ID="m_lbl_nt_co_quan_quan_ly_thu" runat="server" Width="92.2%"></asp:Label>
				</td>
  <td colspan=2 class=xl1039437>Mã CQ thu:</td>
  <td class=xl639437>
					<asp:Label ID="m_lbl_nt_ma_cq_thu" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Có TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1039437 style='height:15.0pt'>KBNN hạch toán
  khoản thu:<asp:Label ID="m_lbl_nt_kbnn_hach_toan_thu" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Mã CQ thu:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl779437 colspan=3 style='height:15.0pt'>Số tiền nộp thuế
  (ghi bằng chữ):</td>
  <td colspan=5 class=xl1029437>
					<asp:Label ID="m_lbl_nt_so_tien_nop_thue" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Mã ĐBHC:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1069437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl829437 colspan=2 style='border-right:.5pt solid black'><span
  style='mso-spacerun:yes'>  </span>2. Trả đơn vị hưởng:</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=4 height=20 class=xl1129437 style='height:15.0pt'>THANH TOÁN CHO
  ĐƠN VỊ HƯỞNG:</td>
  <td class=xl749437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Nợ TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl759437 colspan=2 style='height:15.0pt'>Đơn vị nhận
  tiền:</td>
  <td colspan=6 class=xl1189437>
					<asp:Label ID="m_lbl_ttdvh_don_vi_nhan_tien" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Có TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl779437 style='height:15.0pt;border-top:none'>Địa chỉ:</td>
  <td colspan=7 class=xl1019437>
					<asp:Label ID="m_lbl_ttdvh_dia_chi" runat="server" Width="100%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Nợ TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=3 height=20 class=xl1039437 style='height:15.0pt'>Mã ĐVQHNS:<asp:Label ID="m_lbl_ttdvh_ma_dvqhns" runat="server" Width="80%"></asp:Label>
				</td>
  <td colspan=5 class=xl1049437>Mã CTMT, DA và HTCT:<asp:Label ID="m_lbl_ttdvh_ma_ctmt_da_htct" runat="server" Width="80%"></asp:Label>
				</td>
  <td class=xl639437></td>
  <td class=xl809437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Có TK:</td>
  <td class=xl819437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td height=20 class=xl779437 style='height:15.0pt;border-top:none'>Tài khoản:</td>
  <td colspan=2 class=xl1019437>
					<asp:Label ID="m_lbl_ttdvh_tai_khoan" runat="server" Width="80%"></asp:Label>
				</td>
  <td class=xl779437 colspan=2>Tại KBNN (NH):<asp:Label ID="m_lbl_ttdvh_tai_kbnn" runat="server" Width="100%"></asp:Label>
				</td>
  <td colspan=3 class=xl1029437>&nbsp;</td>
  <td class=xl639437></td>
  <td colspan=2 class=xl809437 style='border-right:.5pt solid black'><span
  style='mso-spacerun:yes'>  </span>Nợ TK:</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1039437 style='height:15.0pt'>Hoặc người nhận
  tiền:</td>
  <td class=xl639437></td>
  <td colspan=2 class=xl809437 style='border-right:.5pt solid black'><span
  style='mso-spacerun:yes'>  </span>Có TK:</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=8 height=20 class=xl1039437 style='height:15.0pt'>CMND số:<span
  style='mso-spacerun:yes'>                  <span
					style='mso-spacerun: yes'><asp:Label ID="m_lbl_cmnd_so" runat="server" Width="80%"></asp:Label>
				</span>       </span>Cấp ngày<span
  style='mso-spacerun:yes'>    <span
					style='mso-spacerun: yes'><asp:Label ID="m_lbl_cap_ngay" runat="server" Width="80%"></asp:Label>
				</span>                       </span>Nơi cấp:<span
  style='mso-spacerun:yes'>  <asp:Label ID="m_lbl_noi_cap" runat="server" Width="100%" Height="16px"></asp:Label>
				</span></td>
  <td class=xl639437></td>
  <td class=xl949437 style='border-top:none'><span style='mso-spacerun:yes'> 
  </span>Mã ĐBHC:</td>
  <td class=xl959437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=11 height=20 class=xl1009437 style='height:15.0pt'>Số tiền thanh
  toán cho đơn vị hưởng (ghi bằng chữ):</td>
 </tr>
 <tr height=20 style='mso-height-source:userset;height:15.0pt'>
  <td colspan=11 height=20 class=xl1069437 style='height:15.0pt'>
					<asp:Label ID="m_lbl_ttdvh_so_tien_thanh_toan" runat="server" Width="100%"></asp:Label>
				</td>
 </tr>
 <tr height=10 style='mso-height-source:userset;height:7.5pt'>
  <td height=10 class=xl639437 style='height:7.5pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl739437></td>
  <td class=xl969437 style='border-top:none'>&nbsp;</td>
 </tr>
 <tr height=21 style='mso-height-source:userset;height:15.75pt'>
  <td colspan=4 height=21 class=xl1099437 style='height:15.75pt'>Bộ phận kiểm
  soát của KBNN</td>
  <td colspan=7 class=xl1099437>Đơn vị sử dụng ngân sách</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td colspan=4 height=20 class=xl849437 style='height:15.0pt'>Ngày<span
  style='mso-spacerun:yes'>          </span>tháng<span
  style='mso-spacerun:yes'>          </span>năm<span
  style='mso-spacerun:yes'> </span></td>
  <td colspan=7 class=xl849437>Ngày<span style='mso-spacerun:yes'>            
  </span>tháng<span style='mso-spacerun:yes'>            </span>năm 2013</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td colspan=2 height=20 class=xl1109437 style='height:15.0pt'>Kiểm soát</td>
  <td colspan=2 class=xl1109437>Phụ trách</td>
  <td colspan=3 class=xl1109437>Kế toán trưởng</td>
  <td colspan=4 class=xl1109437>Thủ trưởng đơn vị</td>
 </tr>
 <tr height=17 style='mso-height-source:userset;height:12.95pt'>
  <td height=17 class=xl639437 style='height:12.95pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
 </tr>
 <tr height=17 style='mso-height-source:userset;height:12.95pt'>
  <td height=17 class=xl639437 style='height:12.95pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
 </tr>
 <tr height=17 style='mso-height-source:userset;height:12.95pt'>
  <td height=17 class=xl639437 style='height:12.95pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td height=20 class=xl639437 style='height:15.0pt'></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td colspan=3 class=xl1109437>Nguyễn Pháo</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
 </tr>
 <tr height=10 style='mso-height-source:userset;height:7.5pt'>
  <td height=10 class=xl729437 style='height:7.5pt'>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
  <td class=xl729437>&nbsp;</td>
 </tr>
 <tr height=22 style='mso-height-source:userset;height:16.5pt'>
  <td colspan=2 height=22 class=xl1079437 style='border-right:.5pt solid black;
  height:16.5pt'>Người nhận tiền</td>
  <td colspan=5 class=xl1079437 style='border-right:.5pt solid black;
  border-left:none'>KBNN A ghi sổ và thanh toán ngày<span
  style='mso-spacerun:yes'>         </span>/<span
  style='mso-spacerun:yes'>         </span>/<span
  style='mso-spacerun:yes'>       </span></td>
  <td colspan=4 class=xl1079437 style='border-right:.5pt solid black;
  border-left:none'>KBNN B, NH B ghi sổ ngày<span
  style='mso-spacerun:yes'>        </span>/<span
  style='mso-spacerun:yes'>        </span>/<span
  style='mso-spacerun:yes'>      </span></td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td colspan=2 height=20 class=xl1169437 style='border-right:.5pt solid black;
  height:15.0pt'>(Ký, ghi rõ họ, tên)</td>
  <td colspan=5 class=xl1139437 style='border-right:.5pt solid black;
  border-left:none'>Thủ quỹ<span style='mso-spacerun:yes'>        </span>Kế
  toán<span style='mso-spacerun:yes'>        </span>Kế toán trưởng<span
  style='mso-spacerun:yes'>          </span>Giám đốc</td>
  <td colspan=4 class=xl1139437 style='border-right:.5pt solid black;
  border-left:none'><span style='mso-spacerun:yes'>    </span>Kế toán<span
  style='mso-spacerun:yes'>      </span>Kế toán trưởng<span
  style='mso-spacerun:yes'>             </span>Giám đốc</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td height=20 class=xl709437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td height=20 class=xl709437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
 </tr>
 <tr height=20 style='height:15.0pt'>
  <td height=20 class=xl709437 style='height:15.0pt'>&nbsp;</td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
  <td class=xl709437 style='border-left:none'>&nbsp;</td>
  <td class=xl639437></td>
  <td class=xl639437></td>
  <td class=xl719437>&nbsp;</td>
 </tr>
 <![if supportMisalignedColumns]>
 <tr height=0 style='display:none'>
  <td width=80 style='width:60pt'></td>
  <td width=48 style='width:36pt'></td>
  <td width=99 style='width:74pt'></td>
  <td width=66 style='width:50pt'></td>
  <td width=64 style='width:48pt'></td>
  <td width=48 style='width:36pt'></td>
  <td width=60 style='width:45pt'></td>
  <td width=78 style='width:59pt'></td>
  <td width=16 style='width:12pt'></td>
  <td width=96 style='width:72pt'></td>
  <td width=92 style='width:69pt'></td>
 </tr>
 <![endif]>
</table>

</div>


<!----------------------------->
<!--END OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD-->
<!----------------------------->
	</form>
</body>

</html>
--%>
