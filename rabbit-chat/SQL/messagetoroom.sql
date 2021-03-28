drop table messagetoroom;

create table if not exists messagetoroom
(
	messageid integer not null
		constraint messagetoroom_message_id_fk
			references message,
	roomid integer not null
		constraint messagetoroom_room_id_fk
			references room
);

alter table messagetoroom owner to postgres;

create unique index if not exists messagetoroom_messageid_uindex
	on messagetoroom (messageid);

