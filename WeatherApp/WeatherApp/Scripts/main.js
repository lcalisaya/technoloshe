$(document).ready(function () {

    //Trae el estado actual del clima y su pronóstico para el lugar en donde se ejecuta la aplicación
    getCurrentLocation();

    //Cuando se hace click en un radio button, que no comience el comportamiento de un link
    $(this).on('click', '.dropdown-menu.dropdown-menu-form', function (e) {
        e.stopPropagation();
    });

    //Se guarda una ciudad en la lista de ciudades del usuario
    $("#save-city").on("submit", function (event) {
        event.preventDefault();

        var dataform = {};
        $(this).serializeArray().map(function (x) { dataform[x.name] = x.value; });

        $.ajax({
            type: "post",
            dataType: "json",
            url: "/User/AddUserCity",
            traditional: true,
            data: JSON.stringify(dataform),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                $('#saved-cities-list').append(`
                    <li class="search-saved-city"><a href="#">${dataform.CityName}</a></li>
                    `
                );
                $(".my-alert-message").fadeIn();
                setTimeout(function () { $(".my-alert-message").slideUp("slow") }, 2000);
            },
            error: function (xhr) {
                alert('ciudad ya guardada.');
            }
        });
    });

    //Para que no se recargue la página cuando se envía el formulario
    $("#save-city-button").click(function (e) {
        e.preventDefault();
        $("#save-city").submit();
    });

    //Si se identificó una ciudad/ubicación, que se muestre el botón de agregar ciudad
    if ($("#location").text().length > 0) {
        $('#addUserCity').show();
    }

    //Si existe el botón en la pantalla, que se oculte después de 3 segundos
    if ($('.my-alert-message-mvc').length) {
        setTimeout(function () { $('.my-alert-message-mvc').slideUp("slow") }, 3000);
    }; 

    //Cuando se selecciona una de las ciudades guardadas se busca su pronóstico
    $("#saved-cities-list li").on("click", function () {
        const userCity = $(this).text();
        findForecast(userCity);
    });

});

// El Javascript de aquí en adelante pertenece a: Ayo Isaiah
// Github: https://github.com/ayoisaiah/weather-app

const App = {
    city: {
        address: undefined,
        longitude: 0,
        latitude: 0
    },
    weatherForecast: {},
    icons: []
};

function skycons(icons) {
    const skycons = new Skycons({ "color": "#0A0A0A" });
    let canvas = document.getElementsByClassName("canvas");
    console.log(icons);
    console.log(canvas);
    for (let i = 0; i < canvas.length; i++) {
        skycons.add(canvas[i + 1], icons[i]);
    }
    skycons.play();
}

function getCurrentLocation() {
    // Usar la API de Geolocalización de HTML5 si el navegador lo soporta
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            App.city.latitude = position.coords.latitude;
            App.city.longitude = position.coords.longitude;
            geoLocate("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + App.city.latitude + "," + App.city.longitude + "&key=AIzaSyDaZ1O_Gyi-g6Od-U5jyihHroAD5UGVQT4", "geolocation");
        });
    } else {
        // Alternar al método de rastreo con la dirección IP
        $.ajax({
            url: "http://ipinfo.io",
            dataType: "jsonp",
            success: function (data) {
                App.city.longitude = data.loc.split(",")[1];
                App.city.latitude = data.loc.split(",")[0];
            }
        }).done(function () {
            geoLocate("https://maps.googleapis.com/maps/api/geocode/json?latlng=" + App.city.latitude + "," + App.city.longitude + "&key=AIzaSyDaZ1O_Gyi-g6Od-U5jyihHroAD5UGVQT4", "ip");
        });
    }
}

// Obtener los datos de ubicación de la API de Mapas de Google
function geoLocate(url, call) {
    $.ajax({
        url: url,
        success: function (res) {
            //App.city.address = res.results[0].formatted_address;
            App.city.address = res.results[0].address_components[res.results[0].address_components.length - 2].long_name + ", " + res.results[0].address_components[res.results[0].address_components.length - 1].long_name;
            App.city.longitude = res.results[0].geometry.location.lng;
            App.city.latitude = res.results[0].geometry.location.lat;
        }
    }).done(function () {
        getWeatherInfo();
    });
}

// Obtener los datos del clima de DarkSky
function getWeatherInfo() {
    const long = App.city.longitude;
    const lat = App.city.latitude;
    const url = "https://api.darksky.net/forecast/ef3f9f4e547cb7691002e43fed74a9a4/" + lat + "," + long + "/?lang=es";
    $.ajax({
        url: url,
        dataType: "jsonp",
        success: function (json) {
            App.weatherForecast = json;
            console.log(json);
        }
    }).done(function () {
        updateWeatherInfo(App.weatherForecast);
    });
}

// Actualizar la información del clima de la app
function updateWeatherInfo(data) {
    $(".today-grid, .tomorrow, .later").empty();
    App.icons = [];
    currently(data.currently);

    hourly(data.hourly);

    later(data.daily);

    skycons(App.icons);
}

// Actualizar la información del clima (disponible en la pestaña 'today' )
function currently(current) {
    $(".location").text(App.city.address);
    $("#add-hidden").children().remove();
    $("#add-hidden").append(`<input type="hidden" name="CityName" value="${App.city.address}"/>`);
    $(".temperature").text(convertTemperature(current.temperature));
    $(".description").text(current.summary);
    $(".wind").text("Viento: " + current.windSpeed + " m/s");
    $(".pressure").text("Presión: " + current.pressure + " hPa");
    $(".humidity").text("Humedad: " + (current.humidity * 100).toFixed(0) + "%");
    $(".last-updated").text(`Última actualización a las ${convertTimeStamp(current.time).time} hs.`);

    App.icons.push(current.icon);
}

