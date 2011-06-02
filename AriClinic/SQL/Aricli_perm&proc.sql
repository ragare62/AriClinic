

LOCK TABLES `permission` WRITE;

insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,32,45,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,33,46,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,34,47,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,35,48,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,36,49,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,37,50,'\0','\0','\0');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,38,51,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,39,52,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,40,53,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,41,54,'','','');
insert  into `permission`(`view`,`user_group_id`,`process_id`,`permission_id`,`modify`,`execute`,`create`) values ('',14,42,55,'','','');

UNLOCK TABLES;


LOCK TABLES `process` WRITE;

insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (32,'Interna','Contiene los mecanismos de creación de permisos',2,'admint');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (33,'Nomenclator','Contiene el nombre y servicio de todos los procedimientos ofertados',22,'rnomenclator');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (34,'Informe de profesionales','Muestra los profesionales y sus servicios realizados',37,'rprofessionalsrv');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (35,'Informe de categorías de servicio','Lista las categorías con sus servicios asociados.',37,'rcategorysrv');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (36,'comparativa de precios','Muestra la comparativa de precios de servicio de todas las compañías aseguradoras que lo ofertan.',37,'rsrvcomparer');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (37,'Informes de servicios','Cantiene informes con información relevante de los servicios',22,'rservices');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (38,'Facturas emitidas','Muestra las facturas emitidas en un periodo de tiempo determinado.',39,'rinvoicesPeriod');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (39,'Informes de facturas','Recoge todos los informes que muestran detalles de la facturación.',22,'infoFacturas');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (40,'Deudas del paciente','Muestra por cada paciente los tickets impagados',41,'rpatientdebt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (41,'Informe de impagos','Contendrá otros informes aportando datos sobre los tickets impagados.',22,'debt');
insert  into `process`(`process_id`,`name`,`description`,`parent_process_id`,`code`) values (42,'Informe de deudas por aserguradora','Muestra los tickets impagados por cada aseguradora.',41,'rinsurancedebt');

UNLOCK TABLES;


