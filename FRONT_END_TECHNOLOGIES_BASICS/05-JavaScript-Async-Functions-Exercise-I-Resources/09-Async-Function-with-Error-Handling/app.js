async function promiseRejectionAsync() {
   try {
      await Promise.reject(new Error('This is a rejected promise'));
   } catch (error) {
      console.log(error);
   }
}
