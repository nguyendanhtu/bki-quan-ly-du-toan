(function ($) {
	$.fn.scrollbarTable = function (i) {
		var o = {};
		if (typeof (i) == 'number') o.height = i;
		else if (typeof (i) == 'object') o = i;
		else if (typeof (i) == 'undefined') o = {
			height: 500	//Chieu cao cua table
		}
		return this.each(function () {
			var $t = $(this);
			var w = $t.width();
			$t.width(w - function (width) {
				var parent, child;
				if (width === undefined) {
					parent = $('<div style="width:50px;height:50px;overflow:auto"><div style="height:50px;"></div></div>').appendTo('body');
					child = parent.children();
					width = child.innerWidth() - child.height(99).innerWidth();
					parent.remove();
				}
				return width;
			}());
			var cols = [];
			var tableCols = [];
			$t.find('thead th,thead td').each(function () {
				cols.push($(this).width());
			});
			$t.find('tr:eq(1) th,thead td').each(function () {
				tableCols.push($(this).width());
			});
			var $firstRow = $t.clone();
			$firstRow.find('tbody').remove();
			$t.find('thead').remove();
			$t.before($firstRow);
			$firstRow.find('thead th,thead td').each(function (i) {
				$(this).attr('width', cols[i]);
			});
			$t.find('tr:first th,tr:first td').each(function (i) {
				$(this).attr('width', tableCols[i]);
			});
			var $wrap = $('<div>');
			$wrap.css({
				width: w,
				height: o.height,
				overflow: 'auto'
			});
			$t.wrap($wrap);
		})
	};
}(jQuery));