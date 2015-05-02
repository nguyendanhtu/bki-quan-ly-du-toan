<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="F304Print.ascx.cs" Inherits="QuanLyDuToan.UserControls.F304Print" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<%--	<meta name="ProgId" content="Excel.Sheet">
	<meta name="Generator" content="Microsoft Excel 14">--%>
	<title></title>
	<style id="A300_Mau UNC - Mau C4-02-KB_22116_Styles">
		<!-- table {
			mso-displayed-decimal-separator: "\.";
			mso-displayed-thousand-separator: "\,";
		}

		.xl1522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 12.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 12.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl6922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 12.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl7922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl8922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: "\@";
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: "\@";
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: "\@";
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl9922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl10922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl11922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl12322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl12422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 14.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 14.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 11.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl12922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: italic;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl13922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 12.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: none;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 12.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: general;
			vertical-align: bottom;
			border-top: .5pt hairline windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt hairline windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: right;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl14922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl15022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 9.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl15722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: normal;
		}

		.xl15822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 400;
			font-style: normal;
			text-decoration: none;
			font-family: Arial;
			mso-generic-font-family: auto;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl15922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 9.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 9.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 9.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl16922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17022116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: middle;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17122116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			border-top: none;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17222116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: bottom;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17322116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17422116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17522116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 10.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: .5pt solid windowtext;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17622116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: .5pt solid windowtext;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17722116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: none;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17822116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: center;
			vertical-align: bottom;
			border-top: .5pt solid windowtext;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}

		.xl17922116 {
			padding-top: 1px;
			padding-right: 1px;
			padding-left: 1px;
			mso-ignore: padding;
			color: windowtext;
			font-size: 8.0pt;
			font-weight: 700;
			font-style: normal;
			text-decoration: none;
			font-family: Arial, sans-serif;
			mso-font-charset: 0;
			mso-number-format: General;
			text-align: left;
			vertical-align: middle;
			border-top: none;
			border-right: .5pt solid windowtext;
			border-bottom: none;
			border-left: none;
			mso-background-source: auto;
			mso-pattern: auto;
			white-space: nowrap;
		}
		-->
	</style>
</head>

<body>
	<!--[if !excel]>&nbsp;&nbsp;<![endif]-->
	<!--The following information was generated by Microsoft Excel's Publish as Web
Page wizard.-->
	<!--If the same item is republished from Excel, all information between the DIV
