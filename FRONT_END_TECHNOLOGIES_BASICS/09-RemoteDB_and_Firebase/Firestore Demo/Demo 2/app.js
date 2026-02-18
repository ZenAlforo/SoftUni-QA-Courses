// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: import.meta.env.VITE_FIREBASE_API_KEY,
  authDomain: "myfirstproject-55f81.firebaseapp.com",
  projectId: "myfirstproject-55f81",
  storageBucket: "myfirstproject-55f81.firebasestorage.app",
  messagingSenderId: "671671839756",
  appId: "1:671671839756:web:8beebb8bb1d3bd6afe1229",
  measurementId: "G-TGQ378LRDH",
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);
const firestore = firebase.firestore();

// Variable access to the database
const db = firestore.collection("JSAppDemo");

// locate the form submit button
const submitButton = document.getElementById("submit");
// Add an event listener to the submit button
submitButton.addEventListener("click", function (event) {
  event.preventDefault(); // Prevent the default form submission behavior

  // Get from's input fields values
  const firstName = document.getElementById("fname").value;
  const lastName = document.getElementById("lname").value;
  const email = document.getElementById("email").value;
  const country = document.getElementById("country-input").value;

  // Save data to Firebase
  db.doc()
    .set({
      fname: firstName,
      lname: lastName,
      email: email,
      country: country,
    })
    .then(() => {
      console.log("Data is saved!");
    })
    .catch((err) => {
      console.log(err);
    });

  alert("Form submitted successfully!");

  // Function to fetch and display records from Firebase
});

function fetchRecords() {
  const recordsList = document.getElementById("records-list");
  recordsList.innerHTML = ""; // Clear the list before fetching new records

  db.get()
    .then((snapshot) => {
      snapshot.docs.forEach((doc) => {
        const record = doc.data();
        const listItem = document.createElement("li");
        listItem.textContent = `First Name: ${record.fname}, Last Name: ${record.lname}, Email: ${record.email}, Country: ${record.country}`;
        recordsList.appendChild(listItem);
      });
    })
    .catch((err) => {
      console.log("Error fetching records:", err);
    });
}
// Get the button to fetch records and add an event listener
const getRecordsButton = document.getElementById("getRecords");
getRecordsButton.addEventListener("click", fetchRecords);
