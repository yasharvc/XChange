function changeLanguage(sender) {
	$.ajax({
		type: 'POST',
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		url: $(sender).data('request-url'),
		success: function (data) {
			if (data.result) {
				location.reload(true);
			}
		}
	});
}