// Datos del clima para las tarjetas 'today' y 'tomorrow'
function hourly(hour) {

    for (let i = 1; i < (48 - convertTimeStamp(App.weatherForecast.currently.time).time.slice(0, 2)); i++) {
        let hourlyData = {
            temperature: "Temperatura: " + convertTemperature(hour.data[i].temperature),
            description: hour.data[i].summary,
            wind: "Viento: " + hour.data[i].windSpeed + " m/s",
            pressure: "Presión: " + hour.data[i].pressure + " hPa",
            humidity: "Humedad: " + (hour.data[i].humidity * 100).toFixed(0) + "%",
            date: convertTimeStamp(hour.data[i].time).fullDate,
            time: convertTimeStamp(hour.data[i].time).time,
            currentDay: convertTimeStamp(hour.data[i].time).currentDay,
            icon: hour.data[i].icon
        };

        App.icons.push(hourlyData.icon);

        let currentDay = convertTimeStamp(App.weatherForecast.currently.time).fullDate.slice(0, 2);

        let tab = (parseInt(currentDay) == hourlyData.date.slice(0, 2)) ? ".today-grid" : ".tomorrow";

        updateDom(hourlyData, tab);
    }
}

// Datos para las tarjetas del clima de 'later'

function later(daily) {

    for (let i = 2; i <= 7; i++) {

        let dailyData = {
            temperature: "Temperatura: " + convertTemperature(daily.data[i].temperatureMin) + " - " + convertTemperature(daily.data[i].temperatureMax),
            description: daily.data[i].summary,
            wind: `Viento: ${daily.data[i].windSpeed} m/s`,
            pressure: `Presión: ${daily.data[i].pressure} hPa`,
            humidity: `Humedad: ${(daily.data[i].humidity * 100).toFixed(0)} %`,
            date: convertTimeStamp(daily.data[i].time).fullDate,
            time: convertTimeStamp(daily.data[i].time).time,
            currentDay: convertTimeStamp(daily.data[i].time).currentDay,
            sunrise: convertTimeStamp(daily.data[i].sunriseTime).time,
            sunset: convertTimeStamp(daily.data[i].sunsetTime).time,
            icon: daily.data[i].icon
        };

        App.icons.push(dailyData.icon);

        updateDom(dailyData, ".later");
    }

}

// Tarjetas del clima

function updateDom(data, element) {

    if (element == ".later") {
        $(element).append(`
                    <div class="panel panel-default">
                        <div class="panel-heading text-right"><h3>${data.currentDay} ${data.date}</h3></div>
                        <div class="panel-body father-left">
                            <div class="son">
                                <canvas class="canvas" width="200" height="200"></canvas>
                            </div>
                            <div class="son">
                                <h2 class="description">${data.description}</h2>
                                <h3 class="temperature">${data.temperature}</h3>
                                <h4 class="wind">${data.wind}</h4>
                                <h4 class="pressure">${data.pressure}</h4>
                                <h4 class="humidity">${data.humidity}</h4>
                                <h4 class="sunrise">Salida del Sol: ${data.sunrise} hs.</h4>
                                <h4 class="sunset">Puesta del Sol: ${data.sunset} hs.</h4>
                            </div>
                        </div>
                    </div>
                   `
        );
    }
    else {
        $(element).append(`
                    <div class="panel panel-default">
                        <div class="panel-heading text-right"><h3>${data.currentDay} ${data.date} - ${data.time} hs.</h3></div>
                        <div class="panel-body father-left-center">
                            <div class="son">
                                <canvas class="canvas" width="200" height="200"></canvas>
                            </div>
                            <div class="son">
                                <h2 class="description">${data.description}</h2>
                                <h3 class="temperature">${data.temperature}</h3>
                                <h4 class="wind">${data.wind}</h4>
                                <h4 class="pressure">${data.pressure}</h4>
                                <h4 class="humidity">${data.humidity}</h4>
                            </div>
                        </div>
                        
                    </div>
                   `
        );
    }
}

// Algunos detectores de eventos (event listeners)

$("#search-form").on("submit", function (event) {
    event.preventDefault();
    const city = $("#search-field").val().trim();
    findForecast(city);
    document.querySelector("#search-form").reset();
});

$(".search-button").click(function (e) {
    e.preventDefault();
    $("#search-form").submit();
});

$(".refresh-weather").click(function (e) {
    e.preventDefault();
    getWeatherInfo(App.city.longitude, App.city.latitude);
});

$(".celsius, .fahrenheit").on("click", function () {
    getWeatherInfo(App.city.longitude, App.city.latitude);
});

// Función de búsqueda

function findForecast(city) {
    geoLocate("https://maps.googleapis.com/maps/api/geocode/json?address=" + city + "&key=AIzaSyDaZ1O_Gyi-g6Od-U5jyihHroAD5UGVQT4", "search");
}

// Convertidor de Fahrenheit a Celsius

function convertTemperature(temp) {
    if ($(".celsius").is(":checked")) {
        return ((temp - 32) * (5 / 9)).toFixed(0) + "°C";
    } else {
        return (temp.toFixed(0) + "°F");
    }
}

// Convertidor de tiempo UNIX a legible para la gente

function convertTimeStamp(timestamp) {

    let date = new Date(timestamp * 1000),
        days = ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        currentDay = days[date.getDay()],
        year = date.getFullYear(),
        month = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2),
        hours = ("0" + date.getHours()).slice(-2),
        minutes = ("0" + date.getMinutes()).slice(-2),
        seconds = ("0" + date.getSeconds()).slice(-2);

    return {
        currentDay: currentDay,
        fullDate: day + "." + month + "." + year,
        time: hours + ":" + minutes
    };
}

