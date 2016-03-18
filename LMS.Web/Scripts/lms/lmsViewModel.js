var bookApiUrl = '/api/Book/';

function lmsViewModel() {
    var self = this;
    self.books = ko.observableArray([]);
    self.error = ko.observable();
    self.title = ko.observable('');
    self.author = ko.observable('');
    self.isbn = ko.observable('');
    self.genre = ko.observable('');
    self.bookDetails = ko.observable();
    self.bookDetailsViewModel = ko.observable();

    self.loadBooks = function () {
        //To load existing books
        $.ajax({
            url: bookApiUrl + "Get?" + "isbnCode=" + self.isbn() + "&title=" + self.title() + "&genre=" + self.genre() + "&author=" + self.author(),
            dataType: "json",
            contentType: "application/json",
            cache: false,
            type: 'GET'
        })
            .done(function (books) {
                self.books([]);
                if (books.length > 0) {
                    $.each(books, function (index, book) {
                        self.books.push(new Book(book));
                    });
                }
            })
            .fail(function () {
                self.error('unable to load books');
            });
    };

    self.GetBookDetails = function (bookId) {
        var rowdata = ko.utils.arrayFirst(self.books(), function (item) {
            return item.bookId === bookId;
        });

        self.bookDetails(new Book(rowdata));
        self.books(null);
        self.bookDetailsViewModel(new bookDetailsViewModel());
        self.bookDetailsViewModel().loadBookDetails(bookId);

    };

    self.loadBooks();
    return self;
};

lmsViewModel.prototype.BackToMainView = function () {
    self = this;
    self.bookDetails(null);
    self.books(null);
    self.loadBooks();
}
ko.applyBindings(new lmsViewModel());

