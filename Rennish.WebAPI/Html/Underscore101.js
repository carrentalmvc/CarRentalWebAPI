/// <reference path="underscore.js" />
var RJ = RJ || {};
RJ.Underscore = (function () {
    var Init = function () {
        function submitClick() {
            var fullName = $("#txtFirstName").value() + $("#txtLastName").value();
            var vm = {
                name: 'Rennish',
                sayHi: function () {
                    console.log("Hello " + fullName);
                }
            };

            
        }
    };
    return {
        Init: Init
    };
})();