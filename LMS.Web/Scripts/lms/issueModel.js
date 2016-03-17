function Issue(data) {
    var self = this;
    data = data || {};
    self.issueId = data.issueId;
    self.issuedTo = data.issuedTo || "";
    self.comments = data.comments || "";
    self.issueDate = data.issueDate;
    return self;
}