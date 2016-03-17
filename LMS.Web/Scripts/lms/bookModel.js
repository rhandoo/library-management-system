function Book(data) {
    var self = this;
    data = data || {};
    self.bookId = data.bookId;
    self.title = data.title || "";
    self.isbnCode = data.isbnCode || "";
    self.author = data.author || "";
    self.genre = data.genre || "";
    return self;
}