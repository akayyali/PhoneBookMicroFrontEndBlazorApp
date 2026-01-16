export function showPrompt(message) {
    return prompt(message, 'Type anything here');
}


export function showAlert(message) {
    alert(message);
}


export function ConfirmdeleteContact(message) {
    const response = confirm(message);

    if (response) {
        // User clicked OK
        console.log("Item deleted.");
        // Place your deletion logic here (e.g., an API call)
        return true;
    } else {
        // User clicked Cancel
        console.log("Deletion cancelled.");
        return false;
    }
}
