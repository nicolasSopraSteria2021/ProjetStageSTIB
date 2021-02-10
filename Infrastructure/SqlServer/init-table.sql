﻿use fake_Db_STIB;

 



DROP TABLE IF EXISTS WEATHER;
DROP TABLE IF EXISTS TRACKING_DATE;
DROP TABLE IF EXISTS VEHICULE;
DROP TABLE IF EXISTS TRACKING_VEHICULE;
DROP TABLE IF EXISTS STATION;
DROP TABLE IF EXISTS CATEGORY;
DROP TABLE IF EXISTS LINE;


 

 

/*

la station / la gare / l'arret de bus

Possède :

- un id ( identification )

- un nom ( represente le nom de la gare )

*/

CREATE TABLE STATION(

id INT IDENTITY NOT NULL,

STATION_NAME VARCHAR(100) NOT NULL

PRIMARY KEY(id)

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

primary key(id),

FOREIGN KEY(id_station_departure) REFERENCES STATION (id),

FOREIGN KEY(id_station_arrival) REFERENCES STATION (id)

);

/*

la category du vehicule ( T/M/B )

*/

create table category(

id int identity not null,

vehicule_type varchar(100) not null,

primary key(id)

);

 

 

/*

le vehicule

Possède :

- un id ( identification )

- linenumber ( le numero de la ligne utilisé par le vehicule )

- category ( permet de definir sit T/B/M )

-trip (le trajet du T/B/M) 

-delay_min float  ( retard réel)

-delay_forecast (retard prédits )

-id_date ( la date de déplacement du bus)

pour ameliorer la db ( eviter de faire des moves pour rien ) sinon on respect pas les regles

*/

CREATE TABLE VEHICULE

(

id INT IDENTITY NOT NULL,

id_line INT NOT NULL,

id_category INT not NULL,

delay_min float not null,

delay_forecast float not null,

/*id_date int not null, */

PRIMARY KEY(id),

/*FOREIGN KEY(id_date) REFERENCES TRACKING_DATE(id),*/

FOREIGN KEY(id_category) REFERENCES category(id),

FOREIGN KEY(id_line) REFERENCES line(id)

);

 

 

/* 1-N */

create table tracking_vehicule (

                id int identity not null,

                id_vehicule int not null,

                date_observation datetime not null,

                delay_min float not null,

                delay_forecast float not null,

                primary key(id),

                FOREIGN KEY(id_vehicule) REFERENCES vehicule(id)

);