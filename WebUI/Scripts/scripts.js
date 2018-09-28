
var droplist = document.body.getElementsByTagName;
console.log(droplist);
    droplist.click(function (event) {
        event.preventDefault();
        alert("yes");
        console.log("yes in the console");
    });
