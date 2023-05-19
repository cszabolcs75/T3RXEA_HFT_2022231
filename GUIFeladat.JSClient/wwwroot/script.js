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
            "<tr><td>" + t.Id + "</td><td>"
        + t.Name + "</td><td>" +
        `<button type="button" onclick="remove(${t.Id})">Delete</button>` +
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


function create() {
    let name = document.getElementById('name').value;
    fetch('http://localhost:2286/shoe', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
   

}

