function bookDetailsViewModel() {
    var self = this;
    self.bookDetails = ko.observable();
    self.isBookIssued = ko.observable(false);

    self.loadBookDetails = function (book) {
        self.bookDetails(new Book(book));
        //////To load book details with stock information
        ////$.ajax({
        ////    url: bookApiUrl + "Get?" + "bookId=" + bookId,
        ////    dataType: "json",
        ////    contentType: "application/json",
        ////    cache: false,
        ////    type: 'GET'
        ////})
        ////    .done(function (bookdetails) {
                
        ////        self.loadBookDetails(true)
        ////    })
        ////    .fail(function () {
        ////        self.error('unable to load books');
        ////    });
    };

    return self;
}