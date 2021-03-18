

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

insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (1,1,1,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (20,3,4,'2021-02-03 06:30:00 AM','2021-02-03 08:30:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (18,4,5,'2021-02-02 04:30:00 AM','2021-02-02 05:15:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (14,5,6,'2021-02-01 07:30:00 AM','2021-02-01 08:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (13,7,8,'2021-01-31 09:30:00 AM','2021-01-31 10:30:00 AM');
	
insert into vehicule(id_line,id_category) values (1,3);
insert into vehicule(id_line,id_category) values (2,1);
insert into vehicule(id_line,id_category) values (3,3);
insert into vehicule(id_line,id_category) values (4,1);
insert into vehicule(id_line,id_category) values (5,2);


insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 09:00:00','00:30','00:28');

insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 10:00:00','00:30','00:27');

insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 11:00:00','00:30','00:25');



insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 09:00:00','00:45','00:44');

insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 10:00:00','00:45','00:45');

insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 11:00:00','00:45','00:46');

insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 06:30:00','00:46','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 07:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');







--------------------------------------

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

insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (1,1,1,'2021-02-04 06:30:00 AM','2021-02-04 07:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (2,2,1,'2021-02-04 07:30:00 AM','2021-02-04 08:46:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (3,3,1,'2021-02-04 08:30:00 AM','2021-02-04 09:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (4,4,1,'2021-02-04 09:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (5,5,1,'2021-02-04 10:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (6,6,1,'2021-02-04 11:30:00 AM','2021-02-04 13:15:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (7,7,1,'2021-02-04 12:30:00 AM','2021-02-04 13:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (8,8,1,'2021-02-04 13:30:00 AM','2021-02-04 15:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (9,9,1,'2021-02-04 14:30:00 AM','2021-02-04 15:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (10,10,1,'2021-02-04 15:30:00 AM','2021-02-04 16:15:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (11,1,1,'2021-02-04 16:30:00 AM','2021-02-04 17:45:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (12,1,2,'2021-02-04 17:30:00 AM','2021-02-04 18:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (13,1,3,'2021-02-04 18:30:00 AM','2021-02-04 20:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (14,1,4,'2021-02-04 19:30:00 AM','2021-02-04 21:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (16,1,5,'2021-02-04 20:30:00 AM','2021-02-04 22:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (17,1,6,'2021-02-04 21:30:00 AM','2021-02-04 23:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (18,1,7,'2021-02-04 22:30:00 AM','2021-02-04 23:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (19,1,8,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (20,1,9,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (21,1,10,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (22,2,1,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (23,2,3,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (24,2,3,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (25,2,5,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (26,2,7,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (27,2,4,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (28,2,8,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');
insert into line(lineNumber,id_station_departure,id_station_arrival,hour_departure,hour_arrival) values (29,2,6,'2021-02-04 08:30:00 AM','2021-02-04 12:00:00 AM');

	
insert into vehicule(id_line,id_category) values (1,3);
insert into vehicule(id_line,id_category) values (2,1);
insert into vehicule(id_line,id_category) values (3,3);
insert into vehicule(id_line,id_category) values (4,1);
insert into vehicule(id_line,id_category) values (5,2);
insert into vehicule(id_line,id_category) values (6,3);
insert into vehicule(id_line,id_category) values (7,1);
insert into vehicule(id_line,id_category) values (8,3);
insert into vehicule(id_line,id_category) values (9,1);
insert into vehicule(id_line,id_category) values (10,2);
insert into vehicule(id_line,id_category) values (11,3);
insert into vehicule(id_line,id_category) values (12,1);
insert into vehicule(id_line,id_category) values (14,3);
insert into vehicule(id_line,id_category) values (13,1);
insert into vehicule(id_line,id_category) values (15,2);
insert into vehicule(id_line,id_category) values (16,3);
insert into vehicule(id_line,id_category) values (17,1);
insert into vehicule(id_line,id_category) values (18,3);
insert into vehicule(id_line,id_category) values (19,1);
insert into vehicule(id_line,id_category) values (20,2);	
insert into vehicule(id_line,id_category) values (1,3);
insert into vehicule(id_line,id_category) values (2,1);
insert into vehicule(id_line,id_category) values (3,3);
insert into vehicule(id_line,id_category) values (4,1);
insert into vehicule(id_line,id_category) values (5,2);
insert into vehicule(id_line,id_category) values (1,3);
insert into vehicule(id_line,id_category) values (2,1);
insert into vehicule(id_line,id_category) values (3,3);
insert into vehicule(id_line,id_category) values (4,1);
insert into vehicule(id_line,id_category) values (5,2);



insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 09:00:00','00:30','00:28');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 10:00:00','00:30','00:27');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (1,'2021-01-31 11:00:00','00:30','00:25');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 09:00:00','00:45','00:44');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 10:00:00','00:45','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (3,'2021-01-22 11:00:00','00:45','00:46');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 06:30:00','00:46','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 07:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
insert into tracking_vehicule (id_vehicule,date_observation,delay_forecast,delay_min) 
values (2,'2021-01-31 08:30:00','00:44','00:45');
