function myFunction() {
    $.ajax({
        url: 'https://localhost:5001/Project/Details/${projId}',
        type: 'POST'
    }).done((Rewards) => {
        location.reload();
    }).fail((xhr) => {
        alert(xhr.responseText);
    });
}

//${ incentiveId }