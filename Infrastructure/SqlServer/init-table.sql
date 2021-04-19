use fake_Db_STIB;

 



DROP TABLE IF EXISTS WEATHER;
DROP TABLE IF EXISTS TRACKING_DATE;
DROP TABLE IF EXISTS VEHICULE;
DROP TABLE IF EXISTS TRACKING_VEHICULE;
DROP TABLE IF EXISTS CATEGORY;
DROP TABLE IF EXISTS LINE;
DROP TABLE IF EXISTS STATION;

 
 

/*

la station / la gare / l'arret de bus

Possède :

- un id ( identification )

- un nom ( represente le nom de la gare )

*/

CREATE TABLE STATION(

idstat INT IDENTITY NOT NULL,

STATION_NAME VARCHAR(100) NOT NULL

PRIMARY KEY(idstat)

);

/*

Météo

Possède :

- un id ( identification )

- temperature ( la temperature )

-rain_precipitation ( le taux de précipitation de pluie )

-wind_precipitation ( // // de vent )

-snow_precipitation ( // //  de neige )

*/

CREATE TABLE WEATHER(

id INT IDENTITY NOT NULL,

temperature int,

rain_precipitation int,

wind_precipitation int,

snow_precipitation int,

PRIMARY KEY(id)

);

 

 

/*  sert a rien

Date

Possède :

- un id ( identification )

-date_value (la valeur du jours en DD/MM/AAAA)

*/

 

CREATE TABLE TRACKING_DATE(

id INT IDENTITY NOT NULL,

date_value DATETIME NOT NULL,

PRIMARY KEY(id)

);

/*

le voyage du T/B/M

Possède :

-un id ( identification )

-id_station_departure ( la garde de départ )

-id_station_arrival  (la garde d'arrivée )

-hour_departure ( l'heure de depart du vehicule )

-hour_arrival  (l'heure d'arrivé du vehicule )

*/

Create table line

(

id INT IDENTITY not null,

lineNumber int not null,

id_station_departure int not null,

id_station_arrival int not null,

hour_departure datetime not null,

hour_arrival datetime not null,

primary key(idLine),

FOREIGN KEY(id_station_departure) REFERENCES STATION (idstat),

FOREIGN KEY(id_station_arrival) REFERENCES STATION (idstat)

);

/*

la category du vehicule ( T/M/B )

*/

create table category(

idCat int identity not null,

vehicule_type varchar(100) not null,

primary key(idCat)

);

 

 

/*

le vehicule

Possède :

- un id ( identification )

- linenumber ( le numero de la ligne utilisé par le vehicule )

- category ( permet de definir sit T/B/M )

-trip (le trajet du T/B/M) 

-id_date ( la date de déplacement du bus)

pour ameliorer la db ( eviter de faire des moves pour rien ) sinon on respect pas les regles

*/

CREATE TABLE VEHICULE

(

idVeh INT IDENTITY NOT NULL,

id_line INT NOT NULL,

id_category INT not NULL,

/*id_date int not null, */

PRIMARY KEY(idVeh),

/*FOREIGN KEY(id_date) REFERENCES TRACKING_DATE(id),*/

FOREIGN KEY(id_category) REFERENCES category(idCat),

FOREIGN KEY(id_line) REFERENCES line(idLine)

);

 

 

/* 1-N */

create table tracking_vehicule (

                id int identity not null,

                id_vehicule int not null,

                date_observation datetime not null,

                delay_min Time not null,

                delay_forecast Time not null,

                primary key(id),

                FOREIGN KEY(id_vehicule) REFERENCES vehicule(idVeh)

);

use fake_Db_STIB;
drop table line;
create table line (

                id int identity not null,

                date_observation datetime not null,

                delays int not null,

                trip_headsign varchar(100) not null,

				stop_name varchar(100) not null,

				lineNumber int not null,

				vehiculeType varchar(100) not null,

				precip1Hour	float not null,
				precip24Hour float not null,
				precip6Hour	float not null,
				relativeHumidity	float not null,
				snow1Hour	float not null,
				snow24Hour	float not null,
				snow6Hour	float not null,
				temperature float not null,
				temperatureDewPoint float not null,
				temperatureFeelsLike	float not null,
				temperatureMax24Hour	float not null,
				temperatureMin24Hour	float not null,
				uvIndex	float not null,
				visibility	float not null,
				windSpeed	float not null,
				prediction int not null ,

                primary key(id)

);
 


 

