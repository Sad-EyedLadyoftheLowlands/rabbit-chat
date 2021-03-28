drop table usertoroom;

create table if not exists usertoroom
(
	userid integer not null
		constraint usertoroom_user_id_fk
			references "user",
	roomid integer not null
		constraint usertoroom_room_id_fk
			references room
);

alter table messagetoroom owner to postgres;