tags will be replaced.-->
	<!----------------------------->
	<!--START OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD -->
	<!----------------------------->

	<div id="A300_Mau UNC - Mau C4-02-KB_22116" align="center" x:publishsource="Excel">
		<table border="0" cellpadding="0" cellspacing="0" width="745" style='border-collapse: collapse; table-layout: fixed; width: 560pt'>
			<col class="xl6322116" width="74" style='mso-width-source: userset; mso-width-alt: 2104; width: 56pt'>
			<col class="xl6322116" width="32" style='mso-width-source: userset; mso-width-alt: 910; width: 24pt'>
			<col class="xl6322116" width="28" style='mso-width-source: userset; mso-width-alt: 796; width: 21pt'>
			<col class="xl6322116" width="43" style='mso-width-source: userset; mso-width-alt: 1223; width: 32pt'>
			<col class="xl6322116" width="16" style='mso-width-source: userset; mso-width-alt: 455; width: 12pt'>
			<col class="xl6322116" width="37" style='mso-width-source: userset; mso-width-alt: 1052; width: 28pt'>
			<col class="xl6322116" width="73" style='mso-width-source: userset; mso-width-alt: 2076; width: 55pt'>
			<col class="xl6322116" width="31" style='mso-width-source: userset; mso-width-alt: 881; width: 23pt'>
			<col class="xl6322116" width="11" style='mso-width-source: userset; mso-width-alt: 312; width: 8pt'>
			<col class="xl6322116" width="54" style='mso-width-source: userset; mso-width-alt: 1536; width: 41pt'>
			<col class="xl6322116" width="53" style='mso-width-source: userset; mso-width-alt: 1507; width: 40pt'>
			<col class="xl6322116" width="81" style='mso-width-source: userset; mso-width-alt: 2304; width: 61pt'>
			<col class="xl6322116" width="11" style='mso-width-source: userset; mso-width-alt: 312; width: 8pt'>
			<col class="xl6322116" width="51" style='mso-width-source: userset; mso-width-alt: 1450; width: 38pt'>
			<col class="xl6322116" width="94" style='mso-width-source: userset; mso-width-alt: 2673; width: 71pt'>
			<col width="56" style='mso-width-source: userset; mso-width-alt: 1592; width: 42pt'>
			<tr height="20" style='mso-height-source: userset; height: 15.0pt'>
				<td colspan="3" rowspan="2" height="56" class="xl15022116" width="134"
					style='border-right: .5pt solid black; border-bottom: .5pt solid black; height: 42.0pt; width: 101pt'>Không ghi vào
					khu vực này</td>
				<td class="xl8022116" width="43" style='width: 32pt'></td>
				<td class="xl6322116" width="16" style='width: 12pt'></td>
				<td class="xl6322116" width="37" style='width: 28pt'></td>
				<td class="xl6322116" width="73" style='width: 55pt'></td>
				<td class="xl6322116" width="31" style='width: 23pt'></td>
				<td class="xl6322116" width="11" style='width: 8pt'></td>
				<td class="xl6322116" width="54" style='width: 41pt'></td>
				<td class="xl6322116" width="53" style='width: 40pt'></td>
				<td class="xl6322116" width="81" style='width: 61pt'></td>
				<td colspan="4" class="xl15622116" width="212" style='width: 159pt'>M&#7851;u
  s&#7889; C4-02/KB</td>
			</tr>
			<tr height="36" style='mso-height-source: userset; height: 27.0pt'>
				<td colspan="9" height="36" class="xl12422116" style='height: 27.0pt; border-left: none'>UỶ NHIỆM CHI</td>
				<td colspan="4" class="xl15722116" width="212" style='width: 159pt'>(Thông tư
  số 08/2013/TT-BTC ngày 10/01/2013 của Bộ Tài chính)</td>
			</tr>
			<tr height="26" style='mso-height-source: userset; height: 19.5pt'>
				<td height="26" class="xl7922116" style='height: 19.5pt; border-top: none'>&nbsp;</td>
				<td class="xl7922116" style='border-top: none'>&nbsp;</td>
				<td class="xl7922116" style='border-top: none'>&nbsp;</td>
				<td colspan="9" class="xl12622116">CHUYỂN KHOẢN, CHUYỂN TIỀN ĐIỆN TỬ</td>
				<td colspan="4" class="xl7322116">Số:
						<asp:Label ID="m_lbl_so_unc" Text="59Qtu" runat="server"></asp:Label></td>
			</tr>
			<tr height="20" style='height: 15.0pt'>
				<td height="20" class="xl6322116" style='height: 15.0pt'></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td colspan="9" class="xl7322116">Lập ngày
					<asp:Label ID="m_lbl_ngay_thang" Text=" 01 tháng 01 năm 2014" runat="server"></asp:Label>
				</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl1522116"></td>
			</tr>
			<tr height="13" style='mso-height-source: userset; height: 9.75pt'>
				<td height="13" class="xl6322116" style='height: 9.75pt'></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl1522116"></td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="2" height="24" class="xl13622116" style='height: 18.0pt'>&#272;&#417;n
  v&#7883; tr&#7843; ti&#7873;n:</td>
				<td colspan="14" class="xl13622116">
					<asp:Label ID="m_lbl_don_vi_tra_tien" runat="server" Text="Sở Giao thông vận tải Hải Dương"></asp:Label>
				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td height="21" class="xl6422116" style='height: 15.95pt; border-top: none'>&#272;&#7883;a
  ch&#7881;:</td>
				<td colspan="15" class="xl11822116">
					<asp:Label ID="m_lbl_dia_chi" runat="server" Text="79 Bạch Đằng - TP Hải Dương"></asp:Label>
				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="4" height="21" class="xl7222116" style='height: 15.95pt'>T&#7841;i Kho
  b&#7841;c Nhà n&#432;&#7899;c (NH):</td>
				<td colspan="12" class="xl11822116">
					<asp:Label ID="m_lbl_tai_kho_bac_nha_nuoc" runat="server" Text="Kho Bạc Nhà nước tỉnh Hải Dương"></asp:Label>
				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="6" height="21" class="xl7222116" style='height: 15.95pt'>Mã TKKT:<asp:Label ID="m_lbl_ma_tkkt" runat="server" Text="3741.0.1044548"></asp:Label>
				</td>
				<td colspan="5" class="xl8422116">Mã &#272;VQHNS:<asp:Label ID="m_lbl_ma_dvqhns" runat="server" Text="1044548"></asp:Label>
				</td>
				<td colspan="5" class="xl8422116">Mã CTMT, DA và HTCT:<asp:Label ID="m_lbl_ma_ctmt_da_htct" Text="91057" runat="server"></asp:Label>
				</td>
			</tr>
			<tr height="11" style='mso-height-source: userset; height: 8.25pt'>
				<td height="11" class="xl7622116" style='height: 8.25pt'></td>
				<td class="xl7622116"></td>
				<td class="xl7622116"></td>
				<td class="xl7622116"></td>
				<td class="xl7622116"></td>
				<td class="xl7522116"></td>
				<td class="xl7722116"></td>
				<td class="xl7722116"></td>
				<td class="xl7522116"></td>
				<td class="xl7522116"></td>
				<td class="xl7522116"></td>
				<td class="xl7822116"></td>
				<td class="xl7822116"></td>
				<td class="xl7822116"></td>
				<td class="xl7322116"></td>
				<td class="xl7322116"></td>
			</tr>
			<tr height="27" style='mso-height-source: userset; height: 20.25pt'>
				<td colspan="8" rowspan="2" height="74" class="xl11922116" style='border-right: .5pt solid black; height: 55.5pt'>Nội dung thanh toán</td>
				<td colspan="3" rowspan="2" class="xl11922116" style='border-right: .5pt solid black'>Tổng số tiền</td>
				<td colspan="5" class="xl11922116" style='border-right: .5pt solid black; border-left: none'>Chia ra</td>
			</tr>
			<tr height="47" style='mso-height-source: userset; height: 35.25pt'>
				<td colspan="3" height="47" class="xl11922116" style='border-right: .5pt solid black; height: 35.25pt; border-left: none'>Nộp thuế</td>
				<td colspan="2" class="xl12222116" width="150" style='border-right: .5pt solid black; border-left: none; width: 113pt'>Thanh toán cho đơn vị hưởng</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="8" height="21" class="xl9222116" style='border-right: .5pt solid black; height: 15.95pt'>(1)</td>
				<td colspan="3" class="xl9222116" style='border-right: .5pt solid black; border-left: none'>(2)= (3)+(4)</td>
				<td colspan="3" class="xl9222116" style='border-right: .5pt solid black; border-left: none'>(3)</td>
				<td colspan="2" class="xl9222116" style='border-right: .5pt solid black; border-left: none'>(4)</td>
			</tr>
			<%if (m_ds != null && m_ds.Tables.Count > 0)
	 {


		 foreach (System.Data.DataRow dr in m_ds.Tables[0].Rows)%>
			<%{%>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>

				<td colspan="8" height="21" class="xl10622116" style='border-right: .5pt solid black; height: 15.95pt'><%=dr[V_DM_GIAI_NGAN.DISPLAY] %></td>
				<td colspan="3" class="xl9522116" style='border-right: .5pt solid black; border-left: none'><%=get_tong_tien(dr[V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE].ToString(),dr[V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG].ToString()) %></td>
				<td colspan="3" class="xl10822116" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(dr[V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE].ToString()) %></td>
				<td colspan="2" class="xl10822116" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(dr[V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG].ToString()) %></td>

			</tr>
			<%}
	 }%>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="8" height="24" class="xl9022116" style='height: 18.0pt'>Cộng</td>
				<td colspan="3" class="xl14222116" style='border-right: .5pt solid black'><%=format_so_tien(m_dc_tong_tien.ToString()) %></td>
				<td colspan="3" class="xl11522116" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(m_dc_tong_tien_nop_thue.ToString()) %></td>
				<td colspan="2" class="xl11522116" style='border-right: .5pt solid black; border-left: none'><%=format_so_tien(m_dc_tong_tien_thanh_toan_cho_don_vi_huong.ToString()) %></td>
			</tr>
			<tr height="26" style='mso-height-source: userset; height: 20.1pt'>
				<td colspan="4" height="26" class="xl7422116" style='height: 20.1pt'>T&#7893;ng
  s&#7889; ti&#7873;n ghi b&#7857;ng ch&#7919;:</td>
				<td colspan="12" class="xl8322116">
					<asp:Label ID="m_lbl_so_tien_ghi_bang_chu" runat="server"></asp:Label>
				</td>
			</tr>
			<tr height="22" style='mso-height-source: userset; height: 16.5pt'>
				<td colspan="12" height="22" class="xl13222116" style='height: 16.5pt'>&nbsp;</td>
				<td rowspan="11" class="xl13122116">&nbsp;</td>
				<td colspan="3" class="xl11922116" style='border-right: .5pt solid black; border-left: none'>KBNN A GHI</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td height="21" class="xl7622116" style='height: 15.95pt'>Trong &#273;ó:</td>
				<td colspan="11" class="xl8822116">&nbsp;</td>
				<td colspan="3" class="xl13322116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>1. N&#7897;p
  thu&#7871;:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="2" height="21" class="xl7522116" style='height: 15.95pt'>N&#7896;P
  THU&#7870;:</td>
				<td colspan="10" class="xl7622116"></td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>N&#7907; TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td height="21" class="xl7422116" colspan="4" style='height: 15.95pt'>Tên
  &#273;&#417;n v&#7883; (Ng&#432;&#7901;i n&#7897;p thu&#7871;):</td>
				<td colspan="8" class="xl13622116">
					<asp:Label ID="m_lbl_nt_ten_don_vi" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>Có TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="5" height="21" class="xl7222116" style='height: 15.95pt'>Mã s&#7889;
  thu&#7871;:<asp:Label ID="m_lbl_nt_ma_so_thue" runat="server" Text="......"></asp:Label></td>
				<td colspan="5" class="xl8422116">Mã NDKT:<asp:Label ID="m_lbl_nt_ma_ndkt" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="2" class="xl8422116">Mã ch&#432;&#417;ng:<asp:Label ID="m_lbl_nt_ma_chuong" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>N&#7907; TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="10" height="21" class="xl7222116" style='height: 15.95pt'>C&#417; quan
  qu&#7843;n lý thu:<asp:Label ID="m_lbl_nt_co_quan_quan_ly_thu" runat="server" Text="........"></asp:Label>
				</td>
				<td colspan="2" class="xl8422116">Mã CQ thu:<asp:Label ID="m_lbl_nt_ma_cq_thu" runat="server" Text="......"></asp:Label>

				</td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>Có TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="12" height="21" class="xl7222116" style='height: 15.95pt'>KBNN
  h&#7841;ch toán kho&#7843;n thu:<asp:Label ID="m_lbl_nt_co_quan_quan_ly_thu0" runat="server" Text="........"></asp:Label>
				</td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>Mã CQ thu:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="12" height="21" class="xl7222116" style='height: 15.95pt'>S&#7889;
  ti&#7873;n n&#7897;p thu&#7871; (Ghi b&#7857;ng ch&#7919;):<asp:Label ID="m_lbl_nt_so_tien_nop_thue" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="3" class="xl8522116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>Mã &#272;BHC:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="12" height="21" class="xl13022116" style='height: 15.95pt'>&nbsp;</td>
				<td colspan="3" class="xl12722116" style='border-left: none'><span
					style='mso-spacerun: yes'></span>2. Thanh toán cho &#272;V h&#432;&#7903;ng:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="12" height="21" class="xl11822116" style='height: 15.95pt'>THANH TOÁN
  CHO &#272;&#416;N V&#7882; H&#431;&#7902;NG:</td>
				<td colspan="3" class="xl12822116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>N&#7907; TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="3" height="21" class="xl11822116" style='height: 15.95pt'>&#272;&#417;n
  v&#7883; nh&#7853;n ti&#7873;n:</td>
				<td colspan="9" class="xl11822116">
					<asp:Label ID="m_lbl_ttdvh_don_vi_nhan_tien" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="3" class="xl13722116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>Có TK:</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td height="21" class="xl7222116" colspan="2" style='height: 15.95pt'>Mã
  &#272;VQHNS:</td>
				<td colspan="4" class="xl8222116">
					<asp:Label ID="m_lbl_ttdvh_ma_dvqhns" runat="server" Text="1057534"></asp:Label>
				</td>
				<td colspan="10" class="xl8122116">&#272;&#7883;a ch&#7881;:<asp:Label ID="m_lbl_ttdvh_dia_chi" runat="server" Text="......"></asp:Label>
				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="4" height="21" class="xl7422116" style='height: 15.95pt'>Tài
  kho&#7843;n:<asp:Label ID="m_lbl_ttdvh_tai_khoan" runat="server" Text="3511"></asp:Label>
				</td>
				<td class="xl8122116" colspan="4">Mã CTMT, DA và HTCT:</td>
				<td colspan="3" class="xl8122116">
					<asp:Label ID="m_lbl_ttdvh_ma_ctmt_da_htct" runat="server" Text="......"></asp:Label>
				</td>
				<td colspan="5" class="xl8122116">T&#7841;i KBNN (NH):<asp:Label ID="m_lbl_ttdvh_tai_kbnn" runat="server" Text="Kho bạc nhà nước Hà Nội"></asp:Label>
				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="16" height="21" class="xl7222116" style='height: 15.95pt'>S&#7889;
  ti&#7873;n thanh toán cho &#273;&#417;n v&#7883; h&#432;&#7903;ng (Ghi
  b&#7857;ng ch&#7919;):<asp:Label ID="m_lbl_ttdvh_so_tien_thanh_toan_dvh" runat="server" Text="Mười tám triệu sáu trăm chín mươi nghìn đồng chẵn"></asp:Label>

				</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.95pt'>
				<td colspan="16" height="21" class="xl13022116" style='height: 15.95pt'>&nbsp;</td>
			</tr>
			<tr height="10" style='mso-height-source: userset; height: 7.5pt'>
				<td colspan="16" height="10" class="xl7522116" style='height: 7.5pt'></td>
			</tr>
			<tr height="23" style='mso-height-source: userset; height: 17.25pt'>
				<td colspan="6" rowspan="2" height="44" class="xl16522116" style='border-right: .5pt solid black; height: 33.0pt'>&#272;&#416;N V&#7882; TR&#7842; TI&#7872;N</td>
				<td colspan="10" class="xl17322116" style='border-right: .5pt solid black; border-left: none'><span
					style='mso-spacerun: yes'></span>KBNN A</td>
			</tr>
			<tr height="21" style='mso-height-source: userset; height: 15.75pt'>
				<td colspan="5" height="21" class="xl17622116" style='height: 15.75pt; border-left: none'>B&#7896; PH&#7852;N KI&#7874;M SOÁT CHI Ngày<span
					style='mso-spacerun: yes'>      </span>/<span style='mso-spacerun: yes'>     
					</span>/<span style='mso-spacerun: yes'>        </span></td>
				<td colspan="5" class="xl17622116" style='border-right: .5pt solid black'>B&#7896;
  PH&#7852;N K&#7870; TOÁN GHI S&#7892;<span style='mso-spacerun: yes'>  
  </span>Ngày<span style='mso-spacerun: yes'>         </span>/<span
	  style='mso-spacerun: yes'>        </span>/<span
		  style='mso-spacerun: yes'>            </span></td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="2" height="24" class="xl16222116" style='height: 18.0pt'>K&#7871; toán
  tr&#432;&#7903;ng</td>
				<td colspan="4" class="xl14522116" style='border-right: .5pt solid black'>Ch&#7911;
  tài kho&#7843;n</td>
				<td colspan="2" class="xl16422116" style='border-left: none'>Ki&#7875;m soát</td>
				<td colspan="3" class="xl14522116" style='border-right: .5pt solid black'>Ph&#7909;
  trách</td>
				<td colspan="5" class="xl16222116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>K&#7871;
  toán<span style='mso-spacerun: yes'>        </span>K&#7871; toán
  tr&#432;&#7903;ng<span style='mso-spacerun: yes'>              </span>Giám
  &#273;&#7889;c</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td height="24" class="xl6522116" style='height: 18.0pt'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6522116">&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td height="24" class="xl6522116" style='height: 18.0pt'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6522116">&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="2" height="24" class="xl17122116" style='height: 18.0pt'><span
					style='mso-spacerun: yes'></span>Nguy&#7877;n Pháo</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6522116">&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<tr height="13" style='mso-height-source: userset; height: 9.75pt'>
				<td height="13" class="xl6822116" style='height: 9.75pt'>&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl7022116">&nbsp;</td>
				<td class="xl6822116" style='border-left: none'>&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6822116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl6922116">&nbsp;</td>
				<td class="xl7122116">&nbsp;</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="9" height="24" class="xl14722116" style='border-right: .5pt solid black; height: 18.0pt'>NGÂN HÀNG A GHI S&#7892; NGÀY</td>
				<td colspan="7" class="xl14722116" style='border-right: .5pt solid black; border-left: none'>KBNN B, NGÂN HÀNG B GHI S&#7892; NGÀY<span
					style='mso-spacerun: yes'>       </span>/<span
						style='mso-spacerun: yes'>        </span>/<span
							style='mso-spacerun: yes'>    </span></td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td colspan="9" height="24" class="xl15922116" style='border-right: .5pt solid black; height: 18.0pt'><span style='mso-spacerun: yes'></span>K&#7871; toán<span
					style='mso-spacerun: yes'>             </span>K&#7871; toán
  tr&#432;&#7903;ng<span style='mso-spacerun: yes'>                  </span>Giám
  &#273;&#7889;c</td>
				<td colspan="7" class="xl15922116" style='border-right: .5pt solid black; border-left: none'><span style='mso-spacerun: yes'></span>K&#7871;
  toán<span style='mso-spacerun: yes'>              </span>K&#7871; toán
  tr&#432;&#7903;ng<span style='mso-spacerun: yes'>                      
  </span>Giám &#273;&#7889;c</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td height="24" class="xl6522116" style='height: 18.0pt'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td height="24" class="xl6522116" style='height: 18.0pt'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<tr height="24" style='mso-height-source: userset; height: 18.0pt'>
				<td height="24" class="xl6522116" style='height: 18.0pt'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6622116">&nbsp;</td>
				<td class="xl6522116" style='border-left: none'>&nbsp;</td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6322116"></td>
				<td class="xl6722116">&nbsp;</td>
			</tr>
			<![if supportMisalignedColumns]>
 <tr height="0" style='display: none'>
	 <td width="74" style='width: 56pt'></td>
	 <td width="32" style='width: 24pt'></td>
	 <td width="28" style='width: 21pt'></td>
	 <td width="43" style='width: 32pt'></td>
	 <td width="16" style='width: 12pt'></td>
	 <td width="37" style='width: 28pt'></td>
	 <td width="73" style='width: 55pt'></td>
	 <td width="31" style='width: 23pt'></td>
	 <td width="11" style='width: 8pt'></td>
	 <td width="54" style='width: 41pt'></td>
	 <td width="53" style='width: 40pt'></td>
	 <td width="81" style='width: 61pt'></td>
	 <td width="11" style='width: 8pt'></td>
	 <td width="51" style='width: 38pt'></td>
	 <td width="94" style='width: 71pt'></td>
	 <td width="56" style='width: 42pt'></td>
 </tr>
			<![endif]>
		</table>
	</div>
	<!----------------------------->
	<!--END OF OUTPUT FROM EXCEL PUBLISH AS WEB PAGE WIZARD-->
	<!----------------------------->
</body>

</html>
