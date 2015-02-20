/// <reference path="../knockout-3.2.0.js" />
/// <reference path="../jquery-1.4.1.js" />

//class
function NguoiSuDung(data) {
	this.ID = ko.observable(data.ID);
	this.TEN_TRUY_CAP = ko.observable(data.TEN_TRUY_CAP);
	this.TEN = ko.observable(data.TEN);
	this.MAT_KHAU = ko.observable(data.MAT_KHAU);
}

//Model
function NguoiSuDungViewModel() {
	var self = this;
	self.ID = ko.observable();
	self.TEN_TRUY_CAP = ko.observable();
	self.TEN = ko.observable();
	self.MAT_KHAU = ko.observable();
	self.HT_NGUOI_SU_DUNGs = ko.observableArray([]);






	//get data from server
	$.ajax({
		type: "POST",
		url: '/Test/Test.aspx/getList_HT_NGUOI_SU_DUNG',
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (results) {
			var HTNguoiSuDungs = $.map(results.d, function (item) {
				return new NguoiSuDung(item)
			});
			self.HT_NGUOI_SU_DUNGs(HTNguoiSuDungs);
		},
		error: function (err) {
			alert(err.status + " - " + err.statusText);
		}
	})
};


$(document).ready(function () {
	ko.applyBindings(new NguoiSuDungViewModel());
});