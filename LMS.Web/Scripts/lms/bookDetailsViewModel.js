var stockApiUrl = '/api/Stock/';

function bookDetailsViewModel() {
    var self = this;
    self.bookDetails = ko.observable();
    self.isBookIssued = ko.observable(false);

    self.loadBookDetails = function (bookId) {
        //To load book details with stock information
        $.ajax({
            url: stockApiUrl + "Get?" + "bookId=" + bookId,
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'GET'
        })
            .done(function (bookdetails) {
                self.loadBookDetails(true)
            })
            .fail(function () {
                self.error('unable to load books');
            });
    };

    return self;
}