insert into Module([Name], RequiredLogin, IsActive, CreationTime, IsDeleted) values('RoutesModule', 0, 1, getdate(), 0)
insert into Module([Name], RequiredLogin, IsActive, CreationTime, IsDeleted) values('LoginModule', 0, 1, getdate(), 0)
insert into Module([Name], RequiredLogin, IsActive, CreationTime, IsDeleted) values('RegisterModule', 0, 1, getdate(), 0)
insert into Module([Name], RequiredLogin, IsActive, CreationTime, IsDeleted) values('HomeModule', 1, 1, getdate(), 0)
go

insert into ModuleRelationship(ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(1, 2, 1, getdate(), 0)
insert into ModuleRelationship(ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(1, 3, 1, getdate(), 0)
insert into ModuleRelationship(ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(1, 4, 1, getdate(), 0)
go

insert into Component([Name], IsActive, CreationTime, IsDeleted) values('LoginComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('RegisterComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('HomeComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('DashboardComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('ProfileComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('UserComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('LogComponent', 1, getdate(), 0)
insert into Component([Name], IsActive, CreationTime, IsDeleted) values('AboutComponent', 1, getdate(), 0)
go

insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(2, 1, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(3, 2, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 3, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 4, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 5, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 6, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 7, 1, getdate(), 0)
insert into ModuleComponent(ModuleId, ComponentId, IsActive, CreationTime, IsDeleted) values(4, 8, 1, getdate(), 0)
go

insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('login', 1, null, null, './login/login.module#LoginModule', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('register', 1, null, null, './register/register.module#RegisterModule', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('app', 1, null, null, './home/home.module#HomeModule', 1, getdate(), 0)
go

insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('', null, 1, null, '{"pageClass": "page-login", "title": "Login - Sign in"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('', null, 2, null, '{"pageClass": "page-register", "title": "Login - Sign up"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('', null, 3, null, '{"toAuth": true}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('dashboard', null, 4, null, '{"pageClass": "page-home-dashboard", "title": "Admin Dashboard Template"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('profile', null, 5, null, '{"pageClass": "page-home-profile", "title": "Profile"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('user', null, 6, null, '{"pageClass": "page-home-user", "title": "Users"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('log', null, 7, null, '{"pageClass": "page-home-log", "title": "Logs"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('about', null, 8, null, '{"pageClass": "page-home-about", "title": "About"}', 1, getdate(), 0)
go

insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('**', null, null, 1, '{"redirectTo": "login", "patchMath": "full"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('', null, null, 1, '{"redirectTo": "login", "patchMath": "full"}', 1, getdate(), 0)
insert into [Route]([Path], ModuleRelationshipId, ModuleComponentId, ModuleId, Config, IsActive, CreationTime, IsDeleted) values('', null, null, 4, '{"redirectTo": "dashboard", "patchMath": "full"}', 1, getdate(), 0)
go

insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 7, 1, getdate(), 0)
insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 8, 1, getdate(), 0)
insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 9, 1, getdate(), 0)
insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 10, 1, getdate(), 0)
insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 11, 1, getdate(), 0)
insert into [RouteRelationship](ParentId, ChildId, IsActive, CreationTime, IsDeleted) values(6, 14, 1, getdate(), 0)
go
