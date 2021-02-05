

insert into station (STATION_NAME) values ('GARE DE l OUEST');
insert into station (STATION_NAME) values ('STOCKEL');
insert into station (STATION_NAME) values ('ESPLANADE');
insert into station (STATION_NAME) values ('CHURCHILL');
insert into station (STATION_NAME) values ('ERASME');
insert into station (STATION_NAME) values ('HERMANN-DEBROUX');
insert into station (STATION_NAME) values ('HEYSEL');
insert into station (STATION_NAME) values ('GARE DU NORD');
insert into station (STATION_NAME) values ('LOUISE');
insert into station (STATION_NAME) values ('ROODEBEEK');


insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (10,1,4,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (0,0,2,8);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (22,0,1,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (8,4,1,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (15,0,7,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (4,3,0,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (17,0,3,0);
insert into weather (temperature,rain_precipitation,wind_precipitation,snow_precipitation) values (0,0,0,9);

insert into category(vehicule_type) values ('TRAM');
insert into category(vehicule_type) values ('METRO');
insert into category(vehicule_type) values ('BUS');

insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (1,1,1,'2021-02-04 08:30:00 AM','2021-02-04 09:30:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (20,3,4,'2021-02-03 06:30:00 AM','2021-02-03 08:30:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (18,4,5,'2021-02-02 04:30:00 AM','2021-02-02 05:15:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (14,5,6,'2021-02-01 07:30:00 AM','2021-02-01 08:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (13,7,8,'2021-01-31 09:30:00 AM','2021-01-31 10:30:00 AM');
	
insert into vehicule(id_line,id_category,delay_min,delay_forecast) values (1,3,6.0,3.4);
insert into vehicule(id_line,id_category,delay_min,delay_forecast) values (2,1,3.0,4.2);
insert into vehicule(id_line,id_category,delay_min,delay_forecast) values (3,3,6.0,5.7);
insert into vehicule(id_line,id_category,delay_min,delay_forecast) values (4,1,2.0,9.4);
insert into vehicule(id_line,id_category,delay_min,delay_forecast) values (5,2,1.0,1.2);

