//let myActivities = [];

const url = 'http://localhost:5065/api/Activity';

async function handleOnLoad(){
    //await fetchActivitiesFromAPI();

    const response = await fetch(url);
    const myActivities = await response.json();
    //myActivities = data;

    console.log(myActivities);
    
    let html = `
        <nav class="navbar navbar-light bg-light justify-content-between">
            <a class="navbar-brand">Exercise Tracker</a>
        </nav>
    
        <div class="banner">
            <h1>TideFit</h1>
            <p>Where Legends Are Made!</p>
        </div>
    
        <div id="tableBody"></div>
            
        <form onsubmit="return false">
            <label for="dateCompleted">DateCompleted:</label><br>
            <input type="date" id="dateCompleted" name="dateCompleted"><br>
            <label for="activityName">ActivityName:</label><br>
            <input type="text" id="activityName" name="activityName"><br>
            <label for="distance">Distance:</label><br>
            <input type="text" id="distance" name="distance"><br>
            <button onclick="AddActivity()" class="btn btn-primary">Submit</button>
        </form>`;

    document.getElementById('app').innerHTML = html;
    // populateTable();

    let tablehtml =`
    <table class="table table-striped">
        <tr>
            <th>Date Completed</th>
            <th>Activity Name</th>
            <th>Distance(in miles)</th>
            <th>Pinned</th>
            <th>Delete</th>
        </tr>`;
    myActivities.forEach(function(activity){
        if(activity.deleted === false){
            if(activity.distance == undefined){
                activity.distance = 0;
            }
            tablehtml += `
            <tr class="${activity.pinned ? 'pinned' : ''}">
                <td>${activity.dateCompleted}</td>
                <td>${activity.activityType}</td>
                <td>${activity.distance}</td>
                <td>
                    <button class="btn btn-primary" onclick="PinActivity('${activity.activityID}')">
                        ${activity.pinned ? '  📌  Pinned  📌' : 'Click to Pin'}
                    </button>
                </td>
                <td><button class="btn btn-danger" onclick="DeleteActivity('${activity.activityID}')">Delete</button></td>
            </tr>`;
        }
    })
    tablehtml +=`</table>`

    document.getElementById('tableBody').innerHTML = tablehtml;
    
}

async function AddActivity(){
    let activityDate = document.getElementById('dateCompleted').value;
    let activityType = document.getElementById('activityName').value;
    let activityDistance = document.getElementById('distance').value;

    let newActivity = {
        activityType: activityType,
        dateCompleted: activityDate,
        distance: activityDistance,
        pinned: false,
        deleted: false,
    }

    await fetch(url, {
        method: "POST",
        body: JSON.stringify(newActivity),
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    })

    document.getElementById('dateCompleted').value = '';
    document.getElementById('activityName').value = '';
    document.getElementById('distance').value = '';

    handleOnLoad();
}

async function PinActivity(id) {
    await fetch(url+`/${id}`, {
        method: 'PUT',
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    });
    handleOnLoad();
}

async function DeleteActivity(id) {
    await fetch(url+`/${id}`, {
        method: 'DELETE',
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        }
    });
    handleOnLoad();
}

// async function fetchActivitiesFromAPI() {
//     const response = await fetch('http://localhost:5065/api/Activity');
//     const data = await response.json();
//     myActivities = data;
// }

// async function saveActivityToAPI(newActivity) {
//     await fetch('http://localhost:5065/api/Activity', {
//         method: 'POST',
//         headers: {
//             'Content-Type': 'application/json',
//         },
//         body: JSON.stringify(newActivity),
//     });
//     await fetchActivitiesFromAPI();
// }

// async function deleteActivityFromAPI(id) {
//     await fetch(`http://localhost:5065/api/Activity/${id}`, {
//         method: 'DELETE',
//     });
//     await fetchActivitiesFromAPI();
// }

// async function togglePinnedInAPI(id) {
//     await fetch(`http://localhost:5065/api/Activity/${id}`, {
//         method: 'PUT',
//     });
//     await fetchActivitiesFromAPI();
// }

// function populateTable(){
//     let sortedActivities = myActivities.slice().sort(function(a, b) {
//         return new Date(b.DateCompleted) - new Date(a.DateCompleted);
//     });

//     let html =`
//     <table class="table table-striped">
//         <tr>
//             <th>Date Completed</th>
//             <th>Activity Name</th>
//             <th>Distance(in miles)</th>
//             <th>Pinned</th>
//             <th>Delete</th>
//         </tr>`;
//     sortedActivities.forEach(function(activity){
//         if(activity.Distance == undefined){
//             activity.Distance = 0;
//         }
//         html += `
//         <tr class="${activity.Pinned ? 'pinned' : ''}">
//             <td>${activity.DateCompleted}</td>
//             <td>${activity.ActivityName}</td>
//             <td>${activity.Distance}</td>
//             <td>
//                 <button class="btn btn-primary" onclick="togglePinnedInAPI('${activity.ActivityID}')">
//                     ${activity.Pinned ? '  📌  Pinned  📌' : 'Click to Pin'}
//                 </button>
//             </td>
//             <td><button class="btn btn-danger" onclick="deleteActivityFromAPI('${activity.ActivityID}')">Delete</button></td>
//         </tr>`;
//     })
//     html +=`</table>`

//     document.getElementById('tableBody').innerHTML =html;
// }

// async function handleActivityAdd(){
//     let activity = {DateCompleted: document.getElementById('dateCompleted').value, ActivityName: document.getElementById('activityName').value, Distance: document.getElementById('distance').value, Pinned:false, Deleted: false};
    
//     await saveActivityToAPI(activity);
//     populateTable();

//     document.getElementById('dateCompleted').value = '';
//     document.getElementById('activityName').value = '';
//     document.getElementById('distance').value = '';
// }

// function generateUUID() {
//     return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
//         var r = Math.random() * 16 | 0,
//             v = c === 'x' ? r : (r & 0x3 | 0x8);
//         return v.toString(16);
//     });
// }

// async function togglePinned(id) {
//     let activity = myActivities.find(activity => activity.ActivityID === id);
//     if (activity) {
//         activity.Pinned = !activity.Pinned;
//         await saveActivityToAPI(activity);
//         populateTable(); 
//     }
// }
