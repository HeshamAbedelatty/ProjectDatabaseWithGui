/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     5/27/2022 3:05:00 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Admin') and o.name = 'FK_ADMIN_INHERITAN_EMPOLYEE')
alter table Admin
   drop constraint FK_ADMIN_INHERITAN_EMPOLYEE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Category') and o.name = 'FK_CATEGORY_HAS A_DEPARTME')
alter table Category
   drop constraint "FK_CATEGORY_HAS A_DEPARTME"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Customer') and o.name = 'FK_CUSTOMER_DEAL WITH_EMPOLYEE')
alter table Customer
   drop constraint "FK_CUSTOMER_DEAL WITH_EMPOLYEE"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Empolyee') and o.name = 'FK_EMPOLYEE_IS MANAGE_EMPOLYEE')
alter table Empolyee
   drop constraint "FK_EMPOLYEE_IS MANAGE_EMPOLYEE"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Empolyee') and o.name = 'FK_EMPOLYEE_WORK IN_BRANCHE')
alter table Empolyee
   drop constraint "FK_EMPOLYEE_WORK IN_BRANCHE"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('"Order"') and o.name = 'FK_ORDER_NEED TO M_CUSTOMER')
alter table "Order"
   drop constraint "FK_ORDER_NEED TO M_CUSTOMER"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderDetails') and o.name = 'FK_ORDERDET_RELATIONS_PRODUCT')
alter table OrderDetails
   drop constraint FK_ORDERDET_RELATIONS_PRODUCT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderDetails') and o.name = 'FK_ORDERDET_RELATIONS_ORDER')
alter table OrderDetails
   drop constraint FK_ORDERDET_RELATIONS_ORDER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Phone') and o.name = 'FK_PHONE_OWN_CUSTOMER')
alter table Phone
   drop constraint FK_PHONE_OWN_CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Product') and o.name = 'FK_PRODUCT_CONSIST O_CATEGORY')
alter table Product
   drop constraint "FK_PRODUCT_CONSIST O_CATEGORY"
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Product') and o.name = 'FK_PRODUCT_SUPPLIY_SUPPLIER')
alter table Product
   drop constraint FK_PRODUCT_SUPPLIY_SUPPLIER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Admin')
            and   type = 'U')
   drop table Admin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Branche')
            and   type = 'U')
   drop table Branche
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Category')
            and   name  = 'HAS_A_FK'
            and   indid > 0
            and   indid < 255)
   drop index Category.HAS_A_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Category')
            and   type = 'U')
   drop table Category
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Customer')
            and   name  = 'DEAL_WITH_FK'
            and   indid > 0
            and   indid < 255)
   drop index Customer.DEAL_WITH_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Customer')
            and   type = 'U')
   drop table Customer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Department')
            and   type = 'U')
   drop table Department
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Empolyee')
            and   name  = 'IS_MANAGED_BY_FK'
            and   indid > 0
            and   indid < 255)
   drop index Empolyee.IS_MANAGED_BY_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Empolyee')
            and   name  = 'WORK_IN_FK'
            and   indid > 0
            and   indid < 255)
   drop index Empolyee.WORK_IN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Empolyee')
            and   type = 'U')
   drop table Empolyee
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"Order"')
            and   name  = 'NEED_TO_MAKE_FK'
            and   indid > 0
            and   indid < 255)
   drop index "Order".NEED_TO_MAKE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Order"')
            and   type = 'U')
   drop table "Order"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('OrderDetails')
            and   name  = 'RELATIONSHIP_11_FK'
            and   indid > 0
            and   indid < 255)
   drop index OrderDetails.RELATIONSHIP_11_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderDetails')
            and   type = 'U')
   drop table OrderDetails
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Phone')
            and   name  = 'OWN_FK'
            and   indid > 0
            and   indid < 255)
   drop index Phone.OWN_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Phone')
            and   type = 'U')
   drop table Phone
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Product')
            and   name  = 'CONSIST_OF_FK'
            and   indid > 0
            and   indid < 255)
   drop index Product.CONSIST_OF_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Product')
            and   name  = 'SUPPLIY_FK'
            and   indid > 0
            and   indid < 255)
   drop index Product.SUPPLIY_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Product')
            and   type = 'U')
   drop table Product
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Supplier')
            and   type = 'U')
   drop table Supplier
