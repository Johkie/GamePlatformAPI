var URL_HighscoreAPI = "https://localhost:44321/api/HighscoreItems"
var URL_UserSettingsAPI = "https://localhost:44321/api/UserSettings"

async function getDataAsync(url)
{
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

function buildHighscoreList()
{
    getDataAsync(URL_HighscoreAPI).then(data => {
        data.forEach(element => {
            // Create highscoreitem
            var HsRow = document.createElement("tr");
            HsRow.className = "HsItem"
            HsRow.id = HsRow.className + element.id;
 
            HsRow.insertCell(0).innerHTML = element.id;
            HsRow.insertCell(1).innerHTML = element.user;
            HsRow.insertCell(2).innerHTML = element.score;
            document.getElementById("hsTable").appendChild(HsRow);
        });
    });
}

function buildUserSettings()
{
    getDataAsync(URL_UserSettingsAPI).then(data => {
        data.forEach(element => {
            // Create highscoreitem
            var settings = document.createElement("p");
            settings.className = "USItem"
            settings.id = settings.className + element.id;
 
            settings.innerHTML = element.userId + " | " + element.ballColor;
            document.getElementById("settings").appendChild(settings);
        });
    })
}

function buildSite()
{
    buildHighscoreList()
    buildUserSettings();
}
