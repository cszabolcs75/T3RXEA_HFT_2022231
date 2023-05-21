let shoes = [];
let connection = null;

getdata();
let shoeIdToUpdate = -1;


setupSingalR();

function setupSingalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:2286/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ShoeCreated", (user, message) => {
        getdata();
    });

    connection.on("ShoeDeleted", (user, message) => {
        getdata();
    });

    connection.on("ShoeUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}


async function getdata() {
    await fetch('http://localhost:2286/shoe')
        .then(x => x.json())
        .then(y => {
            shoes = y;
           // console.log(shoes);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    shoes.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" +
        t.brandId + "</td><td>" +
        t.sportId + "</td><td>" +
        t.prize + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.id})">Update</button>` +
            "</td></tr>";


    });
}

function remove(id) {
    fetch('http://localhost:2286/shoe/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function showupdate(id) {
    shoeIdToUpdate = id;
    document.getElementById('shoenametoupdate').value = shoes.find(t => t['id'] == id)['name'];
    document.getElementById('shoebrandupdate').value = shoes.find(t => t['id'] == id)['brandId'];
    document.getElementById('shoesportupdate').value = shoes.find(t => t['id'] == id)['sportId'];
    document.getElementById('shoeprizeupdate').value = shoes.find(t => t['id'] == id)['prize'];
    document.getElementById('updateformdiv').style.display = 'flex';
    
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('shoenametoupdate').value;
    let brand = document.getElementById('shoebrandupdate').value;
    let sport = document.getElementById('shoesportupdate').value;
    let prize = document.getElementById('shoeprizeupdate').value;

    fetch('http://localhost:2286/shoe', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { brandId: brand, id: shoeIdToUpdate, sportId: sport, prize: prize, name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('shoename').value;
    let brand = document.getElementById('shoebrand').value;
    let sport = document.getElementById('shoesport').value;
    let prize = document.getElementById('shoeprize').value;
    fetch('http://localhost:2286/shoe', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { brandId: brand, sportId: sport, prize: prize, name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
   

}