go

/*==============================================================*/
/* Table: Admin                                                 */
/*==============================================================*/
create table Admin (
   E_ID                 int                  not null,
   BB_ID                int                  null,
   Emp_E_ID             int                  null,
   F_name               varchar(50)          not null,
   L_name               varchar(50)          not null,
   e_mail               varchar(20)          null,
   job_title            varchar(50)          not null,
   hierd_date           datetime             not null,
   phone_emp            varchar(15)          not null,
   city                 varchar(50)          not null,
   state                varchar(50)          not null,
   street               varchar(50)          not null,
   gender               varchar(50)          not null,
   userName             varchar(50)          not null,
   password             varchar(50)          not null,
   constraint PK_ADMIN primary key (E_ID)
)
go

/*==============================================================*/
/* Table: Branche                                               */
/*==============================================================*/
create table Branche (
   BB_ID                int                  not null,
   BB_city              varchar(50)          not null,
   BB_state             varchar(50)          not null,
   BB_street            varchar(50)          not null,
   BB_country           varchar(50)          not null,
   BB_phone             varchar(15)          not null,
   constraint PK_BRANCHE primary key nonclustered (BB_ID)
)
go

/*==============================================================*/
/* Table: Category                                              */
/*==============================================================*/
create table Category (
   C_ID                 int                  not null,
   D_ID                 int                  not null,
   C_name               varchar(50)          not null,
   constraint PK_CATEGORY primary key nonclustered (C_ID)
)
go

/*==============================================================*/
/* Index: HAS_A_FK                                              */
/*==============================================================*/
create index HAS_A_FK on Category (
D_ID ASC
)
go

/*==============================================================*/
/* Table: Customer                                              */
/*==============================================================*/
create table Customer (
   Cust_ID              int                  not null,
   E_ID                 int                  null,
   Cust_fname           varchar(50)          not null,
   Cust_lname           varchar(50)          not null,
   cust_city            varchar(50)          not null,
   cust_street          varchar(50)          not null,
   cust_state           varchar(50)          not null,
   cust_gender          varchar(50)          not null,
   cust_userName        varchar(50)          not null,
   cust_pasword         varchar(52)          not null,
   constraint PK_CUSTOMER primary key nonclustered (Cust_ID)
)
go

/*==============================================================*/
/* Index: DEAL_WITH_FK                                          */
/*==============================================================*/
create index DEAL_WITH_FK on Customer (
E_ID ASC
)
go

/*==============================================================*/
/* Table: Department                                            */
/*==============================================================*/
create table Department (
   D_ID                 int                  not null,
   D_name               varchar(50)          not null,
   D_location           varchar(50)          not null,
   constraint PK_DEPARTMENT primary key nonclustered (D_ID)
)
go

/*==============================================================*/
/* Table: Empolyee                                              */
/*==============================================================*/
create table Empolyee (
   E_ID                 int                  not null,
   BB_ID                int                  not null,
   Emp_E_ID             int                  null,
   F_name               varchar(50)          not null,
   L_name               varchar(50)          not null,
   e_mail               varchar(20)          null,
   job_title            varchar(50)          not null,
   hierd_date           datetime             not null,
   phone_emp            varchar(15)          not null,
   city                 varchar(50)          not null,
   state                varchar(50)          not null,
   street               varchar(50)          not null,
   gender               varchar(50)          not null,
   constraint PK_EMPOLYEE primary key nonclustered (E_ID)
)
go

/*==============================================================*/
/* Index: WORK_IN_FK                                            */
/*==============================================================*/
create index WORK_IN_FK on Empolyee (
BB_ID ASC
)
go

/*==============================================================*/
/* Index: IS_MANAGED_BY_FK                                      */
/*==============================================================*/
create index IS_MANAGED_BY_FK on Empolyee (
Emp_E_ID ASC
)
go

/*==============================================================*/
/* Table: "Order"                                               */
/*==============================================================*/
create table "Order" (
   O_id                 int                  not null,
   Cust_ID              int                  not null,
   O_date               varchar(50)          not null,
   O_type               varchar(50)          not null,
   constraint PK_ORDER primary key nonclustered (O_id)
)
go

