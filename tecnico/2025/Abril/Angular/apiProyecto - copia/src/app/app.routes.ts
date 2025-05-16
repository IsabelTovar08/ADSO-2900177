import { Routes } from '@angular/router';
import { ListaPersonasComponent } from './Components/Person/lista-personas/lista-personas.component';
import { DashboardComponent } from './pages/dashboard/dashboard/dashboard.component';
import { ListaRolesComponent } from './Components/Rol/lista-roles/lista-roles.component';
import { ListFormComponent } from './Components/Form/list-form/list-form.component';
import { ListModuleComponent } from './Components/Module/list-module/list-module.component';
import { ListPermissionComponent } from './Components/Permission/list-permission/list-permission.component';
import { ListUserRolComponent } from './Components/UserRol/list-user-rol/list-user-rol.component';
import { ListUserComponent } from './Components/User/list-user/list-user.component';
import { ListModuleFOrmComponent } from './Components/ModuleForm/list-module-form/list-module-form.component';
import { ListRolFormPermissionComponent } from './Components/RolFormPermission/list-rol-form-permission/list-rol-form-permission.component';
import { StartedComponent } from './pages/started/started/started.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
    {path : '', component: StartedComponent},
    {path : 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] ,
        children: [
            {path : 'person', component: ListaPersonasComponent},
            {path : 'rol', component: ListaRolesComponent},
            {path : 'form', component: ListFormComponent},
            {path : 'module', component: ListModuleComponent},
            {path : 'permission', component: ListPermissionComponent},
            {path : 'userRol', component: ListUserRolComponent},
            {path : 'user', component: ListUserComponent},
            {path : 'rolFormPermission', component: ListRolFormPermissionComponent},

            {path : 'moduleForm', component: ListModuleFOrmComponent},

            { path: '', redirectTo: 'person', pathMatch: 'full' }

        ]
    },
    { path: '**', redirectTo: '' }
    


];
