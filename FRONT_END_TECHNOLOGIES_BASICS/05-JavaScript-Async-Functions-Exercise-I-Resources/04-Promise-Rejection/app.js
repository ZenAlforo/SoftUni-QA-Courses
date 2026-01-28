function promiseRejection() {
    let result = new Promise((resolve, reject) => {
        setTimeout(() => reject("Something went Wrong!"), 1000);
    })

    result.catch((error) => {
        console.log("Error:", error);
    });
}