/*==============================================================*/
/* Index: NEED_TO_MAKE_FK                                       */
/*==============================================================*/
create index NEED_TO_MAKE_FK on "Order" (
Cust_ID ASC
)
go

/*==============================================================*/
/* Table: OrderDetails                                          */
/*==============================================================*/
create table OrderDetails (
   P_ID                 int                  not null,
   O_id                 int                  not null,
   price                float(10)            not null,
   quantity             int                  null,
   constraint PK_ORDERDETAILS primary key (P_ID, O_id)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_11_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_11_FK on OrderDetails (
O_id ASC
)
go

/*==============================================================*/
/* Table: Phone                                                 */
/*==============================================================*/
create table Phone (
   phone                varchar(15)          not null,
   Cust_ID              int                  not null,
   constraint PK_PHONE primary key nonclustered (phone, Cust_ID)
)
go

/*==============================================================*/
/* Index: OWN_FK                                                */
/*==============================================================*/
create index OWN_FK on Phone (
Cust_ID ASC
)
go

/*==============================================================*/
/* Table: Product                                               */
/*==============================================================*/
create table Product (
   P_ID                 int                  not null,
   C_ID                 int                  not null,
   S_ID                 int                  not null,
   P_name               varchar(50)          not null,
   P_scale              varchar(50)          not null,
   quantity_in_store    int                  null,
   buy_price            float(10)            not null,
   constraint PK_PRODUCT primary key nonclustered (P_ID)
)
go

/*==============================================================*/
/* Index: SUPPLIY_FK                                            */
/*==============================================================*/
create index SUPPLIY_FK on Product (
S_ID ASC
)
go

/*==============================================================*/
/* Index: CONSIST_OF_FK                                         */
/*==============================================================*/
create index CONSIST_OF_FK on Product (
C_ID ASC
)
go

/*==============================================================*/
/* Table: Supplier                                              */
/*==============================================================*/
create table Supplier (
   S_ID                 int                  not null,
   S_Name               varchar(60)          not null,
   S_Street             varchar(50)          not null,
   S_State              varchar(50)          not null,
   S_City               varchar(50)          not null,
   S_Email              varchar(50)          null,
   constraint PK_SUPPLIER primary key nonclustered (S_ID)
)
go

alter table Admin
   add constraint FK_ADMIN_INHERITAN_EMPOLYEE foreign key (E_ID)
      references Empolyee (E_ID)
go

alter table Category
   add constraint "FK_CATEGORY_HAS A_DEPARTME" foreign key (D_ID)
      references Department (D_ID)
go

alter table Customer
   add constraint "FK_CUSTOMER_DEAL WITH_EMPOLYEE" foreign key (E_ID)
      references Empolyee (E_ID)
go

alter table Empolyee
   add constraint "FK_EMPOLYEE_IS MANAGE_EMPOLYEE" foreign key (Emp_E_ID)
      references Empolyee (E_ID)
go

alter table Empolyee
   add constraint "FK_EMPOLYEE_WORK IN_BRANCHE" foreign key (BB_ID)
      references Branche (BB_ID)
go

alter table "Order"
   add constraint "FK_ORDER_NEED TO M_CUSTOMER" foreign key (Cust_ID)
      references Customer (Cust_ID)
go

alter table OrderDetails
   add constraint FK_ORDERDET_RELATIONS_PRODUCT foreign key (P_ID)
      references Product (P_ID)
go

alter table OrderDetails
   add constraint FK_ORDERDET_RELATIONS_ORDER foreign key (O_id)
      references "Order" (O_id)
go

alter table Phone
   add constraint FK_PHONE_OWN_CUSTOMER foreign key (Cust_ID)
      references Customer (Cust_ID)
go

alter table Product
   add constraint "FK_PRODUCT_CONSIST O_CATEGORY" foreign key (C_ID)
      references Category (C_ID)
go

alter table Product
   add constraint FK_PRODUCT_SUPPLIY_SUPPLIER foreign key (S_ID)
      references Supplier (S_ID)
go

