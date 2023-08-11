let getAllBtn = document.getElementById("btn1");
let getByIdBtn = document.getElementById("btn2");

getAllBtn.addEventListener('click', async () => {
    const response = await fetch('http://localhost:5156/api/users');
    const data = await response.json();
    printData(data);
});

getByIdBtn.addEventListener('click', async () => {
    const userId = parseInt(prompt('Enter user id'));
    if (!isNaN(userId)) {
        const response = await fetch(`http://localhost:5156/api/users/${userId}`);
        const data = await response.json();
        printData(data);
    }
});

function printData(data) {
    output.innerHTML = `<p>${JSON.stringify(data, null, 2)}</p>`;
}
