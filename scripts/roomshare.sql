--
-- PostgreSQL database dump
--

-- Dumped from database version 12.0 (Debian 12.0-2.pgdg100+1)
-- Dumped by pg_dump version 12.0

-- Started on 2019-11-22 16:00:00

CREATE DATABASE "lemoras-roomshare-db"
    WITH 
    OWNER = lemoras
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;


\connect "lemoras-roomshare-db"

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

--
-- TOC entry 6 (class 2615 OID 16810)
-- Name: kernel; Type: SCHEMA; Schema: -; Owner: lemoras
--

CREATE SCHEMA kernel;


ALTER SCHEMA kernel OWNER TO lemoras;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 16811)
-- Name: application_module; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.application_module (
    application_module_id integer NOT NULL,
    application_id integer DEFAULT 0 NOT NULL,
    module_id integer DEFAULT 0 NOT NULL,
    business_logic_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.application_module OWNER TO lemoras;

--
-- TOC entry 203 (class 1259 OID 16817)
-- Name: application_module_application_module_id_seq; Type: SEQUENCE; Schema: kernel; Owner: lemoras
--

CREATE SEQUENCE kernel.application_module_application_module_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.application_module_application_module_id_seq OWNER TO lemoras;

--
-- TOC entry 2979 (class 0 OID 0)
-- Dependencies: 203
-- Name: application_module_application_module_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.application_module_application_module_id_seq OWNED BY kernel.application_module.application_module_id;


--
-- TOC entry 204 (class 1259 OID 16819)
-- Name: business_logic; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.business_logic (
    business_logic_id integer NOT NULL,
    business_logic_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    business_service_id integer NOT NULL,
    unique_key character varying(50) NOT NULL
);


ALTER TABLE kernel.business_logic OWNER TO lemoras;

--
-- TOC entry 205 (class 1259 OID 16823)
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE; Schema: kernel; Owner: lemoras
--

CREATE SEQUENCE kernel.business_logic_business_logic_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.business_logic_business_logic_id_seq OWNER TO lemoras;

--
-- TOC entry 2980 (class 0 OID 0)
-- Dependencies: 205
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.business_logic_business_logic_id_seq OWNED BY kernel.business_logic.business_logic_id;


--
-- TOC entry 206 (class 1259 OID 16825)
-- Name: business_service; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.business_service (
    business_service_id integer NOT NULL,
    business_service_name character varying(50) DEFAULT '0'::character varying,
    business_service_key character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.business_service OWNER TO lemoras;

--
-- TOC entry 207 (class 1259 OID 16830)
-- Name: business_service_business_service_id_seq; Type: SEQUENCE; Schema: kernel; Owner: lemoras
--

CREATE SEQUENCE kernel.business_service_business_service_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.business_service_business_service_id_seq OWNER TO lemoras;

--
-- TOC entry 2981 (class 0 OID 0)
-- Dependencies: 207
-- Name: business_service_business_service_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.business_service_business_service_id_seq OWNED BY kernel.business_service.business_service_id;


--
-- TOC entry 208 (class 1259 OID 16832)
-- Name: command; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.command (
    command_id integer NOT NULL,
    command_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    business_service_id integer NOT NULL
);


ALTER TABLE kernel.command OWNER TO lemoras;

--
-- TOC entry 209 (class 1259 OID 16836)
-- Name: command_command_id_seq; Type: SEQUENCE; Schema: kernel; Owner: lemoras
--

CREATE SEQUENCE kernel.command_command_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.command_command_id_seq OWNER TO lemoras;

--
-- TOC entry 2982 (class 0 OID 0)
-- Dependencies: 209
-- Name: command_command_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.command_command_id_seq OWNED BY kernel.command.command_id;


--
-- TOC entry 210 (class 1259 OID 16838)
-- Name: role_authorise; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.role_authorise (
    role_authorise_id integer NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    command_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.role_authorise OWNER TO lemoras;

--
-- TOC entry 211 (class 1259 OID 16843)
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE; Schema: kernel; Owner: lemoras
--

CREATE SEQUENCE kernel.role_authorise_role_authorise_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.role_authorise_role_authorise_id_seq OWNER TO lemoras;

--
-- TOC entry 2983 (class 0 OID 0)
-- Dependencies: 211
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.role_authorise_role_authorise_id_seq OWNED BY kernel.role_authorise.role_authorise_id;


--
-- TOC entry 2804 (class 2604 OID 16845)
-- Name: application_module application_module_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module ALTER COLUMN application_module_id SET DEFAULT nextval('kernel.application_module_application_module_id_seq'::regclass);


--
-- TOC entry 2806 (class 2604 OID 16846)
-- Name: business_logic business_logic_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic ALTER COLUMN business_logic_id SET DEFAULT nextval('kernel.business_logic_business_logic_id_seq'::regclass);


--
-- TOC entry 2809 (class 2604 OID 16847)
-- Name: business_service business_service_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_service ALTER COLUMN business_service_id SET DEFAULT nextval('kernel.business_service_business_service_id_seq'::regclass);


--
-- TOC entry 2811 (class 2604 OID 16848)
-- Name: command command_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command ALTER COLUMN command_id SET DEFAULT nextval('kernel.command_command_id_seq'::regclass);


--
-- TOC entry 2814 (class 2604 OID 16849)
-- Name: role_authorise role_authorise_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise ALTER COLUMN role_authorise_id SET DEFAULT nextval('kernel.role_authorise_role_authorise_id_seq'::regclass);


--
-- TOC entry 2964 (class 0 OID 16811)
-- Dependencies: 202
-- Data for Name: application_module; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.application_module (application_module_id, application_id, module_id, business_logic_id) FROM stdin;
\.


--
-- TOC entry 2966 (class 0 OID 16819)
-- Dependencies: 204
-- Data for Name: business_logic; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.business_logic (business_logic_id, business_logic_name, business_service_id, unique_key) FROM stdin;
\.


--
-- TOC entry 2968 (class 0 OID 16825)
-- Dependencies: 206
-- Data for Name: business_service; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.business_service (business_service_id, business_service_name, business_service_key) FROM stdin;
\.


--
-- TOC entry 2970 (class 0 OID 16832)
-- Dependencies: 208
-- Data for Name: command; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.command (command_id, command_name, business_service_id) FROM stdin;
\.


--
-- TOC entry 2972 (class 0 OID 16838)
-- Dependencies: 210
-- Data for Name: role_authorise; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.role_authorise (role_authorise_id, role_id, command_id) FROM stdin;
\.


--
-- TOC entry 2984 (class 0 OID 0)
-- Dependencies: 203
-- Name: application_module_application_module_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.application_module_application_module_id_seq', 65, true);


--
-- TOC entry 2985 (class 0 OID 0)
-- Dependencies: 205
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.business_logic_business_logic_id_seq', 18, true);


--
-- TOC entry 2986 (class 0 OID 0)
-- Dependencies: 207
-- Name: business_service_business_service_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.business_service_business_service_id_seq', 7, true);


--
-- TOC entry 2987 (class 0 OID 0)
-- Dependencies: 209
-- Name: command_command_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.command_command_id_seq', 101, true);


--
-- TOC entry 2988 (class 0 OID 0)
-- Dependencies: 211
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.role_authorise_role_authorise_id_seq', 129, true);


--
-- TOC entry 2819 (class 2606 OID 16851)
-- Name: application_module application_module_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT application_module_pkey PRIMARY KEY (application_module_id);


--
-- TOC entry 2822 (class 2606 OID 16853)
-- Name: business_logic business_logic_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT business_logic_pkey PRIMARY KEY (business_logic_id);


--
-- TOC entry 2824 (class 2606 OID 16855)
-- Name: business_service business_service_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_service
    ADD CONSTRAINT business_service_pkey PRIMARY KEY (business_service_id);


--
-- TOC entry 2827 (class 2606 OID 16857)
-- Name: command command_command_name_key; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_command_name_key UNIQUE (command_name);


--
-- TOC entry 2829 (class 2606 OID 16859)
-- Name: command command_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_pkey PRIMARY KEY (command_id);


--
-- TOC entry 2833 (class 2606 OID 16861)
-- Name: role_authorise role_authorise_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT role_authorise_pkey PRIMARY KEY (role_authorise_id);


--
-- TOC entry 2815 (class 1259 OID 16862)
-- Name: application_module_FK_application_module_appliaciton; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_appliaciton" ON kernel.application_module USING btree (application_id);


--
-- TOC entry 2816 (class 1259 OID 16863)
-- Name: application_module_FK_application_module_business_logic; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_business_logic" ON kernel.application_module USING btree (business_logic_id);


--
-- TOC entry 2817 (class 1259 OID 16864)
-- Name: application_module_FK_application_module_module; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_module" ON kernel.application_module USING btree (module_id);


--
-- TOC entry 2820 (class 1259 OID 16865)
-- Name: business_logic_FK_business_logic_business_service; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "business_logic_FK_business_logic_business_service" ON kernel.business_logic USING btree (business_service_id);


--
-- TOC entry 2825 (class 1259 OID 16866)
-- Name: command_FK_command_business_service; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "command_FK_command_business_service" ON kernel.command USING btree (business_service_id);


--
-- TOC entry 2830 (class 1259 OID 16867)
-- Name: role_authorise_FK_role_authorise_role; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "role_authorise_FK_role_authorise_role" ON kernel.role_authorise USING btree (role_id);


--
-- TOC entry 2831 (class 1259 OID 16868)
-- Name: role_authorise_FK_role_authorise_route; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "role_authorise_FK_role_authorise_route" ON kernel.role_authorise USING btree (command_id);


--
-- TOC entry 2834 (class 2606 OID 16869)
-- Name: application_module FK_application_module_business_logic; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT "FK_application_module_business_logic" FOREIGN KEY (business_logic_id) REFERENCES kernel.business_logic(business_logic_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2835 (class 2606 OID 16874)
-- Name: business_logic FK_business_logic_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT "FK_business_logic_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2836 (class 2606 OID 16879)
-- Name: command FK_command_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT "FK_command_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2837 (class 2606 OID 16884)
-- Name: role_authorise FK_role_authorise_command; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT "FK_role_authorise_command" FOREIGN KEY (command_id) REFERENCES kernel.command(command_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2019-11-22 16:00:00

--
-- PostgreSQL database dump complete
--

