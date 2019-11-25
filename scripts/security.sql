--
-- PostgreSQL database dump
--

-- Dumped from database version 12.0 (Debian 12.0-2.pgdg100+1)
-- Dumped by pg_dump version 12.0

-- Started on 2019-11-22 15:53:41

CREATE DATABASE "lemoras-security-db"
    WITH 
    OWNER = lemoras
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

\connect "lemoras-security-db"

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
-- TOC entry 5 (class 2615 OID 16890)
-- Name: kernel; Type: SCHEMA; Schema: -; Owner: lemoras
--

CREATE SCHEMA kernel;


ALTER SCHEMA kernel OWNER TO lemoras;

--
-- TOC entry 8 (class 2615 OID 16891)
-- Name: security; Type: SCHEMA; Schema: -; Owner: lemoras
--

CREATE SCHEMA security;


ALTER SCHEMA security OWNER TO lemoras;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 203 (class 1259 OID 16892)
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
-- TOC entry 204 (class 1259 OID 16898)
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
-- TOC entry 3026 (class 0 OID 0)
-- Dependencies: 204
-- Name: application_module_application_module_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.application_module_application_module_id_seq OWNED BY kernel.application_module.application_module_id;


--
-- TOC entry 205 (class 1259 OID 16900)
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
-- TOC entry 206 (class 1259 OID 16904)
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
-- TOC entry 3027 (class 0 OID 0)
-- Dependencies: 206
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.business_logic_business_logic_id_seq OWNED BY kernel.business_logic.business_logic_id;


