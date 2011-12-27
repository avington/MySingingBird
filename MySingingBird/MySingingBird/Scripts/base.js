/// <reference path="jquery-1.7.1-vsdoc.js" />

/// <reference path="jquery-1.7.1.min.js" />



$(document).ready(function () {
    twitterMap.LoadMap();
    userRow.Initialize();
});

function twitterMap() { }
twitterMap._map = null;

twitterMap.LoadMap = function () {
    var $maps = $('#search_main_content .map');
    $maps.each(function (index) {
        if (index === 0) {
            twitterMap._map = new Microsoft.Maps.Map(
                this, {
                    credentials: "place key here",
                    center: new Microsoft.Maps.Location(26.225948, -80.188093),
                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                    zoom: 7
                });

            Microsoft.Maps.Events.addHandler(twitterMap._map, "viewchangeend", twitterMap.onViewChangeEnd);
        }
    });
};

twitterMap.onViewChangeEnd = function () {
    var location = twitterMap._map.getCenter();
    var longitude = location.longitude;
    var latitude = location.latitude;
    if (longitude) {
        $('#search_main_content #Longitude').val(longitude);
    }
    if (latitude) {
        $('#search_main_content #Latitude').val(latitude);
    }


};


function userRow() { }
userRow.searchTable = $('#search-table-list');
userRow.Initialize = function () {
    userRow.searchTable.on("click", ".user-review", null, function () {
        console.log('clicked');
        $.getJSON(userRow.ReviewUrl, userRow.getData(this), function (data) {
            userRow.Success(data,this);
        });
    });
};

userRow.ReviewUrl = '/Profile/Analyze';

userRow.getData = function (e) {
    var val = $(e).attr('name');
    return { id: val };

};

userRow.Success = function (data) {
    var rowId = "#row" + data.UserScreenName;
    var $newRow = $("<div>Followers: " + data.FollowerCount + "</div>");
    var $row = $(rowId);
    console.log($row);
    $row.append($newRow);

}