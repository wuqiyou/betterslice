
(function () {

    "use strict";

    function ContactUsManager(obj) {
        if (obj === undefined) {
            obj = {};
        }
        this.formId = (obj.formId !== undefined ? obj.formId : 'js-contactUsForm');
        this.messageContainerId = (obj.messageContainerId !== undefined ? obj.messageContainerId : 'js-messageContainer');
    }

    ContactUsManager.prototype.init = function () {
        this.contactUsForm = $('#' + this.formId);
        var f = document.getElementById(this.formId);
        f.addEventListener('submit', this.submitForm.bind(this), false);
    }

    ContactUsManager.prototype.submitForm = function (e) {
        e.preventDefault();
        var action = this.contactUsForm.data("action");
        // get the serialized data
        var serializedForm = this.contactUsForm.serialize();
        $.ajax({
            type: "post",
            url: action,
            data: serializedForm,
            dataType: "json",
            context: this
        })
        .done(function (result) {
            this.displayMessage(result.responseText);
            if (result.isSuccessful === true) {
                // Success
                this.hideForm();
            } else {
                // Failure
            }
        })
        .fail(function (result) {
            // Error
            this.displayMessage(result);
        })
    }

    ContactUsManager.prototype.hideForm = function () {
        this.contactUsForm.addClass("is-hidden");
    }

    ContactUsManager.prototype.displayMessage = function (message) {
        $('#' + this.messageContainerId).removeClass("is-hidden");
        $('#' + this.messageContainerId + ' p').text(message);
    }

    window.ContactUsManager = ContactUsManager;

})();

