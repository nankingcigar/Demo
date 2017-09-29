drop table RoleRoute
drop table UserRoute
drop table RouteRelationship
drop table [Route]
drop table ModuleComponent
drop table Component
drop table ModuleRelationship
drop table Module
go


create table Module
(
	Id bigint identity(1,1) constraint PK_Module_Id primary key,
	[Name] nvarchar(50) not null,
	RequiredLogin bit not null
)
go

create table ModuleRelationship
(
	Id bigint identity(1,1) constraint PK_ModuleRelationship_Id primary key,
	ParentId bigint constraint FK_ModuleRelationship_ParentId foreign key references Module(Id) not null,
	ChildId bigint constraint FK_ModuleRelationship_ChildId foreign key references Module(Id) not null
)
go

create table Component
(
	Id bigint identity(1,1) constraint PK_Component_Id primary key,
	[Name] nvarchar(50) not null
)
go

create table ModuleComponent
(
	Id bigint identity(1,1) constraint PK_ModuleComponent_Id primary key,
	ModuleId bigint constraint FK_ModuleComponent_ModuleId foreign key references Module(Id) not null,
	ComponentId bigint constraint FK_ModuleComponent_ComponentId foreign key references Component(Id) not null
)
go

create table [Route]
(
	Id bigint identity(1,1) constraint PK_Route_Id primary key,
	[Path] nvarchar(50) not null,
	ModuleRelationshipId bigint constraint FK_Route_ModuleRelationshipId foreign key references ModuleRelationship(Id),
	ModuleComponentId bigint constraint FK_Route_ModuleComponentId foreign key references ModuleComponent(Id),
	ModuleId bigint constraint FK_Route_ModuleId foreign key references ModuleComponent(Id),
	Config nvarchar(200)
)
go

create table [RouteRelationship]
(
	Id bigint identity(1,1) constraint PK_RouteRelationship_Id primary key,
	ParentId bigint constraint FK_RouteRelationship_ParentId foreign key references [Route](Id) not null,
	ChildId bigint constraint FK_RouteRelationship_ChildId foreign key references [Route](Id) not null
)
go

create table [RoleRoute]
(
	Id bigint identity(1,1) constraint PK_RoleRoute_Id primary key,
	RoleId bigint constraint FK_RoleRoute_RoleId foreign key references [Role](Id),
	RouteId bigint constraint FK_RoleRoute_UserId foreign key references [Route](Id),
	HasPermission bit not null
)
go

create table [UserRoute]
(
	Id bigint identity(1,1) constraint PK_UserRoute_Id primary key,
	UserId bigint constraint FK_UserRoute_UserId foreign key references [User](Id),
	RouteId bigint constraint FK_UserRoute_RouteId foreign key references [Route](Id),
	HasPermission bit not null
)
go


insert into Module values('RoutesModule',0)
insert into Module values('LoginModule',0)
insert into Module values('RegisterModule',0)
insert into Module values('HomeModule',1)
go

insert into ModuleRelationship values(1,2)
insert into ModuleRelationship values(1,3)
insert into ModuleRelationship values(1,4)
go

insert into Component values('LoginComponent')
insert into Component values('RegisterComponent')
insert into Component values('HomeComponent')
insert into Component values('DashboardComponent')
insert into Component values('ProfileComponent')
insert into Component values('UserComponent')
insert into Component values('LogComponent')
insert into Component values('AboutComponent')
go

insert into ModuleComponent values(2,1)
insert into ModuleComponent values(3,2)
insert into ModuleComponent values(4,3)
insert into ModuleComponent values(4,4)
insert into ModuleComponent values(4,5)
insert into ModuleComponent values(4,6)
insert into ModuleComponent values(4,7)
insert into ModuleComponent values(4,8)
go

insert into [Route] values('login', 1, null,null, './login/login.module#LoginModule')
insert into [Route] values('register', 1, null,null, './register/register.module#RegisterModule')
insert into [Route] values('app', 1, null,null, './home/home.module#HomeModule')
go

insert into [Route] values('', null, 1,null,'{"pageClass": "page-login", "title": "Login - Sign in"}')
insert into [Route] values('', null, 2,null,'{"pageClass": "page-register", "title": "Login - Sign up"}')
insert into [Route] values('', null, 3,null,'{"toAuth": true}')
insert into [Route] values('dashboard', null, 4,null,'{"pageClass": "page-home-dashboard", "title": "Admin Dashboard Template"}')
insert into [Route] values('profile', null, 5,null,'{"pageClass": "page-home-profile", "title": "Profile"}')
insert into [Route] values('user', null, 6,null,'{"pageClass": "page-home-user", "title": "Users"}')
insert into [Route] values('log', null, 7,null,'{"pageClass": "page-home-log", "title": "Logs"}')
insert into [Route] values('about', null, 8,null,'{"pageClass": "page-home-about", "title": "About"}')
go

insert into [Route] values('**', null, null,1,'{"redirectTo": "login", "patchMath": "full"}')
insert into [Route] values('', null, null,1,'{"redirectTo": "login", "patchMath": "full"}')
insert into [Route] values('', null, null,4,'{"redirectTo": "dashboard", "patchMath": "full"}')
go

insert into [RouteRelationship] values(6,7)
insert into [RouteRelationship] values(6,8)
insert into [RouteRelationship] values(6,9)
insert into [RouteRelationship] values(6,10)
insert into [RouteRelationship] values(6,11)
insert into [RouteRelationship] values(6,14)
go

select * from [Role]
select * from [User]
select * from [Route]

insert into [RoleRoute] values(2, 6, 1)
insert into [RoleRoute] values(2, 7, 1)
insert into [RoleRoute] values(2, 8, 1)
insert into [RoleRoute] values(2, 9, 1)
insert into [RoleRoute] values(2, 10, 1)
insert into [RoleRoute] values(2, 11, 1)
insert into [RoleRoute] values(2, 12, 1)
go

