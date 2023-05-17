let shoes = [];

function display() {
    document.getElementById('resultarea').innerHTML = "";
    shoes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.shoeId + "</td><td>"
            + t.shoeName + "</td></tr>";


    });
}