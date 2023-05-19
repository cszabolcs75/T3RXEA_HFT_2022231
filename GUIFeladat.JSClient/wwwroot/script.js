let shoes = [];


getdata();


async function getdata() {
    await fetch('http://localhost:2286/shoe')
        .then(x => x.json())
        .then(y => {
            shoes = y;
            console.log(shoes);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    shoes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.shoeId + "</td><td>"
            + t.shoeName + "</td></tr>";


    });
}

function create() {
    let name = document.getElementById('shoename').value;
    fetch('http://localhost:2286/shoe', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { shoeName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
   

}

