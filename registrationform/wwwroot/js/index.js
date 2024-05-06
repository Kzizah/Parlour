

// Target our html with JavaScript
const menu = document.querySelector('#mobile-menu');
const menuLinks = document.querySelector('.navbar__menu');
const serviceList = document.querySelector('#service-list ul');
const serviceDetails = document.querySelector('#service__details');
const imageDiv = document.querySelector('#service-image'); //This is the service image
const priceDiv = document.querySelector('#service-price');
// const descriptionDiv = document.querySelector('#service-description');
const availableSessionSlotsDiv = document.querySelector('#available-session-slots');
const bookNowBtn = document.querySelector('#book-now');
imageDiv.style.height = "400px";
imageDiv.style.width = "400px";
// Display Mobile Menu
const mobileMenu = () => {
    menu.classList.toggle('is-active');
    menuLinks.classList.toggle('active');
};

// Add an eventistener to toggle the two classes.
// Call the mobileMenu function
menu.addEventListener('click', mobileMenu);


//searchbar
function search_service() {
    let input = document.getElementById('searchbar').value
    input = input.toLowerCase();
    let x = document.getElementsByClassName('services');

    for (i = 0; i < x.length; i++) {
        if (!x[i].innerHTML.toLowerCase().includes(input)) {
            x[i].style.display = "none";
        }
        else {
            x[i].style.display = "list-item";
        }
    }
}

getFirstService()
initialize();
//DOM renders 
function renderOneService(service) {
    //Create list item for each service
    let listItem = document.createElement('li');
    let remainingSlots = service.session_slots - service.booked_slots;
    listItem.innerText = `${service.service_name}`;
    //    const deleteButton = createDeleteButton();
    //    listItem.appendChild(deleteButton);

    //    // attach event listener to delete button
    //    deleteButton.addEventListener('click', () => {
    //      listItem.remove(); // remove service item from DOM
    //    });

    //    serviceList.appendChild(listItem);
    listItem.addEventListener('click', () => {
        //Display service Details
        imageDiv.src = service.image;
        priceDiv.textContent = `Service Price: ${service.price}`;
        //descriptionDiv.textContent = `Description: ${service.description}`;
        availableSessionSlotsDiv.textContent = `Available Session Slots: ${remainingSlots}`;

        // Event listener for buy ticket button clicks
        bookNowBtn.addEventListener("click", (e) => {
            e.preventDefault();
            e.stopPropagation();
            console.log("booked Session!");
            if (updateAvailableSlots(service, 1)) {
                service.booked_slots += 1;
                const outputMessage = document.createElement("p");
                outputMessage.textContent = "You have secured a slot";
                availableSessionSlotsDiv.appendChild(outputMessage);
            } else {
                availableSessionSlotsDiv.textContent = `All sessions booked!`;
            }

        });
        // Event listener for delete button clicks

    });
    serviceList.appendChild(listItem);
}

// Fetch all services
function getAllServices() {
    fetch(' http://localhost:3000/services')
        .then(res => res.json())
        .then(services => services.forEach(service => {
            renderOneService(service)
            // updateAvailablesSlots(service)
        }))
}

//Fetch Requests
//Get Fetch for one service resource
function getFirstService() {
    fetch(' http://localhost:3000/services/1')
        .then(res => res.json())
        .then(services => renderOneService(services))
}

//Initialize Render- It will be the first thing that loads from our index js
//Get Data and load/Render our films to the DOM 
function initialize() {
    getAllServices();
}

// Function to update the available tickets on the frontend
function updateAvailableSlots(service, slotsBooked) {
    const remainingSlots = service.session_slots - service.booked_slots;
    const newRemainingSlots = remainingSlots - slotsBooked;
    if (newRemainingSlots < 1) {
        // Can't book more slots than are available
        return false;
    }
    availableSessionSlotsDiv.textContent = `Available Session Slots: ${newRemainingSlots}`;
    return true;
}



//The addService function takes an service object as a parameter, sends a POST request to the API to add the new service, and then logs the response to the console.
function addService(service) {
    fetch(`http://localhost:3000/services`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(service)
    })
        .then(response => response.json())
        .then(service => {
            console.log('Available SLots updated:', service);
            renderOneService(service); // add the new service to the DOM
            form.reset(); //reset the form
        })
        .catch(error => {
            console.error('Error updating Availabe Slots:', error);
        });



}

//the code selects the form element on the page and adds an event listener for the 'submit' event.
//When the form is submitted, the function creates a new animal object using the values entered in the form fields and passes it to the addAnimal function to add it to the API.
let form = document.querySelector("form");
form.addEventListener('submit', (e) => {
    e.preventDefault();
    //get form values
    let service = {
        service_name: document.getElementById("service").value,
        image: document.getElementById("image-url").value,
        session_slots: document.getElementById("session-slots").value,
        booked_slots: document.getElementById("booked-slots").value,
        price: document.getElementById("session-price").value
    }
    addService(service);
});

// create a delete button for each service item
// function createDeleteButton() {
//     const deleteButton = document.createElement('button');
//     deleteButton.classList.add('delete-btn');
//     deleteButton.innerText = 'Delete';
//     return deleteButton;
//   }

