--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "rabbit-chat";
--
-- Name: rabbit-chat; Type: DATABASE; Schema: -; Owner: postgres
--

-- CREATE DATABASE "rabbit-chat" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_Canada.1252' LC_CTYPE = 'English_Canada.1252';

CREATE DATABASE "rabbit-chat";

ALTER DATABASE "rabbit-chat" OWNER TO postgres;

\connect -reuse-previous=on "dbname='rabbit-chat'"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: content; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.content (
    id integer NOT NULL,
    content json NOT NULL
);


ALTER TABLE public.content OWNER TO postgres;

--
-- Name: content_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.content_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.content_id_seq OWNER TO postgres;

--
-- Name: content_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.content_id_seq OWNED BY public.content.id;


--
-- Name: message; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.message (
    id integer NOT NULL,
    userfromid integer NOT NULL,
    usertoid integer NOT NULL,
    roomid integer NOT NULL,
    timesent timestamp without time zone NOT NULL,
    contentid integer NOT NULL
);


ALTER TABLE public.message OWNER TO postgres;

--
-- Name: message_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.message_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.message_id_seq OWNER TO postgres;

--
-- Name: message_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.message_id_seq OWNED BY public.message.id;


--
-- Name: messagetoroom; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.messagetoroom (
    messageid integer NOT NULL,
    roomid integer NOT NULL
);


ALTER TABLE public.messagetoroom OWNER TO postgres;

--
-- Name: room; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.room (
    id integer NOT NULL,
    name character varying NOT NULL
);


ALTER TABLE public.room OWNER TO postgres;

--
-- Name: room_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.room_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.room_id_seq OWNER TO postgres;

--
-- Name: room_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.room_id_seq OWNED BY public.room.id;


--
-- Name: rabbituser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rabbituser (
    id integer NOT NULL,
    username character varying NOT NULL,
    password character varying NOT NULL,
    token character varying,
    refreshtoken character varying,
    alias character varying
);


ALTER TABLE public.rabbituser OWNER TO postgres;

--
-- Name: TABLE rabbituser; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.rabbituser IS 'Contains all users and relevant data';


--
-- Name: rabbituser_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rabbituser_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.rabbituser_id_seq OWNER TO postgres;

--
-- Name: rabbituser_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.rabbituser_id_seq OWNED BY public.rabbituser.id;


--
-- Name: usertoroom; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.usertoroom (
    userid integer NOT NULL,
    roomid integer NOT NULL
);


ALTER TABLE public.usertoroom OWNER TO postgres;

--
-- Name: content id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.content ALTER COLUMN id SET DEFAULT nextval('public.content_id_seq'::regclass);


--
-- Name: message id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.message ALTER COLUMN id SET DEFAULT nextval('public.message_id_seq'::regclass);


--
-- Name: room id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room ALTER COLUMN id SET DEFAULT nextval('public.room_id_seq'::regclass);


--
-- Name: rabbituser id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rabbituser ALTER COLUMN id SET DEFAULT nextval('public.rabbituser_id_seq'::regclass);


--
-- Data for Name: content; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: message; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: messagetoroom; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: room; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: rabbituser; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Data for Name: usertoroom; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Name: content_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.content_id_seq', 1, false);


--
-- Name: message_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.message_id_seq', 1, false);


--
-- Name: room_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.room_id_seq', 1, false);


--
-- Name: rabbituser_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rabbituser_id_seq', 1, false);


--
-- Name: content content_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.content
    ADD CONSTRAINT content_pk PRIMARY KEY (id);


--
-- Name: message message_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.message
    ADD CONSTRAINT message_pk PRIMARY KEY (id);


--
-- Name: room room_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.room
    ADD CONSTRAINT room_pk PRIMARY KEY (id);


--
-- Name: rabbituser rabbituser_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rabbituser
    ADD CONSTRAINT rabbituser_pk PRIMARY KEY (id);


--
-- Name: content_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX content_id_uindex ON public.content USING btree (id);


--
-- Name: message_contentid_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX message_contentid_uindex ON public.message USING btree (contentid);


--
-- Name: message_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX message_id_uindex ON public.message USING btree (id);


--
-- Name: messagetoroom_messageid_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX messagetoroom_messageid_uindex ON public.messagetoroom USING btree (messageid);


--
-- Name: room_id_uindex; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX room_id_uindex ON public.room USING btree (id);


--
-- Name: message message_content_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.message
    ADD CONSTRAINT message_content_id_fk FOREIGN KEY (contentid) REFERENCES public.content(id);


--
-- Name: messagetoroom messagetoroom_message_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.messagetoroom
    ADD CONSTRAINT messagetoroom_message_id_fk FOREIGN KEY (messageid) REFERENCES public.message(id);


--
-- Name: messagetoroom messagetoroom_room_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.messagetoroom
    ADD CONSTRAINT messagetoroom_room_id_fk FOREIGN KEY (roomid) REFERENCES public.room(id);


--
-- Name: usertoroom usertoroom_room_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usertoroom
    ADD CONSTRAINT usertoroom_room_id_fk FOREIGN KEY (roomid) REFERENCES public.room(id);


--
-- Name: usertoroom usertoroom_rabbituser_id_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.usertoroom
    ADD CONSTRAINT usertoroom_rabbituser_id_fk FOREIGN KEY (userid) REFERENCES public.rabbituser(id);


--
-- PostgreSQL database dump complete
--