--
-- TOC entry 207 (class 1259 OID 16906)
-- Name: business_service; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.business_service (
    business_service_id integer NOT NULL,
    business_service_name character varying(50) DEFAULT '0'::character varying,
    business_service_key character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.business_service OWNER TO lemoras;

--
-- TOC entry 208 (class 1259 OID 16911)
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
-- TOC entry 3028 (class 0 OID 0)
-- Dependencies: 208
-- Name: business_service_business_service_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.business_service_business_service_id_seq OWNED BY kernel.business_service.business_service_id;


--
-- TOC entry 209 (class 1259 OID 16913)
-- Name: command; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.command (
    command_id integer NOT NULL,
    command_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    business_service_id integer NOT NULL
);


ALTER TABLE kernel.command OWNER TO lemoras;

--
-- TOC entry 210 (class 1259 OID 16917)
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
-- TOC entry 3029 (class 0 OID 0)
-- Dependencies: 210
-- Name: command_command_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.command_command_id_seq OWNED BY kernel.command.command_id;


--
-- TOC entry 211 (class 1259 OID 16919)
-- Name: role_authorise; Type: TABLE; Schema: kernel; Owner: lemoras
--

CREATE TABLE kernel.role_authorise (
    role_authorise_id integer NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    command_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.role_authorise OWNER TO lemoras;

--
-- TOC entry 212 (class 1259 OID 16924)
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
-- TOC entry 3030 (class 0 OID 0)
-- Dependencies: 212
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: lemoras
--

ALTER SEQUENCE kernel.role_authorise_role_authorise_id_seq OWNED BY kernel.role_authorise.role_authorise_id;


--
-- TOC entry 213 (class 1259 OID 16926)
-- Name: user_user_id_seq; Type: SEQUENCE; Schema: security; Owner: lemoras
--

CREATE SEQUENCE security.user_user_id_seq
    START WITH 21
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


ALTER TABLE security.user_user_id_seq OWNER TO lemoras;

--
-- TOC entry 214 (class 1259 OID 16928)
-- Name: user; Type: TABLE; Schema: security; Owner: lemoras
--

CREATE TABLE security."user" (
    user_id integer DEFAULT nextval('security.user_user_id_seq'::regclass) NOT NULL,
    username character varying(50) DEFAULT '0'::character varying NOT NULL,
    password character varying(50) DEFAULT '0'::character varying NOT NULL,
    email character varying(50) DEFAULT '0'::character varying NOT NULL,
    first_name character varying(50),
    last_name character varying(50),
    active boolean,
    last_login_date timestamp without time zone
);


ALTER TABLE security."user" OWNER TO lemoras;

--
-- TOC entry 215 (class 1259 OID 16935)
-- Name: user_contact_user_contact_id_seq; Type: SEQUENCE; Schema: security; Owner: lemoras
--

CREATE SEQUENCE security.user_contact_user_contact_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


ALTER TABLE security.user_contact_user_contact_id_seq OWNER TO lemoras;

--
-- TOC entry 216 (class 1259 OID 16937)
-- Name: user_contact; Type: TABLE; Schema: security; Owner: lemoras
--

CREATE TABLE security.user_contact (
    user_contact_id integer DEFAULT nextval('security.user_contact_user_contact_id_seq'::regclass) NOT NULL,
    user_id integer DEFAULT 0 NOT NULL,
    phone character varying(13) DEFAULT '0'::character varying NOT NULL,
    fax character varying(13) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE security.user_contact OWNER TO lemoras;

--
-- TOC entry 217 (class 1259 OID 16944)
-- Name: user_role_user_role_id_seq; Type: SEQUENCE; Schema: security; Owner: lemoras
--

CREATE SEQUENCE security.user_role_user_role_id_seq
    START WITH 31
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;


ALTER TABLE security.user_role_user_role_id_seq OWNER TO lemoras;

--
-- TOC entry 218 (class 1259 OID 16946)
-- Name: user_role; Type: TABLE; Schema: security; Owner: lemoras
--

CREATE TABLE security.user_role (
    user_role_id integer DEFAULT nextval('security.user_role_user_role_id_seq'::regclass) NOT NULL,
    user_id integer DEFAULT 0 NOT NULL,
    application_instance_id integer DEFAULT 0 NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    application_id integer NOT NULL,
    application_tag_name character varying(50)
);


ALTER TABLE security.user_role OWNER TO lemoras;

--
-- TOC entry 2823 (class 2604 OID 16953)
-- Name: application_module application_module_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module ALTER COLUMN application_module_id SET DEFAULT nextval('kernel.application_module_application_module_id_seq'::regclass);


--
-- TOC entry 2825 (class 2604 OID 16954)
-- Name: business_logic business_logic_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic ALTER COLUMN business_logic_id SET DEFAULT nextval('kernel.business_logic_business_logic_id_seq'::regclass);


--
-- TOC entry 2828 (class 2604 OID 16955)
-- Name: business_service business_service_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_service ALTER COLUMN business_service_id SET DEFAULT nextval('kernel.business_service_business_service_id_seq'::regclass);


--
-- TOC entry 2830 (class 2604 OID 16956)
-- Name: command command_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command ALTER COLUMN command_id SET DEFAULT nextval('kernel.command_command_id_seq'::regclass);


--
-- TOC entry 2833 (class 2604 OID 16957)
-- Name: role_authorise role_authorise_id; Type: DEFAULT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise ALTER COLUMN role_authorise_id SET DEFAULT nextval('kernel.role_authorise_role_authorise_id_seq'::regclass);


--
-- TOC entry 3005 (class 0 OID 16892)
-- Dependencies: 203
-- Data for Name: application_module; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.application_module (application_module_id, application_id, module_id, business_logic_id) FROM stdin;
67	6	2	21
68	1	2	22
69	2	2	22
\.


--
-- TOC entry 3007 (class 0 OID 16900)
-- Dependencies: 205
-- Data for Name: business_logic; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.business_logic (business_logic_id, business_logic_name, business_service_id, unique_key) FROM stdin;
21	User_Service_Logic	9	UserService
22	Limited_User_Service_Logic	9	LimitedUserService
\.


--
-- TOC entry 3009 (class 0 OID 16906)
-- Dependencies: 207
-- Data for Name: business_service; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.business_service (business_service_id, business_service_name, business_service_key) FROM stdin;
9	User_Service	IUserService
\.


--
-- TOC entry 3011 (class 0 OID 16913)
-- Dependencies: 209
-- Data for Name: command; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.command (command_id, command_name, business_service_id) FROM stdin;
104	GetUser	9
105	GetUsers	9
106	UpdateUser	9
107	DeleteUser	9
\.


--
-- TOC entry 3013 (class 0 OID 16919)
-- Dependencies: 211
-- Data for Name: role_authorise; Type: TABLE DATA; Schema: kernel; Owner: lemoras
--

COPY kernel.role_authorise (role_authorise_id, role_id, command_id) FROM stdin;
150	7	104
151	7	105
152	7	106
153	7	107
154	6	104
155	6	105
156	6	106
157	6	107
158	11	104
159	11	105
160	11	106
161	11	107
\.


--
-- TOC entry 3016 (class 0 OID 16928)
-- Dependencies: 214
-- Data for Name: user; Type: TABLE DATA; Schema: security; Owner: lemoras
--

COPY security."user" (user_id, username, password, email, first_name, last_name, active, last_login_date) FROM stdin;
1	admin	admin	onur.yasar@tatilsepeti.com	onur	yaşar	t	2019-10-20 11:05:28
2	omerdelikaya	123456	omder.delikaya@sompojapan.com.tr	Ömer	Delikaya	t	2019-03-08 09:33:10
3	sabri	123	sabri@umur.com.tr	Sabri Asil	Eyüp	t	2019-07-16 17:27:34
24	dila	dila	dila.coskun@umur.com.tr	dila	coşkun	t	2019-04-05 06:37:38
25	hasan	hasan	hasan@gmail.com	hasan	yaşar	t	2019-06-30 12:12:41
26	omer	123	omer@lemoras.com	Hasan Ömer	Yaşar	t	2019-06-30 13:30:39
\.


--
-- TOC entry 3018 (class 0 OID 16937)
-- Dependencies: 216
-- Data for Name: user_contact; Type: TABLE DATA; Schema: security; Owner: lemoras
--

COPY security.user_contact (user_contact_id, user_id, phone, fax) FROM stdin;
1	1	0	0
\.


--
-- TOC entry 3020 (class 0 OID 16946)
-- Dependencies: 218
-- Data for Name: user_role; Type: TABLE DATA; Schema: security; Owner: lemoras
--

COPY security.user_role (user_role_id, user_id, application_instance_id, role_id, application_id, application_tag_name) FROM stdin;
32	1	8	11	1	Lemoras E-Ticaret
34	2	5	5	2	Sompo E-Commerce
35	3	5	5	2	Sompo E-Commerce
36	24	5	5	2	Sompo E-Commerce
38	25	5	6	2	Sompo E-Commerce
39	26	8	11	1	Lemoras E-Ticaret
41	1	5	6	2	Sompo E-Commerce
40	1	7	7	6	Tüm Sistemin Admin Uygulaması
\.


--
-- TOC entry 3031 (class 0 OID 0)
-- Dependencies: 204
-- Name: application_module_application_module_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.application_module_application_module_id_seq', 69, true);


--
-- TOC entry 3032 (class 0 OID 0)
-- Dependencies: 206
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.business_logic_business_logic_id_seq', 22, true);


--
-- TOC entry 3033 (class 0 OID 0)
-- Dependencies: 208
-- Name: business_service_business_service_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.business_service_business_service_id_seq', 9, true);


--
-- TOC entry 3034 (class 0 OID 0)
-- Dependencies: 210
-- Name: command_command_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.command_command_id_seq', 107, true);


--
-- TOC entry 3035 (class 0 OID 0)
-- Dependencies: 212
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: lemoras
--

SELECT pg_catalog.setval('kernel.role_authorise_role_authorise_id_seq', 161, true);


--
-- TOC entry 3036 (class 0 OID 0)
-- Dependencies: 215
-- Name: user_contact_user_contact_id_seq; Type: SEQUENCE SET; Schema: security; Owner: lemoras
--

SELECT pg_catalog.setval('security.user_contact_user_contact_id_seq', 1, true);


--
-- TOC entry 3037 (class 0 OID 0)
-- Dependencies: 217
-- Name: user_role_user_role_id_seq; Type: SEQUENCE SET; Schema: security; Owner: lemoras
--

SELECT pg_catalog.setval('security.user_role_user_role_id_seq', 41, true);


--
-- TOC entry 3038 (class 0 OID 0)
-- Dependencies: 213
-- Name: user_user_id_seq; Type: SEQUENCE SET; Schema: security; Owner: lemoras
--

SELECT pg_catalog.setval('security.user_user_id_seq', 26, true);


--
-- TOC entry 2850 (class 2606 OID 16959)
-- Name: application_module application_module_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT application_module_pkey PRIMARY KEY (application_module_id);


--
-- TOC entry 2853 (class 2606 OID 16961)
-- Name: business_logic business_logic_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT business_logic_pkey PRIMARY KEY (business_logic_id);


--
-- TOC entry 2855 (class 2606 OID 16963)
-- Name: business_service business_service_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_service
    ADD CONSTRAINT business_service_pkey PRIMARY KEY (business_service_id);


--
-- TOC entry 2858 (class 2606 OID 16965)
-- Name: command command_command_name_key; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_command_name_key UNIQUE (command_name);


--
-- TOC entry 2860 (class 2606 OID 16967)
-- Name: command command_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_pkey PRIMARY KEY (command_id);


--
-- TOC entry 2864 (class 2606 OID 16969)
-- Name: role_authorise role_authorise_pkey; Type: CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT role_authorise_pkey PRIMARY KEY (role_authorise_id);


--
-- TOC entry 2869 (class 2606 OID 16971)
-- Name: user_contact user_contact_pkey; Type: CONSTRAINT; Schema: security; Owner: lemoras
--

ALTER TABLE ONLY security.user_contact
    ADD CONSTRAINT user_contact_pkey PRIMARY KEY (user_contact_id);


--
-- TOC entry 2866 (class 2606 OID 16973)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: security; Owner: lemoras
--

ALTER TABLE ONLY security."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (user_id);


--
-- TOC entry 2872 (class 2606 OID 16975)
-- Name: user_role user_role_pkey; Type: CONSTRAINT; Schema: security; Owner: lemoras
--

ALTER TABLE ONLY security.user_role
    ADD CONSTRAINT user_role_pkey PRIMARY KEY (user_role_id);


--
-- TOC entry 2846 (class 1259 OID 16976)
-- Name: application_module_FK_application_module_appliaciton; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_appliaciton" ON kernel.application_module USING btree (application_id);


--
-- TOC entry 2847 (class 1259 OID 16977)
-- Name: application_module_FK_application_module_business_logic; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_business_logic" ON kernel.application_module USING btree (business_logic_id);


--
-- TOC entry 2848 (class 1259 OID 16978)
-- Name: application_module_FK_application_module_module; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "application_module_FK_application_module_module" ON kernel.application_module USING btree (module_id);


--
-- TOC entry 2851 (class 1259 OID 16979)
-- Name: business_logic_FK_business_logic_business_service; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "business_logic_FK_business_logic_business_service" ON kernel.business_logic USING btree (business_service_id);


--
-- TOC entry 2856 (class 1259 OID 16980)
-- Name: command_FK_command_business_service; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "command_FK_command_business_service" ON kernel.command USING btree (business_service_id);


--
-- TOC entry 2861 (class 1259 OID 16981)
-- Name: role_authorise_FK_role_authorise_role; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "role_authorise_FK_role_authorise_role" ON kernel.role_authorise USING btree (role_id);


--
-- TOC entry 2862 (class 1259 OID 16982)
-- Name: role_authorise_FK_role_authorise_route; Type: INDEX; Schema: kernel; Owner: lemoras
--

CREATE INDEX "role_authorise_FK_role_authorise_route" ON kernel.role_authorise USING btree (command_id);


--
-- TOC entry 2867 (class 1259 OID 16983)
-- Name: user_contact_FK_user_contact_user; Type: INDEX; Schema: security; Owner: lemoras
--

CREATE INDEX "user_contact_FK_user_contact_user" ON security.user_contact USING btree (user_id);


--
-- TOC entry 2870 (class 1259 OID 16984)
-- Name: user_role_FK_user_role_user; Type: INDEX; Schema: security; Owner: lemoras
--

CREATE INDEX "user_role_FK_user_role_user" ON security.user_role USING btree (user_id);


--
-- TOC entry 2873 (class 2606 OID 16985)
-- Name: application_module FK_application_module_business_logic; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT "FK_application_module_business_logic" FOREIGN KEY (business_logic_id) REFERENCES kernel.business_logic(business_logic_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2874 (class 2606 OID 16990)
-- Name: business_logic FK_business_logic_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT "FK_business_logic_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2875 (class 2606 OID 16995)
-- Name: command FK_command_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT "FK_command_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2876 (class 2606 OID 17000)
-- Name: role_authorise FK_role_authorise_command; Type: FK CONSTRAINT; Schema: kernel; Owner: lemoras
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT "FK_role_authorise_command" FOREIGN KEY (command_id) REFERENCES kernel.command(command_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2877 (class 2606 OID 17005)
-- Name: user_contact FK_user_contact_user; Type: FK CONSTRAINT; Schema: security; Owner: lemoras
--

ALTER TABLE ONLY security.user_contact
    ADD CONSTRAINT "FK_user_contact_user" FOREIGN KEY (user_id) REFERENCES security."user"(user_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 2878 (class 2606 OID 17010)
-- Name: user_role FK_user_role_user; Type: FK CONSTRAINT; Schema: security; Owner: lemoras
--

ALTER TABLE ONLY security.user_role
    ADD CONSTRAINT "FK_user_role_user" FOREIGN KEY (user_id) REFERENCES security."user"(user_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2019-11-22 15:53:41

--
-- PostgreSQL database dump complete
--

