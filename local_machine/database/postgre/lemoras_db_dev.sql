--
-- PostgreSQL database dump
--

-- Dumped from database version 11.5 (Debian 11.5-1.pgdg90+1)
-- Dumped by pg_dump version 11.5

-- Started on 2019-09-08 19:07:18

\connect xxx

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
-- TOC entry 6 (class 2615 OID 17866)
-- Name: config; Type: SCHEMA; Schema: -; Owner: xxx
--

CREATE SCHEMA config;


ALTER SCHEMA config OWNER TO xxx;

--
-- TOC entry 8 (class 2615 OID 17353)
-- Name: kernel; Type: SCHEMA; Schema: -; Owner: xxx
--

CREATE SCHEMA kernel;


ALTER SCHEMA kernel OWNER TO xxx;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 17867)
-- Name: config; Type: TABLE; Schema: config; Owner: xxx
--

CREATE TABLE config.config (
    id integer NOT NULL,
    data text
);


ALTER TABLE config.config OWNER TO xxx;

--
-- TOC entry 207 (class 1259 OID 17915)
-- Name: application; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.application (
    application_id integer NOT NULL,
    application_type_id integer DEFAULT 0 NOT NULL,
    application_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    application_js character varying(50) DEFAULT '0'::character varying NOT NULL,
    database_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.application OWNER TO xxx;

--
-- TOC entry 206 (class 1259 OID 17913)
-- Name: application_application_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.application_application_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.application_application_id_seq OWNER TO xxx;

--
-- TOC entry 3286 (class 0 OID 0)
-- Dependencies: 206
-- Name: application_application_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.application_application_id_seq OWNED BY kernel.application.application_id;


--
-- TOC entry 229 (class 1259 OID 18105)
-- Name: application_instance; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.application_instance (
    application_instance_id integer NOT NULL,
    application_id integer DEFAULT 0 NOT NULL,
    company_id integer DEFAULT 0,
    template_id integer DEFAULT 0 NOT NULL,
    application_tag_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    database_name character varying(50),
    connection_string text
);


ALTER TABLE kernel.application_instance OWNER TO xxx;

--
-- TOC entry 228 (class 1259 OID 18103)
-- Name: application_instance_application_instance_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.application_instance_application_instance_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.application_instance_application_instance_id_seq OWNER TO xxx;

--
-- TOC entry 3287 (class 0 OID 0)
-- Dependencies: 228
-- Name: application_instance_application_instance_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.application_instance_application_instance_id_seq OWNED BY kernel.application_instance.application_instance_id;


--
-- TOC entry 221 (class 1259 OID 18021)
-- Name: application_module; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.application_module (
    application_module_id integer NOT NULL,
    application_id integer DEFAULT 0 NOT NULL,
    module_id integer DEFAULT 0 NOT NULL,
    business_logic_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.application_module OWNER TO xxx;

--
-- TOC entry 220 (class 1259 OID 18019)
-- Name: application_module_application_module_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.application_module_application_module_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.application_module_application_module_id_seq OWNER TO xxx;

--
-- TOC entry 3288 (class 0 OID 0)
-- Dependencies: 220
-- Name: application_module_application_module_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.application_module_application_module_id_seq OWNED BY kernel.application_module.application_module_id;


--
-- TOC entry 203 (class 1259 OID 17896)
-- Name: application_type; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.application_type (
    application_type_id integer NOT NULL,
    application_type_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    isbackoffice boolean
);


ALTER TABLE kernel.application_type OWNER TO xxx;

--
-- TOC entry 202 (class 1259 OID 17894)
-- Name: application_type_application_type_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.application_type_application_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.application_type_application_type_id_seq OWNER TO xxx;

--
-- TOC entry 3289 (class 0 OID 0)
-- Dependencies: 202
-- Name: application_type_application_type_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.application_type_application_type_id_seq OWNED BY kernel.application_type.application_type_id;


--
-- TOC entry 217 (class 1259 OID 17986)
-- Name: business_logic; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.business_logic (
    business_logic_id integer NOT NULL,
    business_logic_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    business_service_id integer NOT NULL,
    unique_key character varying(50) NOT NULL
);


ALTER TABLE kernel.business_logic OWNER TO xxx;

--
-- TOC entry 216 (class 1259 OID 17984)
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.business_logic_business_logic_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.business_logic_business_logic_id_seq OWNER TO xxx;

--
-- TOC entry 3290 (class 0 OID 0)
-- Dependencies: 216
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.business_logic_business_logic_id_seq OWNED BY kernel.business_logic.business_logic_id;


--
-- TOC entry 209 (class 1259 OID 17933)
-- Name: business_service; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.business_service (
    business_service_id integer NOT NULL,
    business_service_name character varying(50) DEFAULT '0'::character varying,
    business_service_key character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.business_service OWNER TO xxx;

--
-- TOC entry 208 (class 1259 OID 17931)
-- Name: business_service_business_service_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.business_service_business_service_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.business_service_business_service_id_seq OWNER TO xxx;

--
-- TOC entry 3291 (class 0 OID 0)
-- Dependencies: 208
-- Name: business_service_business_service_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.business_service_business_service_id_seq OWNED BY kernel.business_service.business_service_id;


--
-- TOC entry 211 (class 1259 OID 17943)
-- Name: command; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.command (
    command_id integer NOT NULL,
    command_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    business_service_id integer NOT NULL
);


ALTER TABLE kernel.command OWNER TO xxx;

--
-- TOC entry 210 (class 1259 OID 17941)
-- Name: command_command_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.command_command_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.command_command_id_seq OWNER TO xxx;

--
-- TOC entry 3292 (class 0 OID 0)
-- Dependencies: 210
-- Name: command_command_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.command_command_id_seq OWNED BY kernel.command.command_id;


--
-- TOC entry 201 (class 1259 OID 17888)
-- Name: company; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.company (
    company_id integer NOT NULL,
    company_name character varying(50) NOT NULL
);


ALTER TABLE kernel.company OWNER TO xxx;

--
-- TOC entry 200 (class 1259 OID 17886)
-- Name: company_company_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.company_company_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.company_company_id_seq OWNER TO xxx;

--
-- TOC entry 3293 (class 0 OID 0)
-- Dependencies: 200
-- Name: company_company_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.company_company_id_seq OWNED BY kernel.company.company_id;


--
-- TOC entry 205 (class 1259 OID 17906)
-- Name: language; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.language (
    language_id integer NOT NULL,
    language_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.language OWNER TO xxx;

--
-- TOC entry 204 (class 1259 OID 17904)
-- Name: language_language_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.language_language_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.language_language_id_seq OWNER TO xxx;

--
-- TOC entry 3294 (class 0 OID 0)
-- Dependencies: 204
-- Name: language_language_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.language_language_id_seq OWNED BY kernel.language.language_id;


--
-- TOC entry 249 (class 1259 OID 18317)
-- Name: menu; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.menu (
    menu_id integer NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    menu_type_id integer NOT NULL,
    parent_menu_id integer,
    page_id integer,
    menu_icon_id integer,
    menu_value_id integer,
    index integer NOT NULL,
    menu_label character varying(50),
    menu_tag character varying(50)
);


ALTER TABLE kernel.menu OWNER TO xxx;

--
-- TOC entry 215 (class 1259 OID 17970)
-- Name: menu_icon; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.menu_icon (
    menu_icon_id integer NOT NULL,
    template_id integer DEFAULT 0 NOT NULL,
    menu_icon_value character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.menu_icon OWNER TO xxx;

--
-- TOC entry 214 (class 1259 OID 17968)
-- Name: menu_icon_menu_icon_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.menu_icon_menu_icon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.menu_icon_menu_icon_id_seq OWNER TO xxx;

--
-- TOC entry 3295 (class 0 OID 0)
-- Dependencies: 214
-- Name: menu_icon_menu_icon_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.menu_icon_menu_icon_id_seq OWNED BY kernel.menu_icon.menu_icon_id;


--
-- TOC entry 248 (class 1259 OID 18315)
-- Name: menu_menu_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.menu_menu_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.menu_menu_id_seq OWNER TO xxx;

--
-- TOC entry 3296 (class 0 OID 0)
-- Dependencies: 248
-- Name: menu_menu_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.menu_menu_id_seq OWNED BY kernel.menu.menu_id;


--
-- TOC entry 235 (class 1259 OID 18166)
-- Name: menu_type; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.menu_type (
    menu_type_id integer NOT NULL,
    application_id integer DEFAULT 0 NOT NULL,
    menu_type_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.menu_type OWNER TO xxx;

--
-- TOC entry 234 (class 1259 OID 18164)
-- Name: menu_type_menu_type_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.menu_type_menu_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.menu_type_menu_type_id_seq OWNER TO xxx;

--
-- TOC entry 3297 (class 0 OID 0)
-- Dependencies: 234
-- Name: menu_type_menu_type_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.menu_type_menu_type_id_seq OWNED BY kernel.menu_type.menu_type_id;


--
-- TOC entry 233 (class 1259 OID 18150)
-- Name: menu_value; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.menu_value (
    menu_value_id integer NOT NULL,
    language_id integer DEFAULT 0 NOT NULL,
    menu_value_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.menu_value OWNER TO xxx;

--
-- TOC entry 232 (class 1259 OID 18148)
-- Name: menu_value_menu_value_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.menu_value_menu_value_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.menu_value_menu_value_id_seq OWNER TO xxx;

--
-- TOC entry 3298 (class 0 OID 0)
-- Dependencies: 232
-- Name: menu_value_menu_value_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.menu_value_menu_value_id_seq OWNED BY kernel.menu_value.menu_value_id;


--
-- TOC entry 225 (class 1259 OID 18072)
-- Name: microservice; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.microservice (
    microservice_id integer NOT NULL,
    unique_key bytea NOT NULL,
    microservice_name character varying(50) NOT NULL
);


ALTER TABLE kernel.microservice OWNER TO xxx;

--
-- TOC entry 224 (class 1259 OID 18070)
-- Name: microservice_microservice_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.microservice_microservice_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.microservice_microservice_id_seq OWNER TO xxx;

--
-- TOC entry 3299 (class 0 OID 0)
-- Dependencies: 224
-- Name: microservice_microservice_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.microservice_microservice_id_seq OWNED BY kernel.microservice.microservice_id;


--
-- TOC entry 227 (class 1259 OID 18085)
-- Name: microservice_module; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.microservice_module (
    microservice_module_id integer NOT NULL,
    microservice_id integer NOT NULL,
    module_id integer NOT NULL
);


ALTER TABLE kernel.microservice_module OWNER TO xxx;

--
-- TOC entry 226 (class 1259 OID 18083)
-- Name: microservice_module_microservice_module_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.microservice_module_microservice_module_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.microservice_module_microservice_module_id_seq OWNER TO xxx;

--
-- TOC entry 3300 (class 0 OID 0)
-- Dependencies: 226
-- Name: microservice_module_microservice_module_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.microservice_module_microservice_module_id_seq OWNED BY kernel.microservice_module.microservice_module_id;


--
-- TOC entry 199 (class 1259 OID 17879)
-- Name: module; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.module (
    module_id integer NOT NULL,
    module_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.module OWNER TO xxx;

--
-- TOC entry 198 (class 1259 OID 17877)
-- Name: module_module_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.module_module_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.module_module_id_seq OWNER TO xxx;

--
-- TOC entry 3301 (class 0 OID 0)
-- Dependencies: 198
-- Name: module_module_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.module_module_id_seq OWNED BY kernel.module.module_id;


--
-- TOC entry 239 (class 1259 OID 18198)
-- Name: module_page; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.module_page (
    module_page_id integer NOT NULL,
    application_instance_id integer DEFAULT 0 NOT NULL,
    application_module_id integer DEFAULT 0 NOT NULL,
    page_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.module_page OWNER TO xxx;

--
-- TOC entry 238 (class 1259 OID 18196)
-- Name: module_page_module_page_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.module_page_module_page_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.module_page_module_page_id_seq OWNER TO xxx;

--
-- TOC entry 3302 (class 0 OID 0)
-- Dependencies: 238
-- Name: module_page_module_page_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.module_page_module_page_id_seq OWNED BY kernel.module_page.module_page_id;


--
-- TOC entry 219 (class 1259 OID 18001)
-- Name: page; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.page (
    page_id integer NOT NULL,
    template_id integer DEFAULT 0 NOT NULL,
    route_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    template_url character varying(80) DEFAULT '0'::character varying NOT NULL,
    controller_url character varying(80) DEFAULT '0'::character varying NOT NULL,
    controller_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    controller_as_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.page OWNER TO xxx;

--
-- TOC entry 223 (class 1259 OID 18050)
-- Name: page_detail; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.page_detail (
    page_detail_id integer NOT NULL,
    page_id integer DEFAULT 0 NOT NULL,
    language_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.page_detail OWNER TO xxx;

--
-- TOC entry 222 (class 1259 OID 18048)
-- Name: page_detail_page_detail_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.page_detail_page_detail_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.page_detail_page_detail_id_seq OWNER TO xxx;

--
-- TOC entry 3303 (class 0 OID 0)
-- Dependencies: 222
-- Name: page_detail_page_detail_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.page_detail_page_detail_id_seq OWNED BY kernel.page_detail.page_detail_id;


--
-- TOC entry 218 (class 1259 OID 17999)
-- Name: page_page_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.page_page_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.page_page_id_seq OWNER TO xxx;

--
-- TOC entry 3304 (class 0 OID 0)
-- Dependencies: 218
-- Name: page_page_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.page_page_id_seq OWNED BY kernel.page.page_id;


--
-- TOC entry 237 (class 1259 OID 18182)
-- Name: role; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.role (
    role_id integer NOT NULL,
    application_id integer DEFAULT 0 NOT NULL,
    role_name character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.role OWNER TO xxx;

--
-- TOC entry 241 (class 1259 OID 18227)
-- Name: role_authorise; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.role_authorise (
    role_authorise_id integer NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    command_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.role_authorise OWNER TO xxx;

--
-- TOC entry 240 (class 1259 OID 18225)
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.role_authorise_role_authorise_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.role_authorise_role_authorise_id_seq OWNER TO xxx;

--
-- TOC entry 3305 (class 0 OID 0)
-- Dependencies: 240
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.role_authorise_role_authorise_id_seq OWNED BY kernel.role_authorise.role_authorise_id;


--
-- TOC entry 243 (class 1259 OID 18249)
-- Name: role_page; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.role_page (
    role_page_id integer NOT NULL,
    role_id integer DEFAULT 0 NOT NULL,
    module_page_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.role_page OWNER TO xxx;

--
-- TOC entry 242 (class 1259 OID 18247)
-- Name: role_page_role_page_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.role_page_role_page_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.role_page_role_page_id_seq OWNER TO xxx;

--
-- TOC entry 3306 (class 0 OID 0)
-- Dependencies: 242
-- Name: role_page_role_page_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.role_page_role_page_id_seq OWNED BY kernel.role_page.role_page_id;


--
-- TOC entry 236 (class 1259 OID 18180)
-- Name: role_role_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.role_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.role_role_id_seq OWNER TO xxx;

--
-- TOC entry 3307 (class 0 OID 0)
-- Dependencies: 236
-- Name: role_role_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.role_role_id_seq OWNED BY kernel.role.role_id;


--
-- TOC entry 213 (class 1259 OID 17960)
-- Name: template; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.template (
    template_id integer NOT NULL,
    template_name character varying(50) DEFAULT '0'::character varying NOT NULL,
    template_url character varying(50) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.template OWNER TO xxx;

--
-- TOC entry 212 (class 1259 OID 17958)
-- Name: template_template_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.template_template_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.template_template_id_seq OWNER TO xxx;

--
-- TOC entry 3308 (class 0 OID 0)
-- Dependencies: 212
-- Name: template_template_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.template_template_id_seq OWNED BY kernel.template.template_id;


--
-- TOC entry 231 (class 1259 OID 18138)
-- Name: user; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel."user" (
    user_id integer NOT NULL,
    username character varying(50) DEFAULT '0'::character varying NOT NULL,
    password character varying(50) DEFAULT '0'::character varying NOT NULL,
    email character varying(50) DEFAULT '0'::character varying NOT NULL,
    first_name character varying(50),
    last_name character varying(50),
    active boolean,
    last_login_date timestamp without time zone
);


ALTER TABLE kernel."user" OWNER TO xxx;

--
-- TOC entry 245 (class 1259 OID 18271)
-- Name: user_contact; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.user_contact (
    user_contact_id integer NOT NULL,
    user_id integer DEFAULT 0 NOT NULL,
    phone character varying(13) DEFAULT '0'::character varying NOT NULL,
    fax character varying(13) DEFAULT '0'::character varying NOT NULL
);


ALTER TABLE kernel.user_contact OWNER TO xxx;

--
-- TOC entry 244 (class 1259 OID 18269)
-- Name: user_contact_user_contact_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.user_contact_user_contact_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.user_contact_user_contact_id_seq OWNER TO xxx;

--
-- TOC entry 3309 (class 0 OID 0)
-- Dependencies: 244
-- Name: user_contact_user_contact_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.user_contact_user_contact_id_seq OWNED BY kernel.user_contact.user_contact_id;


--
-- TOC entry 247 (class 1259 OID 18288)
-- Name: user_role; Type: TABLE; Schema: kernel; Owner: xxx
--

CREATE TABLE kernel.user_role (
    user_role_id integer NOT NULL,
    user_id integer DEFAULT 0 NOT NULL,
    application_instance_id integer DEFAULT 0 NOT NULL,
    role_id integer DEFAULT 0 NOT NULL
);


ALTER TABLE kernel.user_role OWNER TO xxx;

--
-- TOC entry 246 (class 1259 OID 18286)
-- Name: user_role_user_role_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.user_role_user_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.user_role_user_role_id_seq OWNER TO xxx;

--
-- TOC entry 3310 (class 0 OID 0)
-- Dependencies: 246
-- Name: user_role_user_role_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.user_role_user_role_id_seq OWNED BY kernel.user_role.user_role_id;


--
-- TOC entry 230 (class 1259 OID 18136)
-- Name: user_user_id_seq; Type: SEQUENCE; Schema: kernel; Owner: xxx
--

CREATE SEQUENCE kernel.user_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE kernel.user_user_id_seq OWNER TO xxx;

--
-- TOC entry 3311 (class 0 OID 0)
-- Dependencies: 230
-- Name: user_user_id_seq; Type: SEQUENCE OWNED BY; Schema: kernel; Owner: xxx
--

ALTER SEQUENCE kernel.user_user_id_seq OWNED BY kernel."user".user_id;


--
-- TOC entry 2906 (class 2604 OID 17918)
-- Name: application application_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application ALTER COLUMN application_id SET DEFAULT nextval('kernel.application_application_id_seq'::regclass);


--
-- TOC entry 2940 (class 2604 OID 18108)
-- Name: application_instance application_instance_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_instance ALTER COLUMN application_instance_id SET DEFAULT nextval('kernel.application_instance_application_instance_id_seq'::regclass);


--
-- TOC entry 2931 (class 2604 OID 18024)
-- Name: application_module application_module_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_module ALTER COLUMN application_module_id SET DEFAULT nextval('kernel.application_module_application_module_id_seq'::regclass);


--
-- TOC entry 2901 (class 2604 OID 17899)
-- Name: application_type application_type_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_type ALTER COLUMN application_type_id SET DEFAULT nextval('kernel.application_type_application_type_id_seq'::regclass);


--
-- TOC entry 2922 (class 2604 OID 17989)
-- Name: business_logic business_logic_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.business_logic ALTER COLUMN business_logic_id SET DEFAULT nextval('kernel.business_logic_business_logic_id_seq'::regclass);


--
-- TOC entry 2911 (class 2604 OID 17936)
-- Name: business_service business_service_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.business_service ALTER COLUMN business_service_id SET DEFAULT nextval('kernel.business_service_business_service_id_seq'::regclass);


--
-- TOC entry 2914 (class 2604 OID 17946)
-- Name: command command_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.command ALTER COLUMN command_id SET DEFAULT nextval('kernel.command_command_id_seq'::regclass);


--
-- TOC entry 2900 (class 2604 OID 17891)
-- Name: company company_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.company ALTER COLUMN company_id SET DEFAULT nextval('kernel.company_company_id_seq'::regclass);


--
-- TOC entry 2904 (class 2604 OID 17909)
-- Name: language language_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.language ALTER COLUMN language_id SET DEFAULT nextval('kernel.language_language_id_seq'::regclass);


--
-- TOC entry 2977 (class 2604 OID 18320)
-- Name: menu menu_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu ALTER COLUMN menu_id SET DEFAULT nextval('kernel.menu_menu_id_seq'::regclass);


--
-- TOC entry 2919 (class 2604 OID 17973)
-- Name: menu_icon menu_icon_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_icon ALTER COLUMN menu_icon_id SET DEFAULT nextval('kernel.menu_icon_menu_icon_id_seq'::regclass);


--
-- TOC entry 2953 (class 2604 OID 18169)
-- Name: menu_type menu_type_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_type ALTER COLUMN menu_type_id SET DEFAULT nextval('kernel.menu_type_menu_type_id_seq'::regclass);


--
-- TOC entry 2950 (class 2604 OID 18153)
-- Name: menu_value menu_value_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_value ALTER COLUMN menu_value_id SET DEFAULT nextval('kernel.menu_value_menu_value_id_seq'::regclass);


--
-- TOC entry 2938 (class 2604 OID 18075)
-- Name: microservice microservice_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice ALTER COLUMN microservice_id SET DEFAULT nextval('kernel.microservice_microservice_id_seq'::regclass);


--
-- TOC entry 2939 (class 2604 OID 18088)
-- Name: microservice_module microservice_module_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice_module ALTER COLUMN microservice_module_id SET DEFAULT nextval('kernel.microservice_module_microservice_module_id_seq'::regclass);


--
-- TOC entry 2898 (class 2604 OID 17882)
-- Name: module module_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module ALTER COLUMN module_id SET DEFAULT nextval('kernel.module_module_id_seq'::regclass);


--
-- TOC entry 2959 (class 2604 OID 18201)
-- Name: module_page module_page_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module_page ALTER COLUMN module_page_id SET DEFAULT nextval('kernel.module_page_module_page_id_seq'::regclass);


--
-- TOC entry 2924 (class 2604 OID 18004)
-- Name: page page_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page ALTER COLUMN page_id SET DEFAULT nextval('kernel.page_page_id_seq'::regclass);


--
-- TOC entry 2935 (class 2604 OID 18053)
-- Name: page_detail page_detail_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page_detail ALTER COLUMN page_detail_id SET DEFAULT nextval('kernel.page_detail_page_detail_id_seq'::regclass);


--
-- TOC entry 2956 (class 2604 OID 18185)
-- Name: role role_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role ALTER COLUMN role_id SET DEFAULT nextval('kernel.role_role_id_seq'::regclass);


--
-- TOC entry 2963 (class 2604 OID 18230)
-- Name: role_authorise role_authorise_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_authorise ALTER COLUMN role_authorise_id SET DEFAULT nextval('kernel.role_authorise_role_authorise_id_seq'::regclass);


--
-- TOC entry 2966 (class 2604 OID 18252)
-- Name: role_page role_page_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_page ALTER COLUMN role_page_id SET DEFAULT nextval('kernel.role_page_role_page_id_seq'::regclass);


--
-- TOC entry 2916 (class 2604 OID 17963)
-- Name: template template_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.template ALTER COLUMN template_id SET DEFAULT nextval('kernel.template_template_id_seq'::regclass);


--
-- TOC entry 2945 (class 2604 OID 18141)
-- Name: user user_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel."user" ALTER COLUMN user_id SET DEFAULT nextval('kernel.user_user_id_seq'::regclass);


--
-- TOC entry 2969 (class 2604 OID 18274)
-- Name: user_contact user_contact_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_contact ALTER COLUMN user_contact_id SET DEFAULT nextval('kernel.user_contact_user_contact_id_seq'::regclass);


--
-- TOC entry 2973 (class 2604 OID 18291)
-- Name: user_role user_role_id; Type: DEFAULT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_role ALTER COLUMN user_role_id SET DEFAULT nextval('kernel.user_role_user_role_id_seq'::regclass);


--
-- TOC entry 3228 (class 0 OID 17867)
-- Dependencies: 197
-- Data for Name: config; Type: TABLE DATA; Schema: config; Owner: xxx
--

COPY config.config (id, data) FROM stdin;
7	{"module":{"account":{"caption":"Profili Düzenle","label":"Profilini Tamamla","username":"Kullanıcı adı (disabled)","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","btnProfileUpdate":"Profili Güncelle","passwdLogo":"./assets/img/faces/key2.png","passwdPowered":"Powered by Lemoras","passwdCaption":"Şifre değiştir","currentPasswd":"Mevcut şifre","passwd":"Şifre","rePasswd":"Tekrar şifre","btnPasswdChange":"Değiştir"},"user":{"compose":{"caption":"Kullanıcı Oluştur","label":"Kullanıcı tamamla","username":"Kullanıcı adı","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","active":"Aktif/Pasif","passwd":"Şifre","btnUserAdd":"Kullanıcıyı ekle"},"list":{"caption":"Kullanıcı Listesi Caption","label":"Tüm kullanıcılar; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"E-posta","index":1},{"name":"Adı","index":2},{"name":"Soyadı","index":3},{"name":"Aktif/Pasif","index":4},{"name":"Sisteme son girişi","index":5}]}},"userRole":{"compose":{"caption":"Kullanıcıya Rol Ata Caption","label":"Kullanıcıya rol ata Label","username":"Kullanıcı adı","applicationName":"Uygulama Adı","roleName":"Rol Adı","btnUserRoleAdd":"Kullanıcıya rol ata",},"list":{"caption":"Kullanıcı Rol Listesi Caption","label":"Tüm kullanıcıların rolleri; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"Uygulama Adı","index":1},{"name":"Rol Adı","index":2}]}},"menu":{"compose":{"caption":"Menu oluştur caption","label":"menu formu label","roleName":"Rol adı","menuTypename":"Menu tür ismi","parentMenuName":"İlişkili üst menü","pageName":"Sayfa ismi","menuIcon":"Menü ikonu","menuValue":"Menü ismi","index":"Dizilim sırası","menulabel":"Menü tag ismi","btnMenuAdd":"Menü ekle"},"list":{"caption":"Menü Listesi caption","label":"Menü listesi label","properties":[{"name":"id","index":0},{"name":"Rol","index":1},{"name":"Menü Tür","index":2},{"name":"İlişkili Menü","index":3},{"name":"Sayfa","index":4},{"name":"İkon","index":5},{"name":"İsmi","index":6},{"name":"Sıra","index":7},{"name":"Etiket","index":8}]}},"menuIcon":{"compose":{"caption":"Menu ikon oluştur caption","label":"menu ikon formu label","templateName":"şablon adı","menuIconValue":"Menu ikon değeri","btnMenuIconAdd":"Menü ikon ekle"},"list":{"caption":"Menü ikon listesi caption","label":"Menü ikon listesi label","properties":[{"name":"id","index":0},{"name":"Şabon ismi","index":1},{"name":"Menü ikon değeri","index":2}]}},"menuType":{"compose":{"caption":"Menu tür oluştur caption","label":"menu tür formu label","applicationName":"Uygulama adı","menuTypeName":"Menu tür ismi","btnMenuTypeAdd":"Menü tür ekle"},"list":{"caption":"Menü tür listesi","label":"Menü tür listesi label","properties":[{"name":"id","index":0},{"name":"Uygulama Adı","index":1},{"name":"Menü türü","index":2}]}},"menuValue":{"compose":{"caption":"Menu İsmi oluştur caption","label":"menu İsmi formu label","languageName":"Dil adı","menuValueName":"Menü ismi","btnMenuValueAdd":"Menü ismi ekle"},"list":{"caption":"Menü isim listesi","label":"Menü isim listesi label","properties":[{"name":"id","index":0},{"name":"Dil Adı","index":1},{"name":"Menü ismi","index":2}]}},"pageDetail":{"compose":{"caption":"Sayfa detay oluştur caption","label":"Sayfa detay formu label","languageName":"Dil adı","pageName":"Sayfa ismi","btnPageDetailAdd":"Sayfa detay ekle"},"list":{"caption":"Sayfa detay listesi caption","label":"Sayfa detay listesi label","properties":[{"name":"id","index":0},{"name":"Dil adı","index":1},{"name":"Sayfa İsmi","index":2}]}},"pageProperty":{"compose":{"caption":"Sayfa detay özelliği oluştur caption","label":"Sayfa detay özelliği formu label","pageName":"Sayfa adı","propertyData":"Özellik verisi","btnPagePropertyAdd":"Özellik ekle"},"list":{"caption":"Sayfa özellik dataları listesi","label":"Sayfa özellik verileri listesi label","properties":[{"name":"id","index":0},{"name":"Sayfa ismi","index":1},{"name":"Özellik verisi","index":2}]}},"language":{"compose":{"caption":"Dil tanımı oluştur caption","label":"Dil tanımı formu label","languageName":"Dil adı","btnLanguageAdd":"Dil ekle"},"list":{"caption":"Dil listesi","label":"Dil listesi label","properties":[{"name":"id","index":0},{"name":"Dil ismi","index":1}]}},"template":{"compose":{"caption":"şablon tanımı oluştur caption","label":"Şablon tanımı formu label","templateName":"şablon adı","templateUrl":"şablon URL","btnTemplateAdd":"Şablon ekle"},"list":{"caption":"Şablon listesi","label":"şablon listesi label","properties":[{"name":"id","index":0},{"name":"şablon ismi","index":1},{"name":"şablon Url","index":2}]}},"leaveMessage":{"compose":{"caption":"mesaj oluştur","label":"mesaj formu","subject":"konu","message":"mesaj içerği","messageDetail":"lütfen, sorunlarınızı yazınız..","btnMessageSend":"mesajı gönder"},"list":{"caption":"mesajlar","label":"mesajlarınız ve durumları hakkında bilgiler","properties":[{"name":"mesaj id","index":0},{"name":"durum","index":1},{"name":"konu","index":2},{"name":"mesaj","index":3}]}},"callUs":{"image":"./assets/img/phone-call.png","caption":"Call Us","esPhone":"+372 302 72-07","trPhone":"+90 546 533 40-26","btnEsCall":"Call Estonia Number","btnTrCall":"Call Turkey Number","btnLeaveMessage":"leave a message"},"logout":{"caption":"Çıkış","label":"Sistemden çıkmak istediğinize emin misiniz ?","btnCancel":"İptal","btnLogout":"Çıkış"},"application":{"compose":{"caption":"Uygumala Oluştur","label":"Uygulama tanımlama formu","applicationName":"Uygulama adı","applicationTypeName":"Uygulama Türü","btnApplicationAdd":"uygulamayı ekle"},"list":{"caption":"uygulamalar listesi","label":"tüm uygulamaların listesi; pasif aktif, silinen...","properties":[{"name":"uygulama adı","index":0},{"name":"uygulama türü","index":1}]}},"applicationType":{"compose":{"caption":"uygumala türü oluştur","label":"uygulama türü tanımlama formu","applicationTypeName":"uygulama tür adı","isBackoffice":"Backoffice mi ?","btnApplicationTypeAdd":"uygumala türünü ekle"},"list":{"caption":"uygulama tür listesi","label":"tüm uygulama türlerinin listesi; pasif aktif, silinen...","properties":[{"name":"uygulama tür adı","index":0},{"name":"is backoffice","index":1}]}},"applicationModule":{"compose":{"caption":"Uygulamaya Modülü Ata","label":"Uygulamaya modül ata tanımlama formu","applicationName":"Uygulama adı","moduleName":"Modül Adı","businessLogic":"İş mantığı adı","btnApplicationModuleAdd":"Modülü ata"},"list":{"caption":"Uygulama Modülü listesi","label":"Uygulama modüllerinin listesi; pasif aktif, silinen...","properties":[{"name":"Uygulama adı","index":0},{"name":"Modül adı","index":1},{"name":"İş mantığı adı","index":2}]}},"modulePage":{"compose":{"caption":"Module Page Tanımı Caption","label":"Module Page tanımı label","applicationModuleName":"Uygulama modül adı","page":"Sayfa / Yönlendirme adı","btnModulePageAdd":"Modül sayfasını ekle"},"list":{"caption":"ModulePage List Caption","label":"ModulePage tanımı label","properties":[{"name":"Uygulama modül adı","index":0},{"name":"Sayfa / Yönlendirme adı","index":1}]}},"module":{"compose":{"caption":"Module Tanımı Caption","label":"Module tanımı label","moduleName":"Modül adı","btnModuleAdd":"Modülü ekle"},"list":{"caption":"Module List Caption","label":"Module tanımı label","properties":[{"name":"Modül adı","index":0}]}},"command":{"compose":{"caption":"Komut Tanımı Caption","label":"Komut tanımı label","commandName":"Komut adı","btnCommandAdd":"Komutu ekle"},"list":{"caption":"Komut Listesi Caption","label":"Komut listesi tanımı label","properties":[{"name":"Komut adı","index":0}]}},"company":{"compose":{"caption":"Şirket Tanımı Caption","label":"Şirket tanımı label","companyName":"Şirket adı","btnCompanyAdd":"Şirket ekle"},"list":{"caption":"Şirket Listesi Caption","label":"Şirket listesi tanımı label","properties":[{"name":"Şirket adı","index":0}]}},"companyApplication":{"compose":{"caption":"Şirkete Uygulama Atama Caption","label":"Şirkete uygulama atama label","applicationName":"Uygulama adı","companyName":"Şirket adı","applicationTagName":"Uygulama tag adı","connectionString":"Veritabanı bağlantı url'i","btnCompanyApplicationAdd":"Şirkete uygulamayı ata"},"list":{"caption":"Şirket Listesi Caption","label":"Şirket listesi tanımı label","properties":[{"name":"Şirket adı","index":0},{"name":"Uygulama adı","index":1},{"name":"Uygulama etiket adı","index":2},{"name":"Veritabanı bağlantı url'i","index":3}]}},"businessLogic":{"compose":{"caption":"İş Manıtğı Tanımlama Caption","label":"iş mantığı tanımlama label","businessLogicName":"İş mantığı adı","serviceKey":"Hizmet adı","uniqueKey":"Hizmete ait benzersiz anahtar","btnBusinessLogicAdd":"İş mantığını ekle"},"list":{"caption":"İş Mantığı Listesi Caption","label":"İş Mantığı listesi tanımı label","properties":[{"name":"İş Mantığı adı","index":0},{"name":"Hizmet Adı","index":1},{"name":"Benzersiz Anahtar","index":2}]}},"businessService":{"compose":{"caption":"İş Hizmeti Tanımlama Caption","label":"iş Hizmeti tanımlama label","businessServiceName":"İş Hizmeti adı","businessServiceKey":"Hizmete ait benzersiz anahtar","btnBusinessServiceAdd":"İş hizmetini ekle"},"list":{"caption":"İş Hizmeti Listesi Caption","label":"İş Hizmeti listesi tanımı label","properties":[{"name":"Id","index":0},{"name":"Hizmet Adı","index":1},{"name":"Benzersiz Anahtar","index":2}]}},"microservice":{"compose":{"caption":"Microservice Tanımlama Caption","label":"Mcroservice tanımlama label","microserviceName":"Microservice adı","uniqueKey":"Benzersiz Anahtar","btnMicroserviceAdd":"Microservice ekle"},"list":{"caption":"Microservice Listesi Caption","label":"Microservice listesi tanımı label","properties":[{"name":"Microservice adı","index":0},{"name":"Benzersiz Anahtar","index":1}]}},"microserviceModule":{"compose":{"caption":"Microservice Modül Tanımlama Caption","label":"Mcroservice modül tanımlama label","microserviceName":"Microservice adı","moduleName":"Modül adı","btnMicroserviceModuleAdd":"Microservice modül ekle"},"list":{"caption":"Microservice Modül Listesi Caption","label":"Microservice Modül listesi tanımı label","properties":[{"name":"Microservice adı","index":0},{"name":"Modül adı","index":1}]}},"page":{"compose":{"caption":"Sayfa Tanımı Caption","label":"Sayfa tanımı label","routeName":"Yönlendirme Adı","templateUrl":"Sayfa URL","controllerUrl":"Controller URL","controllerName":"Controller Adı","controllerAsName":"Controller Adı Olarak","btnRouteAdd":"Sayfayı ekle"},"list":{"caption":"Sayfa List Caption","label":"Sayfa tanımı label","properties":[{"name":"Yönlendirme Adı","index":0},{"name":"Controller Adı","index":1},{"name":"Controller URL","index":2},{"name":"Controller Adı Olarak","index":3},{"name":"Controller URL","index":4},{"name":"Sayfa URL","index":5}]}},"role":{"compose":{"caption":"Role Tanımı Caption","label":"Role tanımı label","applicationName":"Uygulama Adı","roleName":"Rol Adı","btnRoleAdd":"Rolü ekle"},"list":{"caption":"Role List Caption","label":"Role List Label","properties":[{"name":"Uygulama Adı","index":0},{"name":"Role Adı","index":1}]}},"roleAuthorise":{"compose":{"caption":"Rol Yetkilendirme Tanımı Caption","label":"Rol yetkilendirme tanımı label","roleName":"Rol Adı","commandName":"Komut Adı","btnRoleAuthoriseAdd":"Rol yetkilendirmesini ekle"},"list":{"caption":"Rol Yetkilendirme Listesi Caption","label":"Rol yetkilendirme Listesi Label","properties":[{"name":"Role Adı","index":0},{"name":"Komut Adı","index":1}]}}},"root":{"titleName":"Lemoras backofficev1.0","companyName":"Lemoras","route":{"default":"/","pages":[{"routeName":"/","templateUrl":"./templates/default/modules/dashboard/dashboard.view.html","controllerUrl":"./system/modules/dashboard/dashboard.controller.js","controllerName":"DashboardController","controllerAsName":"vm"},{"routeName":"/profile","templateUrl":"./templates/default/modules/account/account.view.html","controllerUrl":"./system/modules/account/account.controller.js","controllerName":"AccountController","controllerAsName":"vm"},{"routeName":"/user","templateUrl":"./templates/default/modules/user/user.view.html","controllerUrl":"./system/modules/user/user.controller.js","controllerName":"UserController","controllerAsName":"vm"},{"routeName":"/user-role","templateUrl":"./templates/default/modules/user/userrole.view.html","controllerUrl":"./system/modules/user/userrole.controller.js","controllerName":"UserRoleController","controllerAsName":"vm"},{"routeName":"/application","templateUrl":"./templates/default/modules/application/application.view.html","controllerUrl":"./system/modules/application/application.controller.js","controllerName":"ApplicationController","controllerAsName":"vm"},{"routeName":"/application-type","templateUrl":"./templates/default/modules/application/applicationtype.view.html","controllerUrl":"./system/modules/application/applicationtype.controller.js","controllerName":"ApplicationTypeController","controllerAsName":"vm"},{"routeName":"/application-module","templateUrl":"./templates/default/modules/application/applicationmodule.view.html","controllerUrl":"./system/modules/application/applicationmodule.controller.js","controllerName":"ApplicationModuleController","controllerAsName":"vm"},{"routeName":"/business-logic","templateUrl":"./templates/default/modules/businesslogic/businesslogic.view.html","controllerUrl":"./system/modules/businesslogic/businesslogic.controller.js","controllerName":"BusinessLogicController","controllerAsName":"vm"},{"routeName":"/business-service","templateUrl":"./templates/default/modules/businesslogic/businessservice.view.html","controllerUrl":"./system/modules/businesslogic/businessservice.controller.js","controllerName":"BusinessServiceController","controllerAsName":"vm"},{"routeName":"/command","templateUrl":"./templates/default/modules/command/command.view.html","controllerUrl":"./system/modules/command/command.controller.js","controllerName":"CommandController","controllerAsName":"vm"},{"routeName":"/microservice","templateUrl":"./templates/default/modules/microservice/microservice.view.html","controllerUrl":"./system/modules/microservice/microservice.controller.js","controllerName":"MicroserviceController","controllerAsName":"vm"},{"routeName":"/microservice-module","templateUrl":"./templates/default/modules/microservice/microservicemodule.view.html","controllerUrl":"./system/modules/microservice/microservicemodule.controller.js","controllerName":"MicroserviceModuleController","controllerAsName":"vm"},{"routeName":"/module","templateUrl":"./templates/default/modules/module/module.view.html","controllerUrl":"./system/modules/module/module.controller.js","controllerName":"ModuleController","controllerAsName":"vm"},{"routeName":"/module-page","templateUrl":"./templates/default/modules/module/modulepage.view.html","controllerUrl":"./system/modules/module/modulepage.controller.js","controllerName":"ModulePageController","controllerAsName":"vm"},{"routeName":"/page","templateUrl":"./templates/default/modules/page/page.view.html","controllerUrl":"./system/modules/page/page.controller.js","controllerName":"PageController","controllerAsName":"vm"},{"routeName":"/page-detail","templateUrl":"./templates/default/modules/page/pagedetail.view.html","controllerUrl":"./system/modules/page/pagedetail.controller.js","controllerName":"PageDetailController","controllerAsName":"vm"},{"routeName":"/page-property","templateUrl":"./templates/default/modules/page/pageproperty.view.html","controllerUrl":"./system/modules/page/pageproperty.controller.js","controllerName":"PagePropertyController","controllerAsName":"vm"},{"routeName":"/company","templateUrl":"./templates/default/modules/company/company.view.html","controllerUrl":"./system/modules/company/company.controller.js","controllerName":"CompanyController","controllerAsName":"vm"},{"routeName":"/company-application","templateUrl":"./templates/default/modules/company/companyapplication.view.html","controllerUrl":"./system/modules/company/companyapplication.controller.js","controllerName":"CompanyApplicationController","controllerAsName":"vm"},{"routeName":"/role","templateUrl":"./templates/default/modules/role/role.view.html","controllerUrl":"./system/modules/role/role.controller.js","controllerName":"RoleController","controllerAsName":"vm"},{"routeName":"/role-authorise","templateUrl":"./templates/default/modules/role/roleauthorise.view.html","controllerUrl":"./system/modules/role/roleauthorise.controller.js","controllerName":"RoleAuthoriseController","controllerAsName":"vm"},{"routeName":"/role-page","templateUrl":"./templates/default/modules/role/rolepage.view.html","controllerUrl":"./system/modules/role/rolepage.controller.js","controllerName":"RolePageController","controllerAsName":"vm"},{"routeName":"/leavemessage","templateUrl":"./templates/default/modules/support/leavemessage.view.html","controllerUrl":"./system/modules/support/leavemessage.controller.js","controllerName":"LeaveMessageController","controllerAsName":"vm"},{"routeName":"/callus","templateUrl":"./templates/default/modules/support/callus.view.html","controllerUrl":"./system/modules/support/callus.controller.js","controllerName":"CallUsController","controllerAsName":"vm"},{"routeName":"/settings","templateUrl":"./templates/default/modules/settings/settings.view.html","controllerUrl":"./system/modules/settings/settings.controller.js","controllerName":"SettingsController","controllerAsName":"vm"},{"routeName":"/search","templateUrl":"./templates/default/modules/search/search.view.html","controllerUrl":"./system/modules/search/search.controller.js","controllerName":"SearchController","controllerAsName":"vm"},{"routeName":"/aboutus","templateUrl":"./templates/default/modules/lemoras/aboutus.view.html","controllerUrl":"./system/modules/lemoras/aboutus.controller.js","controllerName":"AboutUsController","controllerAsName":"vm"},{"routeName":"/lemoras","templateUrl":"./templates/default/modules/lemoras/lemoras.view.html","controllerUrl":"./system/modules/lemoras/lemoras.controller.js","controllerName":"LemorasController","controllerAsName":"vm"},{"routeName":"/license","templateUrl":"./templates/default/modules/lemoras/license.view.html","controllerUrl":"./system/modules/lemoras/license.controller.js","controllerName":"LicenseController","controllerAsName":"vm"},{"routeName":"/template","templateUrl":"./templates/default/modules/template/template.view.html","controllerUrl":"./system/modules/template/template.controller.js","controllerName":"TemplateController","controllerAsName":"vm"},{"routeName":"/language","templateUrl":"./templates/default/modules/language/language.view.html","controllerUrl":"./system/modules/language/language.controller.js","controllerName":"LanguageController","controllerAsName":"vm"},{"routeName":"/menu","templateUrl":"./templates/default/modules/menu/menu.view.html","controllerUrl":"./system/modules/menu/menu.controller.js","controllerName":"MenuController","controllerAsName":"vm"},{"routeName":"/menu-icon","templateUrl":"./templates/default/modules/menu/menuicon.view.html","controllerUrl":"./system/modules/menu/menuicon.controller.js","controllerName":"MenuIconController","controllerAsName":"vm"},{"routeName":"/menu-type","templateUrl":"./templates/default/modules/menu/menutype.view.html","controllerUrl":"./system/modules/menu/menutype.controller.js","controllerName":"MenuTypeController","controllerAsName":"vm"},{"routeName":"/menu-value","templateUrl":"./templates/default/modules/menu/menuvalue.view.html","controllerUrl":"./system/modules/menu/menuvalue.controller.js","controllerName":"MenuValueController","controllerAsName":"vm"}]},"navList":[{"value":"Ön-panel","label":"","icon":"dashboard","link":"/","tag":"dashboard","index":0,"list":[]},{"value":"Hesap","label":"","icon":"person","link":"#","tag":"account","index":1,"list":[{"value":"Kullanıcı Profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]}]},{"value":"Kullanıcı Yönetimi","label":"","icon":"supervisor_account","link":"#","tag":"systemadmin","index":1,"list":[{"value":"Kullanıcılar","label":"","icon":"dropdown-item","link":"#!/user","tag":"user","index":0,"list":[]},{"value":"Kullanıcı Rolleri","label":"","icon":"dropdown-item","link":"#!/user-role","tag":"user","index":1,"list":[]}]},{"value":"Uygulama Yönetimi","label":"","icon":"android","link":"#","tag":"systemadmin","index":2,"list":[{"value":"Uygulamalar","label":"","icon":"dropdown-item","link":"#!/application","tag":"application","index":0,"list":[]},{"value":"Şirket Uygulamaları","label":"","icon":"dropdown-item","link":"#!/company-application","tag":"user","index":1,"list":[]},{"value":"Uygulama Türleri","label":"","icon":"dropdown-item","link":"#!/application-type","tag":"application-type","index":2,"list":[]}]},{"value":"Rol Yönetimi","label":"","icon":"list_alt","link":"#","tag":"systemadmin","index":3,"list":[{"value":"Roller","label":"","icon":"dropdown-item","link":"#!/role","tag":"role","index":0,"list":[]},{"value":"Rol Yetkileri","label":"","icon":"dropdown-item","link":"#!/role-authorise","tag":"roleauthorise","index":1,"list":[]},{"value":"Rol Sayfa","label":"","icon":"dropdown-item","link":"#!/role-page","tag":"rolepage","index":2,"list":[]}]},{"value":"Modül Yönetimi","label":"","icon":"view_module","link":"#","tag":"systemadmin","index":4,"list":[{"value":"Modüller","label":"","icon":"dropdown-item","link":"#!/module","tag":"module","index":0,"list":[]},{"value":"Uygulama Modülleri","label":"","icon":"dropdown-item","link":"#!/application-module","tag":"application-type","index":1,"list":[]},{"value":"Uygulama Modülüne Sayfa Atama","label":"","icon":"dropdown-item","link":"#!/module-page","tag":"module-page","index":2,"list":[]},{"value":"Microservice Modülleri","label":"","icon":"dropdown-item","link":"#!/microservice-module","tag":"user","index":3,"list":[]}]},{"value":"Tanımlamar","label":"","icon":"notes","link":"#","tag":"systemadmin","index":5,"list":[{"value":"Sayfalar","label":"","icon":"dropdown-item","link":"#!/page","tag":"page","index":0,"list":[]},{"value":"Şirketler","label":"","icon":"dropdown-item","link":"#!/company","tag":"company","index":1,"list":[]},{"value":"Komutlar","label":"","icon":"dropdown-item","link":"#!/command","tag":"user","index":2,"list":[]},{"value":"İş Mantıkları","label":"","icon":"dropdown-item","link":"#!/business-logic","tag":"user","index":3,"list":[]},{"value":"İş Mantığı Hizmetleri","label":"","icon":"dropdown-item","link":"#!/business-service","tag":"user","index":4,"list":[]},{"value":"Microserviceler","label":"","icon":"dropdown-item","link":"#!/microservice","tag":"user","index":4,"list":[]},{"value":"Dil Tanımmı","label":"","icon":"dropdown-item","link":"#!/language","tag":"user","index":5,"list":[]},{"value":"Sayfa detal Tanımlama","label":"","icon":"dropdown-item","link":"#!/page-detail","tag":"user","index":7,"list":[]},{"value":"Sayfa detay özellikleri","label":"","icon":"dropdown-item","link":"#!/page-property","tag":"user","index":8,"list":[]},{"value":"Menu Tanımla","label":"","icon":"dropdown-item","link":"#!/menu","tag":"user","index":9,"list":[]},{"value":"Menu türü Tanımla","label":"","icon":"dropdown-item","link":"#!/menu-type","tag":"user","index":10,"list":[]},{"value":"Menu Icon Tanımla","label":"","icon":"dropdown-item","link":"#!/menu-icon","tag":"user","index":11,"list":[]},{"value":"Menu Deger Tanımla","label":"","icon":"dropdown-item","link":"#!/menu-value","tag":"user","index":12,"list":[]},{"value":"Şablon Tanımla","label":"","icon":"dropdown-item","link":"#!/template","tag":"user","index":13,"list":[]}]},{"value":"destek","label":"","icon":"contact_support","link":"#","tag":"support","index":6,"list":[{"value":"mesaj bırakın","label":"","icon":"dropdown-item","link":"#!/leavemessage","tag":"leavemessage","index":0,"list":[]},{"value":"bizi arayın","label":"","icon":"dropdown-item","link":"#!/callus","tag":"callus","index":1,"list":[]}]},{"value":"Çıkış","label":"","icon":"power_settings_new","link":"#!/logout","tag":"logout","index":7,"list":[]}],"userNavList":[{"value":"stats","label":"","icon":"dashboard","link":"/","tag":"","index":0,"list":[]},{"value":"bildirimler","label":"","icon":"notifications","link":"#","tag":"notifications","index":1,"list":[]},{"value":"hesap","label":"","icon":"person","link":"#","tag":"useraccount","index":2,"list":[{"value":"kullanıcı profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]},{"value":"ayarlar","label":"","icon":"dropdown-item","link":"#!/settings","tag":"settings","index":1,"list":[]},{"value":"Çıkış","label":"","icon":"dropdown-item","link":"#!/logout","tag":"logout","index":2,"list":[]}]}],"footerMenuList":[{"value":"Lemoras","label":null,"icon":null,"link":"/","tag":null,"index":0,"list":[]},{"value":"hakkımızda","label":null,"icon":null,"link":"#!/aboutus","tag":null,"index":1,"list":[]},{"value":"lisanslar","label":null,"icon":null,"link":"#!/license","tag":null,"index":2,"list":[]}],"searchBox":{"value":"ara...","label":"","icon":"search","link":"#!/search/:id","tag":null,"index":0,"list":[]}},"ApplicationJS":"whale.js"}
5	{"module":{"account":{"caption":"Profili Düzenle","label":"Profilini Tamamla","username":"Kullanıcı adı (disabled)","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","btnProfileUpdate":"Profili Güncelle","passwdLogo":"./assets/img/faces/key2.png","passwdPowered":"Powered by Lemoras","passwdCaption":"Şifre değiştir","currentPasswd":"Mevcut şifre","passwd":"Şifre","rePasswd":"Tekrar şifre","btnPasswdChange":"Değiştir"},"leaveMessage":{"compose":{"caption":"mesaj oluştur","label":"mesaj formu","subject":"konu","message":"mesaj içerği","messageDetail":"lütfen, sorunlarınızı yazınız..","btnMessageSend":"mesajı gönder"},"list":{"caption":"mesajlar","label":"mesajlarınız ve durumları hakkında bilgiler","properties":[{"name":"mesaj id","index":0},{"name":"durum","index":1},{"name":"konu","index":2},{"name":"mesaj","index":3}]}},"callUs":{"image":"./assets/img/phone-call.png","caption":"Call Us","esPhone":"+372 302 72-07","trPhone":"+90 546 533 40-26","btnEsCall":"Call Estonia Number","btnTrCall":"Call Turkey Number","btnLeaveMessage":"leave a message"},"logout":{"caption":"Çıkış","label":"Sistemden çıkmak istediğinize emin misiniz ?","btnCancel":"İptal","btnLogout":"Çıkış"}},"root":{"titleName":"Lemoras backofficev1.0","companyName":"Lemoras","route":{"default":"/","pages":[{"routeName":"/","templateUrl":"./templates/default/modules/dashboard/dashboard.view.html","controllerUrl":"./system/modules/dashboard/dashboard.controller.js","controllerName":"DashboardController","controllerAsName":"vm"},{"routeName":"/profile","templateUrl":"./templates/default/modules/account/account.view.html","controllerUrl":"./system/modules/account/account.controller.js","controllerName":"AccountController","controllerAsName":"vm"},{"routeName":"/leavemessage","templateUrl":"./templates/default/modules/support/leavemessage.view.html","controllerUrl":"./system/modules/support/leavemessage.controller.js","controllerName":"LeaveMessageController","controllerAsName":"vm"},{"routeName":"/callus","templateUrl":"./templates/default/modules/support/callus.view.html","controllerUrl":"./system/modules/support/callus.controller.js","controllerName":"CallUsController","controllerAsName":"vm"},{"routeName":"/settings","templateUrl":"./templates/default/modules/settings/settings.view.html","controllerUrl":"./system/modules/settings/settings.controller.js","controllerName":"SettingsController","controllerAsName":"vm"},{"routeName":"/search","templateUrl":"./templates/default/modules/search/search.view.html","controllerUrl":"./system/modules/search/search.controller.js","controllerName":"SearchController","controllerAsName":"vm"},{"routeName":"/aboutus","templateUrl":"./templates/default/modules/lemoras/aboutus.view.html","controllerUrl":"./system/modules/lemoras/aboutus.controller.js","controllerName":"AboutUsController","controllerAsName":"vm"},{"routeName":"/lemoras","templateUrl":"./templates/default/modules/lemoras/lemoras.view.html","controllerUrl":"./system/modules/lemoras/lemoras.controller.js","controllerName":"LemorasController","controllerAsName":"vm"},{"routeName":"/license","templateUrl":"./templates/default/modules/lemoras/license.view.html","controllerUrl":"./system/modules/lemoras/license.controller.js","controllerName":"LicenseController","controllerAsName":"vm"}]},"navList":[{"value":"Ön-panel","label":"","icon":"dashboard","link":"/","tag":"dashboard","index":0,"list":[]},{"value":"Hesap","label":"","icon":"person","link":"#","tag":"account","index":1,"list":[{"value":"Kullanıcı Profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]}]},{"value":"destek","label":"","icon":"contact_support","link":"#","tag":"support","index":6,"list":[{"value":"mesaj bırakın","label":"","icon":"dropdown-item","link":"#!/leavemessage","tag":"leavemessage","index":0,"list":[]},{"value":"bizi arayın","label":"","icon":"dropdown-item","link":"#!/callus","tag":"callus","index":1,"list":[]}]},{"value":"Çıkış","label":"","icon":"power_settings_new","link":"#!/logout","tag":"logout","index":7,"list":[]}],"userNavList":[{"value":"stats","label":"","icon":"dashboard","link":"/","tag":"","index":0,"list":[]},{"value":"bildirimler","label":"","icon":"notifications","link":"#","tag":"notifications","index":1,"list":[]},{"value":"hesap","label":"","icon":"person","link":"#","tag":"useraccount","index":2,"list":[{"value":"kullanıcı profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]},{"value":"ayarlar","label":"","icon":"dropdown-item","link":"#!/settings","tag":"settings","index":1,"list":[]},{"value":"Çıkış","label":"","icon":"dropdown-item","link":"#!/logout","tag":"logout","index":2,"list":[]}]}],"footerMenuList":[{"value":"Lemoras","label":null,"icon":null,"link":"/","tag":null,"index":0,"list":[]},{"value":"hakkımızda","label":null,"icon":null,"link":"#!/aboutus","tag":null,"index":1,"list":[]},{"value":"lisanslar","label":null,"icon":null,"link":"#!/license","tag":null,"index":2,"list":[]}],"searchBox":{"value":"ara...","label":"","icon":"search","link":"#!/search/:id","tag":null,"index":0,"list":[]}}}
6	{"module":{"account":{"caption":"Profili Düzenle","label":"Profilini Tamamla","username":"Kullanıcı adı (disabled)","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","btnProfileUpdate":"Profili Güncelle","passwdLogo":"./assets/img/faces/key2.png","passwdPowered":"Powered by Lemoras","passwdCaption":"Şifre değiştir","currentPasswd":"Mevcut şifre","passwd":"Şifre","rePasswd":"Tekrar şifre","btnPasswdChange":"Değiştir"},"user":{"compose":{"caption":"Kullanıcı Oluştur","label":"Kullanıcı tamamla","username":"Kullanıcı adı","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","active":"Aktif/Pasif","passwd":"Şifre","btnUserAdd":"Kullanıcıyı ekle"},"list":{"caption":"Kullanıcı Listesi Caption","label":"Tüm kullanıcılar; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"E-posta","index":1},{"name":"Adı","index":2},{"name":"Soyadı","index":3},{"name":"Aktif/Pasif","index":4},{"name":"Sisteme son girişi","index":5}]}},"userRole":{"compose":{"caption":"Kullanıcıya Rol Ata Caption","label":"Kullanıcıya rol ata Label","username":"Kullanıcı adı","applicationName":"Uygulama Adı","roleName":"Rol Adı","btnUserRoleAdd":"Kullanıcıya rol ata",},"list":{"caption":"Kullanıcı Rol Listesi Caption","label":"Tüm kullanıcıların rolleri; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"Uygulama Adı","index":1},{"name":"Rol Adı","index":2}]}},"leaveMessage":{"compose":{"caption":"mesaj oluştur","label":"mesaj formu","subject":"konu","message":"mesaj içerği","messageDetail":"lütfen, sorunlarınızı yazınız..","btnMessageSend":"mesajı gönder"},"list":{"caption":"mesajlar","label":"mesajlarınız ve durumları hakkında bilgiler","properties":[{"name":"mesaj id","index":0},{"name":"durum","index":1},{"name":"konu","index":2},{"name":"mesaj","index":3}]}},"callUs":{"image":"./assets/img/phone-call.png","caption":"Call Us","esPhone":"+372 302 72-07","trPhone":"+90 546 533 40-26","btnEsCall":"Call Estonia Number","btnTrCall":"Call Turkey Number","btnLeaveMessage":"leave a message"},"logout":{"caption":"Çıkış","label":"Sistemden çıkmak istediğinize emin misiniz ?","btnCancel":"İptal","btnLogout":"Çıkış"}},"root":{"titleName":"Lemoras backofficev1.0","companyName":"Lemoras","route":{"default":"/","pages":[{"routeName":"/","templateUrl":"./templates/default/modules/dashboard/dashboard.view.html","controllerUrl":"./system/modules/dashboard/dashboard.controller.js","controllerName":"DashboardController","controllerAsName":"vm"},{"routeName":"/profile","templateUrl":"./templates/default/modules/account/account.view.html","controllerUrl":"./system/modules/account/account.controller.js","controllerName":"AccountController","controllerAsName":"vm"},{"routeName":"/user","templateUrl":"./templates/default/modules/user/user.view.html","controllerUrl":"./system/modules/user/user.controller.js","controllerName":"UserController","controllerAsName":"vm"},{"routeName":"/user-role","templateUrl":"./templates/default/modules/user/userrole.view.html","controllerUrl":"./system/modules/user/userrole.controller.js","controllerName":"UserRoleController","controllerAsName":"vm"},{"routeName":"/leavemessage","templateUrl":"./templates/default/modules/support/leavemessage.view.html","controllerUrl":"./system/modules/support/leavemessage.controller.js","controllerName":"LeaveMessageController","controllerAsName":"vm"},{"routeName":"/callus","templateUrl":"./templates/default/modules/support/callus.view.html","controllerUrl":"./system/modules/support/callus.controller.js","controllerName":"CallUsController","controllerAsName":"vm"},{"routeName":"/settings","templateUrl":"./templates/default/modules/settings/settings.view.html","controllerUrl":"./system/modules/settings/settings.controller.js","controllerName":"SettingsController","controllerAsName":"vm"},{"routeName":"/search","templateUrl":"./templates/default/modules/search/search.view.html","controllerUrl":"./system/modules/search/search.controller.js","controllerName":"SearchController","controllerAsName":"vm"},{"routeName":"/aboutus","templateUrl":"./templates/default/modules/lemoras/aboutus.view.html","controllerUrl":"./system/modules/lemoras/aboutus.controller.js","controllerName":"AboutUsController","controllerAsName":"vm"},{"routeName":"/lemoras","templateUrl":"./templates/default/modules/lemoras/lemoras.view.html","controllerUrl":"./system/modules/lemoras/lemoras.controller.js","controllerName":"LemorasController","controllerAsName":"vm"},{"routeName":"/license","templateUrl":"./templates/default/modules/lemoras/license.view.html","controllerUrl":"./system/modules/lemoras/license.controller.js","controllerName":"LicenseController","controllerAsName":"vm"}]},"navList":[{"value":"Ön-panel","label":"","icon":"dashboard","link":"/","tag":"dashboard","index":0,"list":[]},{"value":"Hesap","label":"","icon":"person","link":"#","tag":"account","index":1,"list":[{"value":"Kullanıcı Profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]}]},{"value":"Kullanıcı Yönetimi","label":"","icon":"supervisor_account","link":"#","tag":"admin","index":1,"list":[{"value":"Kullanıcılar","label":"","icon":"dropdown-item","link":"#!/user","tag":"user","index":0,"list":[]},{"value":"Kullanıcı Rolleri","label":"","icon":"dropdown-item","link":"#!/user-role","tag":"user","index":1,"list":[]}]},{"value":"destek","label":"","icon":"contact_support","link":"#","tag":"support","index":6,"list":[{"value":"mesaj bırakın","label":"","icon":"dropdown-item","link":"#!/leavemessage","tag":"leavemessage","index":0,"list":[]},{"value":"bizi arayın","label":"","icon":"dropdown-item","link":"#!/callus","tag":"callus","index":1,"list":[]}]},{"value":"Çıkış","label":"","icon":"power_settings_new","link":"#!/logout","tag":"logout","index":7,"list":[]}],"userNavList":[{"value":"stats","label":"","icon":"dashboard","link":"/","tag":"","index":0,"list":[]},{"value":"bildirimler","label":"","icon":"notifications","link":"#","tag":"notifications","index":1,"list":[]},{"value":"hesap","label":"","icon":"person","link":"#","tag":"useraccount","index":2,"list":[{"value":"kullanıcı profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]},{"value":"ayarlar","label":"","icon":"dropdown-item","link":"#!/settings","tag":"settings","index":1,"list":[]},{"value":"Çıkış","label":"","icon":"dropdown-item","link":"#!/logout","tag":"logout","index":2,"list":[]}]}],"footerMenuList":[{"value":"Lemoras","label":null,"icon":null,"link":"/","tag":null,"index":0,"list":[]},{"value":"hakkımızda","label":null,"icon":null,"link":"#!/aboutus","tag":null,"index":1,"list":[]},{"value":"lisanslar","label":null,"icon":null,"link":"#!/license","tag":null,"index":2,"list":[]}],"searchBox":{"value":"ara...","label":"","icon":"search","link":"#!/search/:id","tag":null,"index":0,"list":[]}}}
11	{"module":{"account":{"caption":"Profili Düzenle","label":"Profilini Tamamla","username":"Kullanıcı adı (disabled)","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","btnProfileUpdate":"Profili Güncelle","passwdLogo":"./assets/img/faces/key2.png","passwdPowered":"Powered by Lemoras","passwdCaption":"Şifre değiştir","currentPasswd":"Mevcut şifre","passwd":"Şifre","rePasswd":"Tekrar şifre","btnPasswdChange":"Değiştir"},"user":{"compose":{"caption":"Kullanıcı Oluştur","label":"Kullanıcı tamamla","username":"Kullanıcı adı","email":"E-posta","company":"Şirket","firstname":"Adı","lastname":"Soyadı","active":"Aktif/Pasif","passwd":"Şifre","btnUserAdd":"Kullanıcıyı ekle"},"list":{"caption":"Kullanıcı Listesi Caption","label":"Tüm kullanıcılar; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"E-posta","index":1},{"name":"Adı","index":2},{"name":"Soyadı","index":3},{"name":"Aktif/Pasif","index":4},{"name":"Sisteme son girişi","index":5}]}},"userRole":{"compose":{"caption":"Kullanıcıya Rol Ata Caption","label":"Kullanıcıya rol ata Label","username":"Kullanıcı adı","applicationName":"Uygulama Adı","roleName":"Rol Adı","btnUserRoleAdd":"Kullanıcıya rol ata",},"list":{"caption":"Kullanıcı Rol Listesi Caption","label":"Tüm kullanıcıların rolleri; aktif, pasif, silinen..","properties":[{"name":"Kullanıcı adı","index":0},{"name":"Uygulama Adı","index":1},{"name":"Rol Adı","index":2}]}},"leaveMessage":{"compose":{"caption":"mesaj oluştur","label":"mesaj formu","subject":"konu","message":"mesaj içerği","messageDetail":"lütfen, sorunlarınızı yazınız..","btnMessageSend":"mesajı gönder"},"list":{"caption":"mesajlar","label":"mesajlarınız ve durumları hakkında bilgiler","properties":[{"name":"mesaj id","index":0},{"name":"durum","index":1},{"name":"konu","index":2},{"name":"mesaj","index":3}]}},"callUs":{"image":"./assets/img/phone-call.png","caption":"Call Us","esPhone":"+372 302 72-07","trPhone":"+90 546 533 40-26","btnEsCall":"Call Estonia Number","btnTrCall":"Call Turkey Number","btnLeaveMessage":"leave a message"},"logout":{"caption":"Çıkış","label":"Sistemden çıkmak istediğinize emin misiniz ?","btnCancel":"İptal","btnLogout":"Çıkış"}},"root":{"titleName":"Lemoras backofficev1.0","companyName":"Lemoras","route":{"default":"/","pages":[{"routeName":"/","templateUrl":"./templates/default/modules/dashboard/dashboard.view.html","controllerUrl":"./system/modules/dashboard/dashboard.controller.js","controllerName":"DashboardController","controllerAsName":"vm"},{"routeName":"/profile","templateUrl":"./templates/default/modules/account/account.view.html","controllerUrl":"./system/modules/account/account.controller.js","controllerName":"AccountController","controllerAsName":"vm"},{"routeName":"/user","templateUrl":"./templates/default/modules/user/user.view.html","controllerUrl":"./system/modules/user/user.controller.js","controllerName":"UserController","controllerAsName":"vm"},{"routeName":"/user-role","templateUrl":"./templates/default/modules/user/userrole.view.html","controllerUrl":"./system/modules/user/userrole.controller.js","controllerName":"UserRoleController","controllerAsName":"vm"},{"routeName":"/leavemessage","templateUrl":"./templates/default/modules/support/leavemessage.view.html","controllerUrl":"./system/modules/support/leavemessage.controller.js","controllerName":"LeaveMessageController","controllerAsName":"vm"},{"routeName":"/callus","templateUrl":"./templates/default/modules/support/callus.view.html","controllerUrl":"./system/modules/support/callus.controller.js","controllerName":"CallUsController","controllerAsName":"vm"},{"routeName":"/settings","templateUrl":"./templates/default/modules/settings/settings.view.html","controllerUrl":"./system/modules/settings/settings.controller.js","controllerName":"SettingsController","controllerAsName":"vm"},{"routeName":"/search","templateUrl":"./templates/default/modules/search/search.view.html","controllerUrl":"./system/modules/search/search.controller.js","controllerName":"SearchController","controllerAsName":"vm"},{"routeName":"/aboutus","templateUrl":"./templates/default/modules/lemoras/aboutus.view.html","controllerUrl":"./system/modules/lemoras/aboutus.controller.js","controllerName":"AboutUsController","controllerAsName":"vm"},{"routeName":"/lemoras","templateUrl":"./templates/default/modules/lemoras/lemoras.view.html","controllerUrl":"./system/modules/lemoras/lemoras.controller.js","controllerName":"LemorasController","controllerAsName":"vm"},{"routeName":"/license","templateUrl":"./templates/default/modules/lemoras/license.view.html","controllerUrl":"./system/modules/lemoras/license.controller.js","controllerName":"LicenseController","controllerAsName":"vm"}]},"navList":[{"value":"Ön-panel","label":"","icon":"dashboard","link":"/","tag":"dashboard","index":0,"list":[]},{"value":"Hesap","label":"","icon":"person","link":"#","tag":"account","index":1,"list":[{"value":"Kullanıcı Profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]}]},{"value":"Kullanıcı Yönetimi","label":"","icon":"supervisor_account","link":"#","tag":"admin","index":1,"list":[{"value":"Kullanıcılar","label":"","icon":"dropdown-item","link":"#!/user","tag":"user","index":0,"list":[]},{"value":"Kullanıcı Rolleri","label":"","icon":"dropdown-item","link":"#!/user-role","tag":"user","index":1,"list":[]}]},{"value":"destek","label":"","icon":"contact_support","link":"#","tag":"support","index":6,"list":[{"value":"mesaj bırakın","label":"","icon":"dropdown-item","link":"#!/leavemessage","tag":"leavemessage","index":0,"list":[]},{"value":"bizi arayın","label":"","icon":"dropdown-item","link":"#!/callus","tag":"callus","index":1,"list":[]}]},{"value":"Çıkış","label":"","icon":"power_settings_new","link":"#!/logout","tag":"logout","index":7,"list":[]}],"userNavList":[{"value":"stats","label":"","icon":"dashboard","link":"/","tag":"","index":0,"list":[]},{"value":"bildirimler","label":"","icon":"notifications","link":"#","tag":"notifications","index":1,"list":[]},{"value":"hesap","label":"","icon":"person","link":"#","tag":"useraccount","index":2,"list":[{"value":"kullanıcı profili","label":"","icon":"dropdown-item","link":"#!/profile","tag":"userprofile","index":0,"list":[]},{"value":"ayarlar","label":"","icon":"dropdown-item","link":"#!/settings","tag":"settings","index":1,"list":[]},{"value":"Çıkış","label":"","icon":"dropdown-item","link":"#!/logout","tag":"logout","index":2,"list":[]}]}],"footerMenuList":[{"value":"Lemoras","label":null,"icon":null,"link":"/","tag":null,"index":0,"list":[]},{"value":"hakkımızda","label":null,"icon":null,"link":"#!/aboutus","tag":null,"index":1,"list":[]},{"value":"lisanslar","label":null,"icon":null,"link":"#!/license","tag":null,"index":2,"list":[]}],"searchBox":{"value":"ara...","label":"","icon":"search","link":"#!/search/:id","tag":null,"index":0,"list":[]}}}
\.


--
-- TOC entry 3238 (class 0 OID 17915)
-- Dependencies: 207
-- Data for Name: application; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.application (application_id, application_type_id, application_name, application_js, database_name) FROM stdin;
1	5	Camel	camel.js	0
2	5	Sample E-Ticaret Backoffice	whale.js	0
3	6	Sample E-Ticaret	whale.js	0
6	7	System_Backoffice	whale.js	0
\.


--
-- TOC entry 3260 (class 0 OID 18105)
-- Dependencies: 229
-- Data for Name: application_instance; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.application_instance (application_instance_id, application_id, company_id, template_id, application_tag_name, database_name, connection_string) FROM stdin;
5	2	2	1	Sompo E-Commerce	xxx	Host=xxx.com;Database=xxx;Username=xxx; Password=xxx;
7	6	6	1	Tüm Sistemin Admin Uygulaması	xxx	Host=xxx.com;Database=xxx;Username=xxx; Password=xxx;
8	1	6	1	Lemoras E-Ticaret	\N	\N
\.


--
-- TOC entry 3252 (class 0 OID 18021)
-- Dependencies: 221
-- Data for Name: application_module; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.application_module (application_module_id, application_id, module_id, business_logic_id) FROM stdin;
19	6	5	4
20	6	3	5
21	6	4	7
23	6	7	8
27	6	6	8
28	6	8	17
32	6	10	8
33	6	2	8
34	6	9	8
46	2	4	12
47	2	7	13
50	2	5	9
55	1	4	12
57	6	23	7
58	6	16	8
59	6	17	8
60	6	18	15
61	6	19	8
62	6	20	8
63	6	22	8
64	6	24	8
65	6	25	8
\.


--
-- TOC entry 3234 (class 0 OID 17896)
-- Dependencies: 203
-- Data for Name: application_type; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.application_type (application_type_id, application_type_name, isbackoffice) FROM stdin;
1	B2B - CMS	1
2	B2C - CMS	0
3	B2B - CRM	1
4	B2C - CRM	0
5	B2B - E-Commerce	1
6	B2C - E-Commerce	0
7	System - Admin	1
\.


--
-- TOC entry 3248 (class 0 OID 17986)
-- Dependencies: 217
-- Data for Name: business_logic; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.business_logic (business_logic_id, business_logic_name, business_service_id, unique_key) FROM stdin;
4	Application_Default_Logic	1	ApplicationService
5	Company_Default_Logic	2	CompanyService
6	Config_Default_Logic	3	ConfigService
7	User_Default_logic	4	UserService
8	System_Default_logic	5	SystemService
9	Application_Limited_Logic	1	LimitedApplicationService
12	User_Limited_Logic	4	LimitedUserService
13	System_Limited_Logic	5	LimitedSystemService
15	Menu_Default_Logic	6	MenuService
16	Menu_Limited_Logic	6	LimitedMenuService
17	Page_Default_Logic	7	PageService
18	Page_Limited_logic	7	LimitedPageService
\.


--
-- TOC entry 3240 (class 0 OID 17933)
-- Dependencies: 209
-- Data for Name: business_service; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.business_service (business_service_id, business_service_name, business_service_key) FROM stdin;
1	Application Service	IApplicationService
2	Company Service	ICompanyService
3	Config Service	IConfigService
4	User Service	IUserService
5	System Service	ISystemService
6	Menu Service	IMenuService
7	Page Service	IPageService
\.


--
-- TOC entry 3242 (class 0 OID 17943)
-- Dependencies: 211
-- Data for Name: command; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.command (command_id, command_name, business_service_id) FROM stdin;
1	AddNewApplication	1
2	DeleteApplication	1
3	RemoveApplicationFromCompany	1
4	AttachToApplicationAtCompany	1
5	SetActiveToApplication	1
6	SetPassiveToApplication	1
8	GetApplicationsOfCompany	1
9	GetApplications	1
10	GetApplicationTypes	1
11	GetApplicationType	1
12	CreateRoleToApplication	1
13	RemoveRoleFromApplication	1
14	GetRolesOfApplication	1
15	GetApplicationsOfRole	1
16	AddNewCompany	2
17	DeleteCompany	2
18	UpdateCompany	2
19	SetActiveToCompany	2
20	SetPassiveToCompany	2
21	GetCompanies	2
22	GetCompany	2
24	AddNewUser	4
25	DeleteUser	4
26	RemoveUserFromApplicationAndRole	4
27	AttachToUserAtApplicationAndRole	4
28	SetActiveToUser	4
29	SetPassiveToUser	4
30	GetUsersOfCompany	4
31	GetUsersOfApplication	4
32	GetUsers	4
33	GetUserRole	4
34	GetMyProfile	4
35	AddNewModule	5
36	DeleteModule	5
37	AttachToPageAtModule	5
38	AttachToCommandAtRole	5
39	AttachToModuleAtMicroservice	5
40	AddNewPage	5
41	DeletePage	5
42	AddNewCommand	5
43	DeleteCommand	5
44	AddNewBusinessLogic	5
45	DeleteBusinessLogic	5
46	AddNewMicroservice	5
47	DeleteMicroservice	5
48	GetMicroservices	5
49	GetMicroserviceModules	5
50	GetModules	5
51	GetModuleRoutes	5
52	GetRoles	5
53	GetRoleAuthorises	5
54	GetRoutes	5
55	GetCommands	5
56	GetBusinessLogics	5
57	GetApplicationModules	1
58	UpdateProfile	4
59	AddNewApplicationType	1
60	GetApplicationsOfCompanies	1
61	DeleteApplicationType	1
63	DeleteRoleAuthorise	5
64	DeleteMicroserviceModule	5
65	DeleteApplicationModule	1
66	AddNewApplicationModule	1
69	GetBusinessServices	5
70	AddNewBusinessService	5
71	DeleteBusinessService	5
72	GetLanguages	5
73	AddLanguage	5
74	DeleteLanguage	5
75	GetTemplates	5
76	AddTemplate	5
77	DeleteTemplate	5
78	GetMenus	6
79	AddMenu	6
80	DeleteMenu	6
81	GetMenuIcons	6
82	AddMenuIcon	6
83	DeleteMenuIcon	6
84	GetMenuTypes	6
85	AddMenuType	6
86	DeleteMenuType	6
87	GetMenuValues	6
88	AddMenuValue	6
89	DeleteMenuValue	6
90	GetPages	7
91	AddPage	7
96	GetPageDetails	7
97	AddPageDetail	7
98	DeletePageDetail	7
99	GetPageProperties	7
100	AddPageProperty	7
101	DeletePageProperty	7
\.


--
-- TOC entry 3232 (class 0 OID 17888)
-- Dependencies: 201
-- Data for Name: company; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.company (company_id, company_name) FROM stdin;
1	Umur Basım
2	Sompo Japan
3	Aksigorta
6	Lemoras
\.


--
-- TOC entry 3236 (class 0 OID 17906)
-- Dependencies: 205
-- Data for Name: language; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.language (language_id, language_name) FROM stdin;
1	Türkçe
\.


--
-- TOC entry 3280 (class 0 OID 18317)
-- Dependencies: 249
-- Data for Name: menu; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.menu (menu_id, role_id, menu_type_id, parent_menu_id, page_id, menu_icon_id, menu_value_id, index, menu_label, menu_tag) FROM stdin;
1	7	1	\N	4	1	1	0		dashboard
2	7	1	\N	\N	2	5	1	\N	account
3	7	1	2	5	3	6	0	\N	userprofile
4	7	1	\N	\N	4	7	2	\N	systemadmin
5	7	1	4	6	3	8	0	\N	user
6	7	1	4	7	3	9	1	\N	user
7	7	1	\N	\N	6	10	3	\N	systemadmin
8	7	1	7	8	3	11	0	\N	application
9	7	1	7	19	3	12	1	\N	application
10	7	1	7	9	3	13	2	\N	application-type
11	7	1	\N	\N	5	14	4	\N	systemadmin
12	7	1	11	20	3	15	0	\N	role
13	7	1	11	21	3	16	1	\N	roleauthorise
14	7	1	\N	\N	10	19	5	\N	systemadmin
15	7	1	14	15	3	20	0	\N	module
16	7	1	14	10	3	21	1	\N	application-module
17	7	1	14	14	3	22	3	\N	microservice-module
18	7	1	14	16	3	23	2	\N	module-page
19	7	1	\N	\N	8	24	6	\N	systemadmin
20	7	1	19	17	3	26	0	\N	page
21	7	1	19	18	3	25	1	\N	company
22	7	1	19	12	3	27	2	\N	command
23	7	1	19	11	3	28	3	\N	business-ogic
24	7	1	19	13	3	29	4	\N	microservices
25	7	1	\N	\N	11	30	7	\N	support
26	7	1	25	22	3	31	0	\N	leavemessage
27	7	1	25	23	3	41	1	\N	callus
28	7	1	\N	\N	12	32	8	\N	logout
29	7	2	\N	\N	1	33	0	\N	\N
30	7	2	\N	\N	7	34	1	\N	notifications
31	7	2	\N	\N	2	5	2	\N	useraccount
32	7	2	29	5	3	6	0	\N	userprofile
33	7	2	29	24	3	35	1	\N	settings
34	7	2	29	\N	3	32	2	\N	logout
35	7	3	\N	4	\N	37	0	\N	\N
36	7	3	\N	26	\N	38	1	\N	\N
37	7	3	\N	28	\N	39	2	\N	\N
38	7	4	\N	\N	\N	40	0	\N	\N
\.


--
-- TOC entry 3246 (class 0 OID 17970)
-- Dependencies: 215
-- Data for Name: menu_icon; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.menu_icon (menu_icon_id, template_id, menu_icon_value) FROM stdin;
1	1	dashboard
2	1	person
3	1	dropdown-item
4	1	supervisor_account
5	1	list_alt
6	1	android
7	1	notifications
8	1	notes
9	1	search
10	1	view_module
11	1	contact_support
12	1	power_settings_new
\.


--
-- TOC entry 3266 (class 0 OID 18166)
-- Dependencies: 235
-- Data for Name: menu_type; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.menu_type (menu_type_id, application_id, menu_type_name) FROM stdin;
1	6	nav list
2	6	user nav list
3	6	footer menu list
4	6	search box
\.


--
-- TOC entry 3264 (class 0 OID 18150)
-- Dependencies: 233
-- Data for Name: menu_value; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.menu_value (menu_value_id, language_id, menu_value_name) FROM stdin;
1	1	Ön-panel
5	1	Hesap
6	1	Kullanıcı profili
7	1	Kullanıcı yönetimi
8	1	Kullanıcılar
9	1	Kullanıcı rolleri
10	1	Uygulama yönetimi
11	1	Uygulamalar
12	1	Şirket uygulamaları
13	1	Uygulama türleri
14	1	Rol yönetimi
15	1	Roller
16	1	Rol yetkileri
19	1	Modül yönetimi
20	1	Modüller
21	1	Uygulama modülleri
22	1	Microservice modülleri
23	1	Uygulama modülüne Sayfa Atama
24	1	Tanımlamalar
25	1	Şirketler
26	1	Sayfalar
27	1	Komutlar
28	1	İş mantıkları
29	1	Microservice'ler
30	1	Destek
31	1	Mesaj bırakın
32	1	Çıkış
33	1	stats
34	1	Bildirimler
35	1	Ayarlar
37	1	Lemoras
38	1	Hakkmızda
39	1	Lisanslar
40	1	ara..
41	1	Bizi arayın
\.


--
-- TOC entry 3256 (class 0 OID 18072)
-- Dependencies: 225
-- Data for Name: microservice; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.microservice (microservice_id, unique_key, microservice_name) FROM stdin;
1	\\x34303130464645342d383436312d343143322d413032322d303035423936363338433831	Auth_Microservice
2	\\x35323045363135452d463145302d344437362d394231322d313241373942444532303330	Payment_Microservice
3	\\x42423533303342332d334643452d344445432d393634352d413245314331364135323444	Order_Microservice
4	\\x46324232343835352d343643462d344244362d384534302d374430343833413138333641	Product_Microservice
5	\\x46354444344142332d393645322d344237312d414144412d423043423332383932443931	App_Microservice
\.


--
-- TOC entry 3258 (class 0 OID 18085)
-- Dependencies: 227
-- Data for Name: microservice_module; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.microservice_module (microservice_module_id, microservice_id, module_id) FROM stdin;
7	5	5
8	5	6
9	5	8
10	5	7
11	5	4
12	5	10
13	5	9
14	5	2
15	5	3
\.


--
-- TOC entry 3230 (class 0 OID 17879)
-- Dependencies: 199
-- Data for Name: module; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.module (module_id, module_name) FROM stdin;
2	Command
3	Company
4	User
5	Application
6	Module
7	Role
8	Page
9	Microservice
10	BusinessLogic
16	Template
17	Language
18	Menu
19	Lemoras
20	Settings
22	Support
23	Account
24	Dashboard
25	Search
\.


--
-- TOC entry 3270 (class 0 OID 18198)
-- Dependencies: 239
-- Data for Name: module_page; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.module_page (module_page_id, application_instance_id, application_module_id, page_id) FROM stdin;
15	7	19	8
16	7	19	9
19	7	19	10
20	7	19	19
21	7	32	11
22	7	33	12
23	7	20	18
24	7	34	13
25	7	34	14
26	7	27	15
27	7	27	16
28	7	28	17
29	7	23	20
30	7	23	21
33	7	21	5
34	7	21	6
35	7	21	7
\.


--
-- TOC entry 3250 (class 0 OID 18001)
-- Dependencies: 219
-- Data for Name: page; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.page (page_id, template_id, route_name, template_url, controller_url, controller_name, controller_as_name) FROM stdin;
1	1	/paymenthistory	assets/app/module/payment/peymenthistory.view.html	assets/app/module/payment/peymenthistory.controller.html	PaymentHistoryController	vm
2	1	/paymentmethod	assets/app/module/payment/paymentmethod.view.html	assets/app/module/payment/paymentmethod.controller.html	PaymentMethodController	vm
4	1	/	./templates/default/modules/dashboard/dashboard.view.html	./system/modules/dashboard/dashboard.controller.js	DashboardController	vm
5	1	/profile	./templates/default/modules/account/account.view.html	./system/modules/account/account.controller.js	AccountController	vm
6	1	/user	./templates/default/modules/user/user.view.html	./system/modules/user/user.controller.js	UserController	vm
7	1	/user-role	./templates/default/modules/user/userrole.view.html	./system/modules/user/userrole.controller.js	UserRoleController	vm
8	1	/application	./templates/default/modules/application/application.view.html	./system/modules/application/application.controller.js	ApplicationController	vm
9	1	/application-type	./templates/default/modules/application/applicationtype.view.html	./system/modules/application/applicationtype.controller.js	ApplicationTypeController	vm
10	1	/application_module	./templates/default/modules/application/applicationmodule.view.html	./system/modules/application/applicationmodule.controller.js	ApplicationModuleController	vm
11	1	/business-logic	./templates/default/modules/businesslogic/businesslogic.view.html	./system/modules/businesslogic/businesslogic.controller.js	BusinessLogicController	vm
12	1	/command	./templates/default/modules/command/command.view.html	./system/modules/command/command.controller.js	CommandController	vm
13	1	/microservice	./templates/default/modules/microservice/microservice.view.html	./system/modules/microservice/microservice.controller.js	MicroserviceController	vm
14	1	/microservice-module	./templates/default/modules/microservice/microservicemodule.view.html	./system/modules/microservice/microservicemodule.controller.js	MicroserviceModuleController	vm
15	1	/module	./templates/default/modules/module/module.view.html	./system/modules/module/module.controller.js	ModuleController	vm
16	1	/module-page	./templates/default/modules/module/modulepage.view.html	./system/modules/module/modulepage.controller.js	ModulePageController	vm
17	1	/page	./templates/default/modules/page/page.view.html	./system/modules/page/page.controller.js	PageController	vm
18	1	/company	./templates/default/modules/company/company.view.html	./system/modules/company/company.controller.js	CompanyController	vm
19	1	/company-application	./templates/default/modules/company/companyapplication.view.html	./system/modules/company/companyapplication.controller.js	CompanyApplicationController	vm
20	1	/role	./templates/default/modules/role/role.view.html	./system/modules/role/role.controller.js	RoleController	vm
21	1	/role-authorise	./templates/default/modules/role/roleauthorise.view.html	./system/modules/role/roleauthorise.controller.js	RoleAuthoriseController	vm
22	1	/leavemessage	./templates/default/modules/support/leavemessage.view.html	./system/modules/support/leavemessage.controller.js	LeaveMessageController	vm
23	1	/callus	./templates/default/modules/support/callus.view.html	./system/modules/support/callus.controller.js	CallUsController	vm
24	1	/settings	./templates/default/modules/settings/settings.view.html	./system/modules/settings/settings.controller.js	SettingsController	vm
25	1	/search	./templates/default/modules/search/search.view.html	./system/modules/search/search.controller.js	SearchController	vm
26	1	/aboutus	./templates/default/modules/lemoras/aboutus.view.html	./system/modules/lemoras/aboutus.controller.js	AboutUsController	vm
27	1	/lemoras	./templates/default/modules/lemoras/lemoras.view.html	./system/modules/lemoras/lemoras.controller.js	LemorasController	vm
28	1	/license	./templates/default/modules/lemoras/license.view.html	./system/modules/lemoras/license.controller.js	LicenseController	vm
29	1	/logout	./system/modules/logout/logout.view.html	./system/modules/logout/logout.controller.js	LogoutController	vm
33	1	/business-service	./templates/default/modules/businesslogic/businessservice.view.html	./system/modules/businesslogic/businessservice.controller.js	BusinessServiceController	vm
35	1	/page-detail	./templates/default/modules/page/pagedetail.view.html	./system/modules/page/pagedetail.controller.js	PageDetailController	vm
36	1	/page-property	./templates/default/modules/page/pageproperty.view.html	./system/modules/page/pageproperty.controller.js	PagePropertyController	vm
37	1	/menu	./templates/default/modules/menu/menu.view.html	./system/modules/menu/menu.controller.js	MenuController	vm
38	1	/menu-icon	./templates/default/modules/menu/menuicon.view.html	./system/modules/menu/menuicon.controller.js	MenuIconController	vm
39	1	/menu-type	./templates/default/modules/menu/menutype.view.html	./system/modules/menu/menutype.controller.js	MenuTypeController	vm
40	1	/menu-value	./templates/default/modules/menu/menuvalue.view.html	./system/modules/menu/menuvalue.controller.js	MenuValueController	vm
41	1	/role-page	./templates/default/modules/role/rolepage.view.html	./system/modules/role/rolepage.controller.js	RolePageController	vm
42	1	/template	./templates/default/modules/template/template.view.html	./system/modules/template/template.controller.js	TemplateController	vm
43	1	/language	./templates/default/modules/language/language.view.html	./system/modules/language/language.controller.js	LanguageController	vm
\.


--
-- TOC entry 3254 (class 0 OID 18050)
-- Dependencies: 223
-- Data for Name: page_detail; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.page_detail (page_detail_id, page_id, language_id) FROM stdin;
53	5	1
55	8	1
56	9	1
57	10	1
58	11	1
59	33	1
60	23	1
61	12	1
62	18	1
63	19	1
64	43	1
65	26	1
66	22	1
67	27	1
68	28	1
69	29	1
70	37	1
71	38	1
72	39	1
75	40	1
76	13	1
77	14	1
78	15	1
79	16	1
80	17	1
81	35	1
82	36	1
83	1	1
84	2	1
85	20	1
86	21	1
87	41	1
88	25	1
89	24	1
92	42	1
93	6	1
94	7	1
\.


--
-- TOC entry 3268 (class 0 OID 18182)
-- Dependencies: 237
-- Data for Name: role; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.role (role_id, application_id, role_name) FROM stdin;
5	2	Agency
6	2	Admin
7	6	System_Admin
11	1	admin-lemoras
\.


--
-- TOC entry 3272 (class 0 OID 18227)
-- Dependencies: 241
-- Data for Name: role_authorise; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.role_authorise (role_authorise_id, role_id, command_id) FROM stdin;
4	7	1
5	7	2
6	7	3
7	7	4
8	7	5
9	7	6
10	7	16
11	7	24
12	7	27
14	7	12
16	7	17
17	7	25
18	7	9
19	7	8
22	7	15
23	7	11
24	7	10
26	7	21
27	7	22
29	7	14
30	7	33
31	7	32
32	7	31
33	7	30
34	7	13
35	7	26
36	7	19
37	7	28
39	7	20
41	7	29
43	7	18
44	7	34
45	7	35
46	7	36
47	7	37
48	7	38
49	7	39
50	7	40
51	7	41
54	7	42
55	7	43
56	7	44
57	7	45
58	7	46
59	7	47
60	7	48
61	7	49
62	7	50
63	7	51
64	7	52
65	7	53
66	7	54
67	7	55
68	7	56
69	7	57
70	7	58
71	7	59
74	7	60
75	7	61
78	7	63
80	7	64
81	7	65
82	7	66
89	5	34
91	6	34
92	6	32
94	6	14
95	6	60
96	6	33
97	11	34
98	6	24
99	7	70
100	7	69
101	7	71
102	7	72
103	7	73
104	7	74
105	7	75
106	7	76
107	7	77
108	7	78
109	7	79
110	7	80
111	7	81
112	7	82
113	7	83
114	7	84
115	7	85
116	7	86
117	7	87
118	7	88
119	7	89
120	7	90
121	7	91
124	7	96
125	7	97
126	7	98
127	7	99
128	7	100
129	7	101
\.


--
-- TOC entry 3274 (class 0 OID 18249)
-- Dependencies: 243
-- Data for Name: role_page; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.role_page (role_page_id, role_id, module_page_id) FROM stdin;
1	7	15
2	7	16
3	7	19
4	7	20
5	7	21
6	7	22
7	7	23
8	7	24
9	7	25
10	7	26
11	7	27
12	7	28
13	7	29
14	7	30
15	7	33
16	7	34
17	7	35
\.


--
-- TOC entry 3244 (class 0 OID 17960)
-- Dependencies: 213
-- Data for Name: template; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.template (template_id, template_name, template_url) FROM stdin;
1	Varsayılan	default
\.


--
-- TOC entry 3262 (class 0 OID 18138)
-- Dependencies: 231
-- Data for Name: user; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel."user" (user_id, username, password, email, first_name, last_name, active, last_login_date) FROM stdin;
1	admin	admin	onur.yasar@tatilsepeti.com	onur	yaşar	1	2019-08-08 10:42:24
2	omerdelikaya	123456	omder.delikaya@sompojapan.com.tr	Ömer	Delikaya	1	2019-03-08 09:33:10
17	sabri	123	sabri@umur.com.tr	Sabri Asil	Eyüp	1	2019-07-16 17:27:34
18	dila	dila	dila.coskun@umur.com.tr	dila	coşkun	1	2019-04-05 06:37:38
19	hasan	hasan	hasan@gmail.com	hasan	yaşar	1	2019-06-30 12:12:41
21	omer	123	omer@lemoras.com	Hasan Ömer	Yaşar	1	2019-06-30 13:30:39
\.


--
-- TOC entry 3276 (class 0 OID 18271)
-- Dependencies: 245
-- Data for Name: user_contact; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.user_contact (user_contact_id, user_id, phone, fax) FROM stdin;
1	1	0	0
\.


--
-- TOC entry 3278 (class 0 OID 18288)
-- Dependencies: 247
-- Data for Name: user_role; Type: TABLE DATA; Schema: kernel; Owner: xxx
--

COPY kernel.user_role (user_role_id, user_id, application_instance_id, role_id) FROM stdin;
12	2	5	5
16	17	5	5
17	18	5	5
18	1	7	7
22	1	5	6
29	19	5	6
30	21	8	11
31	1	8	11
\.


--
-- TOC entry 3312 (class 0 OID 0)
-- Dependencies: 206
-- Name: application_application_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.application_application_id_seq', 6, true);


--
-- TOC entry 3313 (class 0 OID 0)
-- Dependencies: 228
-- Name: application_instance_application_instance_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.application_instance_application_instance_id_seq', 8, true);


--
-- TOC entry 3314 (class 0 OID 0)
-- Dependencies: 220
-- Name: application_module_application_module_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.application_module_application_module_id_seq', 65, true);


--
-- TOC entry 3315 (class 0 OID 0)
-- Dependencies: 202
-- Name: application_type_application_type_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.application_type_application_type_id_seq', 7, true);


--
-- TOC entry 3316 (class 0 OID 0)
-- Dependencies: 216
-- Name: business_logic_business_logic_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.business_logic_business_logic_id_seq', 18, true);


--
-- TOC entry 3317 (class 0 OID 0)
-- Dependencies: 208
-- Name: business_service_business_service_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.business_service_business_service_id_seq', 7, true);


--
-- TOC entry 3318 (class 0 OID 0)
-- Dependencies: 210
-- Name: command_command_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.command_command_id_seq', 101, true);


--
-- TOC entry 3319 (class 0 OID 0)
-- Dependencies: 200
-- Name: company_company_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.company_company_id_seq', 6, true);


--
-- TOC entry 3320 (class 0 OID 0)
-- Dependencies: 204
-- Name: language_language_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.language_language_id_seq', 1, true);


--
-- TOC entry 3321 (class 0 OID 0)
-- Dependencies: 214
-- Name: menu_icon_menu_icon_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.menu_icon_menu_icon_id_seq', 12, true);


--
-- TOC entry 3322 (class 0 OID 0)
-- Dependencies: 248
-- Name: menu_menu_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.menu_menu_id_seq', 38, true);


--
-- TOC entry 3323 (class 0 OID 0)
-- Dependencies: 234
-- Name: menu_type_menu_type_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.menu_type_menu_type_id_seq', 4, true);


--
-- TOC entry 3324 (class 0 OID 0)
-- Dependencies: 232
-- Name: menu_value_menu_value_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.menu_value_menu_value_id_seq', 41, true);


--
-- TOC entry 3325 (class 0 OID 0)
-- Dependencies: 224
-- Name: microservice_microservice_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.microservice_microservice_id_seq', 5, true);


--
-- TOC entry 3326 (class 0 OID 0)
-- Dependencies: 226
-- Name: microservice_module_microservice_module_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.microservice_module_microservice_module_id_seq', 15, true);


--
-- TOC entry 3327 (class 0 OID 0)
-- Dependencies: 198
-- Name: module_module_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.module_module_id_seq', 25, true);


--
-- TOC entry 3328 (class 0 OID 0)
-- Dependencies: 238
-- Name: module_page_module_page_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.module_page_module_page_id_seq', 35, true);


--
-- TOC entry 3329 (class 0 OID 0)
-- Dependencies: 222
-- Name: page_detail_page_detail_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.page_detail_page_detail_id_seq', 94, true);


--
-- TOC entry 3330 (class 0 OID 0)
-- Dependencies: 218
-- Name: page_page_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.page_page_id_seq', 43, true);


--
-- TOC entry 3331 (class 0 OID 0)
-- Dependencies: 240
-- Name: role_authorise_role_authorise_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.role_authorise_role_authorise_id_seq', 129, true);


--
-- TOC entry 3332 (class 0 OID 0)
-- Dependencies: 242
-- Name: role_page_role_page_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.role_page_role_page_id_seq', 17, true);


--
-- TOC entry 3333 (class 0 OID 0)
-- Dependencies: 236
-- Name: role_role_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.role_role_id_seq', 11, true);


--
-- TOC entry 3334 (class 0 OID 0)
-- Dependencies: 212
-- Name: template_template_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.template_template_id_seq', 1, true);


--
-- TOC entry 3335 (class 0 OID 0)
-- Dependencies: 244
-- Name: user_contact_user_contact_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.user_contact_user_contact_id_seq', 1, true);


--
-- TOC entry 3336 (class 0 OID 0)
-- Dependencies: 246
-- Name: user_role_user_role_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.user_role_user_role_id_seq', 31, true);


--
-- TOC entry 3337 (class 0 OID 0)
-- Dependencies: 230
-- Name: user_user_id_seq; Type: SEQUENCE SET; Schema: kernel; Owner: xxx
--

SELECT pg_catalog.setval('kernel.user_user_id_seq', 21, true);


--
-- TOC entry 2980 (class 2606 OID 17874)
-- Name: config config_pkey; Type: CONSTRAINT; Schema: config; Owner: xxx
--

ALTER TABLE ONLY config.config
    ADD CONSTRAINT config_pkey PRIMARY KEY (id);


--
-- TOC entry 3031 (class 2606 OID 18117)
-- Name: application_instance application_instance_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_instance
    ADD CONSTRAINT application_instance_pkey PRIMARY KEY (application_instance_id);


--
-- TOC entry 3014 (class 2606 OID 18029)
-- Name: application_module application_module_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT application_module_pkey PRIMARY KEY (application_module_id);


--
-- TOC entry 2991 (class 2606 OID 17924)
-- Name: application application_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application
    ADD CONSTRAINT application_pkey PRIMARY KEY (application_id);


--
-- TOC entry 2986 (class 2606 OID 17903)
-- Name: application_type application_type_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_type
    ADD CONSTRAINT application_type_pkey PRIMARY KEY (application_type_id);


--
-- TOC entry 3006 (class 2606 OID 17992)
-- Name: business_logic business_logic_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT business_logic_pkey PRIMARY KEY (business_logic_id);


--
-- TOC entry 2993 (class 2606 OID 17940)
-- Name: business_service business_service_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.business_service
    ADD CONSTRAINT business_service_pkey PRIMARY KEY (business_service_id);


--
-- TOC entry 2996 (class 2606 OID 17951)
-- Name: command command_command_name_key; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_command_name_key UNIQUE (command_name);


--
-- TOC entry 2998 (class 2606 OID 17949)
-- Name: command command_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT command_pkey PRIMARY KEY (command_id);


--
-- TOC entry 2984 (class 2606 OID 17893)
-- Name: company company_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.company
    ADD CONSTRAINT company_pkey PRIMARY KEY (company_id);


--
-- TOC entry 2988 (class 2606 OID 17912)
-- Name: language language_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.language
    ADD CONSTRAINT language_pkey PRIMARY KEY (language_id);


--
-- TOC entry 3003 (class 2606 OID 17977)
-- Name: menu_icon menu_icon_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_icon
    ADD CONSTRAINT menu_icon_pkey PRIMARY KEY (menu_icon_id);


--
-- TOC entry 3071 (class 2606 OID 18323)
-- Name: menu menu_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT menu_pkey PRIMARY KEY (menu_id);


--
-- TOC entry 3039 (class 2606 OID 18173)
-- Name: menu_type menu_type_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_type
    ADD CONSTRAINT menu_type_pkey PRIMARY KEY (menu_type_id);


--
-- TOC entry 3036 (class 2606 OID 18157)
-- Name: menu_value menu_value_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_value
    ADD CONSTRAINT menu_value_pkey PRIMARY KEY (menu_value_id);


--
-- TOC entry 3026 (class 2606 OID 18090)
-- Name: microservice_module microservice_module_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice_module
    ADD CONSTRAINT microservice_module_pkey PRIMARY KEY (microservice_module_id);


--
-- TOC entry 3020 (class 2606 OID 18080)
-- Name: microservice microservice_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice
    ADD CONSTRAINT microservice_pkey PRIMARY KEY (microservice_id);


--
-- TOC entry 3022 (class 2606 OID 18082)
-- Name: microservice microservice_unique_key_key; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice
    ADD CONSTRAINT microservice_unique_key_key UNIQUE (unique_key);


--
-- TOC entry 3047 (class 2606 OID 18206)
-- Name: module_page module_page_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module_page
    ADD CONSTRAINT module_page_pkey PRIMARY KEY (module_page_id);


--
-- TOC entry 2982 (class 2606 OID 17885)
-- Name: module module_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module
    ADD CONSTRAINT module_pkey PRIMARY KEY (module_id);


--
-- TOC entry 3018 (class 2606 OID 18057)
-- Name: page_detail page_detail_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page_detail
    ADD CONSTRAINT page_detail_pkey PRIMARY KEY (page_detail_id);


--
-- TOC entry 3009 (class 2606 OID 18012)
-- Name: page page_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page
    ADD CONSTRAINT page_pkey PRIMARY KEY (page_id);


--
-- TOC entry 3051 (class 2606 OID 18234)
-- Name: role_authorise role_authorise_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT role_authorise_pkey PRIMARY KEY (role_authorise_id);


--
-- TOC entry 3055 (class 2606 OID 18256)
-- Name: role_page role_page_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_page
    ADD CONSTRAINT role_page_pkey PRIMARY KEY (role_page_id);


--
-- TOC entry 3042 (class 2606 OID 18189)
-- Name: role role_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role
    ADD CONSTRAINT role_pkey PRIMARY KEY (role_id);


--
-- TOC entry 3000 (class 2606 OID 17967)
-- Name: template template_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.template
    ADD CONSTRAINT template_pkey PRIMARY KEY (template_id);


--
-- TOC entry 3058 (class 2606 OID 18279)
-- Name: user_contact user_contact_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_contact
    ADD CONSTRAINT user_contact_pkey PRIMARY KEY (user_contact_id);


--
-- TOC entry 3033 (class 2606 OID 18147)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (user_id);


--
-- TOC entry 3063 (class 2606 OID 18296)
-- Name: user_role user_role_pkey; Type: CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_role
    ADD CONSTRAINT user_role_pkey PRIMARY KEY (user_role_id);


--
-- TOC entry 2989 (class 1259 OID 17930)
-- Name: application_FK_application_application_type; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_FK_application_application_type" ON kernel.application USING btree (application_type_id);


--
-- TOC entry 3027 (class 1259 OID 18133)
-- Name: application_instance_FK_appliaciton_company; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_instance_FK_appliaciton_company" ON kernel.application_instance USING btree (company_id);


--
-- TOC entry 3028 (class 1259 OID 18135)
-- Name: application_instance_FK_application_instance_template; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_instance_FK_application_instance_template" ON kernel.application_instance USING btree (template_id);


--
-- TOC entry 3029 (class 1259 OID 18134)
-- Name: application_instance_FK_company_appliaciton_application; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_instance_FK_company_appliaciton_application" ON kernel.application_instance USING btree (application_id);


--
-- TOC entry 3010 (class 1259 OID 18045)
-- Name: application_module_FK_application_module_appliaciton; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_module_FK_application_module_appliaciton" ON kernel.application_module USING btree (application_id);


--
-- TOC entry 3011 (class 1259 OID 18047)
-- Name: application_module_FK_application_module_business_logic; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_module_FK_application_module_business_logic" ON kernel.application_module USING btree (business_logic_id);


--
-- TOC entry 3012 (class 1259 OID 18046)
-- Name: application_module_FK_application_module_module; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "application_module_FK_application_module_module" ON kernel.application_module USING btree (module_id);


--
-- TOC entry 3004 (class 1259 OID 17998)
-- Name: business_logic_FK_business_logic_business_service; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "business_logic_FK_business_logic_business_service" ON kernel.business_logic USING btree (business_service_id);


--
-- TOC entry 2994 (class 1259 OID 17957)
-- Name: command_FK_command_business_service; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "command_FK_command_business_service" ON kernel.command USING btree (business_service_id);


--
-- TOC entry 3064 (class 1259 OID 18356)
-- Name: menu_FK_menu_menu; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_menu" ON kernel.menu USING btree (parent_menu_id);


--
-- TOC entry 3065 (class 1259 OID 18357)
-- Name: menu_FK_menu_menu_icon; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_menu_icon" ON kernel.menu USING btree (menu_icon_id);


--
-- TOC entry 3066 (class 1259 OID 18355)
-- Name: menu_FK_menu_menu_type; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_menu_type" ON kernel.menu USING btree (menu_type_id);


--
-- TOC entry 3067 (class 1259 OID 18359)
-- Name: menu_FK_menu_menu_value; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_menu_value" ON kernel.menu USING btree (menu_value_id);


--
-- TOC entry 3068 (class 1259 OID 18354)
-- Name: menu_FK_menu_page; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_page" ON kernel.menu USING btree (page_id);


--
-- TOC entry 3069 (class 1259 OID 18358)
-- Name: menu_FK_menu_role; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_FK_menu_role" ON kernel.menu USING btree (role_id);


--
-- TOC entry 3001 (class 1259 OID 17983)
-- Name: menu_icon_FK_menu_icon_template; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_icon_FK_menu_icon_template" ON kernel.menu_icon USING btree (template_id);


--
-- TOC entry 3037 (class 1259 OID 18179)
-- Name: menu_type_FK_menu_type_application; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_type_FK_menu_type_application" ON kernel.menu_type USING btree (application_id);


--
-- TOC entry 3034 (class 1259 OID 18163)
-- Name: menu_value_FK_menu_value_language; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "menu_value_FK_menu_value_language" ON kernel.menu_value USING btree (language_id);


--
-- TOC entry 3023 (class 1259 OID 18102)
-- Name: microservice_module_FK_microservice_module_microservice; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "microservice_module_FK_microservice_module_microservice" ON kernel.microservice_module USING btree (microservice_id);


--
-- TOC entry 3024 (class 1259 OID 18101)
-- Name: microservice_module_FK_microservice_module_module; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "microservice_module_FK_microservice_module_module" ON kernel.microservice_module USING btree (module_id);


--
-- TOC entry 3043 (class 1259 OID 18224)
-- Name: module_page_FK_module_page_application_instance; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "module_page_FK_module_page_application_instance" ON kernel.module_page USING btree (application_instance_id);


--
-- TOC entry 3044 (class 1259 OID 18223)
-- Name: module_page_FK_module_page_application_module; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "module_page_FK_module_page_application_module" ON kernel.module_page USING btree (application_module_id);


--
-- TOC entry 3045 (class 1259 OID 18222)
-- Name: module_page_FK_module_page_page; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "module_page_FK_module_page_page" ON kernel.module_page USING btree (page_id);


--
-- TOC entry 3007 (class 1259 OID 18018)
-- Name: page_FK_page_template; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "page_FK_page_template" ON kernel.page USING btree (template_id);


--
-- TOC entry 3015 (class 1259 OID 18069)
-- Name: page_detail_FK_page_detail_language; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "page_detail_FK_page_detail_language" ON kernel.page_detail USING btree (language_id);


--
-- TOC entry 3016 (class 1259 OID 18068)
-- Name: page_detail_FK_page_detail_page; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "page_detail_FK_page_detail_page" ON kernel.page_detail USING btree (page_id);


--
-- TOC entry 3040 (class 1259 OID 18195)
-- Name: role_FK_role_appliaciton; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "role_FK_role_appliaciton" ON kernel.role USING btree (application_id);


--
-- TOC entry 3048 (class 1259 OID 18245)
-- Name: role_authorise_FK_role_authorise_role; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "role_authorise_FK_role_authorise_role" ON kernel.role_authorise USING btree (role_id);


--
-- TOC entry 3049 (class 1259 OID 18246)
-- Name: role_authorise_FK_role_authorise_route; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "role_authorise_FK_role_authorise_route" ON kernel.role_authorise USING btree (command_id);


--
-- TOC entry 3052 (class 1259 OID 18267)
-- Name: role_page_FK_role_page_module_page; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "role_page_FK_role_page_module_page" ON kernel.role_page USING btree (module_page_id);


--
-- TOC entry 3053 (class 1259 OID 18268)
-- Name: role_page_FK_role_page_role; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "role_page_FK_role_page_role" ON kernel.role_page USING btree (role_id);


--
-- TOC entry 3056 (class 1259 OID 18285)
-- Name: user_contact_FK_user_contact_user; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "user_contact_FK_user_contact_user" ON kernel.user_contact USING btree (user_id);


--
-- TOC entry 3059 (class 1259 OID 18314)
-- Name: user_role_FK_user_role_appliaciton; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "user_role_FK_user_role_appliaciton" ON kernel.user_role USING btree (application_instance_id);


--
-- TOC entry 3060 (class 1259 OID 18313)
-- Name: user_role_FK_user_role_role; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "user_role_FK_user_role_role" ON kernel.user_role USING btree (role_id);


--
-- TOC entry 3061 (class 1259 OID 18312)
-- Name: user_role_FK_user_role_user; Type: INDEX; Schema: kernel; Owner: xxx
--

CREATE INDEX "user_role_FK_user_role_user" ON kernel.user_role USING btree (user_id);


--
-- TOC entry 3072 (class 2606 OID 17925)
-- Name: application FK_application_application_type; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application
    ADD CONSTRAINT "FK_application_application_type" FOREIGN KEY (application_type_id) REFERENCES kernel.application_type(application_type_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3084 (class 2606 OID 18118)
-- Name: application_instance FK_application_instance_template; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_instance
    ADD CONSTRAINT "FK_application_instance_template" FOREIGN KEY (template_id) REFERENCES kernel.template(template_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3077 (class 2606 OID 18030)
-- Name: application_module FK_application_module_appliaciton; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT "FK_application_module_appliaciton" FOREIGN KEY (application_id) REFERENCES kernel.application(application_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3078 (class 2606 OID 18035)
-- Name: application_module FK_application_module_business_logic; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT "FK_application_module_business_logic" FOREIGN KEY (business_logic_id) REFERENCES kernel.business_logic(business_logic_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3079 (class 2606 OID 18040)
-- Name: application_module FK_application_module_module; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_module
    ADD CONSTRAINT "FK_application_module_module" FOREIGN KEY (module_id) REFERENCES kernel.module(module_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3075 (class 2606 OID 17993)
-- Name: business_logic FK_business_logic_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.business_logic
    ADD CONSTRAINT "FK_business_logic_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3073 (class 2606 OID 17952)
-- Name: command FK_command_business_service; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.command
    ADD CONSTRAINT "FK_command_business_service" FOREIGN KEY (business_service_id) REFERENCES kernel.business_service(business_service_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3085 (class 2606 OID 18123)
-- Name: application_instance FK_company_appliaciton_application; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_instance
    ADD CONSTRAINT "FK_company_appliaciton_application" FOREIGN KEY (application_id) REFERENCES kernel.application(application_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3086 (class 2606 OID 18128)
-- Name: application_instance FK_company_appliaciton_company; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.application_instance
    ADD CONSTRAINT "FK_company_appliaciton_company" FOREIGN KEY (company_id) REFERENCES kernel.company(company_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3074 (class 2606 OID 17978)
-- Name: menu_icon FK_menu_icon_template; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_icon
    ADD CONSTRAINT "FK_menu_icon_template" FOREIGN KEY (template_id) REFERENCES kernel.template(template_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3101 (class 2606 OID 18324)
-- Name: menu FK_menu_menu; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_menu" FOREIGN KEY (parent_menu_id) REFERENCES kernel.menu(menu_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3102 (class 2606 OID 18329)
-- Name: menu FK_menu_menu_icon; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_menu_icon" FOREIGN KEY (menu_icon_id) REFERENCES kernel.menu_icon(menu_icon_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3103 (class 2606 OID 18334)
-- Name: menu FK_menu_menu_type; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_menu_type" FOREIGN KEY (menu_type_id) REFERENCES kernel.menu_type(menu_type_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3104 (class 2606 OID 18339)
-- Name: menu FK_menu_menu_value; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_menu_value" FOREIGN KEY (menu_value_id) REFERENCES kernel.menu_value(menu_value_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3105 (class 2606 OID 18344)
-- Name: menu FK_menu_page; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_page" FOREIGN KEY (page_id) REFERENCES kernel.page(page_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3106 (class 2606 OID 18349)
-- Name: menu FK_menu_role; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu
    ADD CONSTRAINT "FK_menu_role" FOREIGN KEY (role_id) REFERENCES kernel.role(role_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3088 (class 2606 OID 18174)
-- Name: menu_type FK_menu_type_application; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_type
    ADD CONSTRAINT "FK_menu_type_application" FOREIGN KEY (application_id) REFERENCES kernel.application(application_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3087 (class 2606 OID 18158)
-- Name: menu_value FK_menu_value_language; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.menu_value
    ADD CONSTRAINT "FK_menu_value_language" FOREIGN KEY (language_id) REFERENCES kernel.language(language_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3082 (class 2606 OID 18091)
-- Name: microservice_module FK_microservice_module_microservice; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice_module
    ADD CONSTRAINT "FK_microservice_module_microservice" FOREIGN KEY (microservice_id) REFERENCES kernel.microservice(microservice_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3083 (class 2606 OID 18096)
-- Name: microservice_module FK_microservice_module_module; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.microservice_module
    ADD CONSTRAINT "FK_microservice_module_module" FOREIGN KEY (module_id) REFERENCES kernel.module(module_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3090 (class 2606 OID 18207)
-- Name: module_page FK_module_page_application_instance; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module_page
    ADD CONSTRAINT "FK_module_page_application_instance" FOREIGN KEY (application_instance_id) REFERENCES kernel.application_instance(application_instance_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3091 (class 2606 OID 18212)
-- Name: module_page FK_module_page_application_module; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module_page
    ADD CONSTRAINT "FK_module_page_application_module" FOREIGN KEY (application_module_id) REFERENCES kernel.application_module(application_module_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3092 (class 2606 OID 18217)
-- Name: module_page FK_module_page_page; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.module_page
    ADD CONSTRAINT "FK_module_page_page" FOREIGN KEY (page_id) REFERENCES kernel.page(page_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3080 (class 2606 OID 18058)
-- Name: page_detail FK_page_detail_language; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page_detail
    ADD CONSTRAINT "FK_page_detail_language" FOREIGN KEY (language_id) REFERENCES kernel.language(language_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3081 (class 2606 OID 18063)
-- Name: page_detail FK_page_detail_page; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page_detail
    ADD CONSTRAINT "FK_page_detail_page" FOREIGN KEY (page_id) REFERENCES kernel.page(page_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3076 (class 2606 OID 18013)
-- Name: page FK_page_template; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.page
    ADD CONSTRAINT "FK_page_template" FOREIGN KEY (template_id) REFERENCES kernel.template(template_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3089 (class 2606 OID 18190)
-- Name: role FK_role_appliaciton; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role
    ADD CONSTRAINT "FK_role_appliaciton" FOREIGN KEY (application_id) REFERENCES kernel.application(application_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3093 (class 2606 OID 18235)
-- Name: role_authorise FK_role_authorise_command; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT "FK_role_authorise_command" FOREIGN KEY (command_id) REFERENCES kernel.command(command_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3094 (class 2606 OID 18240)
-- Name: role_authorise FK_role_authorise_role; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_authorise
    ADD CONSTRAINT "FK_role_authorise_role" FOREIGN KEY (role_id) REFERENCES kernel.role(role_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3095 (class 2606 OID 18257)
-- Name: role_page FK_role_page_module_page; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_page
    ADD CONSTRAINT "FK_role_page_module_page" FOREIGN KEY (module_page_id) REFERENCES kernel.module_page(module_page_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3096 (class 2606 OID 18262)
-- Name: role_page FK_role_page_role; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.role_page
    ADD CONSTRAINT "FK_role_page_role" FOREIGN KEY (role_id) REFERENCES kernel.role(role_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3097 (class 2606 OID 18280)
-- Name: user_contact FK_user_contact_user; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_contact
    ADD CONSTRAINT "FK_user_contact_user" FOREIGN KEY (user_id) REFERENCES kernel."user"(user_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3098 (class 2606 OID 18297)
-- Name: user_role FK_user_role_application_instance; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_role
    ADD CONSTRAINT "FK_user_role_application_instance" FOREIGN KEY (application_instance_id) REFERENCES kernel.application_instance(application_instance_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3099 (class 2606 OID 18302)
-- Name: user_role FK_user_role_role; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_role
    ADD CONSTRAINT "FK_user_role_role" FOREIGN KEY (role_id) REFERENCES kernel.role(role_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 3100 (class 2606 OID 18307)
-- Name: user_role FK_user_role_user; Type: FK CONSTRAINT; Schema: kernel; Owner: xxx
--

ALTER TABLE ONLY kernel.user_role
    ADD CONSTRAINT "FK_user_role_user" FOREIGN KEY (user_id) REFERENCES kernel."user"(user_id) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2019-09-08 19:07:20

--
-- PostgreSQL database dump complete
--

