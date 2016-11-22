(function () {
    var perfHub = $.connection.chatHub;
    $.connection.hub.logging = false;
    $.connection.hub.start().done(init);


        console.log("ready!");


        perfHub.client.newMessage = function (message) {
            model.addMessage(message);
        };

        perfHub.client.displayMessages = function (messages) {
            console.log("here");
            console.log(messages);
            for (var i = 0; i < messages.length; i++) {
                console.log(messages[i].message1);
                var result;
                if (messages[i].sended)
                    result = "<div class='bubble me'>" + messages[i].message1 + "</div>";
                else {
                    result = "<div class='bubble you'>" + messages[i].message1 + "</div>";
                }
               // $("#getMessages").text("ssss");
                document.getElementById('getOldMessages').innerHTML += result;

            }
        };

        function init() {
            perfHub.server.getmessages();
        }



    var Model = function() {
        var self = this;
        self.message = ko.observable(""),
            self.messages = ko.observableArray();


    };

    Model.prototype = {
        sendMessage: function() {
            var self = this;
            perfHub.server.send(self.message(),id);

            self.message("");
        },
        addMessage: function(message) {
            var self = this;
            self.messages.push(message);
        }
    };

    var model = new Model();

    $(function() {
        ko.applyBindings(model);
    })

}());
