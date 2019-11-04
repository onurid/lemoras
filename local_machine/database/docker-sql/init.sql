-- --------------------------------------------------------
-- Host:                         database.xxx
-- Server version:               10.2.25-MariaDB-1:10.2.25+maria~bionic - mariadb.org binary distribution
-- Server OS:                    debian-linux-gnu
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for xxx
CREATE DATABASE IF NOT EXISTS `xxx` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `xxx`;

-- Dumping structure for table xxx.application
CREATE TABLE IF NOT EXISTS `application` (
  `application_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_type_id` int(11) NOT NULL DEFAULT 0,
  `application_name` varchar(50) NOT NULL DEFAULT '0',
  `application_js` varchar(50) NOT NULL DEFAULT '0',
  `database_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`application_id`),
  KEY `FK_application_application_type` (`application_type_id`),
  CONSTRAINT `FK_application_application_type` FOREIGN KEY (`application_type_id`) REFERENCES `application_type` (`application_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.application: ~4 rows (approximately)
/*!40000 ALTER TABLE `application` DISABLE KEYS */;
INSERT INTO `application` (`application_id`, `application_type_id`, `application_name`, `application_js`, `database_name`) VALUES
	(1, 5, 'Camel', 'camel.js', '0'),
	(2, 5, 'Sample E-Ticaret Backoffice', 'whale.js', '0'),
	(3, 6, 'Sample E-Ticaret', 'whale.js', '0'),
	(6, 7, 'System_Backoffice', 'whale.js', '0');
/*!40000 ALTER TABLE `application` ENABLE KEYS */;

-- Dumping structure for table xxx.application_instance
CREATE TABLE IF NOT EXISTS `application_instance` (
  `application_instance_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_id` int(11) NOT NULL DEFAULT 0,
  `company_id` int(11) DEFAULT 0,
  `template_id` int(11) NOT NULL DEFAULT 0,
  `application_tag_name` varchar(50) NOT NULL DEFAULT '0',
  `database_name` varchar(50) DEFAULT NULL,
  `connection_string` text DEFAULT NULL,
  PRIMARY KEY (`application_instance_id`),
  KEY `FK_appliaciton_company` (`company_id`),
  KEY `FK_company_appliaciton_application` (`application_id`),
  KEY `FK_application_instance_template` (`template_id`),
  CONSTRAINT `FK_application_instance_template` FOREIGN KEY (`template_id`) REFERENCES `template` (`template_id`),
  CONSTRAINT `FK_company_appliaciton_application` FOREIGN KEY (`application_id`) REFERENCES `application` (`application_id`),
  CONSTRAINT `FK_company_appliaciton_company` FOREIGN KEY (`company_id`) REFERENCES `company` (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.application_instance: ~3 rows (approximately)
/*!40000 ALTER TABLE `application_instance` DISABLE KEYS */;
INSERT INTO `application_instance` (`application_instance_id`, `application_id`, `company_id`, `template_id`, `application_tag_name`, `database_name`, `connection_string`) VALUES
	(5, 2, 2, 1, 'Sompo E-Commerce', 'xxx', 'server=dev.database.xxx;database=xxx;user=xxx; password=xxx; Character Set=utf8'),
	(7, 6, 6, 1, 'Tüm Sistemin Admin Uygulaması', 'xxx', 'server=dev.database.xxx;database=xxx;user=xxx; password=xxx; Character Set=utf8'),
	(8, 1, 6, 1, 'Lemoras E-Ticaret', NULL, NULL);
/*!40000 ALTER TABLE `application_instance` ENABLE KEYS */;

-- Dumping structure for table xxx.application_module
CREATE TABLE IF NOT EXISTS `application_module` (
  `application_module_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_id` int(11) NOT NULL DEFAULT 0,
  `module_id` int(11) NOT NULL DEFAULT 0,
  `business_logic_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`application_module_id`),
  KEY `FK_application_module_appliaciton` (`application_id`),
  KEY `FK_application_module_module` (`module_id`),
  KEY `FK_application_module_business_logic` (`business_logic_id`),
  CONSTRAINT `FK_application_module_appliaciton` FOREIGN KEY (`application_id`) REFERENCES `application` (`application_id`),
  CONSTRAINT `FK_application_module_business_logic` FOREIGN KEY (`business_logic_id`) REFERENCES `business_logic` (`business_logic_id`),
  CONSTRAINT `FK_application_module_module` FOREIGN KEY (`module_id`) REFERENCES `module` (`module_id`)
) ENGINE=InnoDB AUTO_INCREMENT=66 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.application_module: ~7 rows (approximately)
/*!40000 ALTER TABLE `application_module` DISABLE KEYS */;
INSERT INTO `application_module` (`application_module_id`, `application_id`, `module_id`, `business_logic_id`) VALUES
	(19, 6, 5, 4),
	(20, 6, 3, 5),
	(21, 6, 4, 7),
	(23, 6, 7, 8),
	(27, 6, 6, 8),
	(28, 6, 8, 17),
	(32, 6, 10, 8),
	(33, 6, 2, 8),
	(34, 6, 9, 8),
	(46, 2, 4, 12),
	(47, 2, 7, 13),
	(50, 2, 5, 9),
	(55, 1, 4, 12),
	(57, 6, 23, 7),
	(58, 6, 16, 8),
	(59, 6, 17, 8),
	(60, 6, 18, 15),
	(61, 6, 19, 8),
	(62, 6, 20, 8),
	(63, 6, 22, 8),
	(64, 6, 24, 8),
	(65, 6, 25, 8);
/*!40000 ALTER TABLE `application_module` ENABLE KEYS */;

-- Dumping structure for table xxx.application_type
CREATE TABLE IF NOT EXISTS `application_type` (
  `application_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_type_name` varchar(50) NOT NULL DEFAULT '0',
  `isbackoffice` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`application_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.application_type: ~7 rows (approximately)
/*!40000 ALTER TABLE `application_type` DISABLE KEYS */;
INSERT INTO `application_type` (`application_type_id`, `application_type_name`, `isbackoffice`) VALUES
	(1, 'B2B - CMS', b'1'),
	(2, 'B2C - CMS', b'0'),
	(3, 'B2B - CRM', b'1'),
	(4, 'B2C - CRM', b'0'),
	(5, 'B2B - E-Commerce', b'1'),
	(6, 'B2C - E-Commerce', b'0'),
	(7, 'System - Admin', b'1');
/*!40000 ALTER TABLE `application_type` ENABLE KEYS */;

-- Dumping structure for table xxx.business_logic
CREATE TABLE IF NOT EXISTS `business_logic` (
  `business_logic_id` int(11) NOT NULL AUTO_INCREMENT,
  `business_logic_name` varchar(50) NOT NULL DEFAULT '0',
  `business_service_id` int(11) NOT NULL,
  `unique_key` varchar(50) NOT NULL,
  PRIMARY KEY (`business_logic_id`),
  KEY `FK_business_logic_business_service` (`business_service_id`),
  CONSTRAINT `FK_business_logic_business_service` FOREIGN KEY (`business_service_id`) REFERENCES `business_service` (`business_service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.business_logic: ~12 rows (approximately)
/*!40000 ALTER TABLE `business_logic` DISABLE KEYS */;
INSERT INTO `business_logic` (`business_logic_id`, `business_logic_name`, `business_service_id`, `unique_key`) VALUES
	(4, 'Application_Default_Logic', 1, 'ApplicationService'),
	(5, 'Company_Default_Logic', 2, 'CompanyService'),
	(6, 'Config_Default_Logic', 3, 'ConfigService'),
	(7, 'User_Default_logic', 4, 'UserService'),
	(8, 'System_Default_logic', 5, 'SystemService'),
	(9, 'Application_Limited_Logic', 1, 'LimitedApplicationService'),
	(12, 'User_Limited_Logic', 4, 'LimitedUserService'),
	(13, 'System_Limited_Logic', 5, 'LimitedSystemService'),
	(15, 'Menu_Default_Logic', 6, 'MenuService'),
	(16, 'Menu_Limited_Logic', 6, 'LimitedMenuService'),
	(17, 'Page_Default_Logic', 7, 'PageService'),
	(18, 'Page_Limited_logic', 7, 'LimitedPageService');
/*!40000 ALTER TABLE `business_logic` ENABLE KEYS */;

-- Dumping structure for table xxx.business_service
CREATE TABLE IF NOT EXISTS `business_service` (
  `business_service_id` int(11) NOT NULL AUTO_INCREMENT,
  `business_service_name` varchar(50) DEFAULT '0',
  `business_service_key` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`business_service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.business_service: ~7 rows (approximately)
/*!40000 ALTER TABLE `business_service` DISABLE KEYS */;
INSERT INTO `business_service` (`business_service_id`, `business_service_name`, `business_service_key`) VALUES
	(1, 'Application Service', 'IApplicationService'),
	(2, 'Company Service', 'ICompanyService'),
	(3, 'Config Service', 'IConfigService'),
	(4, 'User Service', 'IUserService'),
	(5, 'System Service', 'ISystemService'),
	(6, 'Menu Service', 'IMenuService'),
	(7, 'Page Service', 'IPageService');
/*!40000 ALTER TABLE `business_service` ENABLE KEYS */;

-- Dumping structure for table dev_xxxmand
CREATE TABLE IF NOT EXISTS `command` (
  `command_id` int(11) NOT NULL AUTO_INCREMENT,
  `command_name` varchar(50) NOT NULL DEFAULT '0',
  `business_service_id` int(11) NOT NULL,
  PRIMARY KEY (`command_id`),
  UNIQUE KEY `command_name` (`command_name`),
  KEY `FK_command_business_service` (`business_service_id`),
  CONSTRAINT `FK_command_business_service` FOREIGN KEY (`business_service_id`) REFERENCES `business_service` (`business_service_id`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8;

-- Dumping data for table dev_xxxmand: ~72 rows (approximately)
/*!40000 ALTER TABLE `command` DISABLE KEYS */;
INSERT INTO `command` (`command_id`, `command_name`, `business_service_id`) VALUES
	(1, 'AddNewApplication', 1),
	(2, 'DeleteApplication', 1),
	(3, 'RemoveApplicationFromCompany', 1),
	(4, 'AttachToApplicationAtCompany', 1),
	(5, 'SetActiveToApplication', 1),
	(6, 'SetPassiveToApplication', 1),
	(8, 'GetApplicationsOfCompany', 1),
	(9, 'GetApplications', 1),
	(10, 'GetApplicationTypes', 1),
	(11, 'GetApplicationType', 1),
	(12, 'CreateRoleToApplication', 1),
	(13, 'RemoveRoleFromApplication', 1),
	(14, 'GetRolesOfApplication', 1),
	(15, 'GetApplicationsOfRole', 1),
	(16, 'AddNewCompany', 2),
	(17, 'DeleteCompany', 2),
	(18, 'UpdateCompany', 2),
	(19, 'SetActiveToCompany', 2),
	(20, 'SetPassiveToCompany', 2),
	(21, 'GetCompanies', 2),
	(22, 'GetCompany', 2),
	(24, 'AddNewUser', 4),
	(25, 'DeleteUser', 4),
	(26, 'RemoveUserFromApplicationAndRole', 4),
	(27, 'AttachToUserAtApplicationAndRole', 4),
	(28, 'SetActiveToUser', 4),
	(29, 'SetPassiveToUser', 4),
	(30, 'GetUsersOfCompany', 4),
	(31, 'GetUsersOfApplication', 4),
	(32, 'GetUsers', 4),
	(33, 'GetUserRole', 4),
	(34, 'GetMyProfile', 4),
	(35, 'AddNewModule', 5),
	(36, 'DeleteModule', 5),
	(37, 'AttachToPageAtModule', 5),
	(38, 'AttachToCommandAtRole', 5),
	(39, 'AttachToModuleAtMicroservice', 5),
	(40, 'AddNewPage', 5),
	(41, 'DeletePage', 5),
	(42, 'AddNewCommand', 5),
	(43, 'DeleteCommand', 5),
	(44, 'AddNewBusinessLogic', 5),
	(45, 'DeleteBusinessLogic', 5),
	(46, 'AddNewMicroservice', 5),
	(47, 'DeleteMicroservice', 5),
	(48, 'GetMicroservices', 5),
	(49, 'GetMicroserviceModules', 5),
	(50, 'GetModules', 5),
	(51, 'GetModuleRoutes', 5),
	(52, 'GetRoles', 5),
	(53, 'GetRoleAuthorises', 5),
	(54, 'GetRoutes', 5),
	(55, 'GetCommands', 5),
	(56, 'GetBusinessLogics', 5),
	(57, 'GetApplicationModules', 1),
	(58, 'UpdateProfile', 4),
	(59, 'AddNewApplicationType', 1),
	(60, 'GetApplicationsOfCompanies', 1),
	(61, 'DeleteApplicationType', 1),
	(63, 'DeleteRoleAuthorise', 5),
	(64, 'DeleteMicroserviceModule', 5),
	(65, 'DeleteApplicationModule', 1),
	(66, 'AddNewApplicationModule', 1),
	(69, 'GetBusinessServices', 5),
	(70, 'AddNewBusinessService', 5),
	(71, 'DeleteBusinessService', 5),
	(72, 'GetLanguages', 5),
	(73, 'AddLanguage', 5),
	(74, 'DeleteLanguage', 5),
	(75, 'GetTemplates', 5),
	(76, 'AddTemplate', 5),
	(77, 'DeleteTemplate', 5),
	(78, 'GetMenus', 6),
	(79, 'AddMenu', 6),
	(80, 'DeleteMenu', 6),
	(81, 'GetMenuIcons', 6),
	(82, 'AddMenuIcon', 6),
	(83, 'DeleteMenuIcon', 6),
	(84, 'GetMenuTypes', 6),
	(85, 'AddMenuType', 6),
	(86, 'DeleteMenuType', 6),
	(87, 'GetMenuValues', 6),
	(88, 'AddMenuValue', 6),
	(89, 'DeleteMenuValue', 6),
	(90, 'GetPages', 7),
	(91, 'AddPage', 7),
	(96, 'GetPageDetails', 7),
	(97, 'AddPageDetail', 7),
	(98, 'DeletePageDetail', 7),
	(99, 'GetPageProperties', 7),
	(100, 'AddPageProperty', 7),
	(101, 'DeletePageProperty', 7);
/*!40000 ALTER TABLE `command` ENABLE KEYS */;

-- Dumping structure for table dev_xxxpany
CREATE TABLE IF NOT EXISTS `company` (
  `company_id` int(11) NOT NULL AUTO_INCREMENT,
  `company_name` varchar(50) NOT NULL,
  PRIMARY KEY (`company_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- Dumping data for table dev_xxxpany: ~4 rows (approximately)
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` (`company_id`, `company_name`) VALUES
	(1, 'Umur Basım'),
	(2, 'Sompo Japan'),
	(3, 'Aksigorta'),
	(6, 'Lemoras');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;

-- Dumping structure for table xxx.language
CREATE TABLE IF NOT EXISTS `language` (
  `language_id` int(11) NOT NULL AUTO_INCREMENT,
  `language_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`language_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.language: ~0 rows (approximately)
/*!40000 ALTER TABLE `language` DISABLE KEYS */;
INSERT INTO `language` (`language_id`, `language_name`) VALUES
	(1, 'Türkçe');
/*!40000 ALTER TABLE `language` ENABLE KEYS */;

-- Dumping structure for table xxx.menu
CREATE TABLE IF NOT EXISTS `menu` (
  `menu_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` int(11) NOT NULL DEFAULT 0,
  `menu_type_id` int(11) NOT NULL,
  `parent_menu_id` int(11) DEFAULT NULL,
  `page_id` int(11) DEFAULT NULL,
  `menu_icon_id` int(11) DEFAULT NULL,
  `menu_value_id` int(11) DEFAULT NULL,
  `index` int(11) NOT NULL,
  `menu_label` varchar(50) DEFAULT NULL,
  `menu_tag` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`menu_id`),
  KEY `FK_menu_page` (`page_id`),
  KEY `FK_menu_menu_type` (`menu_type_id`),
  KEY `FK_menu_menu` (`parent_menu_id`),
  KEY `FK_menu_menu_icon` (`menu_icon_id`),
  KEY `FK_menu_role` (`role_id`),
  KEY `FK_menu_menu_value` (`menu_value_id`),
  CONSTRAINT `FK_menu_menu` FOREIGN KEY (`parent_menu_id`) REFERENCES `menu` (`menu_id`),
  CONSTRAINT `FK_menu_menu_icon` FOREIGN KEY (`menu_icon_id`) REFERENCES `menu_icon` (`menu_icon_id`),
  CONSTRAINT `FK_menu_menu_type` FOREIGN KEY (`menu_type_id`) REFERENCES `menu_type` (`menu_type_id`),
  CONSTRAINT `FK_menu_menu_value` FOREIGN KEY (`menu_value_id`) REFERENCES `menu_value` (`menu_value_id`),
  CONSTRAINT `FK_menu_page` FOREIGN KEY (`page_id`) REFERENCES `page` (`page_id`),
  CONSTRAINT `FK_menu_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.menu: ~38 rows (approximately)
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` (`menu_id`, `role_id`, `menu_type_id`, `parent_menu_id`, `page_id`, `menu_icon_id`, `menu_value_id`, `index`, `menu_label`, `menu_tag`) VALUES
	(1, 7, 1, NULL, 4, 1, 1, 0, '', 'dashboard'),
	(2, 7, 1, NULL, NULL, 2, 5, 1, NULL, 'account'),
	(3, 7, 1, 2, 5, 3, 6, 0, NULL, 'userprofile'),
	(4, 7, 1, NULL, NULL, 4, 7, 2, NULL, 'systemadmin'),
	(5, 7, 1, 4, 6, 3, 8, 0, NULL, 'user'),
	(6, 7, 1, 4, 7, 3, 9, 1, NULL, 'user'),
	(7, 7, 1, NULL, NULL, 6, 10, 3, NULL, 'systemadmin'),
	(8, 7, 1, 7, 8, 3, 11, 0, NULL, 'application'),
	(9, 7, 1, 7, 19, 3, 12, 1, NULL, 'application'),
	(10, 7, 1, 7, 9, 3, 13, 2, NULL, 'application-type'),
	(11, 7, 1, NULL, NULL, 5, 14, 4, NULL, 'systemadmin'),
	(12, 7, 1, 11, 20, 3, 15, 0, NULL, 'role'),
	(13, 7, 1, 11, 21, 3, 16, 1, NULL, 'roleauthorise'),
	(14, 7, 1, NULL, NULL, 10, 19, 5, NULL, 'systemadmin'),
	(15, 7, 1, 14, 15, 3, 20, 0, NULL, 'module'),
	(16, 7, 1, 14, 10, 3, 21, 1, NULL, 'application-module'),
	(17, 7, 1, 14, 14, 3, 22, 3, NULL, 'microservice-module'),
	(18, 7, 1, 14, 16, 3, 23, 2, NULL, 'module-page'),
	(19, 7, 1, NULL, NULL, 8, 24, 6, NULL, 'systemadmin'),
	(20, 7, 1, 19, 17, 3, 26, 0, NULL, 'page'),
	(21, 7, 1, 19, 18, 3, 25, 1, NULL, 'company'),
	(22, 7, 1, 19, 12, 3, 27, 2, NULL, 'command'),
	(23, 7, 1, 19, 11, 3, 28, 3, NULL, 'business-ogic'),
	(24, 7, 1, 19, 13, 3, 29, 4, NULL, 'microservices'),
	(25, 7, 1, NULL, NULL, 11, 30, 7, NULL, 'support'),
	(26, 7, 1, 25, 22, 3, 31, 0, NULL, 'leavemessage'),
	(27, 7, 1, 25, 23, 3, 41, 1, NULL, 'callus'),
	(28, 7, 1, NULL, NULL, 12, 32, 8, NULL, 'logout'),
	(29, 7, 2, NULL, NULL, 1, 33, 0, NULL, NULL),
	(30, 7, 2, NULL, NULL, 7, 34, 1, NULL, 'notifications'),
	(31, 7, 2, NULL, NULL, 2, 5, 2, NULL, 'useraccount'),
	(32, 7, 2, 29, 5, 3, 6, 0, NULL, 'userprofile'),
	(33, 7, 2, 29, 24, 3, 35, 1, NULL, 'settings'),
	(34, 7, 2, 29, NULL, 3, 32, 2, NULL, 'logout'),
	(35, 7, 3, NULL, 4, NULL, 37, 0, NULL, NULL),
	(36, 7, 3, NULL, 26, NULL, 38, 1, NULL, NULL),
	(37, 7, 3, NULL, 28, NULL, 39, 2, NULL, NULL),
	(38, 7, 4, NULL, NULL, NULL, 40, 0, NULL, NULL);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;

-- Dumping structure for table xxx.menu_icon
CREATE TABLE IF NOT EXISTS `menu_icon` (
  `menu_icon_id` int(11) NOT NULL AUTO_INCREMENT,
  `template_id` int(11) NOT NULL DEFAULT 0,
  `menu_icon_value` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`menu_icon_id`),
  KEY `FK_menu_icon_template` (`template_id`),
  CONSTRAINT `FK_menu_icon_template` FOREIGN KEY (`template_id`) REFERENCES `template` (`template_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.menu_icon: ~12 rows (approximately)
/*!40000 ALTER TABLE `menu_icon` DISABLE KEYS */;
INSERT INTO `menu_icon` (`menu_icon_id`, `template_id`, `menu_icon_value`) VALUES
	(1, 1, 'dashboard'),
	(2, 1, 'person'),
	(3, 1, 'dropdown-item'),
	(4, 1, 'supervisor_account'),
	(5, 1, 'list_alt'),
	(6, 1, 'android'),
	(7, 1, 'notifications'),
	(8, 1, 'notes'),
	(9, 1, 'search'),
	(10, 1, 'view_module'),
	(11, 1, 'contact_support'),
	(12, 1, 'power_settings_new');
/*!40000 ALTER TABLE `menu_icon` ENABLE KEYS */;

-- Dumping structure for table xxx.menu_type
CREATE TABLE IF NOT EXISTS `menu_type` (
  `menu_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_id` int(11) NOT NULL DEFAULT 0,
  `menu_type_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`menu_type_id`),
  KEY `FK_menu_type_application` (`application_id`),
  CONSTRAINT `FK_menu_type_application` FOREIGN KEY (`application_id`) REFERENCES `application` (`application_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.menu_type: ~4 rows (approximately)
/*!40000 ALTER TABLE `menu_type` DISABLE KEYS */;
INSERT INTO `menu_type` (`menu_type_id`, `application_id`, `menu_type_name`) VALUES
	(1, 6, 'nav list'),
	(2, 6, 'user nav list'),
	(3, 6, 'footer menu list'),
	(4, 6, 'search box');
/*!40000 ALTER TABLE `menu_type` ENABLE KEYS */;

-- Dumping structure for table xxx.menu_value
CREATE TABLE IF NOT EXISTS `menu_value` (
  `menu_value_id` int(11) NOT NULL AUTO_INCREMENT,
  `language_id` int(11) NOT NULL DEFAULT 0,
  `menu_value_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`menu_value_id`),
  KEY `FK_menu_value_language` (`language_id`),
  CONSTRAINT `FK_menu_value_language` FOREIGN KEY (`language_id`) REFERENCES `language` (`language_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.menu_value: ~35 rows (approximately)
/*!40000 ALTER TABLE `menu_value` DISABLE KEYS */;
INSERT INTO `menu_value` (`menu_value_id`, `language_id`, `menu_value_name`) VALUES
	(1, 1, 'Ön-panel'),
	(5, 1, 'Hesap'),
	(6, 1, 'Kullanıcı profili'),
	(7, 1, 'Kullanıcı yönetimi'),
	(8, 1, 'Kullanıcılar'),
	(9, 1, 'Kullanıcı rolleri'),
	(10, 1, 'Uygulama yönetimi'),
	(11, 1, 'Uygulamalar'),
	(12, 1, 'Şirket uygulamaları'),
	(13, 1, 'Uygulama türleri'),
	(14, 1, 'Rol yönetimi'),
	(15, 1, 'Roller'),
	(16, 1, 'Rol yetkileri'),
	(19, 1, 'Modül yönetimi'),
	(20, 1, 'Modüller'),
	(21, 1, 'Uygulama modülleri'),
	(22, 1, 'Microservice modülleri'),
	(23, 1, 'Uygulama modülüne Sayfa Atama'),
	(24, 1, 'Tanımlamalar'),
	(25, 1, 'Şirketler'),
	(26, 1, 'Sayfalar'),
	(27, 1, 'Komutlar'),
	(28, 1, 'İş mantıkları'),
	(29, 1, 'Microservice\'ler'),
	(30, 1, 'Destek'),
	(31, 1, 'Mesaj bırakın'),
	(32, 1, 'Çıkış'),
	(33, 1, 'stats'),
	(34, 1, 'Bildirimler'),
	(35, 1, 'Ayarlar'),
	(37, 1, 'Lemoras'),
	(38, 1, 'Hakkmızda'),
	(39, 1, 'Lisanslar'),
	(40, 1, 'ara..'),
	(41, 1, 'Bizi arayın');
/*!40000 ALTER TABLE `menu_value` ENABLE KEYS */;

-- Dumping structure for table xxx.microservice
CREATE TABLE IF NOT EXISTS `microservice` (
  `microservice_id` int(11) NOT NULL AUTO_INCREMENT,
  `unique_key` binary(36) NOT NULL,
  `microservice_name` varchar(50) NOT NULL,
  PRIMARY KEY (`microservice_id`),
  UNIQUE KEY `unique_key` (`unique_key`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.microservice: ~5 rows (approximately)
/*!40000 ALTER TABLE `microservice` DISABLE KEYS */;
INSERT INTO `microservice` (`microservice_id`, `unique_key`, `microservice_name`) VALUES
	(1, _binary 0x34303130464645342D383436312D343143322D413032322D303035423936363338433831, 'Auth_Microservice'),
	(2, _binary 0x35323045363135452D463145302D344437362D394231322D313241373942444532303330, 'Payment_Microservice'),
	(3, _binary 0x42423533303342332D334643452D344445432D393634352D413245314331364135323444, 'Order_Microservice'),
	(4, _binary 0x46324232343835352D343643462D344244362D384534302D374430343833413138333641, 'Product_Microservice'),
	(5, _binary 0x46354444344142332D393645322D344237312D414144412D423043423332383932443931, 'App_Microservice');
/*!40000 ALTER TABLE `microservice` ENABLE KEYS */;

-- Dumping structure for table xxx.microservice_module
CREATE TABLE IF NOT EXISTS `microservice_module` (
  `microservice_module_id` int(11) NOT NULL AUTO_INCREMENT,
  `microservice_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  PRIMARY KEY (`microservice_module_id`),
  KEY `FK_microservice_module_module` (`module_id`),
  KEY `FK_microservice_module_microservice` (`microservice_id`),
  CONSTRAINT `FK_microservice_module_microservice` FOREIGN KEY (`microservice_id`) REFERENCES `microservice` (`microservice_id`),
  CONSTRAINT `FK_microservice_module_module` FOREIGN KEY (`module_id`) REFERENCES `module` (`module_id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.microservice_module: ~9 rows (approximately)
/*!40000 ALTER TABLE `microservice_module` DISABLE KEYS */;
INSERT INTO `microservice_module` (`microservice_module_id`, `microservice_id`, `module_id`) VALUES
	(7, 5, 5),
	(8, 5, 6),
	(9, 5, 8),
	(10, 5, 7),
	(11, 5, 4),
	(12, 5, 10),
	(13, 5, 9),
	(14, 5, 2),
	(15, 5, 3);
/*!40000 ALTER TABLE `microservice_module` ENABLE KEYS */;

-- Dumping structure for table xxx.module
CREATE TABLE IF NOT EXISTS `module` (
  `module_id` int(11) NOT NULL AUTO_INCREMENT,
  `module_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`module_id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.module: ~18 rows (approximately)
/*!40000 ALTER TABLE `module` DISABLE KEYS */;
INSERT INTO `module` (`module_id`, `module_name`) VALUES
	(2, 'Command'),
	(3, 'Company'),
	(4, 'User'),
	(5, 'Application'),
	(6, 'Module'),
	(7, 'Role'),
	(8, 'Page'),
	(9, 'Microservice'),
	(10, 'BusinessLogic'),
	(16, 'Template'),
	(17, 'Language'),
	(18, 'Menu'),
	(19, 'Lemoras'),
	(20, 'Settings'),
	(22, 'Support'),
	(23, 'Account'),
	(24, 'Dashboard'),
	(25, 'Search');
/*!40000 ALTER TABLE `module` ENABLE KEYS */;

-- Dumping structure for table xxx.module_page
CREATE TABLE IF NOT EXISTS `module_page` (
  `module_page_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_instance_id` int(11) NOT NULL DEFAULT 0,
  `application_module_id` int(11) NOT NULL DEFAULT 0,
  `page_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`module_page_id`),
  KEY `FK_module_page_page` (`page_id`),
  KEY `FK_module_page_application_module` (`application_module_id`),
  KEY `FK_module_page_application_instance` (`application_instance_id`),
  CONSTRAINT `FK_module_page_application_instance` FOREIGN KEY (`application_instance_id`) REFERENCES `application_instance` (`application_instance_id`),
  CONSTRAINT `FK_module_page_application_module` FOREIGN KEY (`application_module_id`) REFERENCES `application_module` (`application_module_id`),
  CONSTRAINT `FK_module_page_page` FOREIGN KEY (`page_id`) REFERENCES `page` (`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.module_page: ~17 rows (approximately)
/*!40000 ALTER TABLE `module_page` DISABLE KEYS */;
INSERT INTO `module_page` (`module_page_id`, `application_instance_id`, `application_module_id`, `page_id`) VALUES
	(15, 7, 19, 8),
	(16, 7, 19, 9),
	(19, 7, 19, 10),
	(20, 7, 19, 19),
	(21, 7, 32, 11),
	(22, 7, 33, 12),
	(23, 7, 20, 18),
	(24, 7, 34, 13),
	(25, 7, 34, 14),
	(26, 7, 27, 15),
	(27, 7, 27, 16),
	(28, 7, 28, 17),
	(29, 7, 23, 20),
	(30, 7, 23, 21),
	(33, 7, 21, 5),
	(34, 7, 21, 6),
	(35, 7, 21, 7);
/*!40000 ALTER TABLE `module_page` ENABLE KEYS */;

-- Dumping structure for table xxx.page
CREATE TABLE IF NOT EXISTS `page` (
  `page_id` int(11) NOT NULL AUTO_INCREMENT,
  `template_id` int(11) NOT NULL DEFAULT 0,
  `route_name` varchar(50) NOT NULL DEFAULT '0',
  `template_url` varchar(80) NOT NULL DEFAULT '0',
  `controller_url` varchar(80) NOT NULL DEFAULT '0',
  `controller_name` varchar(50) NOT NULL DEFAULT '0',
  `controller_as_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`page_id`),
  KEY `FK_page_template` (`template_id`),
  CONSTRAINT `FK_page_template` FOREIGN KEY (`template_id`) REFERENCES `template` (`template_id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.page: ~38 rows (approximately)
/*!40000 ALTER TABLE `page` DISABLE KEYS */;
INSERT INTO `page` (`page_id`, `template_id`, `route_name`, `template_url`, `controller_url`, `controller_name`, `controller_as_name`) VALUES
	(1, 1, '/paymenthistory', 'assets/app/module/payment/peymenthistory.view.html', 'assets/app/module/payment/peymenthistory.controller.html', 'PaymentHistoryController', 'vm'),
	(2, 1, '/paymentmethod', 'assets/app/module/payment/paymentmethod.view.html', 'assets/app/module/payment/paymentmethod.controller.html', 'PaymentMethodController', 'vm'),
	(4, 1, '/', './templates/default/modules/dashboard/dashboard.view.html', './system/modules/dashboard/dashboard.controller.js', 'DashboardController', 'vm'),
	(5, 1, '/profile', './templates/default/modules/account/account.view.html', './system/modules/account/account.controller.js', 'AccountController', 'vm'),
	(6, 1, '/user', './templates/default/modules/user/user.view.html', './system/modules/user/user.controller.js', 'UserController', 'vm'),
	(7, 1, '/user-role', './templates/default/modules/user/userrole.view.html', './system/modules/user/userrole.controller.js', 'UserRoleController', 'vm'),
	(8, 1, '/application', './templates/default/modules/application/application.view.html', './system/modules/application/application.controller.js', 'ApplicationController', 'vm'),
	(9, 1, '/application-type', './templates/default/modules/application/applicationtype.view.html', './system/modules/application/applicationtype.controller.js', 'ApplicationTypeController', 'vm'),
	(10, 1, '/application_module', './templates/default/modules/application/applicationmodule.view.html', './system/modules/application/applicationmodule.controller.js', 'ApplicationModuleController', 'vm'),
	(11, 1, '/business-logic', './templates/default/modules/businesslogic/businesslogic.view.html', './system/modules/businesslogic/businesslogic.controller.js', 'BusinessLogicController', 'vm'),
	(12, 1, '/command', './templates/default/modules/command/command.view.html', './system/modules/command/command.controller.js', 'CommandController', 'vm'),
	(13, 1, '/microservice', './templates/default/modules/microservice/microservice.view.html', './system/modules/microservice/microservice.controller.js', 'MicroserviceController', 'vm'),
	(14, 1, '/microservice-module', './templates/default/modules/microservice/microservicemodule.view.html', './system/modules/microservice/microservicemodule.controller.js', 'MicroserviceModuleController', 'vm'),
	(15, 1, '/module', './templates/default/modules/module/module.view.html', './system/modules/module/module.controller.js', 'ModuleController', 'vm'),
	(16, 1, '/module-page', './templates/default/modules/module/modulepage.view.html', './system/modules/module/modulepage.controller.js', 'ModulePageController', 'vm'),
	(17, 1, '/page', './templates/default/modules/page/page.view.html', './system/modules/page/page.controller.js', 'PageController', 'vm'),
	(18, 1, '/company', './templates/default/modules/company/company.view.html', './system/modules/company/company.controller.js', 'CompanyController', 'vm'),
	(19, 1, '/company-application', './templates/default/modules/company/companyapplication.view.html', './system/modules/company/companyapplication.controller.js', 'CompanyApplicationController', 'vm'),
	(20, 1, '/role', './templates/default/modules/role/role.view.html', './system/modules/role/role.controller.js', 'RoleController', 'vm'),
	(21, 1, '/role-authorise', './templates/default/modules/role/roleauthorise.view.html', './system/modules/role/roleauthorise.controller.js', 'RoleAuthoriseController', 'vm'),
	(22, 1, '/leavemessage', './templates/default/modules/support/leavemessage.view.html', './system/modules/support/leavemessage.controller.js', 'LeaveMessageController', 'vm'),
	(23, 1, '/callus', './templates/default/modules/support/callus.view.html', './system/modules/support/callus.controller.js', 'CallUsController', 'vm'),
	(24, 1, '/settings', './templates/default/modules/settings/settings.view.html', './system/modules/settings/settings.controller.js', 'SettingsController', 'vm'),
	(25, 1, '/search', './templates/default/modules/search/search.view.html', './system/modules/search/search.controller.js', 'SearchController', 'vm'),
	(26, 1, '/aboutus', './templates/default/modules/lemoras/aboutus.view.html', './system/modules/lemoras/aboutus.controller.js', 'AboutUsController', 'vm'),
	(27, 1, '/lemoras', './templates/default/modules/lemoras/lemoras.view.html', './system/modules/lemoras/lemoras.controller.js', 'LemorasController', 'vm'),
	(28, 1, '/license', './templates/default/modules/lemoras/license.view.html', './system/modules/lemoras/license.controller.js', 'LicenseController', 'vm'),
	(29, 1, '/logout', './system/modules/logout/logout.view.html', './system/modules/logout/logout.controller.js', 'LogoutController', 'vm'),
	(33, 1, '/business-service', './templates/default/modules/businesslogic/businessservice.view.html', './system/modules/businesslogic/businessservice.controller.js', 'BusinessServiceController', 'vm'),
	(35, 1, '/page-detail', './templates/default/modules/page/pagedetail.view.html', './system/modules/page/pagedetail.controller.js', 'PageDetailController', 'vm'),
	(36, 1, '/page-property', './templates/default/modules/page/pageproperty.view.html', './system/modules/page/pageproperty.controller.js', 'PagePropertyController', 'vm'),
	(37, 1, '/menu', './templates/default/modules/menu/menu.view.html', './system/modules/menu/menu.controller.js', 'MenuController', 'vm'),
	(38, 1, '/menu-icon', './templates/default/modules/menu/menuicon.view.html', './system/modules/menu/menuicon.controller.js', 'MenuIconController', 'vm'),
	(39, 1, '/menu-type', './templates/default/modules/menu/menutype.view.html', './system/modules/menu/menutype.controller.js', 'MenuTypeController', 'vm'),
	(40, 1, '/menu-value', './templates/default/modules/menu/menuvalue.view.html', './system/modules/menu/menuvalue.controller.js', 'MenuValueController', 'vm'),
	(41, 1, '/role-page', './templates/default/modules/role/rolepage.view.html', './system/modules/role/rolepage.controller.js', 'RolePageController', 'vm'),
	(42, 1, '/template', './templates/default/modules/template/template.view.html', './system/modules/template/template.controller.js', 'TemplateController', 'vm'),
	(43, 1, '/language', './templates/default/modules/language/language.view.html', './system/modules/language/language.controller.js', 'LanguageController', 'vm');
/*!40000 ALTER TABLE `page` ENABLE KEYS */;

-- Dumping structure for table xxx.page_detail
CREATE TABLE IF NOT EXISTS `page_detail` (
  `page_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `page_id` int(11) NOT NULL DEFAULT 0,
  `language_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`page_detail_id`),
  KEY `FK_page_detail_page` (`page_id`),
  KEY `FK_page_detail_language` (`language_id`),
  CONSTRAINT `FK_page_detail_language` FOREIGN KEY (`language_id`) REFERENCES `language` (`language_id`),
  CONSTRAINT `FK_page_detail_page` FOREIGN KEY (`page_id`) REFERENCES `page` (`page_id`)
) ENGINE=InnoDB AUTO_INCREMENT=95 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.page_detail: ~37 rows (approximately)
/*!40000 ALTER TABLE `page_detail` DISABLE KEYS */;
INSERT INTO `page_detail` (`page_detail_id`, `page_id`, `language_id`) VALUES
	(53, 5, 1),
	(55, 8, 1),
	(56, 9, 1),
	(57, 10, 1),
	(58, 11, 1),
	(59, 33, 1),
	(60, 23, 1),
	(61, 12, 1),
	(62, 18, 1),
	(63, 19, 1),
	(64, 43, 1),
	(65, 26, 1),
	(66, 22, 1),
	(67, 27, 1),
	(68, 28, 1),
	(69, 29, 1),
	(70, 37, 1),
	(71, 38, 1),
	(72, 39, 1),
	(75, 40, 1),
	(76, 13, 1),
	(77, 14, 1),
	(78, 15, 1),
	(79, 16, 1),
	(80, 17, 1),
	(81, 35, 1),
	(82, 36, 1),
	(83, 1, 1),
	(84, 2, 1),
	(85, 20, 1),
	(86, 21, 1),
	(87, 41, 1),
	(88, 25, 1),
	(89, 24, 1),
	(92, 42, 1),
	(93, 6, 1),
	(94, 7, 1);
/*!40000 ALTER TABLE `page_detail` ENABLE KEYS */;

-- Dumping structure for table xxx.role
CREATE TABLE IF NOT EXISTS `role` (
  `role_id` int(11) NOT NULL AUTO_INCREMENT,
  `application_id` int(11) NOT NULL DEFAULT 0,
  `role_name` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`role_id`),
  KEY `FK_role_appliaciton` (`application_id`),
  CONSTRAINT `FK_role_appliaciton` FOREIGN KEY (`application_id`) REFERENCES `application` (`application_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.role: ~0 rows (approximately)
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` (`role_id`, `application_id`, `role_name`) VALUES
	(5, 2, 'Agency'),
	(6, 2, 'Admin'),
	(7, 6, 'System_Admin'),
	(11, 1, 'admin-lemoras');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

-- Dumping structure for table xxx.role_authorise
CREATE TABLE IF NOT EXISTS `role_authorise` (
  `role_authorise_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` int(11) NOT NULL DEFAULT 0,
  `command_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`role_authorise_id`),
  KEY `FK_role_authorise_role` (`role_id`),
  KEY `FK_role_authorise_route` (`command_id`),
  CONSTRAINT `FK_role_authorise_command` FOREIGN KEY (`command_id`) REFERENCES `command` (`command_id`),
  CONSTRAINT `FK_role_authorise_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.role_authorise: ~80 rows (approximately)
/*!40000 ALTER TABLE `role_authorise` DISABLE KEYS */;
INSERT INTO `role_authorise` (`role_authorise_id`, `role_id`, `command_id`) VALUES
	(4, 7, 1),
	(5, 7, 2),
	(6, 7, 3),
	(7, 7, 4),
	(8, 7, 5),
	(9, 7, 6),
	(10, 7, 16),
	(11, 7, 24),
	(12, 7, 27),
	(14, 7, 12),
	(16, 7, 17),
	(17, 7, 25),
	(18, 7, 9),
	(19, 7, 8),
	(22, 7, 15),
	(23, 7, 11),
	(24, 7, 10),
	(26, 7, 21),
	(27, 7, 22),
	(29, 7, 14),
	(30, 7, 33),
	(31, 7, 32),
	(32, 7, 31),
	(33, 7, 30),
	(34, 7, 13),
	(35, 7, 26),
	(36, 7, 19),
	(37, 7, 28),
	(39, 7, 20),
	(41, 7, 29),
	(43, 7, 18),
	(44, 7, 34),
	(45, 7, 35),
	(46, 7, 36),
	(47, 7, 37),
	(48, 7, 38),
	(49, 7, 39),
	(50, 7, 40),
	(51, 7, 41),
	(54, 7, 42),
	(55, 7, 43),
	(56, 7, 44),
	(57, 7, 45),
	(58, 7, 46),
	(59, 7, 47),
	(60, 7, 48),
	(61, 7, 49),
	(62, 7, 50),
	(63, 7, 51),
	(64, 7, 52),
	(65, 7, 53),
	(66, 7, 54),
	(67, 7, 55),
	(68, 7, 56),
	(69, 7, 57),
	(70, 7, 58),
	(71, 7, 59),
	(74, 7, 60),
	(75, 7, 61),
	(78, 7, 63),
	(80, 7, 64),
	(81, 7, 65),
	(82, 7, 66),
	(89, 5, 34),
	(91, 6, 34),
	(92, 6, 32),
	(94, 6, 14),
	(95, 6, 60),
	(96, 6, 33),
	(97, 11, 34),
	(98, 6, 24),
	(99, 7, 70),
	(100, 7, 69),
	(101, 7, 71),
	(102, 7, 72),
	(103, 7, 73),
	(104, 7, 74),
	(105, 7, 75),
	(106, 7, 76),
	(107, 7, 77),
	(108, 7, 78),
	(109, 7, 79),
	(110, 7, 80),
	(111, 7, 81),
	(112, 7, 82),
	(113, 7, 83),
	(114, 7, 84),
	(115, 7, 85),
	(116, 7, 86),
	(117, 7, 87),
	(118, 7, 88),
	(119, 7, 89),
	(120, 7, 90),
	(121, 7, 91),
	(124, 7, 96),
	(125, 7, 97),
	(126, 7, 98),
	(127, 7, 99),
	(128, 7, 100),
	(129, 7, 101);
/*!40000 ALTER TABLE `role_authorise` ENABLE KEYS */;

-- Dumping structure for table xxx.role_page
CREATE TABLE IF NOT EXISTS `role_page` (
  `role_page_id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` int(11) NOT NULL DEFAULT 0,
  `module_page_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`role_page_id`),
  KEY `FK_role_page_module_page` (`module_page_id`),
  KEY `FK_role_page_role` (`role_id`),
  CONSTRAINT `FK_role_page_module_page` FOREIGN KEY (`module_page_id`) REFERENCES `module_page` (`module_page_id`),
  CONSTRAINT `FK_role_page_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

-- Dumping data for table xxx.role_page: ~0 rows (approximately)
/*!40000 ALTER TABLE `role_page` DISABLE KEYS */;
INSERT INTO `role_page` (`role_page_id`, `role_id`, `module_page_id`) VALUES
	(1, 7, 15),
	(2, 7, 16),
	(3, 7, 19),
	(4, 7, 20),
	(5, 7, 21),
	(6, 7, 22),
	(7, 7, 23),
	(8, 7, 24),
	(9, 7, 25),
	(10, 7, 26),
	(11, 7, 27),
	(12, 7, 28),
	(13, 7, 29),
	(14, 7, 30),
	(15, 7, 33),
	(16, 7, 34),
	(17, 7, 35);
/*!40000 ALTER TABLE `role_page` ENABLE KEYS */;

-- Dumping structure for table xxx.template
CREATE TABLE IF NOT EXISTS `template` (
  `template_id` int(11) NOT NULL AUTO_INCREMENT,
  `template_name` varchar(50) NOT NULL DEFAULT '0',
  `template_url` varchar(50) NOT NULL DEFAULT '0',
  PRIMARY KEY (`template_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.template: ~0 rows (approximately)
/*!40000 ALTER TABLE `template` DISABLE KEYS */;
INSERT INTO `template` (`template_id`, `template_name`, `template_url`) VALUES
	(1, 'Varsayılan', 'default');
/*!40000 ALTER TABLE `template` ENABLE KEYS */;

-- Dumping structure for table xxx.user
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL DEFAULT '0',
  `password` varchar(50) NOT NULL DEFAULT '0',
  `email` varchar(50) NOT NULL DEFAULT '0',
  `first_name` varchar(50) DEFAULT NULL,
  `last_name` varchar(50) DEFAULT NULL,
  `active` bit(1) DEFAULT b'0',
  `last_login_date` datetime DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.user: ~0 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`user_id`, `username`, `password`, `email`, `first_name`, `last_name`, `active`, `last_login_date`) VALUES
	(1, 'admin', 'admin', 'onur.yasar@tatilsepeti.com', 'onur', 'yaşar', b'1', '2019-08-08 10:42:24'),
	(2, 'omerdelikaya', '123456', 'omder.delikaya@sompojapan.com.tr', 'Ömer', 'Delikaya', b'1', '2019-03-08 09:33:10'),
	(17, 'sabri', '123', 'sabri@umur.com.tr', 'Sabri Asil', 'Eyüp', b'1', '2019-07-16 17:27:34'),
	(18, 'dila', 'dila', 'dila.coskun@umur.com.tr', 'dila', 'coşkun', b'1', '2019-04-05 06:37:38'),
	(19, 'hasan', 'hasan', 'hasan@gmail.com', 'hasan', 'yaşar', b'1', '2019-06-30 12:12:41'),
	(21, 'omer', '123', 'omer@xxx', 'Hasan Ömer', 'Yaşar', b'1', '2019-06-30 13:30:39');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- Dumping structure for table xxx.user_contact
CREATE TABLE IF NOT EXISTS `user_contact` (
  `user_contact_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL DEFAULT 0,
  `phone` varchar(13) NOT NULL DEFAULT '0',
  `fax` varchar(13) NOT NULL DEFAULT '0',
  PRIMARY KEY (`user_contact_id`),
  KEY `FK_user_contact_user` (`user_id`),
  CONSTRAINT `FK_user_contact_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.user_contact: ~0 rows (approximately)
/*!40000 ALTER TABLE `user_contact` DISABLE KEYS */;
INSERT INTO `user_contact` (`user_contact_id`, `user_id`, `phone`, `fax`) VALUES
	(1, 1, '0', '0');
/*!40000 ALTER TABLE `user_contact` ENABLE KEYS */;

-- Dumping structure for table xxx.user_role
CREATE TABLE IF NOT EXISTS `user_role` (
  `user_role_id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL DEFAULT 0,
  `application_instance_id` int(11) NOT NULL DEFAULT 0,
  `role_id` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`user_role_id`),
  KEY `FK_user_role_user` (`user_id`),
  KEY `FK_user_role_role` (`role_id`),
  KEY `FK_user_role_appliaciton` (`application_instance_id`),
  CONSTRAINT `FK_user_role_application_instance` FOREIGN KEY (`application_instance_id`) REFERENCES `application_instance` (`application_instance_id`),
  CONSTRAINT `FK_user_role_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`),
  CONSTRAINT `FK_user_role_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8;

-- Dumping data for table xxx.user_role: ~0 rows (approximately)
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
INSERT INTO `user_role` (`user_role_id`, `user_id`, `application_instance_id`, `role_id`) VALUES
	(12, 2, 5, 5),
	(16, 17, 5, 5),
	(17, 18, 5, 5),
	(18, 1, 7, 7),
	(22, 1, 5, 6),
	(29, 19, 5, 6),
	(30, 21, 8, 11),
	(31, 1, 8, 11);
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
